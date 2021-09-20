using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcommApi.Models.DTO
{
    public class FileTestDTO
    {
        public int Id { get; set; }
        public string FileName { get; set; }
        public IFormFile File { get; set; }
        
    }
}
