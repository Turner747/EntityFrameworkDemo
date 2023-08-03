using EntityFrameworkDemo.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityFrameworkDemo.Models;
using EntityFrameworkDemo.Data;

namespace EntityFrameworkDemo.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly PizzaContext _context;

        public CustomerRepository(PizzaContext ctx)
        {
            _context = ctx;
        }

        public IQueryable<Customer> Customers => _context.Customers;
        public void AddCustomer(Customer c)
        {
            _context.Add(c);
            _context.SaveChanges();
        }

        public void SaveCustomer(Customer c)
        {
            _context.SaveChanges();
        }

        public void DeleteCustomer(Customer c)
        {
            _context.Remove(c);
            _context.SaveChanges();
        }
    }
}
