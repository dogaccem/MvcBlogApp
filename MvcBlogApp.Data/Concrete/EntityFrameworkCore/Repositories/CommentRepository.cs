using Microsoft.EntityFrameworkCore;
using MvcBlogApp.Data.Abstract;
using MvcBlogApp.Entities.Concrete;
using MvcBlogApp.Shared.Data.Concrete.EntityFrameworkCore;

namespace MvcBlogApp.Data.Concrete.EntityFrameworkCore.Repositories
{
    class CommentRepository : EfEntityRepositoryBase<Comment>, ICommentRepository
    {
        public CommentRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}
