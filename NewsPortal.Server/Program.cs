using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using NewsPortal.Server.Lib.DataBase;
using NewsPortal.Server.Lib.Models;

namespace NewsPortal.Server
{
    internal static class Program
    {
        private static async Task Main()
        {
            var server = new TcpListener(IPAddress.Loopback, 8005);
            server.Start();

            while (true)
            {
                var client = await server.AcceptTcpClientAsync();
                var clientStream = client.GetStream();

                var requestRaw = await GetRequest(clientStream);
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
            var db = new DB();
            var news = await db.GetAllNews();

            await SendData(news, stream);
        }

        private static async Task SendData(object value, Stream stream)
        {
            var sendRaw = JsonSerializer.Serialize(value, value.GetType());
            var data = Encoding.Unicode.GetBytes(sendRaw);
            await stream.WriteAsync(data.AsMemory(0, data.Length));
        }
        private static async Task<string> GetRequest(NetworkStream stream)
        {
            var builder = new StringBuilder();
            var data = new byte[64];
            do
            {
                var bytes = await stream.ReadAsync(data.AsMemory(0, data.Length));
                builder.Append(Encoding.Unicode.GetString(data, 0, bytes));
            }
            while (stream.DataAvailable);

            return builder.ToString();
        }
    }
}