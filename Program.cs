using EntityFrameworkDemo.Data;
using EntityFrameworkDemo.Models;

using (PizzaContext context = new())
{
    Product meatLovers = new()
    {
        Name = "Meat Lovers",
        Price = 12.95M
    };
    context.Products.Add(meatLovers);

    Product supreme = new()
    {
        Name = "Supreme",
        Price = 12.95M
    };
    context.Products.Add(supreme);

    context.SaveChanges();
}
