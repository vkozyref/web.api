using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace web.api.business.logic.Contracts.Products
{
    public interface IProductService
    {
        Task GetProducts();

    }
}
