using System;

namespace NewsPortal.Server.Lib.Models
{
    public class News
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime DateOfCreation { get; set; }
        public int AuthorId { get; set; }
    }
}