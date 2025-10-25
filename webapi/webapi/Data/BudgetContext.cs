using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using webapi.Enums;
using webapi.Model;

namespace webapi.Data
{
    public class BudgetContext : IdentityDbContext<IdentityUser>
    {
        public BudgetContext(DbContextOptions<BudgetContext> options) : base(options)
        {
        }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Budget> Budgets { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure entity relationships and properties here if needed
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Transaction>().ToTable("Transaction");
            modelBuilder.Entity<Category>().ToTable("Category");
            modelBuilder.Entity<Budget>().ToTable("Budget");

            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Groceries", UserId = null },
                new Category { Id = 2, Name = "Fixed cost", UserId = null },
                new Category { Id = 3, Name = "Utilities", UserId = null }
            );
        }
    }
}
