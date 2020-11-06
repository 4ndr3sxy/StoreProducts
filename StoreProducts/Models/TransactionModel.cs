using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StoreProducts.Models
{
    public class TransactionModel
    {
        private int id;
        private int fk_code_product;
        private int amount;
        private string typeT;

        public int Id { get => id; set => id = value; }
        public int Fk_code_product { get => fk_code_product; set => fk_code_product = value; }
        public int Amount { get => amount; set => amount = value; }
        public string TypeT { get => typeT; set => typeT = value; }
    }
}