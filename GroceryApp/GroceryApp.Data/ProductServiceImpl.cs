using GroceryApp.Entity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroceryApp.Data
{
    public class ProductServiceImpl:IProductService
    {
        private string connectionString = "server=INL615;database=GroceryDB;trusted_connection=yes";
        private SqlConnection conn;
        private SqlCommand cmd;

        public ProductServiceImpl()
        {
            conn = new SqlConnection(connectionString);
            cmd = new SqlCommand();
            cmd.Connection = conn;
        }

        public Products AddProduct(Products product)
        {
            try
            {
                cmd.CommandText = "insert into Products (ProductName, Description, UnitPrice, UnitsinStock, Discontinued, SubcategoryId, ProductUrl, DiscountedPrice, UnitType, CategoryId) values ('" + product.ProductName + "','" + product.Description + "'," + product.UnitPrice + "," + product.UnitsinStock + "," + product.Discontinued + "," + product.SubcategoryId + ",'" + product.ProductUrl + "'," + product.DiscountedPrice + ",'" + product.UnitType + "'," + product.CategoryId + ")";
                conn.Open();
                int row = cmd.ExecuteNonQuery();
                conn.Close();
                if (row > 0)
                    return product;
                return null;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }

        public bool EditProduct(int id)
        {
            try
            {
                cmd.CommandText = "update Product set UnitsinStock=UnitsinStock-1 where Id=" + id;
                conn.Open();
                int row = cmd.ExecuteNonQuery();
                conn.Close();
                if (row > 0)
                    return true;
                return false;
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
            
        }

        public List<Products> GetAllProducts()
        {
            try
            {
                List<Products> list = new List<Products>();
                cmd.CommandText = "select * from Products";
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Products product = new Products();
                    product.Id = (int)reader["Id"];                   
                    product.ProductName = (string)reader["ProductName"];
                    product.ProductUrl = (string)reader["ProductUrl"];
                    product.Description = (string)reader["Description"];
                    product.UnitPrice = (float)reader["UnitPrice"];
                    product.SubcategoryId = (int)reader["SubcategoryId"];
                    product.DiscountedPrice = (float)reader["DiscountedPrice"];
                    product.CategoryId = (int)reader["CategoryId"];
                    product.UnitType = (string)reader["UnitType"];
                    list.Add(product);
                }
                conn.Close();
                return list;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }

        public Products GetProductById(int id)
        {
            try
            {
                Products product = new Products();
                cmd.CommandText = "select * from Products where Id=" + id;
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                reader.Read();
                product.Id = (int)reader["Id"];
                product.ProductName = (string)reader["ProductName"];
                product.ProductUrl = (string)reader["ProductUrl"];
                product.Description = (string)reader["Description"];
                product.UnitPrice = (float)reader["UnitPrice"];
                product.SubcategoryId = (int)reader["SubcategoryId"];
                product.DiscountedPrice = (float)reader["DiscountedPrice"];
                product.CategoryId = (int)reader["CategoryId"];
                product.UnitType = (string)reader["UnitType"];
                conn.Close();
                return product;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }

        public List<Products> SearchProduct(int catId, int subCatId)
        {
            try
            {
                List<Products> list = new List<Products>();
                cmd.CommandText = "select * from Products where CategoryId="+catId+" and SubcategoryId="+subCatId;
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Products product = new Products();
                    product.Id = (int)reader["Id"];
                    product.ProductName = (string)reader["ProductName"];
                    product.ProductUrl = (string)reader["ProductUrl"];
                    product.Description = (string)reader["Description"];
                    product.UnitPrice = (float)reader["UnitPrice"];
                    product.SubcategoryId = (int)reader["SubcategoryId"];
                    product.DiscountedPrice = (float)reader["DiscountedPrice"];
                    product.CategoryId = (int)reader["CategoryId"];
                    product.UnitType = (string)reader["UnitType"];
                    list.Add(product);
                }
                conn.Close();
                //Console.WriteLine(list);
                return list;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }

        public List<Products> SearchProduct(string productName)
        {
            try
            {
                List<Products> list = new List<Products>();
                cmd.CommandText = "select * from Products where ProductName like '%" + productName + "%'";
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Products product = new Products();
                    product.Id = (int)reader["Id"];
                    product.ProductName = (string)reader["ProductName"];
                    product.ProductUrl = (string)reader["ProductUrl"];
                    product.Description = (string)reader["Description"];
                    product.UnitPrice = (float)reader["UnitPrice"];
                    product.SubcategoryId = (int)reader["SubcategoryId"];
                    product.DiscountedPrice = (float)reader["DiscountedPrice"];
                    product.CategoryId = (int)reader["CategoryId"];
                    product.UnitType = (string)reader["UnitType"];
                    list.Add(product);
                }
                conn.Close();
                //Console.WriteLine(list);
                return list;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }
    }
}
