using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace employee_management_system
{
    public partial class Register : Form
    {
        public Register()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            // navigate to login
            Login login = new Login();
            login.Show();
            this.Hide();
        }

        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {
            // get user inputs
            String name = tbFullName.Text;
            String username = tbUsername.Text;
            String email = tbEmail.Text;
            String password = tbPassword.Text;
            String key = tbKey.Text;

            // put user inputs to an array
            String[] values = new string[] { name, username, email, password };

            // validate all textfields
            bool isValid = true;
            foreach (var value in values)
            {
                if(value.Trim().Equals(""))
                {
                    isValid = false;
                }
            }

            if(isValid && !key.Equals(""))
            {
                // validate Security Key
                String query1 = "SELECT * FROM secure_key WHERE `key` = ?";
                MySqlDataReader reader = Mysql.search(query1, new string[] { key });
                if(!reader.Read())
                {
                    new Message().set("Invalid Security Key", "ERROR", Message.error);
                    reader.Close();
                }
                else
                {
                    // validate a user exist with the given email or username
                    reader.Close();
                    String query2 = "SELECT * FROM users WHERE `email` = ? OR `username` = ?";
                    reader = Mysql.search(query2, new String[] { email, username } );
                    if(reader.Read())
                    {
                        new Message().set("User Already Exist", "ERROR", Message.error);
                        reader.Close();
                    }
                    else
                    {
                        // add new user account if all validation passed
                        reader.Close();
                        String query3 = "INSERT INTO `users`(`name`, `username`, `email`, `password`) VALUES(?, ?, ?, ?)";
                        Mysql.insert(query3, values);

                        new Dashboard().Show();
                        this.Hide();
                    }
                }
            }
            else
            {
                new Message().set("Please Fill All TextFields", "ERROR", Message.error);
            }
        }
    }
}
