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
    public partial class MainDashBoard : Form
    {

        public static int accountBalance;
        public MainDashBoard()
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
                            string userid = reader["user_id"].ToString();
                            string accountno = reader["account_no"].ToString();
                            string mobileno = reader["mobile_no"].ToString();
                            string dateofbirth = reader["date_of_birth"].ToString();
                            string address = reader["address"].ToString();
                            string emailId = reader["email_id"].ToString();
                            ShowNameLabel.Text = fullName;
                            ShowNameLabeltextbox.Text = fullName;
                            ShowNameLabel2.Text = "Detail of  " + fullName;
                            ShowEmailLabel.Text = emailId;
                            ACNo_textbox.Text = accountno;
                            UserIDtextBox.Text = userid;
                            ADM_textBox.Text = mobileno;
                            AddresstextBox.Text = address;
                            AD_dateTimePicker1.Text = dateofbirth;
                        }
                    }
                    connection.Close();
                }
            }
        }

        private void MainDashBoard_Load(object sender, EventArgs e)
        {
            AD_dateTimePicker2.Format = DateTimePickerFormat.Custom;
            AD_dateTimePicker2.CustomFormat = "dd/MM/yyyy";
            AD_dateTimePicker1.Format = DateTimePickerFormat.Custom;
            AD_dateTimePicker1.CustomFormat = "dd/MM/yyyy";
            string userId = BMS_DashBoard.userId;
            LoadUserData(userId);

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

        private void AD_dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
           
        }

        private void AD_dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
        
            if (UNbutton.Visible == false) {
                UNbutton.Visible = true;
                UIDbutton.Visible = true;
                MNobutton.Visible = true;
                Addressbutton.Visible = true;
                DOBbutton.Visible = true;



            }
            else
            {
                UNbutton.Visible = false;
                UIDbutton.Visible = false;
                MNobutton.Visible = false;
                Addressbutton.Visible = false;
                DOBbutton.Visible = false;
            }



        }

        private void ADM_textBox_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                // If the key pressed is not a control key or a digit, handle the event to cancel it
                e.Handled = true;
            }
        }
    }
}
