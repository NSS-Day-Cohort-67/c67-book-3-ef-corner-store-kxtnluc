using CornerStore.Models;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Http.Json;
using CornerStore.Models.DTOs;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
// allows passing datetimes without time zone data 
AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

// allows our api endpoints to access the database through Entity Framework Core and provides dummy value for testing
builder.Services.AddNpgsql<CornerStoreDbContext>(builder.Configuration["CornerStoreDbConnectionString"] ?? "testing");

// Set the JSON serializer options
builder.Services.Configure<JsonOptions>(options =>
{
    options.SerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

//=================================================================================================================================================================================================
//=====================================================================================Endpoints===================================================================================================
//=================================================================================================================================================================================================

                                                                                                    //cashiers  ===[DONE]===
                                                                                                        //GETs  [DONE]
                                                                                                            //a single cashier [DONE]
app.MapGet("/cashiers/{id}", (int id, CornerStoreDbContext db) =>
{
    Cashier foundCashier = db.Cashiers
        .Include(c => c.Orders)
        .ThenInclude(c => c.OrderProducts)
        .ThenInclude(c => c.Product)
        .FirstOrDefault(c => c.Id == id);

    if (foundCashier == null)
    {
        return Results.NotFound();
    }

    var result = new CashierDTO
    {
        Id = foundCashier.Id,
        FirstName = foundCashier.FirstName,
        LastName = foundCashier.LastName,
        Orders = foundCashier.Orders
            .Select(o => new OrderDTO
            {
                Id = o.Id,
                CashierId = o.CashierId,
                Cashier = null,
                OrderProducts = o.OrderProducts
                    .Select(op => new OrderProductDTO
                    {
                        Id = op.Id,
                        OrderId = op.OrderId,
                        ProductId = op.ProductId,
                        Product = new ProductDTO
                        {
                            Id = op.Product.Id,
                            Price = op.Product.Price,
                            ProductName = op.Product.ProductName,
                            Brand = op.Product.Brand,
                            CategoryId = op.Product.CategoryId,
                            Category = null
                        },
                        Quantity = op.Quantity,
                        Order = null,
                    }).ToList(),
                PaidOnDate = o.PaidOnDate
            }).ToList(),
    };

    return Results.Ok(result);
});
                                                                                                        //POSTs [DONE]
                                                                                                            //a single cashier [DONE]
app.MapPost("/cashiers", (CornerStoreDbContext db, Cashier cashierToPost) =>
{
    try
    {
        db.Cashiers.Add(cashierToPost);
        db.SaveChanges();
        return Results.Created($"/cashiers/{cashierToPost.Id}", cashierToPost);
    }
    catch (DbUpdateException)
    {
        return Results.BadRequest("Invalid Data Submitted");
    }
});
                                                                                                    //products  ===[DONE]===
                                                                                                        //GETs  [DONE]
                                                                                                            //all products with search [DONE]
app.MapGet("/products", (CornerStoreDbContext db, string search) =>
{
    var query = db.Products
        .Include(p => p.Category)
        .AsQueryable();

    if (!string.IsNullOrEmpty(search))
    {
        query = query.Where(p => p.ProductName.Contains(search) || p.Category.CategoryName.Contains(search));
    }

    var result = query
        .Select(p => new ProductDTO
        {
            Id = p.Id,
            ProductName = p.ProductName,
            Price = p.Price,
            Brand = p.Brand,
            CategoryId = p.CategoryId,
            Category = new CategoryDTO
            {
                Id = p.Category.Id,
                CategoryName = p.Category.CategoryName
            }
        });

    return Results.Ok(result);

});
                                                                                                        //POSTs [DONE]
                                                                                                            //a new product [DONE]
app.MapPost("/products", (CornerStoreDbContext db, Product productToPost) =>
{
    try
    {
        db.Products.Add(productToPost);
        db.SaveChanges();
        return Results.Created($"/products/{productToPost.Id}", productToPost);
    }
    catch (DbUpdateException)
    {
        return Results.BadRequest("Invalid Data Submitted");
    }
});
                                                                                                        //PUTs [DONE]
                                                                                                            //a product [DONE]
app.MapPut("/products/{id}", (int id, CornerStoreDbContext db, Product productUpdates) =>
{
    Product foundProduct = db.Products.FirstOrDefault(p => p.Id == id);

    if (!string.IsNullOrEmpty(productUpdates.ProductName)) { foundProduct.ProductName = productUpdates.ProductName; }
    if (productUpdates.Price != 0) { foundProduct.Price = productUpdates.Price; }
    if (!string.IsNullOrEmpty(productUpdates.Brand)) { foundProduct.Brand = productUpdates.Brand; }
    if (productUpdates.CategoryId != 0) { foundProduct.CategoryId = productUpdates.CategoryId; }

    db.SaveChanges();

    return Results.NoContent();

});
                                                                                                    //orders ===[DONE]===
                                                                                                        //GETs [DONE] 
                                                                                                            //all orders with a search by orderDate functionality [DONE] https://localhost:5001/orders?orderDate=2024-1-6
app.MapGet("/orders", (CornerStoreDbContext db, DateTime? orderDate) =>
{
    var query = db.Orders
        .Include(o => o.Cashier)
        .AsQueryable();

    if (orderDate != null)
    {
        query = query.Where(o => o.PaidOnDate == orderDate);
    }

    var result = query
        .Select(o => new OrderDTO
        {
            Id = o.Id,
            CashierId = o.CashierId,
            Cashier = new CashierDTO
            {
                Id = o.Cashier.Id,
                FirstName = o.Cashier.FirstName,
                LastName = o.Cashier.LastName
            },
            PaidOnDate = o.PaidOnDate
        }).ToList();

    return Results.Ok(result);

});
                                                                                                            //a single order, including cashier, products, and category [DONE]
app.MapGet("/orders/{id}", (int id, CornerStoreDbContext db) =>
{
    Order foundOrder = db.Orders
        .Include(o => o.Cashier)
        .Include(o => o.OrderProducts)
        .ThenInclude(op => op.Product)
        .ThenInclude(p => p.Category)
        .FirstOrDefault(o => o.Id == id);

    var result = new OrderDTO
    {
        Id = foundOrder.Id,
        CashierId = foundOrder.CashierId,
        Cashier = new CashierDTO
        {
            Id = foundOrder.Cashier.Id,
            FirstName = foundOrder.Cashier.FirstName,
            LastName = foundOrder.Cashier.LastName
        },
        PaidOnDate = foundOrder.PaidOnDate,
        OrderProducts = foundOrder.OrderProducts
            .Select(op => new OrderProductDTO
            {
                Id = op.Id,
                ProductId = op.ProductId,
                Product = new ProductDTO
                {
                    Id = op.Product.Id,
                    ProductName = op.Product.ProductName,
                    Price = op.Product.Price,
                    Brand = op.Product.Brand,
                    CategoryId = op.Product.CategoryId,
                    Category = new CategoryDTO
                    {
                        Id = op.Product.Category.Id,
                        CategoryName = op.Product.Category.CategoryName,
                        Products = null
                    },
                },
                Quantity = op.Quantity,
                OrderId = op.OrderId,
                Order = null
            }).ToList()
    };

    return Results.Ok(result);
});
                                                                                                        //DELETEs [DONE]
                                                                                                            //a single order [DONE]
app.MapDelete("/orders/{id}", (int id, CornerStoreDbContext db) =>
{
    try
    {
        Order foundOrder = db.Orders.FirstOrDefault(o => o.Id == id);
        db.Orders.Remove(foundOrder);
        db.SaveChanges();
        return Results.NoContent();
    }
    catch (DbUpdateException)
    {
        return Results.BadRequest("Invalid Submission");
    }
});
                                                                                                        //POSTs [DONE]
                                                                                                            //a single order with products [DONE]
app.MapPost("/orders", (CornerStoreDbContext db, Order order) =>
{
    Order orderToPost = new Order
    {
        CashierId = order.CashierId
    };

    try
    {
        db.Orders.Add(orderToPost);
        db.SaveChanges(); // SaveChanges to get the newly generated Id

        if (order.OrderProducts != null)
        {
            List<OrderProduct> orderProductsToPost = order.OrderProducts.ToList();
            try
            {
                foreach (var op in orderProductsToPost)
                {
                    op.OrderId = orderToPost.Id; // Set to the newly created order's Id
                    db.OrderProducts.Add(op);
                }

                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                // Handle the exception appropriately
                return Results.BadRequest("Invalid OrderProduct");
            }
        }

        return Results.Created($"/orders/{orderToPost.Id}", orderToPost);
    }
    catch (DbUpdateException)
    {
        // Handle the exception appropriately
        return Results.BadRequest("Invalid Order");
    }
});

//=================================================================================================================================================================================================
//========================================================================================Run======================================================================================================
//=================================================================================================================================================================================================
app.Run();

//don't move or change this!
public partial class Program { }