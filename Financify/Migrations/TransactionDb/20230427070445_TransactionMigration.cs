using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

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
                    TransactionId = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    UserId = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Category = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transactions", x => x.TransactionId);
                });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "Category", "UserId" },
                values: new object[,]
                {
                    { "262235be-8fde-4c95-a74e-e236374647ce", 26.00m, "Entertainment", "Pratik" },
                    { "66e1f61e-66ce-4d5f-be03-e759eee7a244", 10.99m, "Housing", "Tyson" },
                    { "71d863b5-571f-499d-ae87-e0578a3fafae", 10.99m, "Food", "Pratik" },
                    { "74362cbb-476d-40ea-9146-364f2be3f2fa", 39.00m, "Other", "Tyson" },
                    { "87d3ca8d-689a-43b5-ad5a-2f608058dd74", 50.00m, "Food", "Tyson" },
                    { "8869b9c7-60ce-4bda-9c45-50e57a424639", 39.00m, "Food", "Pratik" },
                    { "993e3163-acdf-4825-818f-2ef703934883", 50.00m, "Entertainment", "Pratik" },
                    { "d5ff04a7-b217-4eb2-b349-495ae7c1b343", 26.00m, "Entertainment", "Tyson" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Transactions");
        }
    }
}
