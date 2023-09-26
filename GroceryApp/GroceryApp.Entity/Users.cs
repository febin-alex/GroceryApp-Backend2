using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroceryApp.Entity
{
    public class Users
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        public string Password { get; set; }
        public string Gender { get; set; }
        //[DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }
        public string MobileNo { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
