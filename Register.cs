using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Semipro
{
    public partial class Register : Form
    {
        private MySqlConnection databaseConnection()
        {
            string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=e-sport shop;";
            MySqlConnection conn = new MySqlConnection(connectionString);
            return conn;
        }
        public Register()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MySqlConnection conn = databaseConnection();
            string username = textBox1.Text;
            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            MySqlCommand command = new MySqlCommand("SELECT * FROM datauser WHERE username = @username", conn);
            command.Parameters.Add("@username", MySqlDbType.VarChar).Value = username;
            adapter.SelectCommand = command;
            adapter.Fill(table);
            if (table.Rows.Count > 0) 
            {
               
                MessageBox.Show("The user already has a name in the system. ");
                
            }
            else if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox5.Text == "")
            {
                MessageBox.Show("Please complete the information. ");
            }
            else if (textBox5.Text != textBox2.Text)
            {
                MessageBox.Show("Passwords do not match ");
            }
            else if (textBox4.TextLength < 10)
            {
                MessageBox.Show("Wrong phone number");
            }
            else if (textBox2.TextLength < 6)
            {
                MessageBox.Show("Password must be more than 6 characters.");
            }

            else
            {
                
                MySqlConnection con = databaseConnection();
                string sql1 = "INSERT INTO datauser(username, password, address) VALUES('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "')";
                MySqlCommand cmd = new MySqlCommand(sql1, con);
                con.Open();
                int rows1 = cmd.ExecuteNonQuery();
                if (rows1 > 0)
                {
                    MessageBox.Show("Register Compelete");
                    this.Hide();
                    Register fm = new Register();
                    fm.Show();
                }
                con.Close();

            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            Login bm = new Login();
            bm.Show();
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (System.Text.Encoding.UTF8.GetByteCount(new char[] { e.KeyChar }) > 1)
            {
                e.Handled = true;
            }
        }

        private void Register_Load(object sender, EventArgs e)
        {
            
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (System.Text.Encoding.UTF8.GetByteCount(new char[] { e.KeyChar }) > 1)
            {
                e.Handled = true;
            }
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (System.Text.Encoding.UTF8.GetByteCount(new char[] { e.KeyChar }) > 1)
            {
                e.Handled = true;
            }
        }

        private void tel_KeyPress(object sender, KeyPressEventArgs e)
        {
            textBox4.MaxLength = 10;
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
    }
}
