﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MvcBlogApp.Entities.Concrete;
using MvcBlogApp.Shared.Entities.Abstract;
using MvcBlogApp.Shared.Utilities.Results.ComplexTypes;

namespace MvcBlogApp.Entities.Dtos
{
    public class ArticleDto : DtoGetBase
    {
        public Article Article { get; set; }
    }
}
