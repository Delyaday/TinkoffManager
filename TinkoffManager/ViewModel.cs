using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

using Tinkoff.Trading.OpenApi.Models;
using Tinkoff.Trading.OpenApi.Network;

namespace TinkoffManager
{
    public class ViewModel : NotifyObject
    {
        private static ViewModel _instance;

        public static ViewModel Current
        {
            get
            {
                if (_instance == null)
                    _instance = new ViewModel();
                return _instance;
            }
        }

        private bool _isBusy = false;
        private Portfolio _portfolio;

        private ViewModel()
        {
            var _ = ShouldInitializedAsync();
        }

        public bool IsBusy
        {
            get { return _isBusy; }
            set
            {
                _isBusy = value;
                OnPropertyChanged();
            }
        }

        public Portfolio Portfolio
        {
            get { return _portfolio; }
            set
            {
                _portfolio = value;
                OnPropertyChanged();
            }
        }

        private async Task ShouldInitializedAsync()
        {
            try
            {
                IsBusy = true;

                Portfolio = await GetPortfolioAsync();
            }
            finally
            {
                IsBusy = false;
            }
        }

        private async Task<Portfolio> GetPortfolioAsync()
        {
            using (var reader = File.OpenText("token.txt"))
            {
                var token = await reader.ReadToEndAsync();
                var connection = ConnectionFactory.GetConnection(token);
                var context = connection.Context;
                return await context.PortfolioAsync();
            }
        }
    }

    public class NotifyObject : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
