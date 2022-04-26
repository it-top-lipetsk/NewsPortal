using System.Collections.Generic;
using System.Net.Sockets;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;
using NewsPortal.Client.Components;
using NewsPortal.Client.Models;
using NewsPortal.Client.Windows.Login;
using NewsPortal.Lib;
using NewsPortal.Server.Lib.Models;

namespace NewsPortal.Client.Windows.Main
{
    public partial class MainWindow : Window
    {
        private readonly NetworkStream _stream;
        
        public MainWindow()
        {
            var server = new TcpClient("127.0.0.1", 65003);
            _stream = server.GetStream();
            
            InitializeComponent();

            GetNews();
        }

        private async Task GetNews()
        {
            var request = new Request
            {
                Type = "news_all"
            };
            await Message.SendData(request, _stream);
            
            var responseRaw = await Message.GetRequest(_stream);
            var response = JsonSerializer.Deserialize<IEnumerable<News>>(responseRaw);
            
            foreach (var news in response!)
            {
                var card = new NewsCard(new NewsModel(news, new User {FirstName = "Andrey", LastName = "Starinin", MiddleName = "Nikolaevich"}));
                NewsPanel.Children.Add(card);
            }
        }

        private void ButtonLogin_OnClick(object sender, RoutedEventArgs e)
        {
            new LoginWindow(_stream).Show();
        }
    }
}