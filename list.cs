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
using System.Drawing.Printing;
using Semipro.Properties;
using System.Globalization;

namespace Semipro
{
    public partial class list : Form
    {
        string d;
        public void cd(string c)
        {
            d = c.ToString();
        }
       
        private List<Class1> allbill = new List<Class1>();
       
        public static list Current;
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
        private MySqlConnection databaseConnection()
        {
            string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=e-sport shop;";
            MySqlConnection conn = new MySqlConnection(connectionString);
            return conn;
        }
        List<string> s_size = new List<string> { "S", "M", "L", "XL", "2XL", "3XL", "4XL", "5XL", "6XL" };
        public list()
        {
            Current = this;
            InitializeComponent();
        }
        private void showEquipment()
        {
            MySqlConnection conn = databaseConnection();
            DataSet ds = new DataSet();
            conn.Open();

            MySqlCommand cmd;
            cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT * FROM testsemi WHERE user LIKE '%" + d.ToString() + "%'"; ;

            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
            adapter.Fill(ds);

            conn.Close();
            dataGridView1.DataSource = ds.Tables[0].DefaultView;
            int sum = 0;
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                sum += Convert.ToInt32(dataGridView1.Rows[i].Cells[8].Value);

            }
            textBox1.Text = sum.ToString();
        }

        private void list_Load(object sender, EventArgs e)
        {
            label11.Text = d.ToString();
            for (int i = 0; i < s_size.Count; i++)
            {
                comboBox2.Items.Add(s_size[i]);
            };
            showEquipment();
            textBox3.Text = DateTime.Now.ToShortDateString();
            textBox8.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int price = int.Parse(textBox1.Text);
            int pay = int.Parse(textBox5.Text);
            int result;
            if (pay < price)
            {
                MessageBox.Show("Not enough money ");
            }
            else
            {
                result = pay - price;
                textBox6.Text = result.ToString();
            }
        }

