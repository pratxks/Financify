using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Financify.Migrations
{
    public partial class BudgetMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Budgets",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Income = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    FoodBudget = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    HousingBudget = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    EntertainmentBudget = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    OtherBudget = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Budgets", x => x.UserId);
                });

            migrationBuilder.InsertData(
                table: "Budgets",
                columns: new[] { "UserId", "EntertainmentBudget", "FoodBudget", "HousingBudget", "Income", "OtherBudget" },
                values: new object[] { "John", 1000.00m, 1500.00m, 2500.00m, 8000.00m, 1000.00m });

            migrationBuilder.InsertData(
                table: "Budgets",
                columns: new[] { "UserId", "EntertainmentBudget", "FoodBudget", "HousingBudget", "Income", "OtherBudget" },
                values: new object[] { "Pratik", 500.00m, 1000.00m, 1500.00m, 5000.00m, 1000.00m });

            migrationBuilder.InsertData(
                table: "Budgets",
                columns: new[] { "UserId", "EntertainmentBudget", "FoodBudget", "HousingBudget", "Income", "OtherBudget" },
                values: new object[] { "Tyson", 300.00m, 700.00m, 1000.00m, 3000.00m, 800.00m });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Budgets");
        }
    }
}
