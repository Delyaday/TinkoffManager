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

using TinkoffManager.Models;

namespace TinkoffManager
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            string login = txtUsername.Text.Trim();
            string pass = txtPassword.Password.Trim();

            if (login.Length < 5)
            {
                txtUsername.ToolTip = "Login can't be less than 5 symbols!";
                txtPassword.BorderBrush = Brushes.DarkRed;
            }
            else if (pass.Length < 5)
            {
                txtPassword.ToolTip = "Password can't be less than 5 symbols!";
                txtPassword.BorderBrush = Brushes.DarkRed;
            }
            else
            {
                txtUsername.ToolTip = null;
                txtUsername.BorderBrush = Brushes.Transparent;

                txtPassword.ToolTip = null;
                txtPassword.BorderBrush = Brushes.Transparent;

                User logUser = null;
                using (AppContext db = new AppContext())
                {
                    logUser = db.Users.Where(b => b.Login == login && b.Pass == pass).FirstOrDefault();
                }

                if (logUser != null)
                {
                    MessageBox.Show("All is good, thank you for choosing us!");
                    UserPage userPage = new UserPage();
                    userPage.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Login or Pass is wrong!");
                }

            }
        }

        private void btnSignUp_Click(object sender, RoutedEventArgs e)
        {
            SignUp signUp = new SignUp();
            signUp.Show();
            this.Close();
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
