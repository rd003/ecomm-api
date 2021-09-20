using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcommApi.Models.KeylessModels
{
    [Keyless]
    public class CategoryDisplayModel
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public int Category_Id { get; set; }
        public string ParentCategory { get; set; }
    }
}
