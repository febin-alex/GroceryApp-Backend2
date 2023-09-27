using GroceryApp.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace GroceryApp.API.Controllers
{
    [RoutePrefix("api/Subcategory")]
    public class SubcategoryController : ApiController
    {
        private readonly ISubcategoryService subcategoryService;
        public SubcategoryController()
        {
            this.subcategoryService = new SubcategoryServiceImpl();
        }

        [HttpGet]
        [Route("{catId}")]
        public IHttpActionResult Get(int catId)
        {
            var data = subcategoryService.GetSubCategoriesByCatId(catId);
            if (data == null)
                return NotFound();
            return Ok(data);
        }
    }
}
