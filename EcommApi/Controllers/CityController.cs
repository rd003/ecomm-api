using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using EcommApi.Domain;
using EcommApi.Models;
using EcommApi.Models.DTO;
using EcommApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EcommApi.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class CityController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ICityService _cityService;

        public CityController(IMapper mapper,ICityService cityService)
        {
            _mapper = mapper;
            _cityService = cityService;
        }

        [HttpPost]
        public IActionResult AddUpdateCity(CityDTO model)
        {
            var rm = new ReturnModel();
            if (!ModelState.IsValid)
            {
                rm.StatusCode = 0;
                rm.Message = "Invalid data";
                return Ok(rm);
            }
            var city = _mapper.Map<City>(model);
            var result = city.Id==0? _cityService.Add(city):_cityService.Update(city);
            if(result)
            {
                rm.StatusCode = 1;
                rm.Message = "Added/Updated successfully";
            }
            else
            {
                rm.StatusCode = 0;
                rm.Message = "Error";
            }
            return Ok(rm);
        }

        [HttpGet]
        public IActionResult GetCities()
        {
            var data = _cityService.GetCities();
            return Ok(data);
        }

        [HttpGet]
        public IActionResult DeleteCity(int id)
        {
            var result = _cityService.Delete(id);
            var rm = new ReturnModel();
            if(!result)
            {
                rm.StatusCode = 0;
                rm.Message = "error";
            }
            else
            {
                rm.StatusCode = 1;
                rm.Message = "Deleted";
            }
            return Ok(rm);

        }



    }
}
