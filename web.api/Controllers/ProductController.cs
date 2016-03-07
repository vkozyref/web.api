using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using web.api.business.entities.Products;
using web.api.business.logic.Contracts.Products;

namespace web.api.Controllers
{
    [RoutePrefix("api/product")]
    public class ProductController : ApiController
    {
        public IProductService ProductService { get; set; }

        [Route]
        public async Task<IEnumerable<Product>> GetProducts()
        {
            return await ProductService.GetProducts();
        }

        [Route("{id}")]
        public async Task<Product> GetProduct(int id)
        {
            return await ProductService.GetProduct(id);
        }

        [Route]
        [HttpPost]
        public async Task AddProuct([FromBody]Product product)
        {
            await ProductService.AddProduct(product);
        }

        [Route("{id}")]
        [HttpDelete]
        public async Task RemoveProduct(int id)
        {
            await ProductService.RemoveProduct(id);
        }

        [Route]
        [HttpPut]
        public async Task UpdateProduct([FromBody]Product product)
        {
            await ProductService.UpdateProduct(product);
        }
    }
}
