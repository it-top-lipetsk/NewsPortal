#nullable enable
using NewsPortal.Server.Lib.Models;

namespace NewsPortal.Server
{
    public class Request
    {
        public string Type { get; set; }
        public int? Id { get; set; }
        public News? News { get; set; }
    }
}