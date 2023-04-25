using System.Collections.Generic;

namespace Financify.Models
{
    public class SavingsViewModel
    {
        public string USERID { get; set; }

        public List<Budget> BudgetList { get; set; }

        public decimal FoodSavings { get; set; }

        public decimal HousingSavings { get; set; }

        public decimal EntertainmentSavings { get; set; }

        public decimal OtherSavings { get; set; }

        public decimal TotalSavings { get; set; }
    }
}
