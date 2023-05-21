using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using Entities.Concrete;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductImagesController : ControllerBase
    {
        IProductImageService _productImageService;

        public ProductImagesController(IProductImageService productImageService)
        {
            _productImageService = productImageService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _productImageService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _productImageService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getimagesbyproductid")]
        public IActionResult GetImagesByProductId(int productId)
        {
            var result = _productImageService.GetImagesByProductId(productId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getfilebyid")]
        public IActionResult GetFileById(int id)
        {
            if (id > 0)
            {
                var result = _productImageService.GetById(id);
                if (result.Data != null)
                {
                    if (result.Data.ImagePath != null)
                    {
                        var b = System.IO.File.ReadAllBytes(Environment.CurrentDirectory + "\\wwwroot\\" + result.Data.ImagePath);
                        return File(b, "image/jpeg");
                    }
                    else
                    {
                        var path = Environment.CurrentDirectory + "\\wwwroot\\images\\logo.png";
                        var b = System.IO.File.ReadAllBytes(path);
                        return File(b, "image/jpeg");
                    }
                }

                return BadRequest();
            }

            return BadRequest();
        }

        [HttpPost("add")]
        public IActionResult Add([FromForm(Name = ("Image"))] IFormFile file, [FromForm] ProductImage productImage)
        {
            var result = _productImageService.Add(file, productImage);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("update")]
        public IActionResult Update([FromForm(Name = ("Image"))] IFormFile file, [FromForm] int Id)
        {
            var productImage = _productImageService.GetById(Id).Data;
            var result = _productImageService.Update(file, productImage);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete([FromForm(Name = ("Id"))] int Id)
        {
            var carImage = _productImageService.GetById(Id).Data;

            var result = _productImageService.Delete(carImage);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
