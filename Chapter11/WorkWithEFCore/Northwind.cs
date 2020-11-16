using Microsoft.EntityFrameworkCore;
namespace WorkWithEFCore
{
    public class Northwind: DbContext
    {
        public DbSet<Category> Categories {get; set;}
        public DbSet<Product> Products {get; set;}
        protected override void OnConfiguring (DbContextOptionsBuilder optionsBuilder) {
            string path = System.IO.Path.Combine(System.Environment.CurrentDirectory, "Northwind.db");
            optionsBuilder.UseLazyLoadingProxies().UseSqlite($"Filename={path}");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder){
            //example of using fluent API instead of attributes
            modelBuilder.Entity<Category>().Property(category => category.CategoryName)
            .IsRequired()
            .HasMaxLength(15);
            modelBuilder.Entity<Product>().HasQueryFilter(p=>!p.Discontinued);
            modelBuilder.Entity<Product>().Property(p=>p.Cost).HasConversion<double>();
        }
    }
}