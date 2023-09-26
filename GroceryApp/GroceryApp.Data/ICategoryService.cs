using GroceryApp.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroceryApp.Data
{
    public interface ICategoryService
    {
        List<Categories> GetAllCategories();
        Categories GetCategoryById(int id);
        Categories AddCategory(Categories category);
    }
}
