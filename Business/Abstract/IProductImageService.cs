using System.Collections.Generic;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.AspNetCore.Http;

namespace Business.Abstract
{
    public interface IProductImageService
    {
        IDataResult<List<ProductImage>> GetAll();
        IDataResult<ProductImage> GetById(int id);
        IDataResult<List<ProductImage>> GetImagesByProductId(int productId);
        IResult Add(IFormFile file, ProductImage productImage);
        IResult Delete(ProductImage productImage);
        IResult Update(IFormFile file, ProductImage productId);  
    }
}