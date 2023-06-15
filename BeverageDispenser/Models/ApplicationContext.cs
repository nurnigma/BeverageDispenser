using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;
namespace BeverageDispenser.Models
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Beverage> Beverages { get; set; } = null!;
        public DbSet<Cost> Costs { get; set; } = null!;
        public DbSet<Coin> Coins { get; set; } = null!;

        public ApplicationContext(DbContextOptions<ApplicationContext> options)
           : base(options)
        {
            Database.EnsureCreated();
        }

        // Засеивание некоторыми значениями
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Beverage>().HasData(new Beverage { Id = 1, Name = "Пепси", CostId = 1});
            modelBuilder.Entity<Cost>().HasData(new Cost { Id = 1, Price = 100.00m, Count = 2 });

            modelBuilder.Entity<Coin>().HasData(new Coin { Id = 1, Denomination = Denomination.one, IsDispenser = true },
                                                new Coin { Id = 2, Denomination = Denomination.two, IsDispenser = true },
                                                new Coin { Id = 3,Denomination = Denomination.five, IsDispenser = true },
                                                new Coin { Id = 4, Denomination = Denomination.ten, IsDispenser = true });

        }
    }
}
