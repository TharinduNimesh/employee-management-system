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
    public partial class Message : Form
    {
        public static Image error = global::employee_management_system.Properties.Resources.error;
        public static Image warning = global::employee_management_system.Properties.Resources.warning;
        public static Image success = global::employee_management_system.Properties.Resources.success;

        public Message()
        {
            InitializeComponent();
        }

        public void set(String msg, String title, Image ico)
        {
            // set message, title and icon
            lbMessage.Text = msg;
            lbTitle.Text = title;
            icon.Image = ico;
            this.Show();
        }
    }
}
