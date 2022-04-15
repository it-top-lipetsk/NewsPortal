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
            
            Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;
        }

        public async Task<IEnumerable<News>> GetAllNews()
        {
            await _connection.OpenAsync();

            var sql = "SELECT id, title, content, date_of_creation, author FROM tab_news";
            var result = await _connection.QueryAsync<News>(sql);

            await _connection.CloseAsync();

            return result;
        }

        public async Task<News> GetNewsById(int id)
        {
            await _connection.OpenAsync();

            var sql = $"SELECT id, title, content, date_of_creation, author FROM tab_news WHERE id={id}";
            var news = await _connection.QuerySingleAsync<News>(sql);
            
            await _connection.CloseAsync();

            return news;
        }

        public async Task<bool> InsertNews(News news)
        {
            await _connection.OpenAsync();

            var sql = $"INSERT INTO tab_news (title, content, date_of_creation, author) VALUE ('{news.Title}', '{news.Content}', '{news.DateOfCreation}', {news.Author});";
            var command = new MySqlCommand(sql, _connection);
            var result = await command.ExecuteNonQueryAsync();
            
            await _connection.CloseAsync();
            
            return result == 1;
        }

        public async Task<IEnumerable<User>> GetAllUsers()
        {
            await _connection.OpenAsync();

            var sql = "SELECT id, login, password, email, first_name, last_name, middle_name FROM tab_users;";
            var users = await _connection.QueryAsync<User>(sql);
            
            await _connection.CloseAsync();

            return users;
        }
    }
}