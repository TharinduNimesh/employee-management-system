using System;
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
    public partial class ManageEmployee : Form
    {

        // define dictionary to store reference IDs
        Dictionary<String, int> departments = new Dictionary<String, int>();
        Dictionary<String, int> designations = new Dictionary<String, int>();
        Dictionary<String, int> emp_types = new Dictionary<String, int>();
        Dictionary<String, int> genders = new Dictionary<String, int>();

        private static int searchedID = 0;

        public ManageEmployee()
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
                MySqlDataReader reader = Mysql.search(query, new String[] { });
                while (reader.Read())
                {
                    comboboxes[index].Items.Add(reader.GetString(1));
                    maps[index].Add(reader.GetString(1), reader.GetInt32(0));
                }
                reader.Close();
                index++;
            }
        }

        private void guna2GradientButton3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            // set searchedID to 0
            searchedID = 0;

            // get user input and validate it
            String id = tbID.Text;
            if (id.Trim().Equals(""))
            {
                new Message().set("Please Enter An ID", "WARNING", Message.warning);
                return;
            }

            // perform the search query
            String query = "SELECT e.*, dep.name AS department, des.name AS designation, g.`type` AS gender, et.type AS emp_type\r\nFROM employees e\r\nINNER JOIN departments dep ON dep.id = e.department_id\r\nINNER JOIN designations des ON des.id = e.designation_id\r\nINNER JOIN genders g ON g.id = e.gender_id \r\nINNER JOIN emp_types et ON et.id = e.emp_type_id\r\nWHERE e.id = ? AND is_removed = 0";
            MySqlDataReader reader = Mysql.search(query, new string[] { id });

            // validate employee exist or not
            if (reader.Read())
            {
                // load values to text boxes
                tbFirstName.Text = reader.GetString("first_name");
                tbLastName.Text = reader.GetString("last_name");
                tbDateOfBirth.Text = reader.GetString("date_of_birth");
                tbEmail.Text = reader.GetString("email");
                tbAddress.Text = reader.GetString("address");
                tbMobile.Text = reader.GetString("mobile_number");
                tbLan.Text = reader.GetString("home_number");
                cbGender.SelectedItem = reader.GetString("gender");
                cbDepartment.SelectedItem = reader.GetString("department");
                cbDesignation.SelectedItem = reader.GetString("designation");
                cbEmployeeType.SelectedItem = reader.GetString("emp_type");

                searchedID = int.Parse(id);
            }
            else
            {
                new Message().set("Invalid Employee ID", "ERROR", Message.error);
            }
            reader.Close();
        }

        private void guna2GradientButton2_Click(object sender, EventArgs e)
        {
            // validate user have searched a employee or not
            if(searchedID == 0)
            {
                new Message().set("Please Search A Employee To Delete", "WARNING", Message.warning);
                return;
            }

            // set search employee as removed
            String query = "UPDATE employees SET is_removed = 1 WHERE id = ?";
            Mysql.update(query, new String[] { searchedID.ToString() });

            new Message().set("Employee Removed Successfully", "SUCCESS", Message.success);
        }

        private void Clear()
        {
            // clear all textboxes and comboboxex
            tbFirstName.Text = "";
            tbLastName.Text = "";
            tbDateOfBirth.Text = "";
            tbEmail.Text = "";
            tbAddress.Text = "";
            tbMobile.Text = "";
            tbLan.Text = "";
            cbGender.SelectedItem = "";
            cbDepartment.SelectedIndex = -1;
            cbDesignation.SelectedIndex = -1;
            cbEmployeeType.SelectedIndex = -1;

            // clear searched id and focus to searching input
            tbID.Text = "";
            tbID.Focus();
            searchedID = 0;
        }

        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {
            // validate user have searched a employee or not
            if (searchedID == 0)
            {
                new Message().set("Please Search A Employee To Delete", "WARNING", Message.warning);
                return;
            }

            String FirstName = tbFirstName.Text;
            String LastName = tbLastName.Text;
            String DateOfBirth = tbDateOfBirth.Text;
            String Email = tbEmail.Text;
            String Address = tbAddress.Text;
            String Mobile = tbMobile.Text;
            String Lan = tbLan.Text;


            // validate combobox are selected
            if (cbGender.SelectedIndex == -1 || cbDepartment.SelectedIndex == -1 || cbDesignation.SelectedIndex == -1 || cbEmployeeType.SelectedIndex == -1)
            {
                new Message().set("Please Fill All Text Fields", "WARNING", Message.warning);
                return;
            }
            // get reference id for foreign columns
            String Gender = genders[cbGender.SelectedItem.ToString()].ToString();
            String Department = departments[cbDepartment.SelectedItem.ToString()].ToString();
            String Designation = designations[cbDesignation.SelectedItem.ToString()].ToString();
            String EmployeeType = emp_types[cbEmployeeType.SelectedItem.ToString()].ToString();

            String[] columns = new String[] { "first_name", "last_name", "date_of_birth", "email", "address", "mobile_number",
                "home_number", "gender_id", "department_id", "designation_id", "emp_type_id" };
            
            String[] values = new String[] { FirstName, LastName, DateOfBirth, Email, Address, Mobile, Lan, Gender, Department, Designation, EmployeeType };

            bool isValid = true;
            foreach (var value in values)
            {
                if(value.Equals(""))
                {
                    isValid = false;
                }
            }

            if(!isValid)
            {
                new Message().set("Please Fill All Text Fields", "WARNING", Message.warning);
                return;
            }

            int index = 0;
            foreach (var column in columns)
            {
                String query = "UPDATE employees SET "+ column +" = ? WHERE id = ?";
                Mysql.update(query, new string[] { values[index], searchedID.ToString() });

                index++;
            }
            this.Clear();
        }
    }
}
