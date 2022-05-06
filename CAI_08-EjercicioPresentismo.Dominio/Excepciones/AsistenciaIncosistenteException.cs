using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAI_08_EjercicioPresentismo
{
    public class AsistenciaIncosistenteException : Exception
    {
        public AsistenciaIncosistenteException () : base ("La lista de asistencia ingresada no coincide con la cantidad de alumnos del curso.") { }
    }
}
