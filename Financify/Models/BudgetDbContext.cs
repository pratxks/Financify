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
        }
    }
}

