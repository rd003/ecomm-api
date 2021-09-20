using AutoMapper;
using EcommApi.Models;
using EcommApi.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcommApi
{
    public class Automapping : Profile
    {
        public Automapping()
        {
            CreateMap<State, StateDTO>();
            CreateMap<StateDTO, State>();
            CreateMap<City, CityDTO>();
            CreateMap<CityDTO, City>();
            CreateMap<ProductDTO, Product>();
            CreateMap<Product, ProductDTO>();
        }
    }
}
