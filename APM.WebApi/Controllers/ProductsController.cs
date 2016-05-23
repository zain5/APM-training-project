using APM.WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.OData;

namespace APM.WebApi.Controllers
{
    [EnableCorsAttribute("http://localhost:50856", "*", "*")]
    public class ProductsController : ApiController
    {
        private static ProductRepository repo = new ProductRepository();

        // GET: api/Products
        [EnableQuery()]
        public IQueryable<Product> Get()
        {
            return repo.Retrieve().AsQueryable();
        }

        // GET: api/Products/5
        public Product Get(int id)
        {
            Product product;

            if (id > 0)
            {
                product = repo.Retrieve().FirstOrDefault(T => T.ProductId == id);
            }
            else
            {
                product = repo.Create();
            }

            return product;
        }

        // POST: api/Products
        public void Post([FromBody]Product product)
        {
            var newProduct = repo.Save(product);
        }

        // PUT: api/Products/5
        public void Put(int id, [FromBody]Product product)
        {
            var updatedProduct = repo.Save(id, product);
        }

        // DELETE: api/Products/5
        public void Delete(int id)
        {
        }
    }
}
