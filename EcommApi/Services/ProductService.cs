using EcommApi.Domain;
using EcommApi.Models;
using EcommApi.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcommApi.Services
{
    public class ProductService : IProductService
    {
        private readonly EcommContext _ctx;
        public ProductService(EcommContext ctx)
        {
            _ctx = ctx;
        }



        public bool AddUpdate(Product model)
        {
            try
            {
                if (model.Id == 0)
                    _ctx.Products.Add(model);
                else
                    _ctx.Products.Update(model);
                _ctx.SaveChanges();
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }

        public IEnumerable<ProductDTO> AllProducts()
        {
            var data = (from p in _ctx.Products join c in _ctx.Categories
                        on p.CategoryId equals c.Id
                        select new ProductDTO
                        {
                            Id=p.Id,
                            Price=p.Price,
                            ProductName=p.ProductName,
                            ProductImage=p.ProductImage,
                            CategoryId=c.Id,
                            CategoryName=c.CategoryName

                        }
                        ).ToList();
            return data;
        }

        public bool Delete(int id)
        {
            try
            {
                var product = _ctx.Products.Find(id);
                _ctx.Products.Remove(product);
                _ctx.SaveChanges();
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }
    }
}
