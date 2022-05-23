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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        MySqlConnection bag = new MySqlConnection("Server=localhost; Database=canta; uid=root;");

        private void Form1_Load(object sender, EventArgs e)
        {
            maskedTextBox1.PasswordChar = '*';
            textBox2.PasswordChar = '*';
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if ( checkBox1.Checked == true)
            {
                maskedTextBox1.PasswordChar = '\0';
            }
            else
            {
                maskedTextBox1.PasswordChar = '*';
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked == true)
            {
                textBox2.PasswordChar = '\0';
            }
            else
            {
                textBox2.PasswordChar = '*';
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form2 kayit = new Form2();
            MessageBox.Show("Kayıta Sayfasına Yönlendiriliyorsunuz.", "Yönlendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
            kayit.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form3 stok = new Form3();
            try 
            {
                bag.Open();
                MySqlDataReader dr;
                MySqlCommand login = new MySqlCommand("select * from musteri where ad = @ad AND tc = @tc AND pass = @pass" , bag);
                login.Parameters.AddWithValue("@ad" , textBox1.Text);
                login.Parameters.AddWithValue("@tc", maskedTextBox1.Text);
                login.Parameters.AddWithValue("@pass", textBox2.Text);
                dr = login.ExecuteReader();

                if ( textBox1.Text == "" || textBox2.Text == "" || maskedTextBox1.Text == "" )
                {
                    MessageBox.Show("Lütfen Boş Alan Bırakmayınız.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    bag.Close();
                }
                else if ( dr.Read() )
                {
                    MessageBox.Show("Giriş Başarıyla Yapıldı Gerekli Sayfaya Yönlendiriliyorsunuz.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    bag.Close();
                    stok.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Bilinmeyen Bir Hata İle Karşılaşıldı Lütfen Tekrardan Giriş Yapmayı Deneyiniz. ", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    bag.Close();
                }
            }
            catch(Exception hata)
            {
                MessageBox.Show(hata.ToString(), "Hata", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
