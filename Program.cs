using EntityFrameworkDemo.Data;
using EntityFrameworkDemo.Models;
using EntityFrameworkDemo.Repositories;
using Microsoft.EntityFrameworkCore;

using PizzaContext context = new();

//RemoveData(context);

AddData(context);


static void AddData(PizzaContext context)
{
    var productRepo = new ProductRepository(context);
    
    Product meatLovers = new()
    {
        Name = "Pepperoni",
        Price = 7.95M
    };
    productRepo.AddProduct(meatLovers);

    Product supreme = new()
    {
        Name = "Ham and Pineapple",
        Price = 6.95M
    };
    productRepo.AddProduct(supreme);

    context.SaveChanges();
}

static void QueryDataLambda(PizzaContext context)
{
    var products = context.Products
        .Where(p => p.Price > 8.00M)
        .OrderBy(p => p.Name);

    foreach (var p in products)
    {
        Console.WriteLine($"Id:  {p.Id}");
        Console.WriteLine($"Name:  {p.Name}");
        Console.WriteLine($"Price:  {p.Price}");
        Console.WriteLine(new string('-', 20));
    }
}

static void QueryDataLINQ(PizzaContext context)
{
    var products = from product in context.Products
        where product.Price > 12.00M
        orderby product.Name
        select product;

    foreach (var p in products)
    {
        Console.WriteLine($"Id:  {p.Id}");
        Console.WriteLine($"Name:  {p.Name}");
        Console.WriteLine($"Price:  {p.Price}");
        Console.WriteLine(new string('-', 20));
    }
}

void UpdateData(PizzaContext context)
{
    var meatLovers = context.Products
        .Where(p => p.Name == "Meat Lovers")
        .FirstOrDefault();

    if (meatLovers is Product)
    {
        meatLovers.Price = 9.99M;
    }

    context.SaveChanges();
}

void RemoveData(PizzaContext context)
{
    var meatLovers = context.Products
        .Where(p => p.Name == "Meat Lovers")
        .FirstOrDefault();

    if (meatLovers is Product)
    {
        context.Remove(meatLovers);
    }

    context.SaveChanges();
}