using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MvcBlogApp.Data.Abstract;
using MvcBlogApp.Entities.Concrete;
using MvcBlogApp.Entities.Dtos;
using MvcBlogApp.Services.Abstract;
using MvcBlogApp.Shared.Utilities.Results.Abstract;
using MvcBlogApp.Shared.Utilities.Results.ComplexTypes;
using MvcBlogApp.Shared.Utilities.Results.Concrete;

namespace MvcBlogApp.Services.Concrete
{
    public class ArticleManager : IArticleService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ArticleManager(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IDataResult<ArticleDto>> Get(int articleId)
        {
            var article = await _unitOfWork.Articles.GetAsync(a => a.Id == articleId, a => a.User,a => a.Category);
            if (article != null)
            {
                return new DataResult<ArticleDto>(ResultStatus.Success, new ArticleDto
                {
                    Article = article,
                    ResultStatus = ResultStatus.Success
                });
            }

            return new DataResult<ArticleDto>(ResultStatus.Error, "Böyle bir makale bulunamadı", null);
        }

        public async Task<IDataResult<ArticleListDto>> GetAll()
        {
            var articles = await _unitOfWork.Articles.GetAllAsync(null, a => a.Category, a => a.User);
            if (articles.Count > -1)
            {
                return new DataResult<ArticleListDto>(ResultStatus.Success, new ArticleListDto
                {
                    Articles = articles,
                    ResultStatus = ResultStatus.Success
                });
            }

            return new DataResult<ArticleListDto>(ResultStatus.Error, "makaleler bulanamadı", null);
        }

        public async Task<IDataResult<ArticleListDto>> GetAllByNonDeleted()
        {
            var articles = await _unitOfWork.Articles.GetAllAsync(a => !a.IsDeleted, a => a.Category,a => a.User);
            if (articles.Count > -1)
            {
                return new DataResult<ArticleListDto>(ResultStatus.Success, new ArticleListDto
                {
                    Articles = articles,
                    ResultStatus = ResultStatus.Success
                });
            }

            return new DataResult<ArticleListDto>(ResultStatus.Error, "makaleler bulanamadı", null);
        }

        public async Task<IDataResult<ArticleListDto>> GetAllByNonDeletedAndActive()
        {
            var articles = await _unitOfWork.Articles.GetAllAsync(a => !a.IsDeleted && a.IsActive, a => a.Category, a => a.User);
            if (articles.Count > -1)
            {
                return new DataResult<ArticleListDto>(ResultStatus.Success, new ArticleListDto
                {
                    Articles = articles,
                    ResultStatus = ResultStatus.Success
                });
            }

            return new DataResult<ArticleListDto>(ResultStatus.Error, "makaleler bulanamadı", null);
        }

        public async Task<IDataResult<ArticleListDto>> GetAllByCategory(int categoryId)
        {
            var result =await _unitOfWork.Categories.AnyAsync(c => c.Id == categoryId);
            if (result)
            {
                var articles =
                    await _unitOfWork.Articles.GetAllAsync(a => a.CategoryId == categoryId && !a.IsDeleted && a.IsActive, a => a.Category, a => a.User);
                if (articles.Count > -1)
                {
                    return new DataResult<ArticleListDto>(ResultStatus.Success, new ArticleListDto
                    {
                        Articles = articles,
                        ResultStatus = ResultStatus.Success
                    });
                }

                return new DataResult<ArticleListDto>(ResultStatus.Error, "makaleler bulanamadı", null);
            }

            return new DataResult<ArticleListDto>(ResultStatus.Error, "kategori yok", null);
        }

        public async Task<IResult> Add(ArticleAddDto articleAddDto, string createdByName)
        {
            var article = _mapper.Map<Article>(articleAddDto);
            article.CreatedByName = createdByName;
            article.ModifiedByName = createdByName;
            article.UserId = 1;

            await _unitOfWork.Articles.AddAsync(article);
            await _unitOfWork.SaveAsync();
            return new Result(ResultStatus.Success, $"{articleAddDto.Title} başlıklı makale başarıyla eklenmiştir");
        }

        public async Task<IResult> Update(ArticleUpdateDto articleUpdateDto, string modifiedByName)
        {
            var article = _mapper.Map<Article>(articleUpdateDto);
            article.ModifiedByName = modifiedByName;

            await _unitOfWork.Articles.UpdateAsync(article);
            await _unitOfWork.SaveAsync();
            return new Result(ResultStatus.Success, $"{articleUpdateDto.Title} başlıklı makale başarıyla Güncellenmiştir");
        }

        public async Task<IResult> Delete(int articleId, string modifiedByName)
        {
            var article = await _unitOfWork.Articles.GetAsync(a => a.Id == articleId);
            if (article != null)
            {
                article.IsDeleted = true;
                article.ModifiedByName = modifiedByName;
                article.ModifiedDate = DateTime.Now;
                await _unitOfWork.Articles.UpdateAsync(article);
                await _unitOfWork.SaveAsync();
                return new Result(ResultStatus.Success, "makale başarılı bir şekilde silinmiştir");
            }
            return new Result(ResultStatus.Error, "makale bulanamadı", null);
        }

        public async Task<IResult> HardDelete(int articleId)
        {
            var article = await _unitOfWork.Articles.GetAsync(a => a.Id == articleId);
            if (article != null)
            {
                await _unitOfWork.Articles.DeleteAsync(article);
                await _unitOfWork.SaveAsync();
                return new Result(ResultStatus.Success, "makale başarılı bir şekilde veritabanından silinmiştir");
            }
            return new Result(ResultStatus.Error, "makale bulanamadı", null);
        }
    }
}
