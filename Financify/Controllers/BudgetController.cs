using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NewFinancify.Models;
using NewFinancify.Data;
using System.Reflection;
using Microsoft.EntityFrameworkCore;

namespace NewFinancify.Controllers
{
    public class BudgetController : Controller
    {
        private readonly BudgetDbContext _context;
        private readonly TransactionDbContext _transactioncontext;

        public BudgetController(BudgetDbContext context1, TransactionDbContext context2)
        {
            _context = context1;
            _transactioncontext = context2;
        }

        // GET: Budgets
        public async Task<IActionResult> Index()
        {
            var budgets = await _context.Budgets.ToListAsync();

            return View();
        }


        // GET: Budget/Create
        public IActionResult Create()
        {
            ViewBag.NewBudget = true;

            return View("Budget");
        }


        // POST: Budget/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateBudget(Budget model)
        {
            if (ModelState.IsValid)
            {
                var budget = new Budget
                {
                    UserId = model.UserId,
                    Income = model.Income,
                    FoodBudget = model.FoodBudget,
                    HousingBudget = model.HousingBudget,
                    EntertainmentBudget = model.EntertainmentBudget,
                    OtherBudget = model.OtherBudget
                };

                _context.Add(budget);
                await _context.SaveChangesAsync();
            }

            return View("Budget", model);
        }

        public IActionResult ListBudgets()
        {
            List<Budget> budgets = _context.Budgets.OrderBy(b => b.UserId).ToList(); ;

            var model = new BudgetViewModel
            {
                BudgetList = budgets
            };

            // bind products to view
            return View("ViewBudget", model);
        }

        // GET: Budget/Create
        public IActionResult Edit(string id)
        {
            ViewBag.EditBudget = true;

            var budget = _context.Budgets.Find(id);
            if (budget == null)
            {
                return NotFound();
            }

            return View("EditBudget", budget);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateBudget(Budget model)
        {
            if (model.UserId == null)
            {
                return NotFound();
            }

            var budget = await _context.Budgets.FindAsync(model.UserId);
            if (budget == null)
            {
                return NotFound();
            }
            else 
            {
                budget.UserId = model.UserId;
                budget.Income = model.Income;
                budget.FoodBudget = model.FoodBudget;
                budget.HousingBudget = model.HousingBudget;
                budget.EntertainmentBudget = model.EntertainmentBudget;
                budget.OtherBudget = model.OtherBudget;
            }

            _context.Update(budget);
            await _context.SaveChangesAsync();

            return View("EditBudget", model);
        }

        // GET: Budget/Delete
        public async Task<IActionResult> Delete(string id)
        {
            ViewBag.BudgetDeletedSuceess = false;

            var budget = await _context.Budgets.FindAsync(id);
            if (budget == null)
            {
                return NotFound();
            }

            List<Transaction> transList = _transactioncontext.Transactions.Where(t => t.UserId == id).ToList();

            foreach (Transaction transaction in transList)
            {
                _transactioncontext.Transactions.Remove(transaction);
            }

            await _transactioncontext.SaveChangesAsync();

            _context.Remove(budget);
            await _context.SaveChangesAsync();

            ViewBag.BudgetDeletedSuceess = true;

            return View("DeleteBudget", budget);
        }

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteBudget(Budget model)
        //{
        //    if (model.UserId == null)
        //    {
        //        return NotFound();
        //    }

        //    var budget = await _context.Budgets.FindAsync(model.UserId);
        //    if (budget == null)
        //    {
        //        return NotFound();
        //    }
        //    else
        //    {
        //        budget.UserId = model.UserId;
        //        budget.Income = model.Income;
        //        budget.FoodBudget = model.FoodBudget;
        //        budget.HousingBudget = model.HousingBudget;
        //        budget.EntertainmentBudget = model.EntertainmentBudget;
        //        budget.OtherBudget = model.OtherBudget;
        //    }

        //    _context.Remove(budget);
        //    await _context.SaveChangesAsync();

        //    return View("DeleteBudget", model);
        //}

    }

}
