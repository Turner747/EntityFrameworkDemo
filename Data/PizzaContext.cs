using EntityFrameworkDemo.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace EntityFrameworkDemo.Data
{
    public class PizzaContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"Data Source=pizza_app.db")
                .LogTo(Console.WriteLine, LogLevel.Information);
        }

    }
}
