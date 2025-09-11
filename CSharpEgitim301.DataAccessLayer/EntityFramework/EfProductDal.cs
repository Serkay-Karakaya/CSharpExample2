using CSharpEgitim301.DataAccessLayer.Abstract;
using CSharpEgitim301.DataAccessLayer.Context;
using CSharpEgitim301.DataAccessLayer.Repositories;
using CSharpEgitim301.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpEgitim301.DataAccessLayer.EntityFramework
{
    public class EfProductDal : GenericRepository<Product>, IProductDal
    {
        public List<Object> GetProductByCategory()
        {
            var context = new KampContext();
            var values = context.Products.Select(x => new 
            {
                ProductId = x.ProductId,
                ProductName = x.ProductName,
                ProductStock=x.ProductStock,
                ProductPrice = x.ProductPrice,
                ProductDescription = x.ProductDescription,
                CategoryName = x.Category.CategoryName
            }).ToList();
            return values.Cast<object>().ToList();
        }
    }
}
