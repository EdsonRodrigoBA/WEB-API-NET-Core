using Dominio.Entities;
using Dominio.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Data.EF.Repository
{
    public class RepositoryEF<TEntity> : IRepository<TEntity> where TEntity : Entity
    {
        private readonly DataContext _dataContext;

        protected DbSet<TEntity> _dbSet { get; }

        public RepositoryEF(DataContext dataContext)
        {
            this._dataContext = dataContext;
            _dbSet = dataContext.Set<TEntity>();
        }
        public void Add(TEntity entity)
        {
            _dbSet.Add(entity);
            _dataContext.SaveChanges();
        }

        public void Delete(TEntity entity)
        {
            _dbSet.Remove(entity);
            _dataContext.SaveChanges();
        }
        public void Update(TEntity entity)
        {
            _dbSet.Update(entity);
            _dataContext.SaveChanges();
        }

        public async Task<IEnumerable<TEntity>> GetAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<TEntity> GetAsync(object Id)
        {
            return await _dbSet.FindAsync(Id);
        }
    }
}
