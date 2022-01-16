using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using MvcBlogApp.Data.Abstract;
using MvcBlogApp.Data.Concrete.EntityFrameworkCore.Contexts;
using MvcBlogApp.Services.Abstract;
using MvcBlogApp.Services.Concrete;

namespace MvcBlogApp.Services.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection LoadMyServices(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddDbContext<MvcBlogAppContext>();
            serviceCollection.AddScoped<IUnitOfWork, IUnitOfWork>();
            serviceCollection.AddScoped<ICategoryService, CategoryManager>();
            serviceCollection.AddScoped<IArticleService, ArticleManager>();
            return serviceCollection;
        }
    }
}
