using EcommApi.Domain;
using EcommApi.Models;
using EcommApi.Models.DTO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcommApi.Services
{
    public class CityService : ICityService
    {
        public readonly EcommContext _ctx;
        public CityService(EcommContext ctx)
        {
            _ctx = ctx;
        }
        public bool Add(City city)
        {
            try
            {
                _ctx.Add(city);
                _ctx.SaveChanges();
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }

        public bool Delete(int id)
        {
            try
            {
                var city = Find(id);
                if (city == null)
                    return false;
                else
                {
                    _ctx.Cities.Remove(city);
                    _ctx.SaveChanges();
                    return true;

                }
            }
            catch(Exception ex)
            {
                return false;
            }
        }

        public City Find(int id)
        {
          return  _ctx.Cities.Find(id);
        }

        public  IEnumerable<CityDTO> GetCities()
        {
           
            var data =( from city in _ctx.Cities
                       join state in _ctx.States
on city.StateId equals state.Id
                       select new CityDTO
                       {
                           Id = city.Id,
                           StateId = city.StateId,
                           StateName = state.StateName,
                           CityName = city.CityName
                       }).ToList();
            return data;
            
        }

        public bool Update(City city)
        {
            try
            {
                _ctx.Cities.Update(city);
                _ctx.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
