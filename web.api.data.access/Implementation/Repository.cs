using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using web.api.data.access.Contracts;

namespace web.api.data.access.Implementation
{
    public class Repository<T> : IRepository<T> where T : class, IDisposable
    {
        private readonly DbContext _context;
        private readonly IDbSet<T> _dbSet;
        private bool disposed = false;       

        public Repository()
        {
            //_context = new Context();
            //_dbSet = _context.Set<T>();

        }

        public async Task Add(T item)
        {
            _dbSet.Add(item);
            await _context.SaveChangesAsync();
        }

        public async Task<T> Get(Func<T, bool> criteria)
        {
            return _dbSet.FirstOrDefault(criteria);
        }

        public async Task<IEnumerable<T>> GetMany(Func<T, bool> criteria)
        {
            return new List<T>();
            //return _dbSet.Where(criteria);
        }

        public async Task Remove(Func<T, bool> criteria)
        {
            var entity = _dbSet.FirstOrDefault(criteria);
            if (entity == null)
            {
                throw new Exception("Entity not found");
            }
            _dbSet.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Func<T, bool> criteria, Action<T> action)
        {
            var entity = _dbSet.FirstOrDefault(criteria);
            if (entity == null)
            {
                throw new Exception("Entity not found");
            }
            action.Invoke(entity);
            _dbSet.Attach(entity);
            var entry = _context.Entry(entity);
            entry.State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
