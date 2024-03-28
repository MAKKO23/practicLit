using Microsoft.EntityFrameworkCore.Migrations.Operations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using WpfApp1.Classes;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Environment.Exit(0);
        }

        private void reg_Click(object sender, RoutedEventArgs e)
        {
          

            var login = LoginBox.Text;
            var pass = PasswordBox.Text;
            var mail = MailBox.Text;
            var context = new AppDbContext();

            var user_exist = context.Users.FirstOrDefault(x => x.Login == login);

            if ((!Regex.IsMatch(mail, @"^[a-zA-z0-9_.+-]+@(mail\.ru|gmail.com|yandex\.ru)$")))
            {
                oshibka1.Text = "ПОЧТА НЕ ВЕРНА";
                oshibka1.Visibility = Visibility.Visible;
            }
            else if (((!Regex.IsMatch(pass, @"[!,&%+_]"))))
            {
                oshibka1.Visibility = Visibility.Collapsed;
                oshibka2.Visibility = Visibility.Visible;
                oshibka2.Text = "";
                oshibka2.Text = "НЕТУ СПЕЦ. СИМВОЛА";
            }
            else if (PasswordBox.Text.Length < 6)
            {
                oshibka2.Visibility = Visibility.Visible;
                oshibka2.Text = "";
                oshibka2.Text = "ПАРОЛЬ МАЛЕНЬКИЙ";

            }
            else if (PasswordBox.Text != PovtorBox.Text)
            {
                oshibka2.Visibility = Visibility.Collapsed;
                oshibka3.Visibility = Visibility.Visible;
                oshibka3.Text = "";
                oshibka3.Text = "ПАРОЛИ НЕ СОВПАДАЮТ";

            }
            
            else if (user_exist is not null)
            {
                MessageBox.Show("Тeтот человечишка уже в тута есть");
                return;
            }
            else
            {
                var User = new User { Login = login, Password = pass, Mail = mail };
                context.Users.Add(User);
                context.SaveChanges();
                MessageBox.Show("Добро пожаловать в мир Genshin Impact");
                MainWindow reg = new MainWindow();
                reg.Show();
                this.Hide();
            }
        }

        private void vozvr_Click(object sender, RoutedEventArgs e)
        {
            MainWindow vozvr = new MainWindow();
            vozvr.Show();
            this.Hide();
        }
    }
}
