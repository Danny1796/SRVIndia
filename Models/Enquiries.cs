using System.ComponentModel.DataAnnotations;

namespace SRVIndia.Models
{
    public class Enquiries
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        public string? PersonName { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress]
        public string? UserEmail { get; set; }

        [Required(ErrorMessage = "Mobile number is required")]
        [RegularExpression(@"^[0-9]{10}$", ErrorMessage = "Enter valid 10 digit number")]
        public string? MobileNo { get; set; }

        [Required(ErrorMessage = "State is required")]
        public string? States { get; set; }

        [Required(ErrorMessage = "City is required")]
        public string? City { get; set; }

        [Required(ErrorMessage = "Product is required")]
        public string? ProductName { get; set; }

        [Required(ErrorMessage = "Business type is required")]
        public string? BusinessType { get; set; }

        [Required(ErrorMessage = "Message is required")]
        public string? UserMessage { get; set; }
        public bool IsReply { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
