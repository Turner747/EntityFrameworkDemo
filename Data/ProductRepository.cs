using EntityFrameworkDemo.Interfaces;
using EntityFrameworkDemo.Models;

namespace EntityFrameworkDemo.Data
{
    public class ProductRepository : IProductRepository
    {
        private readonly PizzaContext _context;

        public ProductRepository(PizzaContext ctx)
        {
            _context = ctx;
        }

        public IQueryable<Product> Products => _context.Products;
        public void AddProduct(Product p)
        {
            _context.Add(p);
            _context.SaveChanges();
        }

        public void SaveProduct(Product product)
        {
            _context.SaveChanges();
        }
        
        public void DeleteProduct(Product p)
        {
            _context.Remove(p);
            _context.SaveChanges();
        }
    }
}
