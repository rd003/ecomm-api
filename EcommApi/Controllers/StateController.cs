using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using EcommApi.Domain;
using EcommApi.Models;
using EcommApi.Models.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EcommApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class StateController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IStateService _stateService;
       public StateController(IMapper mapper,IStateService stateService)
        {
            _mapper = mapper;
            _stateService = stateService;
        }

        [HttpPost]
        public IActionResult AddState(StateDTO model)
        {
            var rm = new ReturnModel();
            if(!ModelState.IsValid)
            {
                rm.StatusCode = 0;
                rm.Message = "Validation error";
                return Ok(rm);
            }
            var data = _mapper.Map<State>(model);
            var result = _stateService.Add(data);
            if(result)
            {
                rm.StatusCode = 1;
                rm.Message = "Added successfully";
            }
            else
            {
                rm.StatusCode = 0;
                rm.Message = "Server error";
            }
            return Ok(rm);
        }

        [HttpGet]
        public async Task<IActionResult> GetStates()
        {
            var resources= await _stateService.ListAsync();
            var data = _mapper.Map<IEnumerable<StateDTO>>(resources);
            return Ok(data);
        }

        [HttpPost]
        public IActionResult UpdateState(StateDTO model)
        {
            var rm = new ReturnModel();
            if (!ModelState.IsValid)
            {
                rm.StatusCode = 0;
                rm.Message = "Validation error";
                return Ok(rm);
            }
            var data = _mapper.Map<State>(model);
            var updated = _stateService.Update(data);
            if (updated)
            {
                rm.StatusCode = 1;
                rm.Message = "Updated successfully";
            }
            else
            {
                rm.StatusCode = 0;
                rm.Message = "Server error";
            }
            return Ok(rm);
              
        }

        [HttpGet]
        public IActionResult DeleteState(int id)
        {
            var rm = new ReturnModel();
            var result = _stateService.Delete(id);
            if(result)
            {
                rm.StatusCode = 1;
                rm.Message = "Deleted successfully";
            }
            else
            {
                rm.StatusCode = 0;
                rm.Message = "Couldn't deleted";
            }
            return Ok(rm);
        }


    }
}
