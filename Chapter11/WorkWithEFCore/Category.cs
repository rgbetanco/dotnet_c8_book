using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
namespace WorkWithEFCore
{
    public class Category
    {
        public int CategoryID {get; set;}
        public string CategoryName {get; set;}
        
        [Column(TypeName = "ntext")]
        public string Description {get; set;}
        public virtual ICollection<Product> Products {get; set;}
        //to allow for inserting products into a category
        public Category() {
            this.Products = new List<Product>();
        }
    }
}