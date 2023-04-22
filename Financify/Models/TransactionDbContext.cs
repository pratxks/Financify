using Microsoft.EntityFrameworkCore;
using Financify.Data;
using Financify.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace Financify.Data
{
    public class TransactionDbContext : DbContext
    {
        public TransactionDbContext(DbContextOptions<TransactionDbContext> options) : base(options)
        {
        }

        public DbSet<Transaction> Transactions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //modelBuilder.Entity<Transaction>().HasNoKey();

            // Configure TransactionViewModel entity
            modelBuilder.Entity<Transaction>()
                .Property(b => b.TransactionId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .IsRequired(true);

            modelBuilder.Entity<Transaction>()
                .Property(b => b.UserId)
                .HasMaxLength(50)
                .IsUnicode(false);

            modelBuilder.Entity<Transaction>()
                .Property(b => b.Category)
                .HasMaxLength(20)
                .IsUnicode(false);

            modelBuilder.Entity<Transaction>()
                .Property(b => b.Amount)
                .HasColumnType("decimal(18,2)");
        }
    }
}
