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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        MySqlConnection bag = new MySqlConnection("Server=localhost; Database=canta; uid=root;");

        private void Form2_Load(object sender, EventArgs e)
        {
            maskedTextBox1.PasswordChar = '*';
            textBox3.PasswordChar = '*';
            textBox4.PasswordChar = '*';
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
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
                textBox3.PasswordChar = '\0';
                textBox4.PasswordChar = '\0';
            }
            else
            {
                textBox3.PasswordChar = '*';
                textBox4.PasswordChar = '*';
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 login = new Form1();
            try
            {
                bag.Open();
                MySqlCommand reg = new MySqlCommand("insert into musteri(ad, soyad, tc, pass) values(@ad , @soyad , @tc , @pass)" , bag);
                reg.Parameters.AddWithValue("@ad", textBox1.Text);
                reg.Parameters.AddWithValue("@soyad", textBox2.Text);
                reg.Parameters.AddWithValue("@tc", maskedTextBox1.Text);
                reg.Parameters.AddWithValue("@pass", textBox3.Text);
                object end = reg.ExecuteReader();

                if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || maskedTextBox1.Text == "")
                {
                    MessageBox.Show("Lütfen Boş Alan Bırakmayınız.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    bag.Close();
                }
                else if (textBox3.Text != textBox4.Text)
                {
                    MessageBox.Show("Şifreler Birbiri İle Uyuşmuyor Lütfen Kontrol Ediniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    bag.Close();
                }
                else if (end != null)
                {
                    MessageBox.Show("Kaydınız Başarıyla Alındı Gerekli Sayfaya Yönlendiriliyorsunuz.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    bag.Close();
                    login.Show();
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
