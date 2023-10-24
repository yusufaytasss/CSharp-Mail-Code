using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsForm.Şema;

namespace WindowsForm
{
    public partial class Form1 : Form
    {
        WindowsFormEntities db = new WindowsFormEntities(); //Veritabanı Bağlantısı
        public Form1()
        {
            InitializeComponent();
        }

        //public static int Id;

        private void button1_Click(object sender, EventArgs e)
        {
            var Durum = db.GirisTablo.FirstOrDefault(x => x.MailAdress == textBox1.Text && x.Password == textBox2.Text); //Veritabanı ile bilgi karşılaştırması
            if (Durum != null)
            {   //Başarılı giriş ise yeni sayfaya yönlendiriyor.
                BasariliGiris bg = new BasariliGiris();
                bg.ShowDialog();
            }
            else
            {   //Başarısız giriş ise kullanıcıya mesaj ver.
                MessageBox.Show("Hatalı Giriş ! (Bilgilerinizi Kontrol Edip Tekrardan Deneyiniz.)", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {
            //Şifre sıfırlama ekranına yönlendirir.
            SifreSifirla sifreSifirla = new SifreSifirla();
            sifreSifirla.ShowDialog();
        }
    }
}
