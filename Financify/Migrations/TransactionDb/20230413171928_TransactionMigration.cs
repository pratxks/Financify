using Microsoft.EntityFrameworkCore.Migrations;

namespace Financify.Migrations.TransactionDb
{
    public partial class TransactionMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Transactions",
                columns: table => new
                {
                    TransactionId = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    UserId = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    Category = table.Column<string>(unicode: false, maxLength: 20, nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transactions", x => x.TransactionId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Transactions");
        }
    }
}
