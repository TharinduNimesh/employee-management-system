using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Guna.UI2.WinForms;
using MySql.Data.MySqlClient;

namespace employee_management_system
{
    public partial class AddEmployee : Form
    {
        // define dictionary to store reference IDs
        Dictionary<String, int>  departments = new Dictionary<String, int>();
        Dictionary<String, int> designations = new Dictionary<String, int>();
        Dictionary<String, int> emp_types = new Dictionary<String, int>();
        Dictionary<String, int> genders = new Dictionary<String, int>();

        public AddEmployee()
        {
            InitializeComponent();

            // define all queries
            String query1 = "SELECT DISTINCT * FROM `departments`";
            String query2 = "SELECT DISTINCT * FROM `designations`";
            String query3 = "SELECT DISTINCT * FROM `emp_types`";
            String query4 = "SELECT DISTINCT * FROM `genders`";

            // make arrays and store details
            String[] queries = new String[] { query1, query2, query3, query4 };
            Guna2ComboBox[] comboboxes = new Guna2ComboBox[] { cbDepartment, cbDesignation, cbEmployeeType, cbGender };
            Dictionary<String, int>[] maps = new Dictionary<String, int>[] { departments, designations, emp_types, genders };

            // load combo items and load reference values to dictionaries
            int index = 0;
            foreach (var query in queries)
            {
                MySqlDataReader reader = Mysql.search(query, new String[] {});
                while (reader.Read())
                {
                    comboboxes[index].Items.Add(reader.GetString(1));
                    maps[index].Add(reader.GetString(1), reader.GetInt32(0));
                }
                reader.Close();
                index++;
            }
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            // navigate To Dashboard
            Dashboard dashboard = new Dashboard();  
            dashboard.Show();
            this.Hide();
        }

        private void guna2GradientButton3_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {
            // get user inputs
            String firstName = tbFirstName.Text;
            String lastName = tbLastName.Text;
            String dateOfBirth = tbDateOfBirth.Text;
            String email = tbEmail.Text;
            String address = tbAddress.Text;
            String mobile = tbMobile.Text;
            String lanNumber = tbLan.Text;

            // validate combobox are selected
            if(cbGender.SelectedIndex == 0 || cbDepartment.SelectedIndex == 0 || cbDesignation.SelectedIndex == 0 || cbEmployeeType.SelectedIndex == 0 )
            {
                new Message().set("Please Fill All Text Fields", "WARNING", Message.warning);
                return;
            }

            // get reference id for foreign columns
            String gender = genders[cbGender.SelectedItem.ToString()].ToString();
            String department = departments[cbDepartment.SelectedItem.ToString()].ToString();
            String designation = designations[cbDesignation.SelectedItem.ToString()].ToString();
            String emp_type = emp_types[cbEmployeeType.SelectedItem.ToString()].ToString();

            String[] values = new String[] { firstName, lastName, dateOfBirth, email, address, mobile, lanNumber, gender, department, designation, emp_type };
            
            // validate all user inputs
            bool isValid = true;
            foreach (String value in values)
            {
                if (value.Trim().Equals(""))
                {
                    isValid = false;
                }
            }

            if(isValid)
            {
                String query1 = "SELECT * FROM employees WHERE email = ?";
                MySqlDataReader reader = Mysql.search(query1, new string[] { email });

                // validate user exist or not
                if(reader.Read())
                {
                    new Message().set("An User Already Exists With This Email", "ERROR", Message.error);
                    return;
                }
                reader.Close();

                // perform insert query
                String query = "INSERT INTO employees(`first_name`, `last_name`, `date_of_birth`, `address`, `email`, `mobile_number`, `home_number`, `gender_id`, `department_id`, `designation_id`, `emp_type_id`) VALUES(?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?)";
                Mysql.insert(query, values);

                reader.Close();
                this.Clear();
                new Message().set("New Employee Added", "SUCCESS", Message.success);
            }
            else
            {
                new Message().set("Please Fill All Text Fields", "WARNING", Message.warning);
            }
        }

        private void guna2GradientButton2_Click(object sender, EventArgs e)
        {
            this.Clear();
        }

        private void Clear()
        {
            // clear all textbox, combox and set default values.
            tbFirstName.Text = "";
            tbLastName.Text = "";
            tbDateOfBirth.Text = "";
            tbEmail.Text = "";
            tbAddress.Text = "";
            tbMobile.Text = "";
            tbLan.Text = "";
            cbGender.SelectedIndex = 0;
            cbDepartment.SelectedIndex = 0;
            cbDesignation.SelectedIndex = 0;
            cbEmployeeType.SelectedIndex = 0;

            // set focus to first textbox
            tbFirstName.Focus();
        }
    }
}
