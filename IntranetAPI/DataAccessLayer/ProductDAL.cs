using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccessLayer
{
    public class ProductDAL
    {
        public List<Product> FetchProducts()
        {
            List<Product> lisProd = new List<Product>();
            using(var context = new RingDBEntities())
            {
                var results = from product in context.Products
                              select product;
                foreach(Product product in results)
                {
                    lisProd.Add(product);
                }
            }

            return lisProd;
        }

        public List<ProductType> FetchProductTypes()
        {
            List<ProductType> lisTypes = new List<ProductType>();
            using(var context = new RingDBEntities())
            {
                var results = from type in context.ProductTypes
                              select type;
                foreach(ProductType type in results)
                {
                    lisTypes.Add(type);
                }
            }

            return lisTypes;
        }

        public int CreateProduct(Product product)
        {
            int retValue;
            try
            {
                using(var context = new RingDBEntities())
                {
                    context.Products.Add(product);
                    context.SaveChanges();

                    retValue = context.Products.Max(prod => prod.ProductID);
                }

                //retValue = 1;
            }
            catch(Exception ex)
            {
                retValue = 0;
            }

            return retValue;
        }
    }
}
