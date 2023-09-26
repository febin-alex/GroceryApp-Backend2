using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GroceryApp.Entity;

namespace GroceryApp.Data
{
    public interface IProductService
    {
        List<Products> GetAllProducts();
        Products GetProductById(int id);
        Products AddProduct(Products product);
        bool EditProduct(int id);
        List<Products> SearchProduct(int catId, int subCatId);
        List<Products> SearchProduct(string productName);
    }
}
