using System;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            //ProductManager productManager = new ProductManager(new EfProductDal(), 
            //    new CategoryManager(new EfCategoryDal()));
            //var resultAdd = productManager.Add(new Product
            //{
            //    CategoryId = 2,
            //    Name = "Ceket",
            //    ImagePath = "image",
            //    AddedAt = DateTime.Now,
            //    IsActive = false
            //});
            //if (resultAdd.Success)
            //{
            //    Console.WriteLine(resultAdd.Message);
            //    var result = productManager.GetAll();
            //    foreach (var product in result.Data)
            //    {
            //        Console.WriteLine(product.Name);
            //    }
            //}
            //Console.ReadKey();
        }
    }
}
