using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Windows.Forms;
using Stationery.View;

namespace Stationery
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
            txt_password.UseSystemPasswordChar = true;
        }

        private void btn_login_Click(object sender, EventArgs e)
        {
            if (txt_username.Text == "" || txt_password.Text == "" ) 
                
            {
                MessageBox.Show("Mising Data!!!");
            }
            else if (txt_username.Text == "Admin" && txt_password.Text == "Admin" )
            {
                Dashboard Obj = new Dashboard();
                Obj.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Wrong Username Or Password");
            }
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
