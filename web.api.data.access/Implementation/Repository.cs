using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using web.api.data.access.Contracts;

namespace web.api.data.access.Implementation
{
    public class Repository<T> : IRepository<T> where T : class
    {
        public async Task Add(T item)
        {
            throw new NotImplementedException();
        }

        public async Task<T> Get(Func<T, bool> criteria)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<T>> GetMany(Func<T, bool> criteria)
        {
            await Task.Yield();
            return new List<T>
            {

            };
        }

        public async Task Remove(Func<T, bool> criteria)
        {
            throw new NotImplementedException();
        }

        public async Task Update(Func<T, bool> criteria, Action<T> action)
        {
            throw new NotImplementedException();
        }
    }
}
