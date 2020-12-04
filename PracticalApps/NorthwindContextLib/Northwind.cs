using System;
using Microsoft.EntityFrameworkCore;

namespace Packt.Shared
{
    public class Northwind : DbContext
    {
        public DbSet<Category> Categories {get; set;}
        public DbSet<Product> Products { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Shipper> Shippers { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public Northwind(DbContextOptions<Northwind> options):base(options){}
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Category>()
                .Property(c => c.CategoryName)
                .IsRequired()
                .HasMaxLength(15);
            // define a one to many relationship
            modelBuilder.Entity<Category>()
                .HasMany(c => c.Products)
                .WithOne(c => c.Category);
            modelBuilder.Entity<Customer>()
                .Property(c => c.CustomerID)
                .IsRequired()
                .HasMaxLength(15);
            modelBuilder.Entity<Customer>()
                .Property(c => c.CompanyName)
                .IsRequired()
                .HasMaxLength(40);
            modelBuilder.Entity<Customer>()
                .Property(c => c.ContactName)
                .HasMaxLength(30);
            modelBuilder.Entity<Customer>()
                .Property(c => c.Country)
                .HasMaxLength(15);
            // define a one to many relationship
            modelBuilder.Entity<Customer>()
                .HasMany(c => c.Orders)
                .WithOne(o => o.Customer);
            modelBuilder.Entity<Employee>()
                .Property(c => c.LastName)
                .IsRequired()
                .HasMaxLength(20);
            modelBuilder.Entity<Employee>()
                .Property(c => c.FirstName)
                .IsRequired()
                .HasMaxLength(10);
            modelBuilder.Entity<Employee>()
                .Property(c => c.Country)
                .HasMaxLength(15);
            // define a one to many relationship
            modelBuilder.Entity<Employee>()
                .HasMany(c => c.Orders)
                .WithOne(o => o.Employee);
            modelBuilder.Entity<Product>()
                .Property(c => c.ProductName)
                .IsRequired()
                .HasMaxLength(40);
            // define a one to many relationship
            modelBuilder.Entity<Product>()
                .HasOne(c => c.Category)
                .WithMany(o => o.Products);
            modelBuilder.Entity<Product>()
                .HasOne(c => c.Supplier)
                .WithMany(o => o.Products);
            // define a one to many relationship
            // with a property key that does not
            // follow naming conventions
            modelBuilder.Entity<Order>()
                .HasOne(c => c.Shipper)
                .WithMany(o => o.Orders)
                .HasForeignKey(c => c.ShipVia);
            // the table name has a space in it
            modelBuilder.Entity<OrderDetail>()
                .ToTable("Order Details");
            // define multi-column primary key
            // for order details table
            modelBuilder.Entity<OrderDetail>()
                .HasKey(od => new {od.OrderID, od.ProductID});
            modelBuilder.Entity<Supplier>()
                .Property(c => c.CompanyName)
                .IsRequired()
                .HasMaxLength(40);
            modelBuilder.Entity<Supplier>()
                .HasMany(c => c.Products)
                .WithOne(c => c.Supplier);
        }
    }
}
