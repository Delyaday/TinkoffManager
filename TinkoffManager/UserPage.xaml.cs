using System;
using System.IO;
using System.Threading.Tasks;
using Tinkoff.Trading.OpenApi.Network;
using System.Windows;
using System.Collections.Generic;

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

           
        }

        private async void showInfo_Click(object sender, RoutedEventArgs e)
        {
            using (var reader = File.OpenText("token.txt"))
            {
                var token = await reader.ReadToEndAsync();
                var connection = ConnectionFactory.GetConnection(token);
                var context = connection.Context;
                var portfolio = await context.PortfolioAsync();

                //shareName.Text = portfolio.Positions[0].AveragePositionPrice.Value.ToString();

                myListBox.ItemsSource = portfolio.Positions;
            }
            
        }
    }
}
