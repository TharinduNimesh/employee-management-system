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
    public partial class Employee : Form
    {
        public Employee()
        {
            InitializeComponent();
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
    }
}
