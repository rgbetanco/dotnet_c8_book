using System;
using static System.Console;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace WorkWithEFCore
{
    class Program
    {
        static void Main(string[] args)
        {
            QueryingProducts();
            //QueryingCategories();
        }

        static void QueryingCategories(){
            using (var db = new Northwind()){
                WriteLine("Categories and how many products they have:");
                IQueryable<Category> cats = db.Categories.Include(c=>c.Products);
                foreach(Category cat in cats){
                    WriteLine($"{cat.CategoryName} has {cat.Products.Count} products");
                }
            }
        }

        static void QueryingProducts(){
            using (var db = new Northwind()){
                WriteLine("Products that cost more than a price, highest at top");
                string input;
                decimal price;
                do {
                    Write("Enter a product price"); 
                    input = ReadLine();
                } while(!decimal.TryParse(input, out price));
                IOrderedEnumerable<Product> prods = db.Products.AsEnumerable().Where(product => product.Cost > price).OrderByDescending(product => product.Cost);
                foreach(Product item in prods){
                    WriteLine(
                        "{0}:{1} costs {2:$#,##0.00} and has {3} in stock.",
                        item.ProductID, item.ProductName, item.Cost, item.Stock
                    );
                }
            }
        }
    }
}
