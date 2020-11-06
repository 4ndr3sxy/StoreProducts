using System;
using ConectDB;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

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
    }
}
