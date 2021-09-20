using System;
using System.Collections.Generic;

#nullable disable

namespace EcommApi.Models
{
    public partial class City
    {
        public int Id { get; set; }
        public string CityName { get; set; }
        public int StateId { get; set; }

    }
}
