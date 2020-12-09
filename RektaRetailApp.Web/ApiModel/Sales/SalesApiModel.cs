using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RektaRetailApp.Web.ApiModel.Product;

namespace RektaRetailApp.Web.ApiModel.Sales
{
    public class SalesApiModel
    {
        public SalesApiModel()
        {
            ItemsBought = new List<ProductApiModel>();
        }
        public int Id { get; set; }

        public decimal GrandTotal { get; set; }

        public string SalesPerson { get; set; } = null!;

        public List<ProductApiModel> ItemsBought { get; set; }
    }
}
