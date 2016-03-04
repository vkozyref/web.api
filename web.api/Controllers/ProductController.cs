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
    }
}
