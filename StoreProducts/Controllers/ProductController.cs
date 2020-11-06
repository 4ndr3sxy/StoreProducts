using System;
using ConectDB;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.Entity;
using StoreProducts.Models;

namespace StoreProducts.Controllers
{
    public class ProductController : ApiController
    {
        private db_store_productEntities dbContext = new db_store_productEntities();
        ModelFactory _mf;

        public ProductController()
        {
            _mf = new ModelFactory();
        }

        [HttpGet]
        public IEnumerable<ProductModel> Get()
        {
            Repository r = new Repository();
            return r.getProducts().ToList().Select(x => _mf.CreateP(x));
        }
        [HttpGet]
        public IEnumerable<ProductModel> Get(int code)
        {
            Repository r = new Repository();
            return r.getProduct(code).ToList().Select(x => _mf.CreateP(x));
        }

        [HttpPost]
        public IHttpActionResult AddProduct([FromBody]product pdt)
        {
            if (ModelState.IsValid)
            {
                dbContext.products.Add(pdt);
                dbContext.SaveChanges();
                return Ok(pdt);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPut]
        public IHttpActionResult UpdateProduct(int id, [FromBody] product pdt)
        {
            var getProduct = dbContext.products.Count(x => x.code == id) > 0;

            if (getProduct)
            {
                dbContext.Entry(pdt).State = EntityState.Modified;
                dbContext.SaveChanges();
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }
    }
}
