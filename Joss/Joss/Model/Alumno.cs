using SQLite;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Joss.Model
{
    public class Alumno
    {
        [PrimaryKey, AutoIncrement]
        public int IdAlum { get; set; }
        [MaxLength(50)]

        public string Nom { get; set; }
        [MaxLength(50)]

        public string Apellido { get; set; }
        [MaxLength(50)]
        public int Edad { get; set; }
        [MaxLength(50)]
        public string Email { get; set; }

        public string Carrera { get; set; }
        public string Sede { get; set; }

    }
}
