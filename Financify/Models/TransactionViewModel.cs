using System.Collections.Generic;

namespace Financify.Models
{
    public class TransactionViewModel
    {
        public string USERID { get; set; }

        public string Category { get; set; }

        public List<string> TransactionCategoryList { get; set; }

        public List<Budget> BudgetList { get; set; }

        public List<Transaction> TransactionList { get; set; }

        public List<Transaction> FoodTransList { get; set; }

        public List<Transaction> HousingTransList { get; set; }

        public List<Transaction> EntertainmentTransList { get; set; }

        public List<Transaction> OtherTransList { get; set; }
    }
}
