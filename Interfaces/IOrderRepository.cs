using EntityFrameworkDemo.Models;

namespace EntityFrameworkDemo.Interfaces
{
    public interface IOrderRepository
    {
        IQueryable<Order> Orders { get; }

        void AddOrder(Order o);
    }
}