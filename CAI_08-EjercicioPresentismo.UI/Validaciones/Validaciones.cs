using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAI_08_EjercicioPresentismo.Consola.Validaciones
{
    public static class Validaciones
    {
        public static bool ValidarLimite(int min, int max, int valor)
        {
            if (valor < min || valor > max) { return false; }
            return true;
        }
    }
}
