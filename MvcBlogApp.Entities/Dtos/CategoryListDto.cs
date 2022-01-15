using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using MvcBlogApp.Entities.Concrete;
using MvcBlogApp.Shared.Entities.Abstract;

namespace MvcBlogApp.Entities.Dtos
{
    public class CategoryListDto : DtoGetBase
    {
        public IList<Category> Categories { get; set; }
    }
}
