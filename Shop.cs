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
using System.Drawing.Imaging;
using System.IO;
using System.Globalization;

namespace Semipro
{
    public partial class Shop : Form

    {
        
        string b;
        string c;
        public void ab(string a)
        {
            b = a.ToString();
        }
        public static Shop Current;
        private MySqlConnection databaseConnection()
        {
            string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=e-sport shop;";
            MySqlConnection conn = new MySqlConnection(connectionString);
            return conn;
        }
        
        


        bool es_menu = true;
        List<string> s_size = new List<string> { "S", "M", "L", "XL", "2XL", "3XL", "4XL", "5XL", "6XL" };

        public Shop()
        {
            Current = this;
            InitializeComponent();
        }
       
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            logoshow();
            switch (comboBox1.SelectedIndex)
            {
                case 0:
                    MySqlConnection conn = databaseConnection();
                    DataSet ds = new DataSet();
                    conn.Open();

                    MySqlCommand cmd;
                    cmd = conn.CreateCommand();
                    cmd.CommandText = "SELECT * FROM product WHERE team LIKE '%" + comboBox1.Text + "%'"; ;

                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                    adapter.Fill(ds);

                    conn.Close();
                    dataGridView2.DataSource = ds.Tables[0].DefaultView; break;
                case 1:
                    MySqlConnection conn1 = databaseConnection();
                    DataSet ds1 = new DataSet();
                    conn1.Open();

                    MySqlCommand cmd1;
                    cmd1 = conn1.CreateCommand();
                    cmd1.CommandText = "SELECT * FROM product WHERE team LIKE '%" + comboBox1.Text + "%'"; ;

                    MySqlDataAdapter adapter1 = new MySqlDataAdapter(cmd1);
                    adapter1.Fill(ds1);

                    conn1.Close();
                    dataGridView2.DataSource = ds1.Tables[0].DefaultView; break;
                case 2:
                    MySqlConnection conn2 = databaseConnection();
                    DataSet ds2 = new DataSet();
                    conn2.Open();

                    MySqlCommand cmd2;
                    cmd2 = conn2.CreateCommand();
                    cmd2.CommandText = "SELECT * FROM product WHERE team LIKE '%" + comboBox1.Text + "%'"; ;

                    MySqlDataAdapter adapter2 = new MySqlDataAdapter(cmd2);
                    adapter2.Fill(ds2);

                    conn2.Close();
                    dataGridView2.DataSource = ds2.Tables[0].DefaultView; break;
                case 3:
                    MySqlConnection conn3 = databaseConnection();
                    DataSet ds3 = new DataSet();
                    conn3.Open();

                    MySqlCommand cmd3;
                    cmd3 = conn3.CreateCommand();
                    cmd3.CommandText = "SELECT * FROM product WHERE team LIKE '%" + comboBox1.Text + "%'"; ;

                    MySqlDataAdapter adapter3 = new MySqlDataAdapter(cmd3);
                    adapter3.Fill(ds3);

                    conn3.Close();
                    dataGridView2.DataSource = ds3.Tables[0].DefaultView; break;
                case 4:
                    MySqlConnection conn4 = databaseConnection();
                    DataSet ds4 = new DataSet();
                    conn4.Open();

                    MySqlCommand cmd4;
                    cmd4 = conn4.CreateCommand();
                    cmd4.CommandText = "SELECT * FROM product WHERE team LIKE '%" + comboBox1.Text + "%'"; ;

                    MySqlDataAdapter adapter4 = new MySqlDataAdapter(cmd4);
                    adapter4.Fill(ds4);

                    conn4.Close();
                    dataGridView2.DataSource = ds4.Tables[0].DefaultView; break;
                case 5:
                    MySqlConnection conn5 = databaseConnection();
                    DataSet ds5 = new DataSet();
                    conn5.Open();

                    MySqlCommand cmd5;
                    cmd5 = conn5.CreateCommand();
                    cmd5.CommandText = "SELECT * FROM product WHERE team LIKE '%" + comboBox1.Text + "%'"; ;

                    MySqlDataAdapter adapter5 = new MySqlDataAdapter(cmd5);
                    adapter5.Fill(ds5);

                    conn5.Close();
                    dataGridView2.DataSource = ds5.Tables[0].DefaultView; break;
                case 6:
                    MySqlConnection conn6 = databaseConnection();
                    DataSet ds6 = new DataSet();
                    conn6.Open();

                    MySqlCommand cmd6;
                    cmd6 = conn6.CreateCommand();
                    cmd6.CommandText = "SELECT * FROM product WHERE team LIKE '%" + comboBox1.Text + "%'"; ;

                    MySqlDataAdapter adapter6 = new MySqlDataAdapter(cmd6);
                    adapter6.Fill(ds6);

                    conn6.Close();
                    dataGridView2.DataSource = ds6.Tables[0].DefaultView; break;

            };
            
            
        }
        private void stock()
        {
            int selectedRow = dataGridView2.CurrentCell.RowIndex;
            int amed = Convert.ToInt32(numericUpDown1.Text);
            MySqlConnection conn = databaseConnection();
            String sql = "UPDATE product SET amount = amount - '" + amed + "' WHERE collection = '" + textBox4.Text + "'";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            conn.Open();
            int rows = cmd.ExecuteNonQuery();
            conn.Close();
        }
        public static void dt()
        {
            DateTime localDate = DateTime.Now;
            DateTime utcDate = DateTime.UtcNow;
            String[] cultureNames = { "en-US", "en-GB", "fr-FR",
                                "de-DE", "ru-RU" };

            foreach (var cultureName in cultureNames)
            {
                var culture = new CultureInfo(cultureName);
                Console.WriteLine("{0}:", culture.NativeName);
                Console.WriteLine("   Local date and time: {0}, {1:G}",
                                  localDate.ToString(culture), localDate.Kind);
                Console.WriteLine("   UTC date and time: {0}, {1:G}\n",
                                  utcDate.ToString(culture), utcDate.Kind);
            }
        }
        private void logoshow()
        {
            if (comboBox1.SelectedIndex == 0)
            {
                BackgroundImage = Image.FromFile(@"D:\COMED17\Tanatep_C#\semiproartic\aaa\sgfsg.png");
                //pictureBox2.Image = Image.FromFile(@"D:\COMED17\Tanatep_C#\semiproartic\aaa\aaa.png");
            }
            else if (comboBox1.SelectedIndex == 1)
            {
                BackgroundImage = Image.FromFile(@"D:\COMED17\Tanatep_C#\semiproartic\day\dayy.png");
                //pictureBox2.Image = Image.FromFile(@"D:\COMED17\Tanatep_C#\semiproartic\day\day.png");
            }
            else if (comboBox1.SelectedIndex == 2)
            {
                BackgroundImage = Image.FromFile(@"D:\COMED17\Tanatep_C#\semiproartic\mith\mitht.png");
                //pictureBox2.Image = Image.FromFile(@"D:\COMED17\Tanatep_C#\semiproartic\mith\mith.png");
            }
            else if (comboBox1.SelectedIndex == 3)
            {
                BackgroundImage = Image.FromFile(@"D:\COMED17\Tanatep_C#\semiproartic\msc\mscc.png");
                //pictureBox2.Image = Image.FromFile(@"D:\COMED17\Tanatep_C#\semiproartic\msc\msc.png");
            }
           
        }
        private void customshow()
        {
            if (textBox4.Text == "AAA Jersey 2021 I" || textBox4.Text == "AAA Jersey 2021 II")
            {
                textBox1.Show();
                label3.Show();
                label4.Show();
            }
            else if (textBox4.Text == "DAYTRADE Jersey 2021 I" || textBox4.Text == "DAYTRADE Jersey 2021 II")
            {
                textBox1.Show();
                label3.Show();
                label4.Show();
            }
            else if (textBox4.Text == "MITH JERSEY 2021")
            {
                textBox1.Show();
                label3.Show();
                label4.Show();
            }
            else if (textBox4.Text == "MSC E-Sports Jersey 2020 I" || textBox4.Text == "MSC E-Sports Jersey 2020 II")
            {
                textBox1.Show();
                label3.Show();
                label4.Show();
            }
            else
            {
                label3.Hide();
                label4.Hide();
                textBox1.Hide();
            }
        }
        private void productstock()
        {
            MySqlConnection conn = databaseConnection();
            DataSet ds = new DataSet();
            conn.Open();
            MySqlCommand cmd;
            cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT * FROM product"; ;

            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
            adapter.Fill(ds);

            conn.Close();
            dataGridView2.DataSource = ds.Tables[0].DefaultView;
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            comboBox2.Items.Clear();
            MySqlConnection conn1 = databaseConnection();
            MySqlDataAdapter adapter2 = new MySqlDataAdapter("SELECT DISTINCT team FROM product", conn1);
            DataTable table = new DataTable();
            adapter2.Fill(table);
            conn1.Open();
            comboBox1.DataSource = table;
            comboBox1.ValueMember = "team";
            comboBox1.DisplayMember = "team";
            conn1.Close();
            textBox1.Hide();
            label5.Hide();
            label3.Hide();
            label4.Hide();
            label8.Text = b.ToString();
            MySqlConnection conn = databaseConnection();
            DataSet ds = new DataSet();
            conn.Open();
            MySqlCommand cmd;
            cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT * FROM product"; ;

            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
            adapter.Fill(ds);

            conn.Close();
            dataGridView2.DataSource = ds.Tables[0].DefaultView;
            for (int i = 0; i < s_size.Count; i++)
            {
                comboBox2.Items.Add(s_size[i]);
            };

        }
        private void history()
        {
            int amount = int.Parse(numericUpDown1.Text);
            int basep = 0;
            int price = int.Parse(textBox3.Text);
            basep += price * amount;
            basep.ToString();
            MySqlConnection conn = databaseConnection();
            String sql = "INSERT INTO history (username,team,collection,size,color,custom,price,amount,total,datetime) VALUES('" + b.ToString() + "' ,'" + comboBox1.Text + "' , '" + textBox4.Text + "', '" + comboBox2.Text + "', '" + textBox5.Text + "', '" + textBox1.Text + "','" + textBox3.Text + "','" + numericUpDown1.Text + "','" + basep + "','" + DateTime.Now.ToShortDateString() + "')";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            conn.Open();
            int rows = cmd.ExecuteNonQuery();
            conn.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int amount = int.Parse(numericUpDown1.Text);
            if ((textBox5.Text == "") || (comboBox2.Text == ""))
            {
                MessageBox.Show("Please complete the order.");
            }
            else if (amount == 0)
            {
                MessageBox.Show("Incorrect Amount");
            }
            else if (textBox2.Text == "0")
            {
                MessageBox.Show("Out of stock");
            }
            else
            {
                productstock();
                stock();
                history();
                int basep = 0;
                int price = int.Parse(textBox3.Text);
                basep += price * amount;
                basep.ToString();
                MySqlConnection conn = databaseConnection();
                String sql = "INSERT INTO testsemi (user,collection,size,color,custom,price,amount,total) VALUES('" + b.ToString() + "' , '" + textBox4.Text + "', '" + comboBox2.Text + "', '" + textBox5.Text + "', '" + textBox1.Text + "','" + textBox3.Text + "','" + numericUpDown1.Text + "','" + basep + "')";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                conn.Open();
                int rows = cmd.ExecuteNonQuery();
                conn.Close();
                if (rows > 0)
                {
                    comboBox2.Text = "";
                    textBox2.Clear();
                    MessageBox.Show("Pre-Order Complete");
                    textBox1.Clear();
                }
            }
        }

