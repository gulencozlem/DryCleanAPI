using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;

namespace Entities.DTOs
{
    public class ProductImagesDto : IDto
    {
        public int ProductId { get; set; }  
        public string ProductName { get; set; }
        public string ImagePath { get; set; }
        public DateTime Date { get; set; }
    }
}
