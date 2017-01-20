using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Money_Management
{
    public partial class Main_Menu : Form
    {
        private string user;
        private int admin;
        public Main_Menu(string username, int Admin)
        {
            InitializeComponent();
            user = username;
            admin = Admin;
            label1.Text += " " + user;
            label2.Text += Admin;
        }

        private void Main_Menu_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            Login l = new Login();
            l.Show();
            this.Hide();
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            User_s_List u = new User_s_List(user, admin);
            u.Show();
            this.Hide();
        }

        private void Button1_Click(object sender, EventArgs e)
        {

        }

        private void Main_Menu_Load(object sender, EventArgs e)
        {
            if (admin == 1)
            {
                button1.Enabled = true;
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            Client_s_List c = new Client_s_List(user, admin);
            c.Show();
            this.Hide();
        }

        private void Button6_Click(object sender, EventArgs e)
        {
            Add_Client m = new Add_Client(user, admin);
            m.Show();
            this.Hide();
        }

        private void Button7_Click(object sender, EventArgs e)
        {
            Add_Loan l = new Add_Loan(user, admin);
            l.Show();
            this.Hide();
        }

        private void Button8_Click(object sender, EventArgs e)
        {
            Loan_s_List l = new Loan_s_List(user, admin);
            l.Show();
            this.Hide();
        }
    }
}
