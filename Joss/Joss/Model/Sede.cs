using System;
using System.Collections.Generic;
using System.Text;
using Joss.Data;

namespace Joss.Model
{
    public class Sede
    {
        public long? SedeId { get; set; }
        public string CodigoPostal { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public string Estado { get; set; }
        public string Ciudad { get; set; }
    }
}
