using Microsoft.EntityFrameworkCore;
using MvcBlogApp.Data.Abstract;
using MvcBlogApp.Entities.Concrete;
using MvcBlogApp.Shared.Data.Concrete.EntityFrameworkCore;

namespace MvcBlogApp.Data.Concrete.EntityFrameworkCore.Repositories
{
    public class RoleRepository : EfEntityRepositoryBase<Role>, IRoleRepository
    {
        public RoleRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}
