﻿using System;
using System.Collections.Generic;
using System.Text;
using Joss.Data;

namespace Joss.Model
{
    public class Cliente
    {
        public long? ClienteId { get; set; }
        public string CodigoPostal { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public string Estado { get; set; }
        public string Ciudad { get; set; }
    }
}
