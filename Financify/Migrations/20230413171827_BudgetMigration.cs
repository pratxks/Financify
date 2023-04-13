using Microsoft.EntityFrameworkCore.Migrations;

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
                    UserId = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Budgets");
        }
    }
}
