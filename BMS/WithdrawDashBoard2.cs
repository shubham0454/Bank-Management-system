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
    public partial class WithdrawDashBoard2 : Form
    {
        public WithdrawDashBoard2()
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
                            NameAtextBox.Text = fullName;
                            ShowNametextBox.Text = fullName;
                            ShowEmailLabel.Text = emailId;
                            ACNo_textbox.Text = accountno;
                            ACNo_textbox2.Text = accountno;

                        }
                    }
                    connection.Close();
                }
            }
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

        private void label4_Click(object sender, EventArgs e)
        {
            MoneyTransferDashBoard form6 = new MoneyTransferDashBoard();
            form6.Show();
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

 

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void W_dateTimePicker_ValueChanged(object sender, EventArgs e)
        {
          
        }

        private void WithdrawDashBoard2_Load(object sender, EventArgs e)
        {
            W_dateTimePicker.Format = DateTimePickerFormat.Custom;
            W_dateTimePicker.CustomFormat = "dd/MM/yyyy";
            string userId = BMS_DashBoard.userId;
            LoadUserData(userId);
        }

        private void WA_textBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (char.IsDigit(ch))
            {
                e.Handled = true;
            }
            else
            {
                e.Handled = true;
            }
        }

    
    }
}
