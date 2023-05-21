using Business.Abstract;
using Business.Constants;
using Core.Utilities.Helpers;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Helpers.FileHelper;
using Entities.DTOs;

namespace Business.Concrete
{
    public class ProductImageManager : IProductImageService
    {
        private IProductImageDal _productImageDal;
        public ProductImageManager(IProductImageDal productImageDal)
        {
            _productImageDal = productImageDal;
        }
        public IDataResult<ProductImage> GetById(int id)
        {
            var result = (_productImageDal.Get(p => p.Id == id));
            if (result != null)
            {
                return new SuccessDataResult<ProductImage>(result);
            }
            return new ErrorDataResult<ProductImage>(Messages.ProductNotFound);
        }
        public IDataResult<List<ProductImage>> GetAll()
        {
            return new SuccessDataResult<List<ProductImage>>(_productImageDal.GetAll());
        }

        public IDataResult<List<ProductImage>> GetImagesByProductId(int productId)
        {
            IResult result = BusinessRules.Run(CheckIfProductImageNull(productId));

            if (result != null)
            {
                return new ErrorDataResult<List<ProductImage>>(result.Message);
            }
            return new SuccessDataResult<List<ProductImage>>
                (CheckIfProductImageNull(productId).Data, Messages.ProductImageListed);

        }

        public IResult Add(IFormFile file, ProductImage productImage)
        {
            IResult result = BusinessRules.Run(CheckIfProductImageLimit(productImage.ProductId));
            if (result != null)
            {
                return result;
            }

            var imageResult = FileHelper.Upload(file);
            if (!imageResult.Success)
            {
                return new ErrorResult(imageResult.Message);
            }

            productImage.ImagePath = imageResult.Message;
            productImage.Date = DateTime.Now;
            _productImageDal.Add(productImage);
            return new SuccessResult(Messages.ProductImageAdded);
        }

        public IResult Update(IFormFile file, ProductImage productImage)
        {
            if (productImage != null)
            {
                IResult result = BusinessRules.Run(CheckIfProductImageLimit(productImage.Id));
                if (result != null)
                {
                    return result;
                }
                productImage.ImagePath = FileHelper.Update(file, _productImageDal.Get(p => p.Id == productImage.Id).ImagePath).Message;
                productImage.Date = DateTime.Now;
                _productImageDal.Update(productImage);
                return new SuccessResult(Messages.ProductImageUpdated);
            }

            return new ErrorResult(Messages.ProductNotFound);
        }
        public IResult Delete(ProductImage productImage)
        {
            if (productImage != null)
            {
                FileHelper.Delete(productImage.ImagePath);
                _productImageDal.Delete(productImage);
                return new SuccessResult(Messages.ProductImageDeleted);
            }
            return new ErrorResult(Messages.ProductNotFound);
        }

        private IResult CheckIfProductImageLimit(int productId)
        {
            var imageCount = _productImageDal.GetAll(c => c.ProductId == productId);
            if (imageCount.Count >= 5)
            {
                return new ErrorResult(Messages.ProductImageLimitAchieved);
            }

            return new SuccessResult();
        }
        private IResult CheckIfProductExist(int productId)
        {
            var result = _productImageDal.GetAll(p => p.ProductId == productId);
            if (result.Count == 0)
            {
                return new ErrorResult(Messages.ProductNotFound);
            }

            return new SuccessResult();
        }

        private IDataResult<List<ProductImage>> CheckIfProductImageNull(int productId)
        {
            try
            {
                IResult resultCheck = BusinessRules.Run(CheckIfProductExist(productId));
                if (resultCheck != null)
                {
                    return new ErrorDataResult<List<ProductImage>>(resultCheck.Message);
                }
                string path = @"\images\logo.png";
                var result = _productImageDal.GetAll(c => c.ProductId == productId).Any((x => !string.IsNullOrEmpty(x.ImagePath)));
                if (!result)
                {
                    List<ProductImage> productImages = new List<ProductImage>();
                    productImages.Add(new ProductImage { ProductId = productId, ImagePath = path, Date = DateTime.Now });
                    return new SuccessDataResult<List<ProductImage>>(productImages);
                }
            }
            catch (Exception exception)
            {
                return new ErrorDataResult<List<ProductImage>>(exception.Message);
            }
            return new SuccessDataResult<List<ProductImage>>(_productImageDal.GetAll(c => c.ProductId == productId));
        }

    }
}