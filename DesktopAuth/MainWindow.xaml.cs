using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace DesktopAuth
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            RefreshBtn.IsEnabled = false;
            CodeBx.IsEnabled = false;
            InputBtn.IsEnabled = false;
            PasswordBx.IsEnabled = false;
        }

        string code;
        Random random = new Random();
        static DispatcherTimer timer = new DispatcherTimer();

        private void RefreshBtn_Click(object sender, RoutedEventArgs e)
        {
            code = random.Next(1000, 9999).ToString();
            if (MessageBox.Show(code, "КОД", MessageBoxButton.OK, MessageBoxImage.Information) == MessageBoxResult.OK)
            {
                timer.Interval = TimeSpan.FromSeconds(10);
                timer.Tick += new EventHandler(timerTick);
                timer.Start();
                CodeBx.IsEnabled = true;
            }
        }

        private void timerTick(object sender, EventArgs e)
        {
            code = null;
            timer.Stop();
        }

        private void NumberBx_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                using (var db = new Entities())
                {
                    var number = db.Users.FirstOrDefault(u => u.Number == NumberBx.Text);
                    if (number != null)
                    {
                        PasswordBx.IsEnabled = true;
                    }
                    else
                    {
                        MessageBox.Show("Номер не верный");
                    } 
                }

            }
        }

        private void PasswordBx_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                using (var db = new Entities())
                {
                    var password = db.Users.FirstOrDefault(u => u.Number == NumberBx.Text & u.Password == PasswordBx.Password);
                    if (password == null)
                    {
                        CodeBx.IsEnabled = true;
                        RefreshBtn.IsEnabled = true;
                    }
                    else
                        MessageBox.Show("Пароль не верный");
                }
            }
        }
            private void CodeBx_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                if (code == CodeBx.Text)
                    InputBtn.IsEnabled = true;
                else
                    MessageBox.Show("Код не верный");
            }
        }

        private void InputBtn_Click(object sender, RoutedEventArgs e)
        {
            using (var db = new Entities())
            {
                var user = db.Users.FirstOrDefault(u => u.Number == NumberBx.Text & u.Password == PasswordBx.Password);
                if (user.Acc == true)
                    MessageBox.Show("Добро пожаловать, Администратор");
                else
                    MessageBox.Show("Добро пожаловать, Пользователь");
            }
        }

        private void CancelBtn_Click(object sender, RoutedEventArgs e)
        {
            CodeBx.Text = null;
            PasswordBx.Password = null;
            NumberBx.Text = null;
        }
    }
}
