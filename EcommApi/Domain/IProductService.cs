using EcommApi.Models;
using EcommApi.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcommApi.Domain
{
    public interface IProductService
    {
        bool AddUpdate(Product model);
        bool Delete(int id);
        IEnumerable<ProductDTO> AllProducts();
    }
}
