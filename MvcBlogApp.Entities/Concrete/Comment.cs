using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MvcBlogApp.Shared.Entities.Abstract;

namespace MvcBlogApp.Entities.Concrete
{
    public class Comment : EntityBase, IEntity
    {
        public string Text { get; set; }
        public int ArticleId { get; set; }
        public Article Article { get; set; }
    }
}
