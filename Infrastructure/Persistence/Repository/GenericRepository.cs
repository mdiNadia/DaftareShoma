
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Reflection;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using Application.Interfaces;

namespace Infrastructure.Persistence.Repository
{

    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        internal readonly DataContext context;
        internal readonly IConfiguration _configuration;
        internal DbSet<TEntity> dbSet;

        public GenericRepository(DataContext context, IConfiguration configuration)
        {
            this.context = context;
            this._configuration = configuration;
            this.dbSet = context.Set<TEntity>();


        }

        public IQueryable<TEntity> GetQueryList()
        {
            return dbSet;
        }
        public async Task<TEntity> GetByID(object id)
        {
            return await dbSet.FindAsync(id);
        }

        public void Insert(TEntity entity)
        {
            dbSet.Add(entity);
        }
        public void InsertList(List<TEntity> entity)
        {
            dbSet.AddRange(entity);
        }
        public bool Delete(object id)
        {
            try
            {
                TEntity entityToDelete = dbSet.Find(id);
                Delete(entityToDelete);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Delete(TEntity entityToDelete)
        {
            try
            {
                if (context.Entry(entityToDelete).State == EntityState.Detached)
                {
                    dbSet.Attach(entityToDelete);
                }
                dbSet.Remove(entityToDelete);
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool Delete(ICollection<TEntity> entityToDelete)
        {
            try
            {
                dbSet.RemoveRange(entityToDelete);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public void Update(TEntity entityToUpdate)
        {
            PropertyInfo insertDate = entityToUpdate.GetType().GetProperties().FirstOrDefault(c => c.Name == "InsertDate");

            dbSet.Attach(entityToUpdate);
            context.Entry(entityToUpdate).State = EntityState.Modified;
            if (insertDate != null)
                context.Entry(entityToUpdate).Property("InsertDate").IsModified = false;
        }
        public async Task<int> SaveEntityChangeAsync()
        {
            return await context.SaveChangesAsync();
        }



    
    }


}
