using EntityFrameworkDemo.Models;

namespace EntityFrameworkDemo.Interfaces
{
    public interface ICustomerRepository
    {
        IQueryable<Customer> Customers { get; }

        void AddCustomer(Customer c);
        void SaveCustomer(Customer c);
        void DeleteCustomer(Customer c);
    }
}