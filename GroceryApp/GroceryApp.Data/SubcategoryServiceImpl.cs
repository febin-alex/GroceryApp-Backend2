using GroceryApp.Entity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI;
using System.Globalization;

namespace GroceryApp.Data
{
    public class SubcategoryServiceImpl : ISubcategoryService
    {
        private string connectionString = "server=INL615;database=GroceryDB;trusted_connection=yes";
        private SqlConnection conn;
        private SqlCommand cmd;

        public SubcategoryServiceImpl()
        {
            conn = new SqlConnection(connectionString);
            cmd = new SqlCommand();
            cmd.Connection = conn;
        }

        public List<Subcategories> GetSubCategoriesByCatId(int catId)
        {
            try
            {
                List<Subcategories> list = new List<Subcategories>();
                cmd.CommandText = "select * from Subcategories where CategoryId=" + catId;
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while(reader.Read())
                {
                    Subcategories subcategory = new Subcategories();
                    //System.Diagnostics.Debug.WriteLine((int)reader[2]);

                    subcategory.Id = (int)reader["Id"];
                    subcategory.SubcategoryName = (string)reader["SubcategoryName"];
                    subcategory.CategoryId = (int)reader[2];
                    list.Add(subcategory);
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
    }
}
