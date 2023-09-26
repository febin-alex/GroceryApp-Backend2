using GroceryApp.Entity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace GroceryApp.Data
{
    public class CategoryServiceImpl : ICategoryService
    {
        private string connectionString = "server=INL615;database=SampleDB;trusted_connection=yes";
        private SqlConnection conn;
        private SqlCommand cmd;

        public CategoryServiceImpl()
        {
            conn = new SqlConnection(connectionString);
            cmd = new SqlCommand();
            cmd.Connection = conn;
        }
        public Categories AddCategory(Categories category)
        {
            try{
                cmd.CommandText = "insert into Categories (CategoryName,CategoryUrl) values ('" + category.CategoryName + "','" + category.CategoryUrl + "')";
                conn.Open();
                int row = cmd.ExecuteNonQuery();
                conn.Close();
                if (row > 0)
                    return category;
                return null;
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }

        public List<Categories> GetAllCategories()
        {
            try
            {
                List<Categories> list = new List<Categories>();                          
                cmd.CommandText = "select * from Categories";
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Categories category = new Categories();
                    category.Id = (int)reader["Id"];
                    category.CategoryName = (string)reader["CategoryName"];
                    category.CategoryUrl = (string)reader["CategoryUrl"];
                    list.Add(category);                      
                }
                conn.Close();
                //Console.WriteLine(list);
                return list;
            }
            catch(Exception e) {
                Console.WriteLine(e.Message);
                return null;
            }
        }

        public Categories GetCategoryById(int id)
        {
            try
            {
                Categories category = new Categories();
                cmd.CommandText = "select * from Categories where Id="+id;
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                reader.Read();
                category.Id = (int)reader["Id"];
                category.CategoryName = (string)reader["CategoryName"];
                category.CategoryUrl = (string)reader["CategoryUrl"];
                conn.Close();
                return category;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }
    }
}
