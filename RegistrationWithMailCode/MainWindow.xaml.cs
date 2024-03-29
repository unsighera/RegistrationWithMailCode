using System.Net.Mail;
using System.Net;
using System.Windows;
using static RegistrationWithMailCode.CodeWindow;

namespace RegistrationWithMailCode
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void SignInBtn_Click(object sender, RoutedEventArgs e)
        {
            if (EmailTB.Text != string.Empty || PasswordTB.Password != string.Empty)
            {
                CodeWindow codeWindow = new CodeWindow();
                codeWindow.Show();

                MailSender.SendCode(EmailTB.Text);
            }
            else
            {
                MessageBox.Show("Вы забыли ввести пароль или логин!!!");
            }
        }

        public static class MailSender
        {
            public static void SendMail(string recipient, string subject, string body)
            {
                // кто отправляет
                MailAddress fromM = new MailAddress("seva-em@mail.ru", "C#");
                // куда отправляет
                MailAddress toM = new MailAddress(recipient);

                using (MailMessage message = new MailMessage(fromM, toM))
                using (SmtpClient smtpClient = new SmtpClient())
                {
                    message.Subject = subject; // Заголовок
                    message.Body = body; // Содержание письма

                    smtpClient.Host = "smtp.mail.ru";
                    smtpClient.Port = 25;
                    smtpClient.EnableSsl = true;
                    smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
                    smtpClient.UseDefaultCredentials = false;
                    // задаем ящик который отправляет письмо (адрес и пароль)
                    smtpClient.Credentials = new NetworkCredential(fromM.Address, "gubsb3X8sEBBHcShs9CS");

                    smtpClient.Send(message);
                }
            }

            public static void SendCode(string recipient)
            {
                Random rnd = new Random();
                int code = rnd.Next(1000, 9999);
                sendedCode = $"{code}";
                MailAddress fromM = new MailAddress("seva-em@mail.ru", "C#");
                MailAddress toM = new MailAddress(recipient); //куда отправить

                using (MailMessage message = new MailMessage(fromM, toM))
                using (SmtpClient smtpClient = new SmtpClient())
                {
                    message.Subject = "Оформленеи кредита"; // Заголовок
                    message.Body = $"<h1>This is code for you registration : {code}</h1>"; //Содержание
                    message.IsBodyHtml = true;

                    smtpClient.Host = "smtp.mail.ru";
                    smtpClient.Port = 25;
                    smtpClient.EnableSsl = true;
                    smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
                    smtpClient.UseDefaultCredentials = false;
                    smtpClient.Credentials = new NetworkCredential(fromM.Address, "gubsb3X8sEBBHcShs9CS");

                    smtpClient.Send(message); // Отправка без await
                }
            }
        }
    }
}