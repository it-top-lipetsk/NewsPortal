using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NewsPortal.Server.Lib.DataBase;
using NewsPortal.Server.Lib.Models;
using Xunit;

namespace NewsPortal.Server.Lib.Test
{
    public class DbTest
    {
        [Fact]
        public async Task GetAllNews_Test()
        {
            IEnumerable<News> expectedNews = new List<News>
            {
                new()
                {
                    Id = 1,
                    Title = "News 1",
                    Content = "content 1",
                    DateOfCreation = new DateTime(2022, 4, 12, 18, 48, 51),
                    Author = 1
                }
            };

            var db = new DB();
            var actualNews = await db.GetAllNews();

            Assert.Equal(expectedNews, actualNews);
        }

        [Fact]
        public async Task GetNewsById_Test()
        {
            var expectedNews = new News
            {
                Id = 1,
                Title = "News 1",
                Content = "content 1",
                DateOfCreation = new DateTime(2022, 4, 12, 18, 48, 51),
                Author = 1
            };

            var id = 1;
            var db = new DB();
            var actualNews = await db.GetNewsById(id);
            
            Assert.Equal(expectedNews, actualNews);
        }

        [Fact]
        public async Task InsertNews_Test()
        {
            var news = new News
            {
                Title = "News 2",
                Content = "content 2",
                DateOfCreation = new DateTime(2022, 4, 12, 18, 48, 51),
                Author = 1
            };
            var db = new DB();
            var actual = await db.InsertNews(news);
            
            Assert.True(actual);
        }

        [Fact]
        public async Task GetAllUsers_Test()
        {
            IEnumerable<User> expectedUsers = new List<User>
            {
                new()
                {
                    Id = 1,
                    Login = "admin",
                    Password = "12345",
                    Email = "admin@email.ru",
                    FirstName = "Admin",
                    LastName = "Admin",
                    MiddleName = "Admin"
                }
            };

            var db = new DB();
            var actualUsers = await db.GetAllUsers();
            
            Assert.Equal(expectedUsers, actualUsers);
        }
    }
}