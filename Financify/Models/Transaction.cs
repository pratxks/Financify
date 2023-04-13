using System.ComponentModel.DataAnnotations;

namespace NewFinancify.Models
{
    public class Transaction
    {
        [Key]
        [Required]
        public string TransactionId { get; set; }

        [Required]
        public string UserId { get; set; }

        [Required]
        public string Category { get; set; }

        [Required]
        public decimal Amount { get; set; }
    }
}
