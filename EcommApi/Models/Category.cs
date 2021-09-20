using System;
using System.Collections.Generic;

#nullable disable

namespace EcommApi.Models
{
    public partial class Category
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public int Category_Id { get; set; }
    }
}
