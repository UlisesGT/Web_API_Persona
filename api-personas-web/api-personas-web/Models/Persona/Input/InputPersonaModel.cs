﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api_personas_web.Models.Persona.Input
{
    public class InputPersonaModel
    {
        public int? IdPersonaFisica { get; set; }
        public string Nombre { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public string RFC { get; set; }
        public Nullable<DateTime> FechaNacimiento { get; set; }
        public int? UsuarioAgrega { get; set; }
    }
}
