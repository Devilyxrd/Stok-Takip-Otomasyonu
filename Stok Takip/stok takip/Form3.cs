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
    public partial class Form3 : Form
    {
        public Form3()
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

        private void listele()
        {
            MySqlDataAdapter da = new MySqlDataAdapter("select kategori , cinsiyet , marka , beden , renk , fiyat , materyal from urun;", bag);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            yasakla();
            listele();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form4 add = new Form4();
            MessageBox.Show("Ürün Ekleme Sayfası Açılıyor", "Yönlendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
            add.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form5 upd = new Form5();
            MessageBox.Show("Ürün Güncelleme Sayfası Açılıyor", "Yönlendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
            upd.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form6 dlt = new Form6();
            MessageBox.Show("Ürün Silme Sayfası Açılıyor", "Yönlendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
            dlt.ShowDialog();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            textBox4.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            textBox5.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            textBox6.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
            textBox7.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
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

        private void button4_Click(object sender, EventArgs e)
        {
            temizle();
        }
    }
}
