using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using web.api.business.entities.Products;
using web.api.business.logic.Contracts.Products;
using web.api.data.access.Contracts;
using web.api.data.entities.Products;

namespace web.api.business.logic.Implementation
{
    public class ProductService : IProductService
    {
        public IRepository<ProductEntity> ProductRepository { get; set; }
        public async Task<IEnumerable<Product>> GetProducts()
        {
            var products = await ProductRepository.GetMany(p => true);
            return products.Select(s => new Product {
                Id = s.Id,
                Name = s.Name
            });
        }
    }
}
