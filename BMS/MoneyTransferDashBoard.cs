using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;

namespace BMS
{
    public partial class MoneyTransferDashBoard : Form
    {
        public MoneyTransferDashBoard()
        {
            InitializeComponent();
        }
        public void LoadUserData(string userId)
        {
            string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(cs))
            {
                string query = "SELECT * FROM UserAccounts WHERE user_id = @UserId";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@UserId", userId);

                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string fullName = reader["full_name"].ToString();
                            string accountno = reader["account_no"].ToString();
                            string emailId = reader["email_id"].ToString();
                            ShowNameLabel.Text = fullName;
                            ShowNametextBox.Text = fullName;
                            ShowEmailLabel.Text = emailId;
                            ACNo_textbox.Text = accountno;

                        }
                    }
                    connection.Close();
                }
            }
        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {
            MainDashBoard form = new MainDashBoard();
            form.Show();
            this.Close();
        }

        private void label7_Click(object sender, EventArgs e)
        {
            DepositDashBoard form4 = new DepositDashBoard();
            form4.Show();
            this.Close();
        }

        private void label8_Click(object sender, EventArgs e)
        {
            WithdrawDashBoard2 form5 = new WithdrawDashBoard2();
            form5.Show();
            this.Close();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            THDashBoard form7 = new THDashBoard();
            form7.Show();
            this.Close();
        }

        private void label9_Click(object sender, EventArgs e)
        {
            LDDashBoard form8 = new LDDashBoard();
            form8.Show();
            this.Close();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void TMA_textBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            /*           char ch = e.KeyChar;
                       if (char.IsDigit(ch))
                       {
                           e.Handled = true;
                       }
                       else
                       {
                           e.Handled = true;
                       }*/
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                // If the key pressed is not a control key or a digit, handle the event to cancel it
                e.Handled = true;
            }
        }

        private void MoneyTransferDashBoard_Load(object sender, EventArgs e)
        {
            string userId = BMS_DashBoard.userId;
            LoadUserData(userId);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Money Transfer Successfully");
        }

        private void TMA_textBox_KeyDown(object sender, KeyEventArgs e)
        {

        }
    }
}
