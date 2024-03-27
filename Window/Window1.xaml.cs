using Microsoft.EntityFrameworkCore.Migrations.Operations;
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
using System.Windows.Shapes;
using WpfApp1.Classes;

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
            MainWindow reg = new MainWindow();
            reg.ShowDialog();
            this.Hide();

            var login = LoginBox.Text;
            var pass = PasswordBox.Text;
            var povtor = PovtorBox.Text;
            var mail = MailBox.Text;
            var context = new AppDbContext();

            var user_exist = context.Users.FirstOrDefault(x => x.Login == login);
            if (user_exist is not null)
            {
                MessageBox.Show("Тетот человечишка уже в тута есть");
                return;
            }
            var User = new User { Login = login, Password = pass};
            context.Users.Add(User);
            context.SaveChanges();
            MessageBox.Show("Добро пожаловать в мир Genshin Impact");
        }

        private void vozvr_Click(object sender, RoutedEventArgs e)
        {
            MainWindow vozvr = new MainWindow();
            vozvr.Show();
            this.Hide();
        }
    }
}
