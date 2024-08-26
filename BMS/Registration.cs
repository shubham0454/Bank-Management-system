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
using System.Text.RegularExpressions;

namespace BMS
{
    public partial class Registration : Form
    {
        string reg = @"^(?=.*[a-z]).{8,15}$";
        string reg1 = @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$";

        string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;
        public Registration()
        {
            InitializeComponent();
        }

        private void InsertUserAccount(
            string fullName, string userId, string password, string accountType,
            string emailId, long mobileNo, DateTime dateOfBirth, string address)
        {
            using (SqlConnection connection = new SqlConnection(cs))
            {
                string query = "INSERT INTO UserAccounts (full_name, user_id, password, account_type, email_id, mobile_no, date_of_birth, address) " +
                               "VALUES (@FullName, @UserId, @Password, @AccountType, @EmailId, @MobileNo, @DateOfBirth, @Address)";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@FullName", fullName);
                    command.Parameters.AddWithValue("@UserId", userId);
                    command.Parameters.AddWithValue("@Password", password);
                    command.Parameters.AddWithValue("@AccountType", accountType);
                    command.Parameters.AddWithValue("@EmailId", emailId);
                    command.Parameters.AddWithValue("@MobileNo", mobileNo);
                    command.Parameters.AddWithValue("@DateOfBirth", dateOfBirth);
                    command.Parameters.AddWithValue("@Address", address);

                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                }
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                // Validate and convert input data
                string fullName = RUNametextBox.Text;
                string userId = R_UIDtextBox.Text;
                string password = R_PasstextBox.Text;
                string accountType = R_ATcomboBox.Text;
                string emailId = R_EIDtextBox.Text;
                long mobileNo = Convert.ToInt32(R_MNtextBox.Text);


                DateTime dateOfBirth = R_dateTimePicker.Value;
                string address = R_AddresstextBox.Text;

                // Insert the user account into the database
                InsertUserAccount(fullName, userId, password, accountType, emailId, mobileNo, dateOfBirth, address);

                // Show the main dashboard and hide the registration form
                if (fullName.Length != 0 || userId.Length != 0 || password.Length != 0 || emailId.Length != 0 || R_MNtextBox.Text.Length != 0 || address.Length != 0  )
                {

                    BMS_DashBoard form3 = new BMS_DashBoard();
                    form3.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Please fill All Details....");
                }
          
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }



        }

        private void button2_Click(object sender, EventArgs e)
        {
            BMS_DashBoard form3 = new BMS_DashBoard();
            form3.Show();
            this.Hide();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            ForgetPassword form2 = new ForgetPassword();
            form2.Show();
            this.Hide();
        }

        private void RUNametextBox_Leave(object sender, EventArgs e)
        {
            if (RUNametextBox.Text == "")
            {
                RUNametextBox.Text = "Enter Full Name";
                RUNametextBox.ForeColor = Color.Gray;
                RUNametextBox.Focus();
                errorProvider1.SetError(this.RUNametextBox, "Please Enter Name");

            }
      
                if (RUNametextBox.Text.Contains(" "))
                {
                    errorProvider1.Clear();
                }
                else
                {
                    errorProvider1.SetError(this.RUNametextBox, "Please Enter Full Name");
                }

            
    
        }

        private void RUNametextBox_Enter(object sender, EventArgs e)
        {
            if (RUNametextBox.Text == "Enter Full Name")
            {
                RUNametextBox.Text = "";
                RUNametextBox.ForeColor = Color.Black;
            }
        }

        private void R_UIDtextBox_Leave(object sender, EventArgs e)
        {
            if (R_UIDtextBox.Text == "")
            {
                R_UIDtextBox.Text = "Enter User ID";
                R_UIDtextBox.ForeColor = Color.Gray;
            }
          
                if (Regex.IsMatch(R_UIDtextBox.Text, reg) == false)
                {
                    R_UIDtextBox.Focus();
                    errorProvider2.SetError(this.R_UIDtextBox, "Please Enter Unique User ID...");
                }
                else { 
         
                    errorProvider2.Clear();
                }
            

        }

        private void R_UIDtextBox_Enter(object sender, EventArgs e)
        {
            if (R_UIDtextBox.Text == "Enter User ID")
            {
                R_UIDtextBox.Text = "";
                R_UIDtextBox.ForeColor = Color.Black;
            }


        }

        private void R_PasstextBox_Leave(object sender, EventArgs e)
        {
            if (R_PasstextBox.Text == "")
            {
                R_PasstextBox.Text = "Enter Password";
                R_PasstextBox.ForeColor = Color.Gray;
            }
        

            if (Regex.IsMatch(R_PasstextBox.Text, reg) == false)
                {
                    R_PasstextBox.Focus();
                    errorProvider3.SetError(this.R_PasstextBox, "Please Enter Strong password");
                }
                else
                {

                    errorProvider3.Clear();
                }
            

        }

