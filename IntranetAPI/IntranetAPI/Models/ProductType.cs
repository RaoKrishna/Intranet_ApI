using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IntranetAPI.Models
{
    public class ProductType
    {
        public int productTypeID { get; set; }
        public string productTypeName { get; set; }

        ProductDAL productDAL;

        public ProductType()
        {
            productDAL = new ProductDAL();
        }

        public List<ProductType> FetchProductTypes()
        {
            List<ProductType> lisProdType = new List<ProductType>();
            ProductType prod;

            var lis = productDAL.FetchProductTypes();

            foreach (DataAccessLayer.ProductType product in lis)
            {
                prod = new ProductType();
                prod.productTypeID = product.ProductTypeID;
                prod.productTypeName = product.ProductTypeName;
                lisProdType.Add(prod);
            }

            return lisProdType;
        }
    }
}