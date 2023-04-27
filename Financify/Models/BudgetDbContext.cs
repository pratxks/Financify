using System;
using Microsoft.EntityFrameworkCore;
using Financify.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace Financify.Data
{
    [Table("Budgets")]
    public class BudgetDbContext : DbContext
    {
        public BudgetDbContext(DbContextOptions<BudgetDbContext> options) : base(options)
        {
        }

        public DbSet<Budget> Budgets { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //modelBuilder.Entity<Budget>().HasNoKey();

            // Configure BudgetViewModel entity
            modelBuilder.Entity<Budget>()
                .Property(b => b.UserId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .IsRequired(true);

            modelBuilder.Entity<Budget>()
                .Property(b => b.Income)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<Budget>()
                .Property(b => b.FoodBudget)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<Budget>()
                .Property(b => b.HousingBudget)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<Budget>()
                .Property(b => b.EntertainmentBudget)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<Budget>()
                .Property(b => b.OtherBudget)
                .HasColumnType("decimal(18,2)");


            // Seed some example data
            modelBuilder.Entity<Budget>().HasData(
            new Budget 
            { 
                UserId = "Pratik", 
                Income = 5000.00m, 
                FoodBudget = 1000.00m, 
                HousingBudget = 1500.00m, 
                EntertainmentBudget = 500.00m, 
                OtherBudget = 1000.00m 
            },
            new Budget
            {
                UserId = "Tyson",
                Income = 3000.00m,
                FoodBudget = 700.00m,
                HousingBudget = 1000.00m,
                EntertainmentBudget = 300.00m,
                OtherBudget = 800.00m
            },
            new Budget
            {
                UserId = "John",
                Income = 8000.00m,
                FoodBudget = 1500.00m,
                HousingBudget = 2500.00m,
                EntertainmentBudget = 1000.00m,
                OtherBudget = 1000.00m
            }
            );
        }
    }
}

