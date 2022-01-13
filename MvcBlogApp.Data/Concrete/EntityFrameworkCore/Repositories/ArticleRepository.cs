using Microsoft.EntityFrameworkCore;
using MvcBlogApp.Data.Abstract;
using MvcBlogApp.Entities.Concrete;
using MvcBlogApp.Shared.Data.Concrete.EntityFrameworkCore;

namespace MvcBlogApp.Data.Concrete.EntityFrameworkCore.Repositories
{
    public class ArticleRepository : EfEntityRepositoryBase<Article>, IArticleRepository
    {
        public ArticleRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}
