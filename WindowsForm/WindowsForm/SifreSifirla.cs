using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsForm.Şema;

namespace WindowsForm
{
    public partial class SifreSifirla : Form
    {
        public SifreSifirla()
        {
            InitializeComponent();
        }
       
        MailGonder mg = new MailGonder();

        private void button1_Click(object sender, EventArgs e)
        {
            mg.Microsoft(textBox1.Text, textBox2.Text, textBox1.Text);
            MessageBox.Show("Mail Adersinizi Kontrol Ediniz","Bilgi",MessageBoxButtons.OK, MessageBoxIcon.Information); //Kullanıcı Mesajı
        }
    }
}
