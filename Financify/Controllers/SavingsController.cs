using Financify.Data;
using Financify.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Financify.Controllers
{
    public class SavingsController : Controller
    {
        private readonly BudgetDbContext _budgetcontext;
        private readonly TransactionDbContext _transactioncontext;

        public SavingsController(BudgetDbContext context1, TransactionDbContext context2)
        {
            _budgetcontext = context1;
            _transactioncontext = context2;
        }

        public IActionResult Index()
        {
            return View("Index");
        }

        // GET: Savings/InitViewSavings
        public IActionResult InitViewSavings()
        {
            var viewModel = new SavingsViewModel()
            {
                BudgetList = _budgetcontext.Budgets.ToList()
            };

            ViewBag.ViewForm = true;

            return View("ViewSavings", viewModel);
        }

        // POST: Savings/ListSavings
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        public IActionResult ListSavings(SavingsViewModel viewModel, IFormCollection formCollection)
        {
            String userId = formCollection["UserId"];

            Budget budget = _budgetcontext.Budgets.FirstOrDefault(b => b.UserId == userId);

            viewModel = new SavingsViewModel();

            viewModel.USERID = budget.UserId;

            var TransactionCategoryList = new List<string>() { "Food", "Housing", "Entertainment", "Other" };
            var TransactionTotals = new List<decimal>() { 0, 0, 0, 0, 0 };

            for(int i = 0; i < TransactionCategoryList.Count; i++) { 
                _transactioncontext.Transactions.Where(t => t.UserId == userId && t.Category == TransactionCategoryList[i]).ToList().ForEach((trans) => { 
                    TransactionTotals[i] += trans.Amount; 
                    TransactionTotals[4] += trans.Amount; 
                });
            }

            viewModel.FoodSavings          = budget.FoodBudget          - TransactionTotals[0];
            viewModel.HousingSavings       = budget.HousingBudget       - TransactionTotals[1];
            viewModel.EntertainmentSavings = budget.EntertainmentBudget - TransactionTotals[2];
            viewModel.OtherSavings         = budget.OtherBudget         - TransactionTotals[3];
            viewModel.TotalSavings         = budget.TotalBudget         - TransactionTotals[4];
            viewModel.NonBudgetSavings     = budget.Income              - budget.TotalBudget;

            ViewBag.ViewSavings = true;

            return View("ViewSavings", viewModel);
        }
    }
}
