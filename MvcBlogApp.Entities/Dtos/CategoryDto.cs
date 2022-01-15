using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MvcBlogApp.Entities.Concrete;
using MvcBlogApp.Shared.Entities.Abstract;

namespace MvcBlogApp.Entities.Dtos
{
    public class CategoryDto : DtoGetBase
    {
        public Category Category { get; set; }
    }
}
