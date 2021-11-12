using Dominio.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Dominio.Repository
{
    public interface IProdutoRepository : IRepository<Products>
    {
        Task<IEnumerable<Products>> GetByNameAsync(String name);

        Task<IEnumerable<Products>> GetAllWithCategoryAsync();

        Task<Products> GetByIdWithCategoryAsync(int id);



    }
}
