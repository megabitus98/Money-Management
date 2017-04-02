using System.Net.NetworkInformation;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Security.Cryptography;
using System.IO;
using System.Text;
using System.Linq;

namespace Money_Management
{
    class Useful
    {
        public static bool debug = true;

        #region checkEmptySpaces

        public bool CheckEmptySpaces(GroupBox con)
        {
            foreach (Control co in con.Controls)
                if (co is TextBox)
                    if (string.IsNullOrWhiteSpace(((TextBox)co).Text))
                    {
                        MessageBox.Show("You haven't filled all the values!", "Empty Values", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return true;
                    }

            return false;
        }

        public bool CheckEmptySpaces(GroupBox con, params TextBox[] exclusion)
        {
            foreach (Control co in con.Controls)
                if (co is TextBox)
                {
                    if (string.IsNullOrWhiteSpace(((TextBox)co).Text))
                    {
                        bool find = false;
                        foreach (TextBox text in exclusion)
                            if (text.Name == co.Name) find = true;
                        if (find == false)
                        {
                            MessageBox.Show("You haven't filled all the values!", "Empty Values", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return true;
                        }
                    }
                }
            return false;
        }

        public bool CheckEmptySpaces(Form form)
        {
            foreach (Control co in form.Controls)
                if (co is TextBox)
                    if (string.IsNullOrWhiteSpace(((TextBox)co).Text))
                    {
                        MessageBox.Show("You haven't filled all the values!", "Empty Values", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return true;
                    }

            return false;
        }

        #endregion

        #region clearThings

        public void ClearThings(GroupBox con)
        {
            foreach (Control co in con.Controls)
                if (co is TextBox)
                    ((TextBox)co).Clear();
        }

        public void ClearThings(Form form)
        {
            foreach (Control co in form.Controls)
                if (co is TextBox)
                    ((TextBox)co).Clear();
        }

        #endregion

        #region checkServerConnectionIp

        public static string changeText;
        public static bool buttons = false;

        public static bool networkUp = System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable();

        private static bool PingHost(string ip)
        {
            bool pingable = false;
            Ping pinger = new Ping();
            try
            {
                PingReply reply = pinger.Send(ip);
                pingable = reply.Status == IPStatus.Success;
            }
            catch (PingException)
            { }
            return pingable;
        }

        private static bool DatabaseConnection(string ip, int port)
        {
            bool connectable = false;
            string connectionString = "SERVER=" + ip + "; " + "Port=" + port + Properties.Settings.Default.ProjectConnectionTemplate;
            using (MySqlConnection conn = new MySqlConnection())
            {
                conn.ConnectionString = connectionString;
                try
                {
                    conn.Open();
                    connectable = true;
                }
                catch (MySqlException ex)
                {
                    switch (ex.Number)
                    {
                        case 0:
                            MessageBox.Show("Cannot connect to server.  Contact administrator | " + ex.Message);
                            break;

                        case 1045:
                            MessageBox.Show("Invalid username/password, please try again " + ex.Message);
                            break;
                    }
                }
            }
            return connectable;
        }

        public static void TryDatabaseConnection(int[] ports, params string[] ips)
        {
            bool OK = false;
            foreach (int port in ports)
            {
                if (OK == true) break;
                foreach (string ip in ips)
                    if (ip != null)
                    {
                        changeText = "Server Status: Trying to contact server: " + ip + ":" + port;
                        if (PingHost(ip) == true && DatabaseConnection(ip, port) == true)
                        {
                            OK = true;
                            buttons = true;
                            changeText = "Server Status: Connected to server: " + ip + ":" + port;
                            Properties.Settings.Default.ProjectConnectionString = "SERVER=" + ip + "; " + "Port=" + port + Properties.Settings.Default.ProjectConnectionTemplate;
                            Transformation.TransformSize(Form.ActiveForm, 345, 170);
                            break;
                        }
                    }
            }
            if (OK == false)
            {
                changeText = "Server Status: Switching to manual connection!";
                System.Threading.Thread.Sleep(1000);
                Transformation.TransformSize(Form.ActiveForm, 345, 335);
            }

        }

        #endregion

        #region dataAdapterFill

        public void Fill()
        {
            using (MySqlConnection conn = new MySqlConnection())
            {
                conn.ConnectionString = Properties.Settings.Default.ProjectConnectionTemplate;
                conn.Open();
                using (MySqlDataAdapter adapter = new MySqlDataAdapter("SELECT Username, Last_Login_Date, Administrator FROM Utilizatori", conn))
                {
                    DataSet customers = new DataSet();
                    adapter.Fill(customers, "Username");
                }
            }
        }

        #endregion

        #region Useful Commands

        public static void Error_Message(Exception error, bool close)
        {
            MessageBox.Show("Error, " + error.Message, "Eroare!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            if (close == true)
            {
                Application.Exit();
            }
        }

        public static void Error_Message(string error, bool close)
        {
            MessageBox.Show("Error, " + error, "Eroare!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            if (close == true)
            {
                Application.Exit();
            }
        }

        #endregion

        #region Encryption

        public static string Encrypt(string clearText)
        {
            string EncryptionKey = Application.ProductName;
            byte[] clearBytes = Encoding.Unicode.GetBytes(clearText);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(clearBytes, 0, clearBytes.Length);
                        cs.Close();
                    }
                    clearText = Convert.ToBase64String(ms.ToArray());
                }
            }
            return clearText;
        }

        public static string Decrypt(string cipherText)
        {
            string EncryptionKey = Application.ProductName;
            byte[] cipherBytes = Convert.FromBase64String(cipherText);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(cipherBytes, 0, cipherBytes.Length);
                        cs.Close();
                    }
                    cipherText = Encoding.Unicode.GetString(ms.ToArray());
                }
            }
            return cipherText;
        }

        #endregion
    }
}
