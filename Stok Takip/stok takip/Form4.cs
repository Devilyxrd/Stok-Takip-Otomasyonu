using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace Stok_Takip
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        MySqlConnection bag = new MySqlConnection("Server=localhost; Database=canta; uid=root;");

        private void yasakla()
        {
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.ReadOnly = true;
        }

        private void temizle()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox7.Clear();
        }

        private void listele()
        {
            MySqlDataAdapter da = new MySqlDataAdapter("select kategori , cinsiyet , marka , beden , renk , fiyat , materyal from urun;", bag);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            yasakla();
            listele();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                bag.Open();
                MySqlDataAdapter da = new MySqlDataAdapter("select * from urun where kategori = '" + textBox8.Text + "'" , bag);
                DataSet ds = new DataSet();
                da.Fill(ds , "urun");
                this.dataGridView1.DataSource = ds.Tables[0];
                bag.Close();
            }
            catch (Exception hata)
            {
                MessageBox.Show(hata.ToString(), "Hata", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            listele();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                bag.Open();
                MySqlDataReader dr;
                MySqlCommand add = new MySqlCommand("insert into urun(kategori, cinsiyet, marka, beden, renk, fiyat, materyal) values(@kategori, @cinsiyet, @marka, @beden, @renk, @fiyat, @materyal)", bag);
                add.Parameters.AddWithValue("@kategori", textBox1.Text);
                add.Parameters.AddWithValue("@cinsiyet", textBox2.Text);
                add.Parameters.AddWithValue("@marka", textBox3.Text);
                add.Parameters.AddWithValue("@beden", textBox4.Text);
                add.Parameters.AddWithValue("@renk", textBox5.Text);
                add.Parameters.AddWithValue("@fiyat", textBox6.Text);
                add.Parameters.AddWithValue("@materyal", textBox7.Text);
                dr = add.ExecuteReader();
                MessageBox.Show("Ürün Başarıyla Listeye Eklendi.", "Added", MessageBoxButtons.OK, MessageBoxIcon.Information);
                temizle();
                bag.Close();
            }
            catch (Exception hata)
            {
                MessageBox.Show(hata.ToString(), "Hata", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }
    }
}
