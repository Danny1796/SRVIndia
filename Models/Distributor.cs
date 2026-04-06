using System.ComponentModel.DataAnnotations;

namespace SRVIndia.Models
{
    public class Distributor
    {
        public int Id { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Mobile { get; set; }

        public string State { get; set; }
        public string City { get; set; }
        public string Distributorship { get; set; }
        public string Message { get; set; }
    }
}
