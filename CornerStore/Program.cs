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

                                                                                                                                //cashiers
                                                                                                                                    //GETs
                                                                                                                                        //a single cashier
app.MapGet("/cashier/{id}", (int id, CornerStoreDbContext db) => 
{
    Cashier foundCashier = db.Cashiers
        .Include(c => c.Orders)
        .ThenInclude(c => c.OrderProducts)
        .ThenInclude(c => c.Product)
        .FirstOrDefault(c => c.Id == id);

    if(foundCashier == null)
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
                                                                                                                                //products
                                                                                                                                    //GETs

                                                                                                                                //orders
                                                                                                                                    //GETs

//=================================================================================================================================================================================================
//========================================================================================Run======================================================================================================
//=================================================================================================================================================================================================
app.Run();

//don't move or change this!
public partial class Program { }