﻿using System;
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
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            Employee employee = new Employee();
            employee.Show();
            this.Hide();
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            Config config = new Config();
            config.Show();
            this.Hide();
        }
    }
}
