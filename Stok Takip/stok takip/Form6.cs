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
    public partial class Form6 : Form
    {
        public Form6()
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

        private void Form6_Load(object sender, EventArgs e)
        {
            listele();
            yasakla();
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

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                bag.Open();
                MySqlDataReader dr;
                MySqlCommand sil = new MySqlCommand("delete from urun where idurun = @id" , bag);
                sil.Parameters.AddWithValue("@id", textBox9.Text);
                dr = sil.ExecuteReader();
                MessageBox.Show("Seçili Ürün Başarıyla Silindi", "Silindi", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
