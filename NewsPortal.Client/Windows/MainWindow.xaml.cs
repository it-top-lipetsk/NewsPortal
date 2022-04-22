using System.Collections.Generic;
using System.IO;
using System.Net.Sockets;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;
using NewsPortal.Client.Components;
using NewsPortal.Client.Models;
using NewsPortal.Lib;
using NewsPortal.Server.Lib.Models;

namespace NewsPortal.Client.Windows
{
    public partial class MainWindow : Window
    {
        private readonly NetworkStream _stream;
        
        public MainWindow()
        {
            var server = new TcpClient("127.0.0.1", 65003);
            _stream = server.GetStream();
            
            InitializeComponent();
        }

        private async Task GetNews()
        {
            var request = new Request
            {
                Type = "news_all"
            };
            await Message.SendData(request, _stream);
            
            var responseRaw = await Message.GetRequest(_stream);
            var response = JsonSerializer.Deserialize(responseRaw, typeof(IEnumerable<News>)) as IEnumerable<News>;
            foreach (var news in response!)
            {
                var card = new NewsCard(new NewsModel(news, new User {FirstName = "Andrey", LastName = "Starinin", MiddleName = "Nikolaevich"}));
                NewsPanel.Children.Add(card);
            }
        }
    }
}