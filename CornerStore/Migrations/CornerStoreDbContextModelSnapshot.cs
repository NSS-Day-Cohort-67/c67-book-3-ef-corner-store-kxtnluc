﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace CornerStore.Migrations
{
    [DbContext(typeof(CornerStoreDbContext))]
    partial class CornerStoreDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("CornerStore.Models.Cashier", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Cashiers");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            FirstName = "Lucas",
                            LastName = "Joneao"
                        },
                        new
                        {
                            Id = 2,
                            FirstName = "Ella",
                            LastName = "Smith"
                        },
                        new
                        {
                            Id = 3,
                            FirstName = "Mason",
                            LastName = "Williams"
                        },
                        new
                        {
                            Id = 4,
                            FirstName = "Olivia",
                            LastName = "Brown"
                        },
                        new
                        {
                            Id = 5,
                            FirstName = "Liam",
                            LastName = "Davis"
                        },
                        new
                        {
                            Id = 6,
                            FirstName = "Sophia",
                            LastName = "Miller"
                        },
                        new
                        {
                            Id = 7,
                            FirstName = "Noah",
                            LastName = "Moore"
                        },
                        new
                        {
                            Id = 8,
                            FirstName = "Ava",
                            LastName = "Taylor"
                        });
                });

            modelBuilder.Entity("CornerStore.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Categorys");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CategoryName = "Books"
                        },
                        new
                        {
                            Id = 2,
                            CategoryName = "Food"
                        },
                        new
                        {
                            Id = 3,
                            CategoryName = "Legos"
                        },
                        new
                        {
                            Id = 4,
                            CategoryName = "Boardgames"
                        });
                });

            modelBuilder.Entity("CornerStore.Models.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("CashierId")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("PaidOnDate")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("Id");

                    b.HasIndex("CashierId");

                    b.ToTable("Orders");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CashierId = 1,
                            PaidOnDate = new DateTime(2024, 1, 6, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 2,
                            CashierId = 2,
                            PaidOnDate = new DateTime(2023, 12, 24, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 3,
                            CashierId = 3,
                            PaidOnDate = new DateTime(2023, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 4,
                            CashierId = 4,
                            PaidOnDate = new DateTime(2023, 12, 26, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 5,
                            CashierId = 5,
                            PaidOnDate = new DateTime(2023, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 6,
                            CashierId = 1,
                            PaidOnDate = new DateTime(2023, 12, 28, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("CornerStore.Models.OrderProduct", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("OrderId")
                        .HasColumnType("integer");

                    b.Property<int>("ProductId")
                        .HasColumnType("integer");

                    b.Property<int>("Quantity")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.HasIndex("ProductId");

                    b.ToTable("OrderProducts");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            OrderId = 1,
                            ProductId = 1,
                            Quantity = 1
                        },
                        new
                        {
                            Id = 2,
                            OrderId = 1,
                            ProductId = 3,
                            Quantity = 2
                        },
                        new
                        {
                            Id = 3,
                            OrderId = 2,
                            ProductId = 6,
                            Quantity = 1
                        },
                        new
                        {
                            Id = 4,
                            OrderId = 2,
                            ProductId = 9,
                            Quantity = 3
                        },
                        new
                        {
                            Id = 5,
                            OrderId = 3,
                            ProductId = 12,
                            Quantity = 1
                        },
                        new
                        {
                            Id = 6,
                            OrderId = 3,
                            ProductId = 15,
                            Quantity = 2
                        },
                        new
                        {
                            Id = 7,
                            OrderId = 4,
                            ProductId = 18,
                            Quantity = 5
                        },
                        new
                        {
                            Id = 8,
                            OrderId = 4,
                            ProductId = 20,
                            Quantity = 1
                        },
                        new
                        {
                            Id = 9,
                            OrderId = 4,
                            ProductId = 5,
                            Quantity = 2
                        },
                        new
                        {
                            Id = 10,
                            OrderId = 5,
                            ProductId = 11,
                            Quantity = 1
                        });
                });

            modelBuilder.Entity("CornerStore.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Brand")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("CategoryId")
                        .HasColumnType("integer");

                    b.Property<decimal>("Price")
                        .HasColumnType("numeric");

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Brand = "DaysOfWonder",
                            CategoryId = 4,
                            Price = 40.00m,
                            ProductName = "Heat!"
                        },
                        new
                        {
                            Id = 2,
                            Brand = "Penguin Books",
                            CategoryId = 1,
                            Price = 20.00m,
                            ProductName = "To Kill a Mockingbird"
                        },
                        new
                        {
                            Id = 3,
                            Brand = "HarperCollins",
                            CategoryId = 1,
                            Price = 25.00m,
                            ProductName = "1984"
                        },
                        new
                        {
                            Id = 4,
                            Brand = "Kraft",
                            CategoryId = 2,
                            Price = 5.00m,
                            ProductName = "Macaroni and Cheese"
                        },
                        new
                        {
                            Id = 5,
                            Brand = "Campbell's",
                            CategoryId = 2,
                            Price = 2.50m,
                            ProductName = "Chicken Noodle Soup"
                        },
                        new
                        {
                            Id = 6,
                            Brand = "LEGO",
                            CategoryId = 3,
                            Price = 50.00m,
                            ProductName = "Classic Bricks Set"
                        },
                        new
                        {
                            Id = 7,
                            Brand = "Hasbro",
                            CategoryId = 4,
                            Price = 30.00m,
                            ProductName = "Monopoly Board Game"
                        },
                        new
                        {
                            Id = 8,
                            Brand = "Kellogg's",
                            CategoryId = 2,
                            Price = 3.00m,
                            ProductName = "Corn Flakes"
                        },
                        new
                        {
                            Id = 9,
                            Brand = "Ferrero",
                            CategoryId = 2,
                            Price = 8.00m,
                            ProductName = "Ferrero Rocher Chocolates"
                        },
                        new
                        {
                            Id = 10,
                            Brand = "Oxford University Press",
                            CategoryId = 1,
                            Price = 35.00m,
                            ProductName = "Pride and Prejudice"
                        },
                        new
                        {
                            Id = 11,
                            Brand = "LEGO",
                            CategoryId = 3,
                            Price = 40.00m,
                            ProductName = "Star Wars Millennium Falcon"
                        },
                        new
                        {
                            Id = 12,
                            Brand = "Hasbro",
                            CategoryId = 4,
                            Price = 25.00m,
                            ProductName = "Scrabble Board Game"
                        },
                        new
                        {
                            Id = 13,
                            Brand = "Hershey's",
                            CategoryId = 2,
                            Price = 2.00m,
                            ProductName = "Chocolate Bar"
                        },
                        new
                        {
                            Id = 14,
                            Brand = "LEGO",
                            CategoryId = 3,
                            Price = 30.00m,
                            ProductName = "LEGO Technic Car"
                        },
                        new
                        {
                            Id = 15,
                            Brand = "Campbell's",
                            CategoryId = 2,
                            Price = 3.50m,
                            ProductName = "Tomato Soup"
                        },
                        new
                        {
                            Id = 16,
                            Brand = "Penguin Books",
                            CategoryId = 1,
                            Price = 18.00m,
                            ProductName = "The Great Gatsby"
                        },
                        new
                        {
                            Id = 17,
                            Brand = "Hasbro",
                            CategoryId = 4,
                            Price = 15.00m,
                            ProductName = "Clue Board Game"
                        },
                        new
                        {
                            Id = 18,
                            Brand = "Nabisco",
                            CategoryId = 2,
                            Price = 4.00m,
                            ProductName = "Oreo Cookies"
                        },
                        new
                        {
                            Id = 19,
                            Brand = "LEGO",
                            CategoryId = 3,
                            Price = 45.00m,
                            ProductName = "LEGO Architecture Skyline Set"
                        },
                        new
                        {
                            Id = 20,
                            Brand = "Simon & Schuster",
                            CategoryId = 1,
                            Price = 22.00m,
                            ProductName = "To Kill a Mockingbird (Hardcover)"
                        });
                });

            modelBuilder.Entity("CornerStore.Models.Order", b =>
                {
                    b.HasOne("CornerStore.Models.Cashier", "Cashier")
                        .WithMany("Orders")
                        .HasForeignKey("CashierId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cashier");
                });

            modelBuilder.Entity("CornerStore.Models.OrderProduct", b =>
                {
                    b.HasOne("CornerStore.Models.Order", "Order")
                        .WithMany("OrderProducts")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CornerStore.Models.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("CornerStore.Models.Product", b =>
                {
                    b.HasOne("CornerStore.Models.Category", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("CornerStore.Models.Cashier", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("CornerStore.Models.Category", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("CornerStore.Models.Order", b =>
                {
                    b.Navigation("OrderProducts");
                });
#pragma warning restore 612, 618
        }
    }
}
