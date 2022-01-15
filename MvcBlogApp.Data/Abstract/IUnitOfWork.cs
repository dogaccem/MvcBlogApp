using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcBlogApp.Data.Abstract
{
    public interface IUnitOfWork : IAsyncDisposable
    {
        ICategoryRepository Categories { get; }
        IArticleRepository Articles { get; }
        ICommentRepository Comments { get; }
        IRoleRepository Roles { get; }
        IUserRepository Users { get; }
        Task<int> SaveAsync();

    }
}
