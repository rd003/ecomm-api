using EcommApi.Models;
using EcommApi.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcommApi.Domain
{
    public interface ICityService
    {
        bool Add(City city);
        bool Update(City city);
        City Find(int id);
        bool Delete(int id);
        IEnumerable<CityDTO> GetCities();
    }
}
