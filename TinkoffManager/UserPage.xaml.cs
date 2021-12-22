using System.IO;
using Tinkoff.Trading.OpenApi.Network;
using System.Windows;

namespace TinkoffManager
{
    /// <summary>
    /// Логика взаимодействия для UserPage.xaml
    /// </summary>
    public partial class UserPage : Window
    {
        public UserPage()
        {
            InitializeComponent();

            this.DataContext = ViewModel.Current;
        }        
    }
}
