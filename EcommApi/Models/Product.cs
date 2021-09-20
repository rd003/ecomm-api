using System;
using System.Collections.Generic;

#nullable disable

namespace EcommApi.Models
{
    public partial class Product
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public string ProductImage { get; set; }
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
    }
}
