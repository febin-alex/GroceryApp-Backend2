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
    //[EnableCors(origins: "http://example.com", headers: "*", methods: "*")]
    [RoutePrefix("api/Product")]
    public class ProductController : ApiController
    {
        private readonly IProductService productService;
        public ProductController()
        {
            this.productService = new ProductServiceImpl();
        }

        [HttpGet]
        public IHttpActionResult Get()
        {
            var data = productService.GetAllProducts();
            return Ok(data);
        }

        [HttpGet]
        [Route("{id}")]
        public IHttpActionResult Get(int id)
        {
            var data = productService.GetProductById(id);
            return Ok(data);
        }

        [HttpGet]
        [Route("{catId}/{subCatId}")]
        public IHttpActionResult Get(int catId, int subCatId)
        {
            var data = productService.SearchProduct(catId, subCatId);
            return Ok(data);
        }


        [HttpPost]
        public IHttpActionResult Post(Products product)
        {
            var data = productService.AddProduct(product);
            return Ok(data);
        }

        [HttpPut]
        public IHttpActionResult Put(int id)
        {
            var data = productService.EditProduct(id);
            return Ok(data);
        }


        [HttpGet]
        [Route("search/{name}")]
        public IHttpActionResult Get(string name)
        {
            var data = productService.SearchProduct(name);
            return Ok(data);
        }
    }
}
