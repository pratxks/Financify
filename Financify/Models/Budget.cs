using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace NewFinancify.Models
{
    public class Budget
    {
        [Key]
        [Required]
        public string UserId { get; set; }

        [Required]
        public decimal Income { get; set; }

        [Required]
        public decimal FoodBudget { get; set; }

        [Required]
        public decimal HousingBudget { get; set; }

        [Required]
        public decimal EntertainmentBudget { get; set; }

        [Required]
        public decimal OtherBudget { get; set; }

        public decimal TotalBudget => FoodBudget + HousingBudget + EntertainmentBudget + OtherBudget;
    }
}
