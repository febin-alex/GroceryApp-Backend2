using GroceryApp.Entity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroceryApp.Data
{
    public class UserServiceImpl : IUserService
    {
        private string connectionString = "server=INL615;database=SampleDB;trusted_connection=yes";
        private SqlConnection conn;
        private SqlCommand cmd;

        public UserServiceImpl()
        {
            conn = new SqlConnection(connectionString);
            cmd = new SqlCommand();
            cmd.Connection = conn;
        }
        public Users LoginUser(string email, string password)
        {
            try
            {
                Users user = new Users();
                cmd.CommandText = "select * from Users where Email='" + email+"' and Password='"+password+"'";
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                reader.Read();
                user.Id = (int)reader["Id"];
                user.FirstName = (string)reader["FirstName"];
                user.LastName = (string)reader["LastName"];
                user.Email = (string)reader["Email"];
                user.Password = (string)reader["Password"];
                user.MobileNo = (string)reader["MobileNo"];
                user.Gender = (string)reader["Gender"];
                conn.Close();
                return user;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }

        public Users RegisterUser(Users user)
        {
            try
            {
                cmd.CommandText = "insert into Users (FirstName, LastName, Email, Password, Gender, DateOfBirth, MobileNo) values ('" + user.FirstName + "','" + user.LastName + "','" + user.Email + "','" + user.Password + "','" + user.Gender + "','" + user.DateOfBirth + "','" + user.MobileNo + "')";
                conn.Open();
                int row = cmd.ExecuteNonQuery();
                conn.Close();
                if (row > 0)
                    return user;
                return null;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }
    }
}
