using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IntranetAPI.Models
{
    public class Product
    {
        public int productId { get; set; }
        public string productName { get; set; }
        public string productType { get; set; }
        public int materialRate { get; set; }
        public int hours { get; set; }
        public int labour { get; set; }
        public int cavity { get; set; }
        public int shots { get; set; }
        public int weight { get; set; }

        ProductDAL productDAL;

        public Product()
        {
            productDAL = new DataAccessLayer.ProductDAL();
        }

        public List<Product> GetProducts()
        {
            List<Product> lisProd = new List<Product>();
            Product prod;

            var lis = productDAL.FetchProducts();

            foreach (DataAccessLayer.Product product in lis)
            {
                prod = new Product();
                prod.productId = product.ProductID;
                prod.productName = product.ProductName;
                prod.productType = product.ProductType;
                prod.materialRate = product.MaterialRate != null ? Convert.ToInt32(product.MaterialRate) : 0;
                prod.hours = product.Hours != null ? Convert.ToInt32(product.Hours) : 0;
                prod.labour = product.Labour != null ? Convert.ToInt32(product.Labour) : 0;
                prod.cavity = product.Cavity != null ? Convert.ToInt32(product.Cavity) : 0;
                prod.shots = product.Shots != null ? Convert.ToInt32(product.Shots) : 0;
                prod.weight = product.Weight != null ? Convert.ToInt32(product.Weight) : 0;
                
                lisProd.Add(prod);
            }

            return lisProd;
        }

        public int CreateProduct(Product product)
        {
            int retValue;
            DataAccessLayer.Product prod = new DataAccessLayer.Product
            {
                ProductID = product.productId,
                ProductName = product.productName,
                ProductType = product.productType,
                MaterialRate = product.materialRate,
                Labour = product.labour,
                Cavity = product.cavity,
                Shots = product.shots,
                Hours = product.hours,
                Weight = product.weight
            };
            retValue = productDAL.CreateProduct(prod);
            return retValue;
        }
    }
}