        private void R_PasstextBox_Enter(object sender, EventArgs e)
        {
            if (R_PasstextBox.Text == "Enter Password")
            {
                R_PasstextBox.Text = "";
                R_PasstextBox.ForeColor = Color.Black;
            }

        }

        private void R_ATcomboBox_Enter(object sender, EventArgs e)
        {
            if (R_ATcomboBox.Text == "   Select Account Type")
            {
                R_ATcomboBox.Text = "";
                R_ATcomboBox.ForeColor = Color.Black;
            }

        }

        private void R_ATcomboBox_Leave(object sender, EventArgs e)
        {
            if (R_ATcomboBox.Text == "")
            {
                R_ATcomboBox.Text = "   Select Account Type";
                R_ATcomboBox.ForeColor = Color.Gray;
            }
           
                if (R_ATcomboBox.Text == "   Select Account Type")
                {
                    R_ATcomboBox.Focus();
                    errorProvider4.SetError(this.R_ATcomboBox, "Please select Account Type....");
                }
                else
                {

                    errorProvider4.Clear();
                }

            
        }

        private void R_ANtextBox_Leave(object sender, EventArgs e)
        {
            if (R_ANtextBox.Text == "")
            {
                R_ANtextBox.Text = "Enter Account No";
                R_ANtextBox.ForeColor = Color.Gray;
            }
 
        }

        private void R_ANtextBox_Enter(object sender, EventArgs e)
        {
            if (R_ANtextBox.Text == "Enter Account No")
            {
                R_ANtextBox.Text = "";
                R_ANtextBox.ForeColor = Color.Black;
            }
        }

        private void R_EIDtextBox_Leave(object sender, EventArgs e)
        {
            if (R_EIDtextBox.Text == "")
            {
                R_EIDtextBox.Text = "Enter Email ID";
                R_EIDtextBox.ForeColor = Color.Gray;
                errorProvider6.SetError(this.R_EIDtextBox, "Please Enter Email Id");
            }
       
                if (Regex.IsMatch(R_EIDtextBox.Text, reg1) == false)
                {
                    R_EIDtextBox.Focus();
                    errorProvider6.SetError(this.R_EIDtextBox, "Please Enter valid Email Id");
                }
                else
                {
                    errorProvider6.Clear();
                }
            
        }

        private void R_EIDtextBox_Enter(object sender, EventArgs e)
        {
            if (R_EIDtextBox.Text == "Enter Email ID")
            {
                R_EIDtextBox.Text = "";
                R_EIDtextBox.ForeColor = Color.Black;
            } 
        }

        private void R_MNtextBox_Leave(object sender, EventArgs e)
        {
            if (R_MNtextBox.Text == "")
            {
                R_MNtextBox.Text = "Enter Mobile No";
                R_MNtextBox.ForeColor = Color.Gray;
                errorProvider7.SetError(this.R_MNtextBox, "Please Enter Mobile No");
            }
            else
            {

                if (R_MNtextBox.Text.Length != 10)
                {
                    R_MNtextBox.Focus();
                    errorProvider7.SetError(this.R_MNtextBox, "Please Enter 10 digit Mobile No only");
                }
                else
                {
                    errorProvider7.Clear();
                }

            }
        }

        private void R_MNtextBox_Enter(object sender, EventArgs e)
        {
            if (R_MNtextBox.Text == "Enter Mobile No")
            {
                R_MNtextBox.Text = "";
                R_MNtextBox.ForeColor = Color.Black;
            }

        }

        private void R_AddresstextBox_Leave(object sender, EventArgs e)
        {
            if (R_AddresstextBox.Text == "")
            {
                R_AddresstextBox.Text = "Enter Address";
                R_AddresstextBox.ForeColor = Color.Gray;
                errorProvider8.SetError(this.R_AddresstextBox, "Please Enter Address...");
            }
            else
            {
                errorProvider8.Clear();
            }
  


        }

        private void R_AddresstextBox_Enter(object sender, EventArgs e)
        {
            if (R_AddresstextBox.Text == "Enter Address")
            {
                R_AddresstextBox.Text = "";
                R_AddresstextBox.ForeColor = Color.Black;
            }
       
        }

        private void R_dateTimePicker_ValueChanged(object sender, EventArgs e)
        {
 
        }

        private void Registration_Load(object sender, EventArgs e)
        {
            R_dateTimePicker.Format = DateTimePickerFormat.Custom;
            R_dateTimePicker.CustomFormat = "dd/MM/yyyy";
        }

        private void RUNametextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void R_ANtextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            /*          char ch = e.KeyChar;
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

        private void R_MNtextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            /*            char ch = e.KeyChar;
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

        private void R_MNtextBox_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
