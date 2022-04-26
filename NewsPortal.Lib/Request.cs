#nullable enable
using NewsPortal.Server.Lib.Models;

namespace NewsPortal.Lib
{
    public class Request
    {
        public string Type { get; set; }
        public int? Id { get; set; }
        public News? News { get; set; }
        public string? Login { get; set; }
        public string? Password { get; set; }
    }
}