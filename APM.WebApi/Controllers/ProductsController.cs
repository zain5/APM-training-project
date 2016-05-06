﻿using APM.WebAPI.Models;
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

        // GET: api/Products/search="GDN"
        public IEnumerable<Product> Get(string search)
        {
            var products = repo.Retrieve();
            return products.Where(T => T.ProductCode.Contains(search));
        }

        // GET: api/Products/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Products
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Products/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Products/5
        public void Delete(int id)
        {
        }
    }
}
