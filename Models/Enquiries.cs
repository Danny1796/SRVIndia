using System.ComponentModel.DataAnnotations;

namespace SRVIndia.Models
{
    public class Enquiries
    {
        public int Id { get; set;}
        [Required]
        public string PersonName { get; set; }    

        public string UserEmail { get; set; }

        public string CompanyName { get; set; }

        public string WhatsAppNo { get; set; }

        public string UserMessage { get; set; }

        public string BusinessType { get; set; }

        public string UseCargo { get; set; }

    }
}
