using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CAI_08_EjercicioPresentismo.Dominio.Excepciones;


namespace CAI_08_EjercicioPresentismo
{
    public class Presentismo
    {
        private List<Preceptor> _preceptores;
        private List<Alumno> _alumnos;
        private List<Asistencia> _asistencias;
        private List<string> _fechas;

        private bool AsistenciaRegistrada(string fecha)
        {
            foreach (string fecha2 in _fechas)
            {
                if (fecha2 == fecha) { return true; }
            }
            return false;
        }
        private int GetCantidadAlumnosRegulares()
        {
            if (_alumnos.Count == 0)
                throw new NoHayAlumnosCargadosException();
            int _cantAlumnos = 0;
            foreach (Alumno alumno in _alumnos)
            {
                if (alumno.GetType() == typeof(AlumnoRegular))
                {
                    _cantAlumnos++;
                }
            }
            return _cantAlumnos;
        }
        public Preceptor GetPreceptorActivo()
        {
            return _preceptores.FirstOrDefault();
        }
        public List<Alumno> GetListaAlumnos()
        {
            return _alumnos;
        }
        public void AgregarAsistencia(List<Asistencia> listaAsistencia)
        {
            if (listaAsistencia.Count == 0)
                throw new NoHayFechasCargadasException();
            if (AsistenciaRegistrada(listaAsistencia[0].FechaReferencia()))
                throw new AsistenciaExistenteEseDiaException();
            if (GetCantidadAlumnosRegulares() != listaAsistencia.Count())
                throw new AsistenciaIncosistenteException();
            _fechas.Add(listaAsistencia[0].FechaReferencia());
            foreach(Asistencia asistencia in listaAsistencia)
            {
                _asistencias.Add(asistencia);
            }
        }
        public Presentismo()
        {
            _alumnos = new List<Alumno>();
            _asistencias = new List<Asistencia>();
            _preceptores = new List<Preceptor>();
            _fechas = new List<string>();

            _alumnos.Add(new AlumnoRegular("Carlos", "Juarez", 123, "cjua@gmail.com"));
            _alumnos.Add(new AlumnoRegular("Carla", "Jaime", 124, "cjai@gmail.com"));
            _alumnos.Add(new AlumnoOyente("Ramona", "Vals", 320));
            _alumnos.Add(new AlumnoOyente("Alejandro", "Medina", 321));

            _preceptores.Add(new Preceptor("Jorgelina", "Ramos", 5));
        }
        public List<Asistencia> GetAsistenciasPorFecha(string fecha)
        {
            if (AsistenciaRegistrada(fecha))
            {
                List<Asistencia> asistenciaList = new List<Asistencia>();
                foreach (Asistencia asistencia in _asistencias)
                {
                    if (asistencia.FechaReferencia() == fecha)
                    {
                        asistenciaList.Add(asistencia);
                    }
                }
                return asistenciaList;
            }
            else
            {
                return null;
            }
        }
    }
}
