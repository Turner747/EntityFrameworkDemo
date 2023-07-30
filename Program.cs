using EntityFrameworkDemo.Data;
using EntityFrameworkDemo.Models;
using Microsoft.EntityFrameworkCore;

using PizzaContext context = new();

var products = from product in context.Products
               where product.Price > 12.00M
               orderby product.Name
               select product;

foreach (var p in products)
{
    Console.WriteLine($"Id:  {p.Id}");
    Console.WriteLine($"Name:  {p.Name}");
    Console.WriteLine($"Price:  {p.Price}");
    Console.WriteLine(new string('-',20));
}














static void AddData(PizzaContext context)
{
    Product meatLovers = new()
    {
        Name = "Meat Lovers",
        Price = 11.95M
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

static void QueryDataLambda(PizzaContext context)
{
    var products = context.Products
        .Where(p => p.Price > 12.00M)
        .OrderBy(p => p.Name);

    foreach (var p in products)
    {
        Console.WriteLine($"Id:  {p.Id}");
        Console.WriteLine($"Name:  {p.Name}");
        Console.WriteLine($"Price:  {p.Price}");
        Console.WriteLine(new string('-', 20));
    }
}