using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using EcommApi.Domain;
using EcommApi.Models;
using EcommApi.Models.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EcommApi.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IProductService _productService;
        public ProductController(IMapper mapper, IProductService productService)
        {
            _mapper = mapper;
            _productService = productService;
        }

        [HttpPost]
        public IActionResult AddUpdate(ProductDTO model)
        {
            var rm = new ReturnModel();
            if (!ModelState.IsValid)
            {
                rm.StatusCode = 0;
                rm.Message = "Please pass all the fields";
                return Ok(rm);
            }
            var product = _mapper.Map<Product>(model);
            var result = _productService.AddUpdate(product);
            if (result)
            {
                rm.StatusCode = 1;
                rm.Message = "Saved successfully";
            }
            else
            {
                rm.StatusCode = 0;
                rm.Message = "Could not saved";
            }
            return Ok(rm);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var result = _productService.Delete(id);
            var rm = new ReturnModel();
            if (result)
            {
                rm.StatusCode = 1;
                rm.Message = "Deleted successfully";
            }
            else
            {
                rm.StatusCode = 0;
                rm.Message = "Could not deleted";
            }
            return Ok(rm);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_productService.AllProducts());
        }


    }
}
