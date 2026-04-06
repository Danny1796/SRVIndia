using System.ComponentModel.DataAnnotations;

namespace SRVIndia.Models
{
    public class Enquiries
    {
        public int Id { get; set; }

        public string? PersonName { get; set; }

        public string? UserEmail { get; set; }

        public string? MobileNo { get; set; }

        public string? States { get; set; }
        public string? City { get; set; }

        public string? ProductName { get; set; }

        public string? BusinessType { get; set; }

        public string? UserMessage { get; set; }
        public bool IsReply { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