        private void lilst_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView1.CurrentRow.Selected = true;
            textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells["custom"].FormattedValue.ToString();
            textBox4.Text = dataGridView1.Rows[e.RowIndex].Cells["collection"].FormattedValue.ToString();
            comboBox2.Text = dataGridView1.Rows[e.RowIndex].Cells["size"].FormattedValue.ToString();
            textBox7.Text = dataGridView1.Rows[e.RowIndex].Cells["price"].FormattedValue.ToString();
            numericUpDown1.Text = dataGridView1.Rows[e.RowIndex].Cells["amount"].FormattedValue.ToString();
            textBox8.Text = dataGridView1.Rows[e.RowIndex].Cells["amount"].FormattedValue.ToString();
        }
        
        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Shop.Current.ShowDialog();
        }
        private void delsemi()
        {
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                MySqlConnection conn = databaseConnection();
                String sql = "DELETE FROM testsemi WHERE user = '" + d.ToString() + "'";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                conn.Open();
                int rows = cmd.ExecuteNonQuery();
                conn.Close();
            }
        }
        private void delhis()
        {
            MySqlConnection conn = databaseConnection();
            String sql = "DELETE FROM history WHERE collection = '" + textBox4.Text + "'";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            conn.Open();
            int rows = cmd.ExecuteNonQuery();
            conn.Close();
        }
        private void delpro()
        {
            int edamount = Convert.ToInt32(numericUpDown1.Text);
            MySqlConnection conn = databaseConnection();
            String sql = "UPDATE product SET amount = amount + '" + edamount + "' WHERE collection = '" + textBox4.Text + "'";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            conn.Open();
            int rows = cmd.ExecuteNonQuery();
            conn.Close();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            int selectedRow = dataGridView1.CurrentCell.RowIndex;
            int deleteid = Convert.ToInt32(dataGridView1.Rows[selectedRow].Cells["id"].Value);
            MySqlConnection conn = databaseConnection();
            String sql = "DELETE FROM testsemi WHERE id = '" + deleteid + "'";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            conn.Open();
            int rows = cmd.ExecuteNonQuery();
            conn.Close();
            delhis();
            if (rows > 0)
            {
                delpro();
                MessageBox.Show("Remove Complete");
                showEquipment();
            }
        }
        private void editam()
        {

            int amount = Convert.ToInt32(textBox8.Text);
            int edamount = Convert.ToInt32(numericUpDown1.Text);
            if (amount != edamount)
            {
                if ( amount > edamount)
                {
                    int eda1 = 0;
                    eda1 = amount - edamount;
                    MySqlConnection conn = databaseConnection();
                    String sql = "UPDATE product SET amount = amount + '" + eda1 + "' WHERE collection = '" + textBox4.Text + "'";
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    conn.Open();
                    int rows = cmd.ExecuteNonQuery();
                    conn.Close();
                }
                else if(edamount > amount)
                {
                    int eda2 = 0;
                    eda2 = edamount - amount;
                    MySqlConnection conn = databaseConnection();
                    String sql = "UPDATE product SET amount = amount - '" + eda2 + "' WHERE collection = '" + textBox4.Text + "'";
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    conn.Open();
                    int rows = cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            int basep = 0;
            int amount = int.Parse(numericUpDown1.Text);
            int price = int.Parse(textBox7.Text);
            basep += price * amount;
            basep.ToString();
            int selectedRow = dataGridView1.CurrentCell.RowIndex;
            int editid = Convert.ToInt32(dataGridView1.Rows[selectedRow].Cells["id"].Value);
            MySqlConnection conn = databaseConnection();
            String sql = "UPDATE  testsemi SET custom = '" + textBox2.Text + "', size = '" + comboBox2.Text + "', price = '" + textBox7.Text + "', amount = '" + numericUpDown1.Text + "', total = '" + basep + "' WHERE id = '" + editid + "'";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            conn.Open();
            int rows = cmd.ExecuteNonQuery();
            conn.Close();
            if (rows > 0)
            {
                editam();
                MessageBox.Show("Repair Data Complete");
                showEquipment();
            }
        }
       
        private void button5_Click(object sender, EventArgs e)
        {
            printPreviewDialog1.Document = printDocument1;
            printPreviewDialog1.ShowDialog();
            delsemi();
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Image image = Resources.db;
            e.Graphics.DrawImage(image, 0, 0, image.Width, image.Height);
            e.Graphics.DrawString("Data: " + DateTime.Now.ToShortDateString(), new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(25, 160));
            e.Graphics.DrawString("Username: " + label11.Text ,new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(25, 190));
            e.Graphics.DrawString("----------------------------------------------------------------------------------------------------------------------------------------" , new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(25, 230));
            e.Graphics.DrawString("Collection name", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(30, 250));
            e.Graphics.DrawString("Size" , new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(210, 250));
            e.Graphics.DrawString("Color", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(280, 250));
            e.Graphics.DrawString("Custom", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(350, 250));
            e.Graphics.DrawString("Unit Price", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(500, 250));
            e.Graphics.DrawString("Amount", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(600, 250));
            e.Graphics.DrawString("Total Price", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(700, 250));
            e.Graphics.DrawString("----------------------------------------------------------------------------------------------------------------------------------------", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(25, 265));
            int yPos = 290;
            //int index = dataGridView1.CurrentCell.RowIndex;
            //data.RemoveAt(index);
            //dataGridView1.DataSource = null;;
            loaddata();
            foreach (var i in allbill)
            {
                e.Graphics.DrawString(i.Collection, new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(30, yPos));
                e.Graphics.DrawString(i.Size, new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(210, yPos));
                e.Graphics.DrawString(i.Color, new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(280, yPos));
                e.Graphics.DrawString(i.Custom, new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(350, yPos));
                e.Graphics.DrawString(i.Price, new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(500, yPos));
                e.Graphics.DrawString(i.Amount, new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(600, yPos));
                e.Graphics.DrawString(i.Total, new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(700, yPos));

                yPos += 30;
            }
            e.Graphics.DrawString("----------------------------------------------------------------------------------------------------------------------------------------", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(25, yPos));
            e.Graphics.DrawString("   Total Price:   " + textBox1.Text +" ฿", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(550, yPos + 30));
            e.Graphics.DrawString("        Amount:   " + textBox5.Text + " ฿", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(550, yPos + 60));
            e.Graphics.DrawString("Total Change:  " + textBox6.Text + " ฿", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(550, yPos + 90));
        }
        private void loaddata()
        {
            textBox8.Hide();
            MySqlConnection conn = new MySqlConnection("host=127.0.0.1;username=root;password=;database=e-sport shop;");

            conn.Open();

            MySqlCommand cmd = new MySqlCommand($"SELECT * FROM testsemi WHERE user LIKE '%" + d.ToString() + "%'", conn);
            MySqlDataReader adapter = cmd.ExecuteReader();

            while (adapter.Read())
            {
                Program.username = adapter.GetString("user");
                Program.collection = adapter.GetString("collection");
                Program.color = adapter.GetString("color");
                Program.size = adapter.GetString("size");
                Program.custom = adapter.GetString("custom");
                Program.price = adapter.GetString("price");
                Program.amount = adapter.GetString("amount");
                Program.total = adapter.GetString("total");

                Class1 item = new Class1()
                {
                    Username = Program.username,
                    Collection = Program.collection,
                    Price = Program.price,
                    Size = Program.size,
                    Color = Program.color,
                    Custom = Program.custom,
                    Amount = Program.amount,
                    Total = Program.total,
                };
                allbill.Add(item);
            }
        }

        private void entpres_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void amout_KeyPress(object sender, KeyPressEventArgs e)
        {
        }

        private void list_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.Cancel = true;
        }
    }
}
