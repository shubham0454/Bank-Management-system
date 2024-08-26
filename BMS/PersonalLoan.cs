using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BMS
{
    public partial class PersonalLoan : Form
    {
        public PersonalLoan()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            LDDashBoard form8 = new LDDashBoard();
            form8.Show();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.unionbankofindia.co.in/applynow/lead/index?lead_source=Corporate%20Website&lead_sub_source=");
        }
    }
}
