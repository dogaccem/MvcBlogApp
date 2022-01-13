using Microsoft.EntityFrameworkCore;
using MvcBlogApp.Data.Abstract;
using MvcBlogApp.Entities.Concrete;
using MvcBlogApp.Shared.Data.Concrete.EntityFrameworkCore;

namespace MvcBlogApp.Data.Concrete.EntityFrameworkCore.Repositories
{
    public class CategoryRepository : EfEntityRepositoryBase<Category>, ICategoryRepository
    {
        public CategoryRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}
