using EcommApi.Models;
using EcommApi.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcommApi.Domain
{
    public interface IStateService
    {
         bool Add(State model);
        bool Update(State model);
        State Find(int id);
        bool Delete(int id);
        Task <IEnumerable<State>> ListAsync();
       

        
    }
}
