using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text.Json;
using System.Threading.Tasks;
using NewsPortal.Lib;
using NewsPortal.Server.Lib.DataBase;
using NewsPortal.Server.Lib.Models;

namespace NewsPortal.Server
{
    internal static class Program
    {
        private static async Task Main()
        {
            var server = new TcpListener(IPAddress.Loopback, 65003);
            server.Start();

            while (true)
            {
                var client = await server.AcceptTcpClientAsync();
                var clientStream = client.GetStream();

                var requestRaw = await Message.GetRequest(clientStream);
                var request = JsonSerializer.Deserialize<Request>(requestRaw);

                switch (request?.Type)
                {
                    case "news_all":
                        await GetAllNews(clientStream);
                        break;
                    case "users_all":
                        break;
                    case "news":
                        break;
                    case "insert_news":
                        break;
                }
            }
        }

        private static async Task GetAllNews(Stream stream)
        {
            /*
            var db = new DB();
            var news = await db.GetAllNews();
            */
            IEnumerable<News> news = new List<News>
            {
                new ()
                {
                    Id = 0, 
                    Title = "Title 1", 
                    Content = "Content 1", 
                    DateOfCreation = DateTime.Now,
                    Author = 0
                }
            };
            await Message.SendData(news, stream);
        }
    }
}