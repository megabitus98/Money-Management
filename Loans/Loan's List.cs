using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Loans
{
    public partial class Loan_s_List: Form
    {
        string User;
        int Admin;
        public Loan_s_List(string user, int admin)
        {
            InitializeComponent();
            User = user;
            Admin = admin;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Main_Menu m = new Main_Menu(User, Admin);
            m.Show();
            this.Hide();
        }

        private void Loan_s_List_Load(object sender, EventArgs e)
        {
            using (MySqlConnection c = new MySqlConnection(Properties.Settings.Default.ProjectConnectionString))
            {
                c.Open();
                using (MySqlDataAdapter cmd = new MySqlDataAdapter("SELECT Name, Money, Tranzaction_Date FROM LOAN INNER JOIN Client ON LOAN.clientId=Client.clientId;", c))
                {
                    DataTable table = new DataTable();
                    cmd.Fill(table);
                    dataGridView1.DataSource = table;
                }
            }
        }
    }
}
