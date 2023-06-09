﻿// <auto-generated />
using Financify.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Financify.Migrations
{
    [DbContext(typeof(BudgetDbContext))]
    partial class BudgetDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.16")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Financify.Models.Budget", b =>
                {
                    b.Property<string>("UserId")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

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

                    b.HasData(
                        new
                        {
                            UserId = "Pratik",
                            EntertainmentBudget = 500.00m,
                            FoodBudget = 1000.00m,
                            HousingBudget = 1500.00m,
                            Income = 5000.00m,
                            OtherBudget = 1000.00m
                        },
                        new
                        {
                            UserId = "Tyson",
                            EntertainmentBudget = 300.00m,
                            FoodBudget = 700.00m,
                            HousingBudget = 1000.00m,
                            Income = 3000.00m,
                            OtherBudget = 800.00m
                        },
                        new
                        {
                            UserId = "John",
                            EntertainmentBudget = 1000.00m,
                            FoodBudget = 1500.00m,
                            HousingBudget = 2500.00m,
                            Income = 8000.00m,
                            OtherBudget = 1000.00m
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
