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

namespace BMS
{
    public partial class BMS_DashBoard : Form
    {
        public static string userId;
        string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;
        public BMS_DashBoard()
        {
            InitializeComponent();
        }
      



        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Registration form1 = new Registration();
            form1.Show();
            this.Hide();

        }

        private void BMS_DashBoard_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

           userId = IDtextBox.Text;
            if (IDtextBox.Text != "Enter User ID")
            {
                
                if(Passtextbox.Text != "Enter Password")
                {
                    MainDashBoard form = new MainDashBoard();
                    form.Show();
                    this.Hide();

                }
                else
                {
                    errorProvider1.SetError(this.Passtextbox, "Please Enter Password");
                }

            }
            else
            {

                errorProvider1.SetError(this.IDtextBox, "Please Enter user ID");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ForgetPassword form2 = new ForgetPassword();
            form2.Show();
            this.Hide();
        }

        private void IDtextBox_Enter(object sender, EventArgs e)
        {
            if (IDtextBox.Text == "Enter User ID")
            {
                IDtextBox.Text = "";
                IDtextBox.ForeColor = Color.Black;
            }
        }

        private void IDtextBox_Leave(object sender, EventArgs e)
        {
            if (IDtextBox.Text == "")
            {
                IDtextBox.Text = "Enter User ID";
                IDtextBox.ForeColor = Color.Gray;
            }
            else
            {
            if(IDtextBox.Text == "Enter User ID")
            {
                errorProvider1.SetError(this.IDtextBox, "Please Enter user ID");
           
            }
            else
            {
                using (SqlConnection con = new SqlConnection(cs))
                {
                    string query = "SELECT * FROM UserAccounts WHERE user_id=@UserId ";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@UserId", IDtextBox.Text);

                        SqlDataAdapter sda = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        sda.Fill(dt);

                        if (dt.Rows.Count > 0)
                        {
                            errorProvider1.Clear();
                        }
                        else
                        {
                            errorProvider1.SetError(this.IDtextBox, "User ID Not Found");

                        }
                    }

                }
          
            }
            }



        }

        private void Passtextbox_Leave(object sender, EventArgs e)
        {
            if (Passtextbox.Text == "")
            {
                Passtextbox.Text = "Enter Password";
                Passtextbox.ForeColor = Color.Gray;
            }
            else
            {
                if (Passtextbox.Text == "Enter Password")
                {
                    errorProvider1.SetError(this.Passtextbox, "Please Enter Password");
                }
                else
                {
                    using (SqlConnection con = new SqlConnection(cs))
                    {
                        string query1 = "SELECT * FROM UserAccounts WHERE password=@Password";
                        using (SqlCommand cmd = new SqlCommand(query1, con))
                        {
                            cmd.Parameters.AddWithValue("@password", Passtextbox.Text);

                            SqlDataAdapter sda = new SqlDataAdapter(cmd);
                            DataTable dt = new DataTable();
                            sda.Fill(dt);

                            if (dt.Rows.Count > 0)
                            {
                                errorProvider2.Clear();
                            }
                            else
                            {
                                errorProvider2.SetError(this.Passtextbox, "Password Incorrect.....");
                            }
                        }

                    }
                }
            }
           

           

           

        }

        private void Passtextbox_Enter(object sender, EventArgs e)
        {

            if (Passtextbox.Text == "Enter Password")
            {
                Passtextbox.Text = "";
                Passtextbox.ForeColor = Color.Black;
            }


        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

            if(Passtextbox.Text == "Enter Password")
            {

            }
            else
            {
                bool check = checkBox1.Checked;
                switch (check)
                {
                    case true:
                        Passtextbox.UseSystemPasswordChar = false;
                        break;

                    default:
                        Passtextbox.UseSystemPasswordChar = true;
                        break;
                }
            }
 

        }

        private void Passtextbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            Passtextbox.UseSystemPasswordChar = true;
        }
    }
}
