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
    public partial class Database_Info_Selector : Form
    {
        string table_nameo;
        string[] colo;
        public List<string> results = new List<String>();
        public Database_Info_Selector(string table_name, params string[] col)
        {
            InitializeComponent();
            table_nameo = table_name;
            colo = col;
        }

        private void Select(string table_name, params string[] col)
        {
            string command = "SELECT ";
            foreach (string item in col)
            {
                command += item + " ";
            }
            command += "FROM " + table_name;
            using (MySqlConnection c = new MySqlConnection(Properties.Settings.Default.ProjectConnectionString))
            {
                c.Open();
                using (MySqlDataAdapter cmd = new MySqlDataAdapter(command, c))
                {
                    DataTable table = new DataTable();
                    cmd.Fill(table);
                    dataGridView1.DataSource = table;
                }
            }
        }

        private void send_selected()
        {
            results.Clear();
            foreach (DataGridViewRow row in dataGridView1.SelectedRows)
            {
                for (int i = 0; i < dataGridView1.ColumnCount; i++)
                {
                    results.Add(row.Cells[i].Value.ToString());
                }
            }
            Hide();
            Tag = "Closed";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            send_selected();
        }

        private void Database_Info_Selector_Load(object sender, EventArgs e)
        {
            Select(table_nameo, colo);
        }

        private void dataGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            for (int i = 0; i < dataGridView1.ColumnCount; i++)
            {
                dataGridView1.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            }
            dataGridView1.Columns[dataGridView1.ColumnCount - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void dataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            send_selected();
        }
    }
}
