using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAI_08_EjercicioPresentismo
{
    public abstract class Alumno : Persona
    {
        private int _registro;

        public Alumno(string nombre, string apellido, int registro) : base (nombre, apellido)
        {
            _registro = registro;
        }
        public override string Display()
        {
            return _nombre + " (" + _registro + ")";
        }
    }
}