        private void ออกจากระบบToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Logout Complete");
            Login frm1 = new Login();
            frm1.Show();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }


        private void datadata_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
            MySqlConnection conn = databaseConnection();
            dataGridView2.CurrentRow.Selected = true;
            textBox4.Text = dataGridView2.Rows[e.RowIndex].Cells["collection"].FormattedValue.ToString();
            textBox2.Text = dataGridView2.Rows[e.RowIndex].Cells["amount"].FormattedValue.ToString();
            int selectedRow = dataGridView2.CurrentCell.RowIndex;
            int pic = Convert.ToInt32(dataGridView2.Rows[selectedRow].Cells["id"].Value);
            customshow();
            String sql = "SELECT * FROM product WHERE id = '" + pic + "'";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            DataTable table = new DataTable();
            da.Fill(table);
            conn.Open();
            textBox5.Text = table.Rows[0][3].ToString();
            textBox3.Text = table.Rows[0][4].ToString();
            textBox4.Text = table.Rows[0][2].ToString();
            byte[] img = (byte[])table.Rows[0][5];
            MemoryStream ms = new MemoryStream(img);
            pictureBox1.Image = Image.FromStream(ms);
            da.Dispose();
            conn.Close();

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            c = label8.Text;
            list lis = new list();
            lis.cd(c.ToString());
            this.Hide();
            lis.Show();
        }

        private void shoplist_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.Cancel = true;
        }
    }
}

