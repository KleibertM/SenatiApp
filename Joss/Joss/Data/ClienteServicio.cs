using Joss.Model;
using System;
using System.Collections.Generic;
using System.Text;
using Joss.Data;

namespace Joss.Data
{
    internal class ClienteServicio
    {
        public static IEnumerable<Cliente> GetClientes()
        {
            return new List<Cliente>()
            {
                new Cliente {Nombre="Sede ESCUELA DE POSTGRADO TECH SENATI", 
                    Direccion="Av. 28 de Julio 715, Lima", CodigoPostal="15019", Ciudad="Lima", Estado="PE"},
                new Cliente {Nombre="Sede Independencia", 
                    Direccion="Av. Alfredo Mendiola #3540, Lima", CodigoPostal="15123", Ciudad="Lima", Estado="PE"},
                new Cliente {Nombre="Sede Huaura", 
                    Direccion="Av. San Martín #510 y Av. Coronel Portillo #517, Lima", CodigoPostal="Comas", Ciudad="Lima", Estado="PE"},
                new Cliente {Nombre="Sede Cercado de Lima",
                    Direccion="Av. 28 de Julio #715, Lima", CodigoPostal="15086", Ciudad="Lima", Estado="PE"},
                new Cliente {Nombre="Sede Huacho", 
                    Direccion="Ca.San Román #340, Lima", CodigoPostal="15135", Ciudad="Huacho", Estado="PE"},
            };
        }

       
    }
}
