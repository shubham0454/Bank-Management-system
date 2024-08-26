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
    public partial class LDDashBoard : Form
    {

       


        public LDDashBoard()
        {
            InitializeComponent();
        }
        public void LoadUserData(string userId)
        {
            string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(cs))
            {
                string query = "SELECT full_name, email_id FROM UserAccounts WHERE user_id = @UserId";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@UserId", userId);

                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string fullName = reader["full_name"].ToString();
                            string emailId = reader["email_id"].ToString();
                            ShowNameLabel.Text = fullName;
                            ShowEmailLabel.Text = emailId;
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

        private void label6_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            HomeLoan form9 = new HomeLoan();
            form9.Show();
            this.Close();
        }

        private void label11_Click(object sender, EventArgs e)
        {
            HomeLoan form9 = new HomeLoan();
            form9.Show();
            this.Close();
        }

  

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            PersonalLoan form10 = new PersonalLoan();
            form10.Show();
            this.Close();
        }

        private void label12_Click(object sender, EventArgs e)
        {
            PersonalLoan form10 = new PersonalLoan();
            form10.Show();
            this.Close();
        }

     

        private void pictureBox11_Click(object sender, EventArgs e)
        {
            CarLoan form11 = new CarLoan();
            form11.Show();
            this.Close();
        }

        private void label13_Click(object sender, EventArgs e)
        {
            CarLoan form11 = new CarLoan();
            form11.Show();
            this.Close();
        }

    

        private void pictureBox12_Click(object sender, EventArgs e)
        {
            EducationLoan form12 = new EducationLoan();
            form12.Show();
            this.Close();
        }

        private void label14_Click(object sender, EventArgs e)
        {
            EducationLoan form12 = new EducationLoan();
            form12.Show();
            this.Close();

        }

        private void LDDashBoard_Load(object sender, EventArgs e)
        {
            string userId = BMS_DashBoard.userId;
            LoadUserData(userId);
        }
    }
}
