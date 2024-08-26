using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Configuration;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace BMS
{
    public partial class ForgetPassword : Form
    {
        string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;
        string reg = @"^(?=.*[a-z]).{8,15}$";

        public static string NPassword;
        public ForgetPassword()
        {
            InitializeComponent();
        }

        private void ForgetPassword_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Registration form1 = new Registration();
            form1.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            BMS_DashBoard form3 = new BMS_DashBoard();
            form3.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (NPasstextbox.Text == CPasstextBox.Text)
            {
                string query = "UPDATE UserAccounts SET password=@Password WHERE  user_id=@UserId and mobile_no=@MobileNo";
                SqlConnection con = new SqlConnection(cs);
                SqlCommand cmd = new SqlCommand( query, con);

                cmd.Parameters.AddWithValue("@Password", NPasstextbox.Text);
                cmd.Parameters.AddWithValue("@UserId", UIDtextBox.Text);
                cmd.Parameters.AddWithValue("@MobileNo", MtextBox.Text);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("reset successfully");
            }
            else
            {
                MessageBox.Show("check All Details and fill Correct information");

            }



        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (NPasstextbox.Text == "Enter N Password")
            {

            }
            else
            {
                bool check = checkBox1.Checked;
                switch (check)
                {
                    case true:
                        NPasstextbox.UseSystemPasswordChar = false;
                        break;

                    default:
                        NPasstextbox.UseSystemPasswordChar = true;
                        break;
                }
            }
        }

        private void UIDtextBox_Leave(object sender, EventArgs e)
        {
            if (UIDtextBox.Text == "")
            {
                UIDtextBox.Text = "Enter User ID";
                UIDtextBox.ForeColor = Color.Gray;
                UIDtextBox.Focus();
             
            }
            else
            {
                if (UIDtextBox.Text == "Enter User ID")
                {
                    errorProvider1.SetError(this.UIDtextBox, "Please Enter User ID");

                }
                else
                {
                    using (SqlConnection con = new SqlConnection(cs))
                    {
                        string query = "SELECT * FROM UserAccounts WHERE user_id=@UserId ";
                        using (SqlCommand cmd = new SqlCommand(query, con))
                        {
                            cmd.Parameters.AddWithValue("@UserId", UIDtextBox.Text);

                            SqlDataAdapter sda = new SqlDataAdapter(cmd);
                            DataTable dt = new DataTable();
                            sda.Fill(dt);

                            if (dt.Rows.Count > 0)
                            {
                                errorProvider1.Clear();
                            }
                            else
                            {
                                errorProvider1.SetError(this.UIDtextBox, "User ID Not Found");

                            }
                        }

                    }

                }

            }
           

        }

        private void UIDtextBox_Enter(object sender, EventArgs e)
        {
            if (UIDtextBox.Text == "Enter User ID")
            {
                UIDtextBox.Text = "";
                UIDtextBox.ForeColor = Color.Black;
            }
        }

        private void MtextBox_Leave(object sender, EventArgs e)
        {
            if (MtextBox.Text == "")
            {
                MtextBox.Text = "Enter Mobile No";
                MtextBox.ForeColor = Color.Gray;
                MtextBox.Focus();
             
            }
            else
            {
                if (MtextBox.Text == "Enter User ID")
                {
                    errorProvider2.SetError(this.MtextBox, "Please Enter User ID");

                }
                else
                {
                    using (SqlConnection con = new SqlConnection(cs))
                    {
                        string query = "SELECT * FROM UserAccounts WHERE user_id=@UserId and mobile_no=@MobileNo";
                        using (SqlCommand cmd = new SqlCommand(query, con))
                        {
                            cmd.Parameters.AddWithValue("@UserId", UIDtextBox.Text);
                            cmd.Parameters.AddWithValue("@MobileNo", MtextBox.Text);

                            SqlDataAdapter sda = new SqlDataAdapter(cmd);
                            DataTable dt = new DataTable();
                            sda.Fill(dt);

                            if (dt.Rows.Count > 0)
                            {
                                errorProvider2.Clear();
                            }
                            else
                            {
                                errorProvider2.SetError(this.MtextBox, "Please Enter correct Mobile No");

                            }
                        }

                    }

                }
            }
          
        }

        private void MtextBox_Enter(object sender, EventArgs e)
        {
            if (MtextBox.Text == "Enter Mobile No")
            {
                MtextBox.Text = "";
                MtextBox.ForeColor = Color.Black;
            }
        }

        private void NPasstextbox_Leave(object sender, EventArgs e)
        {
            if (NPasstextbox.Text == "")
            {
                NPasstextbox.Text = "Enter N Password";
                NPasstextbox.ForeColor = Color.Gray;
            }
            else
            {
                if (string.IsNullOrEmpty(NPasstextbox.Text) == true)
                {
                    NPasstextbox.Focus();
                    errorProvider3.SetError(this.NPasstextbox, "please enter Password");
                }
                else
                {
                    errorProvider3.Clear();
                }
                if (Regex.IsMatch(NPasstextbox.Text, reg) == false)
                {
                    NPasstextbox.Focus();
                    errorProvider3.SetError(this.NPasstextbox, "Enter Strong password");
                }
                else
                {
                    string LoginPassword = NPasstextbox.Text;
                    errorProvider3.Clear();
                }
            }

          


        }

        private void NPasstextbox_Enter(object sender, EventArgs e)
        {
            if (NPasstextbox.Text == "Enter N Password")
            {
                NPasstextbox.Text = "";
                NPasstextbox.ForeColor = Color.Black;
            }
         
        }

        private void CPasstextBox_Leave(object sender, EventArgs e)
        {
            if (CPasstextBox.Text == "")
            {
                CPasstextBox.Text = "Enter C Password";
                CPasstextBox.ForeColor = Color.Gray;
            }
            else
            {
                if (CPasstextBox.Text != NPasstextbox.Text)
                {
                    CPasstextBox.Focus();
                    errorProvider4.SetError(this.CPasstextBox, "please Enter Same Password");
                }
                else
                {
                    errorProvider4.Clear();
                }

            }
       

        }

        private void CPasstextBox_Enter(object sender, EventArgs e)
        {
            if (CPasstextBox.Text == "Enter C Password")
            {
                CPasstextBox.Text = "";
                CPasstextBox.ForeColor = Color.Black;
            }
           

        }

        private void NPasstextbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            NPasstextbox.UseSystemPasswordChar = true;
        }

        private void MtextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                // If the key pressed is not a control key or a digit, handle the event to cancel it
                e.Handled = true;
            }
        }
    }
}
