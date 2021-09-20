using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EcommApi.Models.DTO
{
    public class StateDTO
    {
        public int Id { get; set; }
        [Required]
        public string StateName { get; set; }
    }
}
