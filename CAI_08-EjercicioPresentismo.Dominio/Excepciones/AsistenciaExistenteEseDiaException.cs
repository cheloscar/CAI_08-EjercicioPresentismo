using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAI_08_EjercicioPresentismo.Dominio.Excepciones
{
    public class AsistenciaExistenteEseDiaException : Exception
    {
        public AsistenciaExistenteEseDiaException() : base ("Ya existe esta fecha en la lista de asistencia.") { }
    }
}
