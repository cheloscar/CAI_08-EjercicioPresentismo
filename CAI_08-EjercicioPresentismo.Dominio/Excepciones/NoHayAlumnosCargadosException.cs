using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAI_08_EjercicioPresentismo.Dominio.Excepciones
{
    public class NoHayAlumnosCargadosException : Exception
    {
        public NoHayAlumnosCargadosException() : base ("No hay alumnos cargados.") { }
    }
}
