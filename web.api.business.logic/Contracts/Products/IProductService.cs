using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using web.api.business.entities.Products;

namespace web.api.business.logic.Contracts.Products
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> GetProducts();
        Task<Product> GetProduct(int id);
        Task UpdateProduct(Product product);
        Task RemoveProduct(int id);
        Task AddProduct(Product product);
    }
}
