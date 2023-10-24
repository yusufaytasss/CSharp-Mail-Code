using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using WindowsForm.Şema;

namespace WindowsForm.Şema
{
    public class MailGonder
    {
        //veritaban bağlantısı
        WindowsFormEntities db = new WindowsFormEntities();
        //Mesaj gönderme metodunu internetten aldım.
        public void Microsoft(string GondericiMail, string GondericiPass, string AliciMail)
        {
            GirisTablo g = db.GirisTablo.FirstOrDefault(x => x.MailAdress == GondericiMail); //Maillerin birbiri ile uyumunu kontrol eder.
            Random rnd = new Random();
            g.Password = rnd.Next(1000,10000).ToString(); //Belirlenen sayı aralığında rastgele bir sayı oluşturur.
            db.SaveChanges(); //Yapılan değişiklikleri veritabanına kaydeder.
            SmtpClient sc = new SmtpClient();
            sc.Port = 587;
            //sc.Port = 465;
            sc.Host = "smtp.outlook.com";
            //sc.Host = "smtp.gmail.com";
            sc.EnableSsl = true;
            sc.Credentials = new NetworkCredential(GondericiMail, GondericiPass);
            MailMessage mail = new MailMessage();
            mail.From = new MailAddress(GondericiMail, "Şifre Sıfırlama");
            mail.To.Add(AliciMail);
            mail.Subject = "Şifre Sıfırlama Talebi";
            mail.IsBodyHtml = true;
            mail.Body = $@"{DateTime.Now.ToString()} Tarihinde Şifre Sıfırlama Talebinde Bulundunuz. Yeni Şifreniz {g.Password}"; //Gönderilen mailin içeriği
            sc.Send(mail);
        }
    }
}
