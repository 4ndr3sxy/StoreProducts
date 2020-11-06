using System;
using ConectDB;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.Entity;

namespace StoreProducts.Controllers
{
    public class ProductController : ApiController
    {
        private db_store_productEntities dbContext = new db_store_productEntities();

        [HttpGet]
        public IEnumerable<product> Get()
        {
            using (db_store_productEntities productsentities = new db_store_productEntities())
            {
                return productsentities.products.ToList();
            }
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
