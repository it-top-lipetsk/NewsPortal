using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace NewsPortal.Server.Lib.Models
{
    public record News
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime DateOfCreation { get; set; }
        public int Author { get; set; }
    }
}