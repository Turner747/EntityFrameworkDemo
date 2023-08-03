using EntityFrameworkDemo.Models;

namespace EntityFrameworkDemo.Interfaces
{
    public interface IProductRepository
    {
        IQueryable<Product> Products { get; }

        void AddProduct(Product p);
        void SaveProduct(Product p);
        void DeleteProduct(Product p);
    }
}
