using Microsoft.AspNetCore.Mvc;
using Financify.Data;
using System.Collections.Generic;
using Financify.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System;
using Microsoft.AspNetCore.Http;

namespace Financify.Controllers
{
    public class TransactionController : Controller
    {
        private readonly BudgetDbContext _budgetcontext;
        private readonly TransactionDbContext _transactioncontext;

        public TransactionController(BudgetDbContext context1, TransactionDbContext context2)
        {
            _budgetcontext = context1;
            _transactioncontext = context2;
        }

        public IActionResult Index()
        {
            return View("Index");
        }

        // GET: Transaction/InputTransaction
        public IActionResult InitAddTransaction()
        {
            var viewModel = new TransactionViewModel()
            {
                TransactionCategoryList = new List<string>(){ "Food", "Housing", "Entertainment", "Other"},
                BudgetList = _budgetcontext.Budgets.ToList()
            };

            ViewBag.InputTransaction = true;

            return View("InputTransaction", viewModel);
        }

        // POST: Transaction/AddTransaction
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> AddTransaction(IFormCollection formCollection)
        {
            String userId = formCollection["userId"];
            String category = formCollection["Category"];
            decimal amount = Decimal.Parse(formCollection["Amount"]);

            ViewBag.TransactionSuccess = false;

            Budget budget = await _budgetcontext.Budgets.FirstOrDefaultAsync(b => b.UserId == userId);

            decimal categoryBudget = 0;

            switch (category)
            {
                case "Food":
                    categoryBudget = budget.FoodBudget;
                    break;
                case "Housing":
                    categoryBudget = budget.HousingBudget;
                    break;
                case "Entertainment":
                    categoryBudget = budget.EntertainmentBudget;
                    break;
                case "Other":
                    categoryBudget = budget.OtherBudget;
                    break;
            }

            // get sum of transactions for the category
            decimal categoryTransactionSum = 0;

            switch (category)
            {
                case "Food":
                    categoryTransactionSum = _transactioncontext.Transactions.Where(t => t.UserId == userId && t.Category == category).Sum(t => t.Amount);
                    break;
                case "Housing":
                    categoryTransactionSum = _transactioncontext.Transactions.Where(t => t.UserId == userId && t.Category == category).Sum(t => t.Amount);
                    break;
                case "Entertainment":
                    categoryTransactionSum = _transactioncontext.Transactions.Where(t => t.UserId == userId && t.Category == category).Sum(t => t.Amount);
                    break;
                case "Other":
                    categoryTransactionSum = _transactioncontext.Transactions.Where(t => t.UserId == userId && t.Category == category).Sum(t => t.Amount);
                    break;
            }

            decimal availableBudget = categoryBudget - categoryTransactionSum;

            if (availableBudget >= amount)
            {
                // add transaction
                var transaction = new Transaction()
                {
                    TransactionId = Guid.NewGuid().ToString(),
                    UserId = userId
                };

                transaction.Category = category;
                transaction.Amount = amount;

                _transactioncontext.Transactions.Add(transaction);
                await _transactioncontext.SaveChangesAsync();

                ViewBag.TransactionSuccess = true;
            }
            else
            {
                ViewBag.ErrorMessage = category + " Transaction Amount: " + amount + " Exceeds Available " + category  + " Budget: " + availableBudget + "";
            }

            return View("InputTransaction");
        }

        public JsonResult GetRemainingBudget(string category, string userId)
        {
            decimal remainingBudget = 0;

            // Retrieve the budget for the user
            var budget = _budgetcontext.Budgets.FirstOrDefault(b => b.UserId == userId);

            if (budget != null)
            {
                switch (category)
                {
                    case "Food":
                        remainingBudget = budget.FoodBudget - _transactioncontext.Transactions.Where(t => t.UserId == userId && t.Category == category).Sum(t => t.Amount);
                        break;
                    case "Housing":
                        remainingBudget = budget.HousingBudget - _transactioncontext.Transactions.Where(t => t.UserId == userId && t.Category == category).Sum(t => t.Amount);
                        break;
                    case "Entertainment":
                        remainingBudget = budget.EntertainmentBudget - _transactioncontext.Transactions.Where(t => t.UserId == userId && t.Category == category).Sum(t => t.Amount);
                        break;
                    case "Other":
                        remainingBudget = budget.OtherBudget - _transactioncontext.Transactions.Where(t => t.UserId == userId && t.Category == category).Sum(t => t.Amount);
                        break;
                }
            }

            return Json(remainingBudget.ToString());
        }


        // GET: Transaction/InitViewTransaction
        public IActionResult InitViewTransaction()
        {
            var viewModel = new TransactionViewModel()
            {
                TransactionCategoryList = new List<string>() { "All", "Food", "Housing", "Entertainment", "Other" },
                BudgetList = _budgetcontext.Budgets.ToList()
            };

            ViewBag.ViewForm = true;

            return View("ViewTransaction", viewModel);
        }

        // POST: Transaction/ListTransaction
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        public IActionResult ListTransaction(TransactionViewModel viewModel, IFormCollection formCollection)
        {
            String userId = formCollection["UserId"];
            String category = formCollection["Category"];

            Budget budget = _budgetcontext.Budgets.FirstOrDefault(b => b.UserId == userId);

            viewModel = new TransactionViewModel();

            viewModel.USERID = budget.UserId;
            viewModel.Category = category;

            switch (category)
            {
                case "All":
                    viewModel.FoodTransList = _transactioncontext.Transactions.Where(t => t.UserId == userId && t.Category == "Food").ToList();
                    viewModel.HousingTransList = _transactioncontext.Transactions.Where(t => t.UserId == userId && t.Category == "Housing").ToList();
                    viewModel.EntertainmentTransList = _transactioncontext.Transactions.Where(t => t.UserId == userId && t.Category == "Entertainment").ToList();
                    viewModel.OtherTransList = _transactioncontext.Transactions.Where(t => t.UserId == userId && t.Category == "Other").ToList();
                    break;
                case "Food":
                case "Housing":
                case "Entertainment":
                case "Other":
                    viewModel.TransactionList = _transactioncontext.Transactions.Where(t => t.UserId == userId && t.Category == category).ToList();
                    break;
            }

            ViewBag.ViewTransaction = true;

            return View("ViewTransaction", viewModel);
        }

        // GET: Transaction/Delete
        public async Task<IActionResult> Delete(string id)
        {
            ViewBag.TransactionDeletedSuceess = false;

            var transaction = await _transactioncontext.Transactions.FirstOrDefaultAsync(t => t.TransactionId == id);

            if (transaction == null)
            {
                return NotFound();
            }

            _transactioncontext.Remove(transaction);
            await _transactioncontext.SaveChangesAsync();

            ViewBag.TransactionDeletedSuceess = true;

            return View("DeleteTransaction");
        }

    }
}
