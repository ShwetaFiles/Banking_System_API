using BankingSystemAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace BankingSystemAPI.Data
{
    public class BankingContext : DbContext
    {
        public BankingContext(DbContextOptions<BankingContext> options) : base(options) { }

        public DbSet<Account> Accounts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>()
                .HasKey(a => a.AccountNumber); // Set AccountNumber as the primary key
        }
    }
}
