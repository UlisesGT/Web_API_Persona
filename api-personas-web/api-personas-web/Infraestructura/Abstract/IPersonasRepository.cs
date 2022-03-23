using api_personas_web.Models.Persona.Input;
using api_personas_web.Models.Persona.Output;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api_personas_web.Infraestructura.Abstract
{
    public interface IPersonasRepository
    {
        Task<Dictionary<int, object>> AddUser(InputPersonaModel model); 
         Task<Dictionary<int, object>> UpdateUser(InputPersonaModel model);
        Task<Dictionary<int, object>> DeleteUser(int IdPersonaFisica);
        Task<Dictionary<int, object>> GetUsers();
    }
}
