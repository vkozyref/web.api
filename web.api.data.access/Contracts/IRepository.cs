using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace web.api.data.access.Contracts
{
    public interface IRepository<T> where T : class
    {
        Task Add(T item);
        Task Remove(Func<T, bool> criteria);
        Task<T> Get(Func<T, bool> criteria);
        Task<IEnumerable<T>> GetMany(Func<T, bool> criteria);
        Task Update(Func<T, bool> criteria, Action<T> action);
    }
}
