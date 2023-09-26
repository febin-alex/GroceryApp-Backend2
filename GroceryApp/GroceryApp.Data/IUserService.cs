﻿using GroceryApp.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroceryApp.Data
{
    public interface IUserService
    {
        Users RegisterUser(Users user);
        Users LoginUser(string email, string password);
    }
}
