﻿using System;
using static System.Console;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace LinqWithEFCore
{
    class Program
    {
        static void Main(string[] args)
        {
            //FilterAndSort();
            JoinCategoriesAndProducts();
            //GroupJoinCategoriesAndProducts();
            //AggregateProducts();
        }
        static void FilterAndSort()
        {
            using (var db = new Northwind()){
                var query = db.Products.AsEnumerable()
                    .Where(p => p.UnitPrice > 10M)
                    .OrderByDescending(p => p.ProductName)
                    .Select(p => new {
                        p.ProductID,
                        p.ProductName,
                        p.UnitPrice
                    });
                WriteLine("Products that cost less than $10:");
                foreach (var item in query)
                {
                    WriteLine("{0}:{1} costs {2:$#,##0.00}",item.ProductID, item.ProductName, item.UnitPrice);
                }
                WriteLine();
            }
        }
        static void GroupJoinCategoriesAndProducts()
        {
            using (var db = new Northwind())
            {
                var queryGroup = db.Categories.AsEnumerable().GroupJoin(
                    inner: db.Products,
                    outerKeySelector: category => category.CategoryID,
                    innerKeySelector: product => product.CategoryID,
                    resultSelector: (c, matchingProducts) => new {
                        c.CategoryName,
                        Products = matchingProducts.OrderBy(p=>p.ProductName)
                    }
                );
                foreach (var item in queryGroup)
                {
                    WriteLine("{0} has {1} products.",
                        arg0: item.CategoryName,
                        arg1: item.Products.Count()
                    );
                    foreach (var product in item.Products)
                    {
                        WriteLine($"{product.ProductName}");
                    }
                }
            }
        }
        static void JoinCategoriesAndProducts(){
            using (var db = new Northwind())
            {
                //join every product to its category to return 77 matches
                var queryJoin = db.Categories.Join(
                    inner:db.Products,
                    outerKeySelector:category => category.CategoryID,
                    innerKeySelector:product => product.CategoryID,
                        resultSelector:(c,p) =>
                            new {c.CategoryName, p.ProductName, p.ProductID}
                ).OrderBy(cp => cp.ProductID).Take(10);

                foreach (var item in queryJoin)
                {
                    WriteLine("{0}:{1} is in {2},",
                        arg0: item.ProductID,
                        arg1: item.ProductName,
                        arg2: item.CategoryName
                    );
                }
            }
        }
        static void AggregateProducts(){
            using (var db = new Northwind())
            {
                WriteLine("{0,-25}{1,10}",
                    arg0: "Product count:",
                    arg1: db.Products.Count()
                );
                WriteLine("{0,-25}{1,10:$#,##0.00}",
                    arg0: "Highest product price:",
                    arg1: db.Products.AsEnumerable().Max(p=>p.UnitPrice)
                );
                WriteLine("{0,-25}{1,10:N0}",
                    arg0: "Sum of units in stock:",
                    arg1: db.Products.Sum(p => p.UnitsInStock)
                );
                WriteLine("{0,-25}{1,10:N0}",
                    arg0: "Sum of units in order:",
                    arg1: db.Products.Sum(p => p.UnitsOnOrder)
                );
                WriteLine("{0,-25}{1,10:$#,##0.00}",
                    arg0: "Average unit price:",
                    arg1: db.Products.AsEnumerable().Average(p=>p.UnitPrice)
                );
                WriteLine("{0,-25}{1,10:$#,##0.00}",
                    arg0: "Value of units in stock:",
                    arg1: db.Products.AsEnumerable().Sum(p=>p.UnitPrice*p.UnitsInStock)
                );
            }
        }
    }
}
