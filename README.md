# Financify
A Web App to Manage Budgets and Track Expenses.
Youtube Final Project Video Link: https://youtu.be/8jDapzu4u3Y


## Layout

**1. Homepage:** Welcome to your personal finance dashboard! This page is where you can access all the tools you need to manage your finances effectively. You can create budgets, view budgets, input transactions, view transaction history, track your savings, and learn how to use the app.

**2. Create Budgets/View Budgets:** This page allows you to create/edit/delete budgets for different categories such as food, housing, entertainment, and more. You can also view existing budgets for different usernames. This will help you set budgets for different categories so you can spend accordingly.

**3. Add Transactions/View Transactions:** On this page, you can add transactions by choosing a username to associate with the transaction, and selecting a category such as food or housing. You can also view transaction history for a specific user, and delete a transaction. This page will help you keep track of your spending and stay within your budget.

**4. Savings Tracker:** The savings tracker displays a table view of all categories and the current balance (budget - expenses). It also includes a graph that shows your progress towards your savings goal (income - budget). This page will help you stay on track with your savings goals and make informed decisions about your spending.

**5. About Us:** This page includes information about the team members behind the app.

**6. How to Use the App and Its Purpose:** This page provides an explanation of how to use the app and its purpose. It will guide you through the features of the app and help you understand how to use them to manage your finances effectively.


## Architecture

This project uses ASP.NET Core 6.0 and Model View Controller (MVC) architecture. The project dependencies include EntityFrameworkCore, EntityFrameworkCore.tools, and EntityFrameworkCore.SQLServer (version=6.0.16). 

In order to set up the database, you need to run the following commands in the Package Manager Console: 
- `Update-Database -Context BudgetDbContext`
- `Update-Database -Context TransactionDbContext`

## Team

### [Pratik Chaudhari](https://github.com/pratxks)

### [Tyson Levy](https://github.com/TysonLevy)

### [Brian Kenkel](https://github.com/kenkelbt)

