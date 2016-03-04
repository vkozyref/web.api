using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using web.api.business.entities.Products;
using web.api.business.logic.Contracts.Products;

namespace web.api.business.logic.Implementation
{
    public class ProductService : IProductService
    {
        public async Task<IEnumerable<Product>> GetProducts()
        {
            return new List<Product>
            {
                new Product
                {
                    Id = 1,
                    Name = "SimpleName"
                }
            };
        }
    }
}
