using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace CornerStore.Migrations
{
    public partial class InitialSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cashier",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FirstName = table.Column<string>(type: "text", nullable: false),
                    LastName = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cashier", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CategoryName = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CashierId = table.Column<int>(type: "integer", nullable: false),
                    PaidOnDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Order_Cashier_CashierId",
                        column: x => x.CashierId,
                        principalTable: "Cashier",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ProductName = table.Column<string>(type: "text", nullable: false),
                    Price = table.Column<decimal>(type: "numeric", nullable: false),
                    Brand = table.Column<string>(type: "text", nullable: false),
                    CategoryId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Product_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Category",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderProduct",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ProductId = table.Column<int>(type: "integer", nullable: false),
                    OrderId = table.Column<int>(type: "integer", nullable: false),
                    Quantity = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderProduct", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderProduct_Order_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Order",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderProduct_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Cashier",
                columns: new[] { "Id", "FirstName", "LastName" },
                values: new object[,]
                {
                    { 1, "Lucas", "Joneao" },
                    { 2, "Ella", "Smith" },
                    { 3, "Mason", "Williams" },
                    { 4, "Olivia", "Brown" },
                    { 5, "Liam", "Davis" },
                    { 6, "Sophia", "Miller" },
                    { 7, "Noah", "Moore" },
                    { 8, "Ava", "Taylor" }
                });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "Id", "CategoryName" },
                values: new object[,]
                {
                    { 1, "Books" },
                    { 2, "Food" },
                    { 3, "Legos" },
                    { 4, "Boardgames" }
                });

            migrationBuilder.InsertData(
                table: "Order",
                columns: new[] { "Id", "CashierId", "PaidOnDate" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2024, 1, 6, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, 1, new DateTime(2023, 12, 24, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, 1, new DateTime(2023, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, 1, new DateTime(2023, 12, 26, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, 1, new DateTime(2023, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 6, 1, new DateTime(2023, 12, 28, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "Id", "Brand", "CategoryId", "Price", "ProductName" },
                values: new object[,]
                {
                    { 1, "DaysOfWonder", 4, 40.00m, "Heat!" },
                    { 2, "Penguin Books", 1, 20.00m, "To Kill a Mockingbird" },
                    { 3, "HarperCollins", 1, 25.00m, "1984" },
                    { 4, "Kraft", 2, 5.00m, "Macaroni and Cheese" },
                    { 5, "Campbell's", 2, 2.50m, "Chicken Noodle Soup" },
                    { 6, "LEGO", 3, 50.00m, "Classic Bricks Set" },
                    { 7, "Hasbro", 4, 30.00m, "Monopoly Board Game" },
                    { 8, "Kellogg's", 2, 3.00m, "Corn Flakes" },
                    { 9, "Ferrero", 2, 8.00m, "Ferrero Rocher Chocolates" },
                    { 10, "Oxford University Press", 1, 35.00m, "Pride and Prejudice" },
                    { 11, "LEGO", 3, 40.00m, "Star Wars Millennium Falcon" },
                    { 12, "Hasbro", 4, 25.00m, "Scrabble Board Game" },
                    { 13, "Hershey's", 2, 2.00m, "Chocolate Bar" },
                    { 14, "LEGO", 3, 30.00m, "LEGO Technic Car" },
                    { 15, "Campbell's", 2, 3.50m, "Tomato Soup" },
                    { 16, "Penguin Books", 1, 18.00m, "The Great Gatsby" },
                    { 17, "Hasbro", 4, 15.00m, "Clue Board Game" },
                    { 18, "Nabisco", 2, 4.00m, "Oreo Cookies" },
                    { 19, "LEGO", 3, 45.00m, "LEGO Architecture Skyline Set" },
                    { 20, "Simon & Schuster", 1, 22.00m, "To Kill a Mockingbird (Hardcover)" }
                });

            migrationBuilder.InsertData(
                table: "OrderProduct",
                columns: new[] { "Id", "OrderId", "ProductId", "Quantity" },
                values: new object[,]
                {
                    { 1, 1, 1, 1 },
                    { 2, 1, 3, 2 },
                    { 3, 2, 6, 1 },
                    { 4, 2, 9, 3 },
                    { 5, 3, 12, 1 },
                    { 6, 3, 15, 2 },
                    { 7, 4, 18, 5 },
                    { 8, 4, 20, 1 },
                    { 9, 4, 5, 2 },
                    { 10, 5, 11, 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Order_CashierId",
                table: "Order",
                column: "CashierId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderProduct_OrderId",
                table: "OrderProduct",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderProduct_ProductId",
                table: "OrderProduct",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_CategoryId",
                table: "Product",
                column: "CategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderProduct");

            migrationBuilder.DropTable(
                name: "Order");

            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "Cashier");

            migrationBuilder.DropTable(
                name: "Category");
        }
    }
}
