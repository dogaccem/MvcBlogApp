using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcBlogApp.Data.Abstract
{
    public interface IIUnitOfWork : IAsyncDisposable
    {
        ICategoryRepository CategoryRepository { get; }
        IArticleRepository ArticleRepository { get; }
        ICommentRepository CommentRepository { get; }
        IRoleRepository RoleRepository { get; }
        IUserRepository UserRepository { get; }
        Task<int> SaveAsync();

    }
}
