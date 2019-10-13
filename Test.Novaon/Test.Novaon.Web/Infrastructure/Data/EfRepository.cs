using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Test.Novaon.Web.Entities;
using Test.Novaon.Web.Interfaces;

namespace Test.Novaon.Web.Infrastructure.Data
{
    public class EfRepository<T, Tkey> : IRepository<T, Tkey> where T : BaseEntity<Tkey>
    {
        protected readonly AppDataContext _dbContext;
        private DbSet<T> _entities;
        private Boolean Disposed;

        public EfRepository(AppDataContext dbContext) => _dbContext = dbContext;


        public virtual void Dispose()
        {
            if (!Disposed)
            {
                if (_dbContext != null)
                {
                    _dbContext.Dispose();
                    Disposed = true;
                }
            }
        }

        public IQueryable<T> Table
        {
            get
            {
                if (_entities == null) _entities = _dbContext.Set<T>();
                return _entities.AsNoTracking();
            }
        }

        public T Add(T entity)
        {
            _dbContext.Set<T>().Add(entity);
            _dbContext.SaveChanges();
            return entity;
        }

        public async Task<T> AddAsync(T entity)
        {
            await _dbContext.Set<T>().AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public void AddRange(IEnumerable<T> entities)
        {
            _dbContext.Set<T>().AddRange(entities);
            _dbContext.SaveChanges();
        }

        public async Task AddRangeAsync(IEnumerable<T> entities)
        {
            await _dbContext.Set<T>().AddRangeAsync(entities);
            await _dbContext.SaveChangesAsync();
        }

        public void Delete(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
            _dbContext.SaveChanges();
        }

        public async Task DeleteAsync(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
            await _dbContext.SaveChangesAsync();
        }

        public virtual T GetById(Tkey Id) => _dbContext.Set<T>().Find(Id);

        public async Task<T> GetByIdAsync(Tkey Id) => await _dbContext.Set<T>().FindAsync(Id);

        public IEnumerable<T> ListAll() => _dbContext.Set<T>().AsNoTracking().AsEnumerable();

        public async Task<IEnumerable<T>> ListAllAsync() => await _dbContext.Set<T>().AsNoTracking().ToListAsync();

        public void Update(T entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            _dbContext.SaveChanges();
        }

        public async Task UpdateAsync(T entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }
    }
}
