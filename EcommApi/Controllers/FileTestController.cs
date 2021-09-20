using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using EcommApi.Models;
using EcommApi.Models.DTO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EcommApi.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class FileTestController : ControllerBase
    {
        public static IWebHostEnvironment _environment;
        private readonly EcommContext _ctx;
        public FileTestController(IWebHostEnvironment environment, EcommContext ctx)
        {
            _environment = environment;
            _ctx = ctx;
        }

        [HttpPost]
        public IActionResult PostFile([FromForm]FileTestDTO files)
        {
            //var p2 = _environment.ContentRootPath + "/Images";
            var rm = new ReturnModel();
            if (files.File.Length > 0)
            {
                try
                {
                    
                   // var path = _environment.WebRootPath + "\\Uploads\\";
                    var path = _environment.ContentRootPath + "\\Uploads\\";
                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }
                    var fileName = Guid.NewGuid() + files.File.FileName;
                    using (FileStream filestream = System.IO.File.Create(path + fileName))
                    {
                        files.File.CopyTo(filestream);
                        filestream.Flush();
                        var fileTest = new FileTest { FileName = fileName };
                        _ctx.FileTest.Add(fileTest);
                        _ctx.SaveChanges();
                        rm.StatusCode = 1;
                        rm.Message = "successfully saved";
                        return Ok(rm);
                    }
                }
                catch (Exception ex)
                {
                    rm.StatusCode = 0;
                    rm.Message = "Could not saved";
                    return Ok(rm);
                }
            }
            else
            {
                rm.StatusCode = 0;
                rm.Message = "unsuccessfull";
                return Ok(rm);
            }

        }

        [HttpGet]
        public IActionResult GetFiles()
        {
            var data = _ctx.FileTest.ToList();
            return Ok(data);
        }

       
    }
}
