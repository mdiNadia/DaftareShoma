using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        IQueryable<TEntity> GetQueryList();
        Task<TEntity> GetByID(object id);
        void Insert(TEntity entity);
        void InsertList(List<TEntity> entity);
        bool Delete(object id);
        bool Delete(TEntity entityToDelete);
        bool Delete(ICollection<TEntity> entityToDelete);
        void Update(TEntity entityToUpdate);
        Task<int> SaveEntityChangeAsync();

    }

}
