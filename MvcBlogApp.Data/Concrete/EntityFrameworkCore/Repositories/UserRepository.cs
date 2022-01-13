using Microsoft.EntityFrameworkCore;
using MvcBlogApp.Data.Abstract;
using MvcBlogApp.Entities.Concrete;
using MvcBlogApp.Shared.Data.Concrete.EntityFrameworkCore;

namespace MvcBlogApp.Data.Concrete.EntityFrameworkCore.Repositories
{
    public class UserRepository : EfEntityRepositoryBase<User>, IUserRepository
    {
        public UserRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}
