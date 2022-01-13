using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MvcBlogApp.Entities.Concrete;
using MvcBlogApp.Shared.Data.Abstract;

namespace MvcBlogApp.Data.Abstract
{
    public interface IArticleRepository : IEntityRepository<Article>
    {
    }
}
