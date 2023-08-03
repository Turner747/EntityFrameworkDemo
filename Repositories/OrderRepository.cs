using EntityFrameworkDemo.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityFrameworkDemo.Data;
using EntityFrameworkDemo.Models;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkDemo.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly PizzaContext _context;

        public OrderRepository(PizzaContext ctx)
        {
            _context = ctx;
        }

        public IQueryable<Order> Orders => _context.Orders
            .Include(o => o.Customer)
            .Include(o => o.OrderDetails)
            .ThenInclude(d => d.Product);
        
        public void AddOrder(Order o)
        {
            _context.AttachRange(o.OrderDetails.Select(d => d.Product));
            
            if (o.Id == 0)
                _context.Add(o);
            
            _context.SaveChanges();
        }
    }
}
