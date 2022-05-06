using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAI_08_EjercicioPresentismo
{
    public class AlumnoRegular : Alumno
    {
        private string _email;
        public AlumnoRegular(string nombre, string apellido, int registro, string email) : base (nombre, apellido, registro)
        {
            _email = email;
        }
    }
}
