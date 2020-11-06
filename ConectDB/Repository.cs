using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConectDB
{
    public class Repository
    {
        public IQueryable<product> getProducts()
        {
            db_store_productEntities ctx = new db_store_productEntities();
            return ctx.products;
        }
        /*
        public IQueryable<product> getUser(String id)
        {
            db_blue_bankEntities ctx = new db_blue_bankEntities();
            return ctx.users.Where(x => x.id == id).Select(x => x);
        }
        */
        public IQueryable<transaction> getTransactions(int id)
        {
            db_store_productEntities ctx = new db_store_productEntities();
            return ctx.transactions.Where(x => x.id == id).Select(x => x);
        }
    }
}
