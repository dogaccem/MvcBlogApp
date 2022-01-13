using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MvcBlogApp.Entities.Concrete;
using MvcBlogApp.Shared.Utilities.Results.Abstract;

namespace MvcBlogApp.Services.Abstract
{
    public interface ICategoryService
    {
        Task<IDataResult<Category>> Get(int categoryId);
        Task<IDataResult<List<Category>>> GetAll();
        Task<IResult> Add(CategoryAddDto categoryAddDto, string createdByName);
        Task<IResult> Update(CategoryUpdateDto categoryUpdateDto, string modifiesByName);
        Task<IResult> Delete(int categoryId);
        Task<IResult> HardDelete(int category);
    }
}
