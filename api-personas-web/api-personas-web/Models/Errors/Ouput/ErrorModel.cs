using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api_personas_web.Models.Errors.Output
{
    public class ErrorModel
    {
        public int IdError { get; set; }
        public string Status { get; set; }
        public string Code { get; set; }
        public string Title { get; set; }
    }
}
