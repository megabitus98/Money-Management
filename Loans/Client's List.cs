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

namespace Money_Management
{
    public partial class Client_s_List : Form
    {
        private bool retur1;
        private string user;
        private int admin;
        public List<string> results = new List<String>();
        public Client_s_List(string username, int Admin, bool retur)
        {
            InitializeComponent();
            user = username;
            admin = Admin;
            retur1 = retur;
        }

        private void Client_s_List_Load(object sender, EventArgs e)
        {
            if (retur1==true)
            {
                button2.Hide();
            }
            using (MySqlConnection c = new MySqlConnection(Properties.Settings.Default.ProjectConnectionString))
            {
                try
                {
                    c.Open();
                    using (MySqlDataAdapter cmd = new MySqlDataAdapter("SELECT * FROM Clients", c))
                    {
                        DataTable table = new DataTable();
                        cmd.Fill(table);
                        dataGridView1.DataSource = table;
                    }
                }
                catch (Exception z)
                {
                    Useful.Error_Message(z, true);
                }
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Hide();
            Main_Menu m = new Main_Menu(user, admin);
            if (retur1==true)
            {
                m.Show();
            }
        }

        private void dataGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dataGridView1.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dataGridView1.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dataGridView1.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }
        private void send_selected()
        {
            if (retur1==false)
            {
                results.Clear();
                foreach (DataGridViewRow row in dataGridView1.SelectedRows)
                {
                    results.Add(row.Cells[0].Value.ToString());
                    results.Add(row.Cells[1].Value.ToString());
                    results.Add(row.Cells[2].Value.ToString());
                    results.Add(row.Cells[3].Value.ToString());
                    results.Add(row.Cells[4].Value.ToString());
                    results.Add(row.Cells[5].Value.ToString());
                }
                Hide();
                Tag = "Closed";
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            send_selected();
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            send_selected();
        }
    }
}
