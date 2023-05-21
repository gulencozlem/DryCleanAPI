using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GetProductImagesDetailController : ControllerBase
    {
        private IProductImageService _productImageService;

        public GetProductImagesDetailController(IProductImageService productImageService)
        {
            _productImageService = productImageService;
        }

        //[HttpGet("getproductimagedetail")]
        //public IActionResult GetProducImageDetail(int productId)
        //{
        //    var result = _productImageService.GetProductImagesDetails(productId);
        //    if (result.Success)
        //    {
        //        return Ok(result);
        //    }
        //    return BadRequest(result);
        //}
    }
}
