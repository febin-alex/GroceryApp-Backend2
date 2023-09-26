using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroceryApp.Entity
{
    public class Subcategories
    {
        public int Id { get; set; }
        public string SubcategoryName { get; set; }
        //public Categories Category { get; set; }
        public int CategoryId { get; set; }
    }
}
