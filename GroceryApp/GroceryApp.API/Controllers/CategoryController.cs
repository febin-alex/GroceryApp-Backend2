using GroceryApp.Data;
using GroceryApp.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace GroceryApp.API.Controllers
{
    [RoutePrefix("api/Category")]
    public class CategoryController : ApiController
    {
        private readonly ICategoryService categoryService;
        public CategoryController()
        {
            this.categoryService = new CategoryServiceImpl();
        }

        [HttpGet]
        public IHttpActionResult Get()
        {
            var data = categoryService.GetAllCategories();
            if (data == null)
                return NotFound();
            return Ok(data);
        }

        [HttpGet]
        [Route("{id}")]
        public IHttpActionResult Get(int id)
        {
            var data = categoryService.GetCategoryById(id);
            if (data == null)
                return NotFound();
            return Ok(data);
        }

        [HttpPost]
        public IHttpActionResult Post(Categories category)
        {
            var data = categoryService.AddCategory(category);
            if (data == null)
                return BadRequest();
            return Ok(data);
        }
    }
    
}
