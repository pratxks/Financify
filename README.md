# Financify

NET 3.1
Installed Entityframeworkcore + tools + sql server (version=3.1.32)


Finance App.

Page 1- Homepage (that contains 4 personal finance options- Page 2, Page 3, Page 4, Page 5.)

Options: 

Page 2- Track Budget- Allows user to create a budget for monthly expenses of different categories (housing, food, entertainment etc.). The total budget cannot exceed users income. The total budget also includes monthly recurring/subscription bills that the user adds in Page 4. This data along with user’s income is stored in the DATABASE.

Page 2, also has a button to navigate to page 4to set monthly recurring bills (read more in page 4 info)

Page 3- Spending Tracker- if budget is not set, this page prompts user to set budget first. User can Input daily transactions along with its category. The total transactions should not exceed the Budget of each category.

~if expenses in each category (food, housing etc.) doesn’t exceed the budget, the total expenses (of all categories) will not exceed the total budget (of all categories)

Page 4- Bill Management & Reminders- Allows user to input monthly recurring bills/subscriptions along with its due date. These bills should automatically be added to “Total Budget” on Page 2. User gets a pop up (on homepage) of “bill due” if current date matches due date. Information such as Subscription name, due date, amount $, Subscription category are stored in a different DATABASE. 

Page 5- Page to Track Budget, spending, bills along with progress towards the goal (set budget). Also displays savings.


Page 6- Options:
1. Login feature (not mandatory as per project requirements)
2. Help Page- Talks about how to use the app.
3. About Page- About the developers and App.
