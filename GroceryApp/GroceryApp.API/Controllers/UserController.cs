using GroceryApp.Data;
using GroceryApp.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;

namespace GroceryApp.API.Controllers
{
    [RoutePrefix("api/User")]
    public class UserController : ApiController
    {
        private readonly IUserService userService;
        public UserController()
        {
            this.userService = new UserServiceImpl();
        }

        [HttpPost]
        [Route("register")]
        public IHttpActionResult Post(Users user)
        {
            user.CreatedDate = DateTime.Now;

            var data = userService.RegisterUser(user);
            if (data != null)
            {
                return Ok(new { 
                    status="success",
                    user=data 
                }
                );
            }
            else
                return Ok(new
                {
                    status = "fail",
                    message = "User already exists"
                });
        }

        [HttpPost]
        [Route("login")]
        public IHttpActionResult Post(Login user)
        {

            Users data = userService.LoginUser(user.Email, user.Password);

            if (data == null)
            {
                return Ok(new
                {
                    status = "error",
                    message = "Invalid email or password"
                });
            }

            return Ok(new
            {
                status = "success",
                message = "Login successful",
                user = data

            });
        }
    }
}
