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
    public partial class Pay_loan : Form
    {
        private static string user;
        private static int admin;
        List<string> Client = new List<string>();
        public Pay_loan(string username, int Admin)
        {
            InitializeComponent();
            user = username;
            admin = Admin;
        }
        Database_Info_Selector l = new Database_Info_Selector("Clients", "*");
        //Client_s_List l = new Client_s_List(user, admin, false);

        private void button2_Click(object sender, EventArgs e)
        {
            l.Tag = " ";
            l.Show();
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if ((string)l.Tag == "Closed")
            {
                Client = l.results;
                textBox1.Text = Client[1];
                timer1.Stop();
            }
        }

        private void Back_Button_Click(object sender, EventArgs e)
        {
            Main_Menu m = new Main_Menu(user, admin);
            m.Show();
            Hide();
        }
    }
}
