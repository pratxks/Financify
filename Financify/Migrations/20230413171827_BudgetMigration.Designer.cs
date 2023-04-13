﻿// <auto-generated />
using Financify.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Financify.Migrations
{
    [DbContext(typeof(BudgetDbContext))]
    [Migration("20230413171827_BudgetMigration")]
    partial class BudgetMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.32")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Financify.Models.Budget", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.Property<decimal>("EntertainmentBudget")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("FoodBudget")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("HousingBudget")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Income")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("OtherBudget")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("UserId");

                    b.ToTable("Budgets");
                });
#pragma warning restore 612, 618
        }
    }
}