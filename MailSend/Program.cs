using System.Net.Mail;
using System.Net;

namespace Maill
{
    static void Main()
    {
        public static class MailSender
        {
            public static void SendMail(string recipient, string subject, string body)
            {
                // кто отправляет
                MailAddress fromM = new MailAddress("ваше мыло", "C#");
                // куда отправляет
                MailAddress toM = new MailAddress(recipient);

                using (MailMessage message = new MailMessage(fromM, toM))
                using (SmtpClient smtpClient = new SmtpClient())
                {
                    message.Subject = subject; // Заголовок
                    message.Body = body; // Содержание письма

                    smtpClient.Host = "smtp.gmail.com";
                    smtpClient.Port = 587;
                    smtpClient.EnableSsl = true;
                    smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
                    smtpClient.UseDefaultCredentials = false;
                    // задаем ящик который отправляет письмо (адрес и пароль)
                    smtpClient.Credentials = new NetworkCredential(fromM.Address, "пароль от почты");

                    smtpClient.Send(message);
                }
            }

            public static async Task SendCode(string recipient)
            {
                Random rnd = new Random();
                int code = rnd.Next(1000, 9999);
                MailAddress fromM = new MailAddress("ваше мыло", "C#");
                MailAddress toM = new MailAddress(recipient); //куда отправить

                using (MailMessage message = new MailMessage(fromM, toM))
                using (SmtpClient smtpClient = new SmtpClient())
                {
                    message.Subject = "Welcome to prop.online!"; // Заголовок
                    message.Body = $"<h1>This is code for you registration : {code}</h1>"; //Содержание
                    message.IsBodyHtml = true;

                    smtpClient.Host = "smtp.gmail.com";
                    smtpClient.Port = 587;
                    smtpClient.EnableSsl = true;
                    smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
                    smtpClient.UseDefaultCredentials = false;
                    smtpClient.Credentials = new NetworkCredential(fromM.Address, "пароль от почты");

                    await smtpClient.SendMailAsync(message);
                }
            }
        }
    }
}
