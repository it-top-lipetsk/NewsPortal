using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text.Json;
using System.Threading.Tasks;
using NewsPortal.Lib;
using NewsPortal.Server.Lib.Models;

namespace NewsPortal.Server.Test_Console
{
    class Program
    {
        static async Task Main()
        {
            var server = new TcpClient("127.0.0.1", 65003);
            var serverStream = server.GetStream();
            
            var request = new Request
            {
                Type = "news_all"
            };
            await Message.SendData(request, serverStream);
            var responseRaw = await Message.GetRequest(serverStream);
            var response = JsonSerializer.Deserialize(responseRaw, typeof(IEnumerable<News>)) as IEnumerable<News>;
            foreach (var news in response!)
            {
                Console.WriteLine($"{news.Id}: {news.Title}, {news.Content}");
            }
        }
    }
}