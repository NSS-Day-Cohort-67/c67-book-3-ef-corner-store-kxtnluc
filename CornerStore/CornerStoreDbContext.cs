using Microsoft.EntityFrameworkCore;
using CornerStore.Models;
public class CornerStoreDbContext : DbContext
{
    public DbSet<Cashier> Cashiers { get; set; }
    public DbSet<Category> Categorys { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderProduct> OrderProducts { get; set; }
    public DbSet<Product> Products { get; set; }


    public CornerStoreDbContext(DbContextOptions<CornerStoreDbContext> context) : base(context)
    {

    }

    //allows us to configure the schema when migrating as well as seed data
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //Cashier
        modelBuilder.Entity<Cashier>().HasData(new Cashier[]
        {
            new Cashier {Id = 1, FirstName = "Lucas", LastName = "Joneao"},
            new Cashier { Id = 2, FirstName = "Ella", LastName = "Smith" },
            new Cashier { Id = 3, FirstName = "Mason", LastName = "Williams" },
            new Cashier { Id = 4, FirstName = "Olivia", LastName = "Brown" },
            new Cashier { Id = 5, FirstName = "Liam", LastName = "Davis" },
            new Cashier { Id = 6, FirstName = "Sophia", LastName = "Miller" },
            new Cashier { Id = 7, FirstName = "Noah", LastName = "Moore" },
            new Cashier { Id = 8, FirstName = "Ava", LastName = "Taylor" }

        });
        //Category
        modelBuilder.Entity<Category>().HasData(new Category[]
        {
            new Category{ Id = 1, CategoryName = "Books"},
            new Category{ Id = 2, CategoryName = "Food"},
            new Category{ Id = 3, CategoryName = "Legos"},
            new Category{ Id = 4, CategoryName = "Boardgames"},
        });
        //Order
        modelBuilder.Entity<Order>().HasData(new Order[]
        {
            new Order{ Id = 1, CashierId = 1, PaidOnDate = new DateTime(2024, 1, 6)},
            new Order { Id = 2, CashierId = 2, PaidOnDate = new DateTime(2023, 12, 24) },
            new Order { Id = 3, CashierId = 3, PaidOnDate = new DateTime(2023, 12, 25) },
            new Order { Id = 4, CashierId = 4, PaidOnDate = new DateTime(2023, 12, 26) },
            new Order { Id = 5, CashierId = 5, PaidOnDate = new DateTime(2023, 12, 27) },
            new Order { Id = 6, CashierId = 1, PaidOnDate = new DateTime(2023, 12, 28) }
        });
        //Product
        modelBuilder.Entity<Product>().HasData(new Product[]
        {
            new Product { Id = 1, Brand = "DaysOfWonder", CategoryId = 4, Price = 40.00M, ProductName = "Heat!" },
            new Product { Id = 2, Brand = "Penguin Books", CategoryId = 1, Price = 20.00M, ProductName = "To Kill a Mockingbird" },
            new Product { Id = 3, Brand = "HarperCollins", CategoryId = 1, Price = 25.00M, ProductName = "1984" },
            new Product { Id = 4, Brand = "Kraft", CategoryId = 2, Price = 5.00M, ProductName = "Macaroni and Cheese" },
            new Product { Id = 5, Brand = "Campbell's", CategoryId = 2, Price = 2.50M, ProductName = "Chicken Noodle Soup" },
            new Product { Id = 6, Brand = "LEGO", CategoryId = 3, Price = 50.00M, ProductName = "Classic Bricks Set" },
            new Product { Id = 7, Brand = "Hasbro", CategoryId = 4, Price = 30.00M, ProductName = "Monopoly Board Game" },
            new Product { Id = 8, Brand = "Kellogg's", CategoryId = 2, Price = 3.00M, ProductName = "Corn Flakes" },
            new Product { Id = 9, Brand = "Ferrero", CategoryId = 2, Price = 8.00M, ProductName = "Ferrero Rocher Chocolates" },
            new Product { Id = 10, Brand = "Oxford University Press", CategoryId = 1, Price = 35.00M, ProductName = "Pride and Prejudice" },
            new Product { Id = 11, Brand = "LEGO", CategoryId = 3, Price = 40.00M, ProductName = "Star Wars Millennium Falcon" },
            new Product { Id = 12, Brand = "Hasbro", CategoryId = 4, Price = 25.00M, ProductName = "Scrabble Board Game" },
            new Product { Id = 13, Brand = "Hershey's", CategoryId = 2, Price = 2.00M, ProductName = "Chocolate Bar" },
            new Product { Id = 14, Brand = "LEGO", CategoryId = 3, Price = 30.00M, ProductName = "LEGO Technic Car" },
            new Product { Id = 15, Brand = "Campbell's", CategoryId = 2, Price = 3.50M, ProductName = "Tomato Soup" },
            new Product { Id = 16, Brand = "Penguin Books", CategoryId = 1, Price = 18.00M, ProductName = "The Great Gatsby" },
            new Product { Id = 17, Brand = "Hasbro", CategoryId = 4, Price = 15.00M, ProductName = "Clue Board Game" },
            new Product { Id = 18, Brand = "Nabisco", CategoryId = 2, Price = 4.00M, ProductName = "Oreo Cookies" },
            new Product { Id = 19, Brand = "LEGO", CategoryId = 3, Price = 45.00M, ProductName = "LEGO Architecture Skyline Set" },
            new Product { Id = 20, Brand = "Simon & Schuster", CategoryId = 1, Price = 22.00M, ProductName = "To Kill a Mockingbird (Hardcover)" }
        });
        //OrderProduct
        modelBuilder.Entity<OrderProduct>().HasData(new OrderProduct[]
        {
            new OrderProduct { Id = 1, OrderId = 1, ProductId = 1, Quantity = 1 },
            new OrderProduct { Id = 2, OrderId = 1, ProductId = 3, Quantity = 2 },
            new OrderProduct { Id = 3, OrderId = 2, ProductId = 6, Quantity = 1 },
            new OrderProduct { Id = 4, OrderId = 2, ProductId = 9, Quantity = 3 },
            new OrderProduct { Id = 5, OrderId = 3, ProductId = 12, Quantity = 1 },
            new OrderProduct { Id = 6, OrderId = 6, ProductId = 15, Quantity = 2 },
            new OrderProduct { Id = 7, OrderId = 4, ProductId = 18, Quantity = 5 },
            new OrderProduct { Id = 8, OrderId = 4, ProductId = 20, Quantity = 1 },
            new OrderProduct { Id = 9, OrderId = 4, ProductId = 5, Quantity = 2 },
            new OrderProduct { Id = 10, OrderId = 5, ProductId = 11, Quantity = 1}
        });
    }
}