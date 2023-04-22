using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace Financify.Models
{
    public class BudgetViewModel
    {
        public List<Budget> BudgetList { get; set; }

    }

}

