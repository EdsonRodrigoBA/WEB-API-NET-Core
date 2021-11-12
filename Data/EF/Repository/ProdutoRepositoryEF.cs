using Dominio.Entities;
using Dominio.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.EF.Repository
{
    public class ProdutoRepositoryEF : RepositoryEF<Products>, IProdutoRepository
    {
        public ProdutoRepositoryEF(DataContext dataContext) : base(dataContext)
        {
        }

        public async Task<IEnumerable<Products>> GetAllWithCategoryAsync()
        {
            return await _dbSet.Include(c => c.Category).ToListAsync();
        }

        public async Task<Products> GetByIdWithCategoryAsync(int id)
        {
            return await _dbSet.Include(c => c.Category).FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<IEnumerable<Products>> GetByNameAsync(string name)
        {
            return await _dbSet.Where(p => p.name.Contains(name)).ToListAsync();
        }
    }
}
