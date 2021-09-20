using EcommApi.Domain;
using EcommApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace EcommApi.Services
{
    public class StateService : IStateService
    {
        private readonly EcommContext _ctx;
        public StateService(EcommContext ctx)
        {
            _ctx = ctx;
        }
        public bool Add(State model)
        {
            try
            {
                _ctx.States.Add(model);
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
                var state = Find(id);
                if (state != null)
                {
                    _ctx.States.Remove(state);
                    _ctx.SaveChanges();
                    return true;
                }
                else
                    return false;
            }
            catch(Exception ex)
            {
                return false;
            }
           
        }

        public State Find(int id)
        {
            var data = _ctx.States.Find(id);
            return data;
        }

        public async Task<IEnumerable<State>> ListAsync()
        {
            var data= await _ctx.States.ToListAsync();
            return data;
        }

        public bool Update(State model)
        {
            try
            {
                _ctx.States.Update(model);
                _ctx.SaveChanges();
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }
    }
}
