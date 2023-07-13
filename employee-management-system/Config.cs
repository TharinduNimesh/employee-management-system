using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace employee_management_system
{
    public partial class Config : Form
    {
        public Config()
        {
            InitializeComponent();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            Dashboard dashboard = new Dashboard();
            dashboard.Show();
            this.Hide();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            Employee employee = new Employee();
            employee.Show();
            this.Hide();
        }

        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {
            // get user input and validate it
            String department = tbDepartment.Text;
            if (department.Trim().Equals(""))
            {
                new Message().set("Please Add Value To New Department", "ERROR", Message.warning);
                return;
            }

            // insert new department to the database
            String query = "INSERT INTO `departments`(`name`) VALUES(?)";
            Mysql.insert(query, new String[] { department });

            // set input empty
            tbDepartment.Text = "";

            new Message().set("New Department Added", "SUCCESS", Message.success);
        }

        private void guna2GradientButton2_Click(object sender, EventArgs e)
        {
            // get user input and validate it
            String designation = tbDesignation.Text;
            if (designation.Trim().Equals(""))
            {
                new Message().set("Please Add Value To New Designation", "ERROR", Message.warning);
                return;
            }

            // insert new designation to the database
            String query = "INSERT INTO `designations`(`name`) VALUES(?)";
            Mysql.insert(query, new String[] { designation });

            // set input empty
            tbDesignation.Text = "";

            new Message().set("New Designation Added", "SUCCESS", Message.success);
        }

        private void guna2GradientButton3_Click(object sender, EventArgs e)
        {
            // get user input and validate it
            String emp_type = tbEmployeeType.Text;
            if (emp_type.Trim().Equals(""))
            {
                new Message().set("Please Add Value To New Employee Type", "ERROR", Message.warning);
                return;
            }

            // insert employee type to the database
            String query = "INSERT INTO `emp_types`(`type`) VALUES(?)";
            Mysql.insert(query, new String[] { emp_type });

            // set input empty
            tbEmployeeType.Text = "";

            new Message().set("New Employee Type Added", "SUCCESS", Message.success);
        }
    }
}
