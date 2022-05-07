using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CAI_08_EjercicioPresentismo
{
    public class Asistencia
    {
        private string _fechaReferencia;
        private DateTime _fechaHoraReal;
        private Preceptor _preceptor;
        private Alumno _alumno;
        private bool _estaPresente;

        public Asistencia(string fechaReferencia, DateTime fechaHoraReal, Preceptor preceptor, Alumno alumno, bool estaPresente)
        {
            _fechaReferencia = fechaReferencia;
            _fechaHoraReal = fechaHoraReal;
            _preceptor = preceptor;
            _alumno = alumno;
            _estaPresente = estaPresente;
        }

        public override string ToString()
        {
            return $"{_fechaReferencia} {_alumno.ToString()} está presente: {_estaPresente.ToString()} por {_preceptor.ToString()} registrado el {_fechaHoraReal.ToString("yyyyMMdd")}";
        }
        public string FechaReferencia()
        {
            return _fechaReferencia;
        }
    }
}
