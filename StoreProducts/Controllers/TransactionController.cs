using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ConectDB;
using StoreProducts.Models;

namespace StoreProducts.Controllers
{
    public class TransactionController : ApiController
    {
        private ProductController objProduct = new ProductController();
        private db_store_productEntities dbContext = new db_store_productEntities();
        ModelFactory _mf;//ModelFactory intermediary between model of EF and Controller
        //builder
        public TransactionController()
        {
            _mf = new ModelFactory();
        }

        [HttpPost]
        public IHttpActionResult AddTransaction([FromBody]transaction trn)
        {
            if (ModelState.IsValid)
            {
                ProductModel obj = objProduct.Get(trn.fk_code_product).First();
                product objP = new product()
                {
                    code = obj.Code,
                    name = obj.Name,
                    defective = obj.Defective,
                    status = obj.Status,
                    stock = obj.Stock
                    //transactions = obj.transactions.ToList(
                };
                    
                switch (trn.typeT)
                {
                    case "entry":
                        objP.stock += trn.amount;
                        break;
                    case "output":
                        objP.stock -= trn.amount;
                        break;
                    case "defective":
                        objP.stock -= trn.amount;
                        break;
                    default:
                        return BadRequest();
                }

                objProduct.UpdateProduct(trn.fk_code_product, objP);
                dbContext.SaveChanges();
                dbContext.transactions.Add(trn);
                dbContext.SaveChanges();
                return Ok(trn);
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
