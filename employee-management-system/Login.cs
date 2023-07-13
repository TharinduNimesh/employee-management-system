using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using Guna.UI2.WinForms;
using MySql.Data.MySqlClient;

namespace employee_management_system
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
            Mysql.connect();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            Register register = new Register();
            register.Show();
            this.Hide();
        }

        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {
            // get user inputs
            String username = tbUsername.Text;
            String password = tbPassword.Text;

            // validate user inputs
            if (username.Trim().Equals("") || password.Trim().Equals(""))
            {
                new Message().set("Please Fill All TextFields", "WARNING", Message.warning);
            }
            else
            {
                // attempt to login
                String query = "SELECT * FROM users WHERE username = ? AND password = ?";
                String[] values = new string[] { username, password };
                MySqlDataReader reader = Mysql.search(query, values);
                if(reader.Read())
                {
                    // navigate to dashboard
                    Dashboard dashboard = new Dashboard();
                    dashboard.Show();
                    this.Hide();
                } 
                else
                {
                    new Message().set("Invalid Login Credentials", "ERROR", Message.error);
                }
                reader.Close();
            }
        }
    }
}
