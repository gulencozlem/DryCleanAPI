using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Context;
using Entities.Concrete;
using Entities.DTOs;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfProductImageDal : EfEntityRepositoryBase<ProductImage, DryCleanContext>, IProductImageDal
    {
        public List<ProductImagesDto> GetProductImagesDetails()
        {
            using (DryCleanContext context = new DryCleanContext())
            {
                var result = from p in context.Products
                    join pi in context.ProductImages
                        on p.Id equals pi.ProductId
                    select new ProductImagesDto()
                    {
                        ProductId = p.Id,
                        ProductName = p.Name,
                        ImagePath = pi.ImagePath,
                        Date = pi.Date
                    };
                return result.ToList();
            }
        }
    }
}
