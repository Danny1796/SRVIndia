using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace SRVIndia.Models
{
    public class ContactUs
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]

        public string Company { get; set; }
        [Required]

        public String Whatsapp { get; set; } = string.Empty;
        [Required]

        public string Email { get; set; }
        [Required]

        public string Cargo { get; set; }
        [Required]

        public string BusinessType { get; set; }
        [Required]

        public string Message { get; set; }
        

    }
}