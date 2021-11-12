using Dominio.Entities;
using Dominio.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.EF.Repository
{
    public class CategoryRepositoryEF : RepositoryEF<Category>, IcategoryRepository
    {
        public CategoryRepositoryEF(DataContext dataContext) : base(dataContext)
        {
        }
    }
}
