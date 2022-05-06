using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAI_08_EjercicioPresentismo
{
    public class Preceptor : Persona
    {
        private int _legajo;

        public override string Display()
        {
            return _apellido + " - " + _legajo;
        }
        public Preceptor(string nombre, string apellido, int legajo) : base (nombre, apellido)
        {
            _legajo = legajo;
        }
        public Preceptor(Preceptor preceptor) : base (preceptor._nombre, preceptor._apellido)
        {
            _legajo = preceptor._legajo;
        }
    }
}
