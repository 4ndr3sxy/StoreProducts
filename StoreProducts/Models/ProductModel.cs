using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StoreProducts.Models
{
    public class ProductModel
    {
        private int code;
        private string name;
        private string status;
        private bool defective;
        private int stock;

        public int Code { get => code; set => code = value; }
        public string Name { get => name; set => name = value; }
        public string Status { get => status; set => status = value; }
        public bool Defective { get => defective; set => defective = value; }
        public int Stock { get => stock; set => stock = value; }

        public IEnumerable<TransactionModel> transactions { get; set; }
    }
}