using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api_personas_web.Models.ResponsesCollection.Output
{
    public class ResponseModel
    {
        public int Codigo { get; set; }
        public string Mensaje { get; set; }
        public object Objeto { get; set; }
        public string Type { get; set; }
    }
}
