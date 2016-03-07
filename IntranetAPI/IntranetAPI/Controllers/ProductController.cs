using IntranetAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Helpers;
using System.Web.Http;

namespace IntranetAPI.Controllers
{
    public class ProductController : ApiController
    {
        Product product;

        public ProductController()
        {
            product = new Product();
        }

        // GET api/product
        public List<Product> Get()
        {
            List<Product> lisProd = product.GetProducts();
            return lisProd;
        }

        //[Route("customers/{customerId}/orders")]
        //[ActionName("GetTypes")]
        public List<ProductType> GetTypes()
        {
            ProductType prodType = new ProductType();
            List<ProductType> lisProd = prodType.FetchProductTypes();
            return lisProd;
        }

        // GET api/product/5
        //public string Get(int id)
        //{
        //    return "value";
        //}

        //// POST api/product
        [HttpPost]
        public int Post(Product product)
        {
            int retValue = product.CreateProduct(product);
            return retValue;
        }

        //public int Post(JsonResult product)
        //{
        //    return 1;
        //}

        //// PUT api/product/5
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        //// DELETE api/product/5
        //public void Delete(int id)
        //{
        //}
    }
}
