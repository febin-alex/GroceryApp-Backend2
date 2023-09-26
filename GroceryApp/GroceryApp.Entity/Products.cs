using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroceryApp.Entity
{
    public class Products
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public float UnitPrice { get; set; }
        public float DiscountedPrice { get; set; }
        public int UnitsinStock { get; set; }
        public string UnitType { get; set; }
        public int Discontinued { get; set; }
        //public Categories Category { get; set; }
        public int CategoryId { get; set; }
        //public Subcategories Subcategory { get; set; }
        public int SubcategoryId { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string ProductUrl { get; set; }
    }
}
