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

namespace TinkoffManager
{
    /// <summary>
    /// Логика взаимодействия для SignUp.xaml
    /// </summary>
    public partial class SignUp : Window
    {
        AppContext db;
        public SignUp()
        {
            InitializeComponent();

            db = new AppContext();
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void btnSignUp_Click(object sender, RoutedEventArgs e)
        {
            string login = txtUsername.Text.Trim();
            string pass = txtPassword.Password.Trim();
            string pass_2 = txtPassword2.Password.Trim();

            if (login.Length < 5)
            {
                txtUsername.ToolTip = "Login can't be less than 5 symbols!";
                txtUsername.BorderBrush = Brushes.DarkRed;
            }
            else if (pass.Length < 5)
            {
                Clear();
                txtPassword.ToolTip = "Password can't be less than 5 symbols!";
                txtPassword.BorderBrush = Brushes.DarkRed;
            }
            else if (pass != pass_2)
            {
                Clear();
                txtPassword2.ToolTip = "Password doesn't match!";
                txtPassword2.BorderBrush = Brushes.DarkRed;
            }
            else
            {
                MessageBox.Show("All is good, thank you for choosing us!");

                User user = new User(login, pass);

                db.Users.Add(user);
                db.SaveChanges();

                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();
                this.Close();
            }
        }

        private void Clear()
        {
            txtUsername.ToolTip = null;
            txtUsername.BorderBrush = Brushes.Transparent;

            txtPassword.ToolTip = null;
            txtPassword.BorderBrush = Brushes.Transparent;

            txtPassword2.ToolTip = null;
            txtPassword2.BorderBrush = Brushes.Transparent;
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
