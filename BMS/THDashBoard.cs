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
    public partial class THDashBoard : Form
    {
        public THDashBoard()
        {
            InitializeComponent();
          
        }
        public void DataShow()
        {
            string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;
            SqlConnection conn = new SqlConnection(cs);
            conn.Open();
            string myquery = "select * from BankInfo ";
            SqlDataAdapter dataAdapter = new SqlDataAdapter(myquery, conn);
            SqlCommandBuilder cmdBuilder = new SqlCommandBuilder(dataAdapter);
            var ds = new DataSet();
            dataAdapter.Fill(ds);
            dataGridView1.ReadOnly = true;
            dataGridView1.DataSource = ds.Tables[0];
            conn.Close();
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

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
    
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
          
        }

        private void THDashBoard_Load(object sender, EventArgs e)
        {
            dateTimePicker2.Format = DateTimePickerFormat.Custom;
            dateTimePicker2.CustomFormat = "dd/MM/yyyy";
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "dd/MM/yyyy";
            string userId = BMS_DashBoard.userId;
            LoadUserData(userId);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataShow();
        }
    }
}
