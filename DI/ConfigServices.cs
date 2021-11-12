using Data.EF;
using Data.EF.Repository;
using Dominio.Repository;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace DI
{
    public static class ConfigServices
    {

        public static void AddDependecies(this IServiceCollection services)
        {
            //instancia unica em todo projeto
            //services.AddSingleton<DataContext>();

            //Ciclo de vida por requisição
            services.AddScoped<DataContext>();

            services.AddTransient<IProdutoRepository, ProdutoRepositoryEF>();
            services.AddTransient<IcategoryRepository, CategoryRepositoryEF>();

        }
    }
}
