using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace api_personas_web.Entities.ModelsSQL
{
    public class sp_ActualizarPersonaFisica_Result
    {
        [Key]
        public int ERROR { get; set; }
        public string MENSAJEERROR { get; set; }
    }
}
