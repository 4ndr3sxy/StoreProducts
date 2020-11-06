using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ConectDB;

namespace StoreProducts.Models
{
    public class ModelFactory
    {
        public ProductModel CreateP(product pdt)
        {
            return new ProductModel()
            {
                Code = pdt.code,
                Name = pdt.name,
                Status = pdt.status,
                Defective = pdt.defective,
                Stock = pdt.stock,
                transactions = pdt.transactions.Select(a => CreateT(a))
            };
        }

        public TransactionModel CreateT(transaction trn)
        {
            return new TransactionModel()
            {
                Id = trn.id,
                Fk_code_product = trn.fk_code_product,
                Amount = trn.amount,
                TypeT = trn.typeT
            };
        }
    }
}