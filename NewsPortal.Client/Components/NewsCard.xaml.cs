using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Controls;
using NewsPortal.Client.Models;

namespace NewsPortal.Client.Components
{
    public partial class NewsCard : UserControl, INotifyPropertyChanged
    {
        private NewsModel _news;
        public NewsModel News
        {
            get => _news;
            set
            {
                if (value == _news) return;
                _news = value;
                OnPropertyChanged(nameof(News));
            }
        }
        
        public NewsCard(NewsModel news)
        {
            News = news;
            
            InitializeComponent();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}