using EntityFrameworkDemo.Data;
using EntityFrameworkDemo.Models;

using PizzaContext context = new();

deliveryOrder(context);

static void deliveryOrder(PizzaContext context)
{
    var or = new OrderRepository(context);
    var order = or.Orders.Where(o => o.Id == 1)?.First();

    order.OrderFulfilled = DateTime.Now;

    or.SaveOrder(order);
}

static void AddOrder(PizzaContext context)
{
    var orderRepo = new OrderRepository(context);
    var productRepo = new ProductRepository(context);
    var customerRepo = new CustomerRepository(context);

    var john = new Customer
    {
        FirstName = "John",
        LastName = "Doe",
        Address = "123 Main",
        Phone = "555-555-5555",
        Email = "john@email.com"
    };
    customerRepo.AddCustomer(john);

    var pepperoni = productRepo.Products
                                .Where(p => p.Name == "Pepperoni")?
                                .FirstOrDefault();

    var order = new Order
    {
        Customer = john,
        OrderDetails = new List<OrderDetail>()
        {
            new OrderDetail
            {
                Product = pepperoni,
                Quantity = 2
            }
        },
        OrderPlaced = DateTime.Now
    };
    orderRepo.SaveOrder(order);
}

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