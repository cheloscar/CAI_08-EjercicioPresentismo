using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAI_08_EjercicioPresentismo
{
    public class NoHayFechasCargadasException : Exception
    {
        public NoHayFechasCargadasException() : base ("No se han cargado fechas de asistencia.") { }
    }
}
