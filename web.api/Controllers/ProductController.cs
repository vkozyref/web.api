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
        public IProductService _productService { get; set; }
        /*private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }*/

        [Route]
        public async Task<IEnumerable<Product>> GetProducts()
        {
            return await _productService.GetProducts();
        }

        [Route("{id}")]
        public async Task<Product> GetProduct(int id)
        {
            return await _productService.GetProduct(id);
        }

        [Route]
        [HttpPost]
        public async Task AddProuct([FromBody]Product product)
        {
            await _productService.AddProduct(product);
        }

        [Route("{id}")]
        [HttpDelete]
        public async Task RemoveProduct(int id)
        {
            await _productService.RemoveProduct(id);
        }

        [Route]
        [HttpPut]
        public async Task UpdateProduct([FromBody]Product product)
        {
            await _productService.UpdateProduct(product);
        }
    }
}
