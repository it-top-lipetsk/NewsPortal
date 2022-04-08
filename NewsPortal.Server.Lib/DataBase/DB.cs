using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Dapper;
using MySql.Data.MySqlClient;
using NewsPortal.Server.Lib.Models;

namespace NewsPortal.Server.Lib.DataBase
{
    public class DB
    {
        private MySqlConnection _connection;

        public DB()
        {
            var conn = File.ReadAllTextAsync("connection_to_db.txt").Result;
            _connection = new MySqlConnection(conn);
        }

        public async Task<IEnumerable<News>> GetAllNews()
        {
            await _connection.OpenAsync();

            var sql = "SELECT id, title, content, date_of_creation, author FROM tab_news";
            var result = await _connection.QueryAsync<News>(sql);

            await _connection.CloseAsync();

            return result;
        }
    }
}