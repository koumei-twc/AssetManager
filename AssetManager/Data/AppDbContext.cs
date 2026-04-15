using Microsoft.EntityFrameworkCore;
using AssetManager.Models;

namespace AssetManager.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<BankAccount> BankAccounts { get; set; }
    }
}