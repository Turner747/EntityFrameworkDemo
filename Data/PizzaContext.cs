using EntityFrameworkDemo.Models;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkDemo.Data
{
    public class PizzaContext : DbContext
    {
        internal DbSet<Product> Products { get; set; }
        internal DbSet<Customer> Customers { get; set; }
        internal DbSet<Order> Orders { get; set; }
        internal DbSet<OrderDetail> OrderDetails { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(
                @"Data Source=D:\development\EntityFrameworkDemo\EntityFrameworkDemo\pizza_app.db");
        }
        
    }
}
