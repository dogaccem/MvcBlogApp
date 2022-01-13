using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MvcBlogApp.Data.Abstract;
using MvcBlogApp.Data.Concrete.EntityFrameworkCore.Contexts;
using MvcBlogApp.Data.Concrete.EntityFrameworkCore.Repositories;

namespace MvcBlogApp.Data.Concrete
{
    public class UnitOfWork : IIUnitOfWork
    {
        private readonly MvcBlogAppContext _context;
        private ArticleRepository _articleRepository;
        private CategoryRepository _categoryRepository;
        private CommentRepository _commentRepository;
        private RoleRepository _roleRepository;
        private UserRepository _userRepository;

        public UnitOfWork(MvcBlogAppContext context)
        {
            _context = context;
        }


        public ICategoryRepository CategoryRepository => _categoryRepository ?? new CategoryRepository(_context);
        public IArticleRepository ArticleRepository => _articleRepository ?? new ArticleRepository(_context);
        public ICommentRepository CommentRepository => _commentRepository ?? new CommentRepository(_context);
        public IRoleRepository RoleRepository => _roleRepository ?? new RoleRepository(_context);
        public IUserRepository UserRepository => _userRepository ?? new UserRepository(_context);
        public async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public async ValueTask DisposeAsync()
        {
            await _context.DisposeAsync();
        }
    }
}
