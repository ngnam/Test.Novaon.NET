using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Test.Novaon.Web.Interfaces
{
    public interface IRepository<T, Tkey> where T : IEntity<Tkey>
    {
        T GetById(Tkey Id);
        IEnumerable<T> ListAll();
        T Add(T entity);
        void AddRange(IEnumerable<T> entities);
        void Update(T entity);
        void Delete(T entity);
        IQueryable<T> Table { get; }
        Task<T> GetByIdAsync(Tkey Id);
        Task<IEnumerable<T>> ListAllAsync();
        Task<T> AddAsync(T entity);
        Task AddRangeAsync(IEnumerable<T> entities);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
    }
}
