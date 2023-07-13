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
    public partial class Employee : Form
    {
        public Employee()
        {
            InitializeComponent();
            this.LoadEmployees();
        }

        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {
            AddEmployee addEmployee = new AddEmployee();
            addEmployee.Show();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            Dashboard dashboard = new Dashboard();
            dashboard.Show();
            this.Hide();
        }

        private void guna2GradientButton2_Click(object sender, EventArgs e)
        {
            ManageEmployee manage = new ManageEmployee();
            manage.Show();
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            Config config = new Config();
            config.Show();
            this.Hide();
        }

        private void LoadEmployees(String name = "")
        {
            // perform search query
            String formattedName = "%" + name + "%";
            String query = "SELECT e.*, dep.name AS department, des.name AS designation FROM employees e INNER JOIN departments dep ON dep.id = e.department_id INNER JOIN designations des ON des.id = e.designation_id  WHERE is_removed = 0 AND (first_name LIKE ? OR last_name like ?)";
            MySqlDataReader reader = Mysql.search(query, new String[] { formattedName, formattedName });

            // remove all items from the list view
            listView1.Items.Clear();

            while (reader.Read())
            {
                string id = reader.GetString("id");
                string firstName = reader.GetString("first_name");
                string mobileNumber = reader.GetString("mobile_number");
                string address = reader.GetString("address");
                string department = reader.GetString("department");
                string designation = reader.GetString("designation");

                // Create a new ListViewItem and add it to the ListView
                ListViewItem item = new ListViewItem(new string[] { id, firstName, mobileNumber, address, department, designation });
                listView1.Items.Add(item);
            }
            reader.Close();
        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            this.LoadEmployees(tbName.Text);
        }

        private void guna2Button6_Click(object sender, EventArgs e)
        {
            tbName.Text = "";
            this.LoadEmployees(tbName.Text);
        }
    }
}
