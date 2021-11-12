using Dominio.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Dominio.Repository
{
    public interface IRepository<TEntity> where TEntity : Entity
    {
        void Add(TEntity entity);

        void Update(TEntity entity);
        void Delete(TEntity entity);

        Task<IEnumerable<TEntity>> GetAsync();

        Task<TEntity> GetAsync(Object Id);




    }
}
