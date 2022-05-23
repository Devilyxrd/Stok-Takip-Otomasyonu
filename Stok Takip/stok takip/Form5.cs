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
    public partial class Form5 : Form
    {
        public Form5()
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
            MySqlDataAdapter da = new MySqlDataAdapter("select * from urun;", bag);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
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
            textBox9.Clear();
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            yasakla();
            listele();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                bag.Open();
                MySqlDataAdapter da = new MySqlDataAdapter("select * from urun where kategori = '" + textBox8.Text + "'", bag);
                DataSet ds = new DataSet();
                da.Fill(ds, "urun");
                this.dataGridView1.DataSource = ds.Tables[0];
                bag.Close();
            }
            catch (Exception hata)
            {
                MessageBox.Show(hata.ToString(), "Hata", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            listele();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                bag.Open();
                MySqlDataReader dr;
                MySqlCommand upd = new MySqlCommand("update urun set kategori = @kg , cinsiyet = @cn , marka = @mr , beden = @bd , renk = @rk , fiyat = @ft , materyal = @mt where idurun = @id" , bag);
                upd.Parameters.AddWithValue("@kg", textBox1.Text);
                upd.Parameters.AddWithValue("@cn", textBox2.Text);
                upd.Parameters.AddWithValue("@mr", textBox3.Text);
                upd.Parameters.AddWithValue("@bd", textBox4.Text);
                upd.Parameters.AddWithValue("@rk", textBox5.Text);
                upd.Parameters.AddWithValue("@ft", textBox6.Text);
                upd.Parameters.AddWithValue("@mt", textBox7.Text);
                upd.Parameters.AddWithValue("id", textBox9.Text);
                dr = upd.ExecuteReader();
                MessageBox.Show("Seçtiğiniz Ürün Başarıyla Güncellendi.", "Güncellendi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                temizle();
                bag.Close();
            }
            catch (Exception hata)
            {
                MessageBox.Show(hata.ToString(), "Hata", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox9.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            textBox3.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            textBox4.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            textBox5.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
            textBox6.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
            textBox7.Text = dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString();
        }
    }
}

//kategori , cinsiyet , marka , beden , renk , fiyat , materyal//
