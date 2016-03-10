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
        public IRepository<ProductEntity> _productRepository { get; set; }
        /*private readonly IRepository<ProductEntity> _productRepository;
        public ProductService(IRepository<ProductEntity> productRepository)
        {
            _productRepository = productRepository;
        }*/

        public async Task AddProduct(Product product)
        {
            await _productRepository.Add(ProductToEntity(product));
        }

        public async Task<Product> GetProduct(int id)
        {
            var product = await _productRepository.Get(x => x.Id == id);
            return EntityToProduct(product);
        }

        public async Task<IEnumerable<Product>> GetProducts()
        {
            var products = await _productRepository.GetMany(p => true);
            return products.Select(s => EntityToProduct(s));
        }

        public async Task RemoveProduct(int id)
        {
            await _productRepository.Remove(p => p.Id == id);
        }

        public async Task UpdateProduct(Product product)
        {
            await _productRepository.Update(p => p.Id == product.Id, mp => {
                mp.Name = product.Name;
            });
        }

        private ProductEntity ProductToEntity(Product product)
        {
            return new ProductEntity
            {
                Id = product.Id,
                Name = product.Name
            };
        }

        private Product EntityToProduct(ProductEntity entity)
        {
            return new Product
            {
                Id = entity.Id,
                Name = entity.Name
            };
        }
    }
}
