using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EcommApi.Models;
using EcommApi.Models.KeylessModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace EcommApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly EcommContext _ctx;

        public CategoryController(EcommContext ctx)
        {
            _ctx = ctx;
        }

        [HttpGet]
        public ActionResult<IEnumerable<CategoryDisplayModel>> GetCategories()
        {
            string query = @"select c.Id,c.CategoryName,c.Category_Id,IsNull(p.CategoryName,'--None--') As ParentCategory
 from Categories c left
 join Categories p on
c.Category_Id = p.Id";
            var data = _ctx.CategoryDisplayModel.FromSqlRaw(query).ToList();
            return data;
        }

        [HttpPost]
        public IActionResult AddCategory(Category model)
        {
            var rm = new ReturnModel();
            if (!ModelState.IsValid)
            {
                rm.StatusCode = 0;
                rm.Message = "Please pass all the fields";
                return BadRequest(rm);
            }
            try
            {
                _ctx.Categories.Add(model);
                _ctx.SaveChanges();
                rm.StatusCode = 1;
                rm.Message = "Successfull added";
                return Ok(rm);
            }
            catch(Exception ex)
            {
                rm.StatusCode = 0;
                rm.Message = "Server error";
                return BadRequest(rm);
            }
        }

        [HttpPost]
        public IActionResult UpdateCategory(Category model)
        {
            var rm = new ReturnModel();
            if (!ModelState.IsValid)
            {
                rm.StatusCode = 0;
                rm.Message = "Please pass all the fields";
                return Ok(rm);
            }
            try
            {
                _ctx.Categories.Update(model);
                _ctx.SaveChanges();
                rm.StatusCode = 1;
                rm.Message = "Successfull added";
                return Ok(rm);
            }
            catch (Exception ex)
            {
                rm.StatusCode = 0;
                rm.Message = "Server error";
                return Ok(rm);
            }
        }

        [HttpGet]
        public IActionResult DeleteCategory(int id)
        {
            var rm = new ReturnModel();
            try
            {
                var category = _ctx.Categories.Find(id);
                if (category != null)
                {
                    _ctx.Categories.Remove(category);
                    _ctx.SaveChanges();
                    rm.StatusCode = 1;
                    rm.Message = "Deleted successfully";
                    return Ok(rm);
                }
                else
                {
                    rm.StatusCode = 0;
                    rm.Message = "Invalid category id";
                    return Ok(rm);
                }
            }
            catch (Exception ex)
            {
                rm.StatusCode = 0;
                rm.Message = "Server error";
                return Ok(rm);
            }
        }

    }
}
