using System.Windows;

namespace RegistrationWithMailCode
{
    public partial class CodeWindow : Window
    {
        public static string sendedCode;
        public CodeWindow()
        {
            InitializeComponent();
        }

        private async void AcceptBtn_Click(object sender, RoutedEventArgs e)
        {
            if (sendedCode == CodeTB.Text)
            {
                Console.WriteLine("Все хорошо!!");
                MessageBox.Show("Вход успешен");
            }
            else
            {
                MessageBox.Show("Вы не ввели код или он неправильный");
            }
        }
    }
}
