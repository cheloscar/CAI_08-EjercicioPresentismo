using System;
using CAI_08_EjercicioPresentismo.Consola.Validaciones;
using CAI_08_EjercicioPresentismo.Dominio.Excepciones;

namespace CAI_08_EjercicioPresentismo
{
    public class Program
    {
        private static Presentismo _presentismo;
        static int _año;
        static int _mes;
        static int _dia;
        static string _fecha;
        static int _asistencia;
        static bool _asist;

        static Program()
        {
            _presentismo = new Presentismo();
        }
        static void Main(string[] args)
        {
            Preceptor preceptorActivo = _presentismo.GetPreceptorActivo();
            

            string _opcionMenu;
            do
            {
                DesplegarOpcionesMenu();
                _opcionMenu = Console.ReadLine();
                switch (_opcionMenu)
                {
                    case "1":
                        TomarAsistencia(preceptorActivo);
                        break;
                    case "2":
                        MostrarAsistencia();
                        break;
                    case "X":
                        // SALIR
                        break;
                    default:
                        break;
                }
            } while (_opcionMenu != "X");
        }
        static void DesplegarOpcionesMenu()
        {
            Console.WriteLine("1) Tomar Asistencia");
            Console.WriteLine("2) Mostrar Asistencia");
            Console.WriteLine("X: Terminar");
        }
        static void TomarAsistencia(Preceptor preceptor)
        {
            bool _continuar;
            // Ingreso fecha
            _fecha = IngresarFecha();

            // Listar los alumnos
            Console.Clear();
            Console.WriteLine("A continuación se muestra la lista actual de alumnos.");
            foreach (Alumno alumno in _presentismo.GetListaAlumnos())
            {
                Console.WriteLine(alumno.Display());
            }
            // para cada alumno solo preguntar si está presente
            Console.WriteLine("A continuación se le solicitará asistencia para cada alumno regular.");
            List<Asistencia> _listaAsistenciaTemp = new List<Asistencia>();
            foreach (Alumno alumno in _presentismo.GetListaAlumnos())
            {
                
                Asistencia _asistenciaTemp;
                if (alumno.GetType() == typeof(AlumnoRegular))
                {
                    do
                    {
                        Console.WriteLine("Indique si " + alumno.Display() + " estuvo presente.");
                        Console.WriteLine("1 - Presente");
                        Console.WriteLine("2 - Ausente");
                        if (int.TryParse(Console.ReadLine(), out _asistencia) && Validaciones.ValidarLimite(1, 2, _asistencia))
                        {
                            if (_asistencia == 1) { _asist = true; }
                            else { _asist = false; }
                            _continuar = false;
                            _asistenciaTemp = new Asistencia(_fecha, DateTime.Now, preceptor, alumno, _asist);
                            _listaAsistenciaTemp.Add(_asistenciaTemp);
                        }
                        else
                        {
                            Console.WriteLine("Ha ingresado un dato incorrecto, intente de nuevo.");
                            _continuar = true;
                        }
                    } while (_continuar);
                }
                else
                {
                    Console.WriteLine(alumno.Display() + "es un alumno oyente y no toma asistencia.");
                    Console.WriteLine("Presione cualquier tecla para continuar.");
                    Console.ReadKey();
                }
            }
            // agrego la lista de asistencia
            try
            {
                _presentismo.AgregarAsistencia(_listaAsistenciaTemp);
            }
            // Error: mostrar el error y que luego muestre el menu nuevamente
            catch (AsistenciaExistenteEseDiaException ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                Console.WriteLine("Presione cualquier tecla para continuar.");
                Console.ReadKey();
                Console.Clear();
            }
        }
        static void MostrarAsistencia()
        {
            // ingreso fecha
            _fecha = IngresarFecha();
            // muestro el toString de cada asistencia
            List<Asistencia> asistenciaList;
            asistenciaList = _presentismo.GetAsistenciasPorFecha(_fecha);
            if (asistenciaList == null)
                throw new NoHayFechasCargadasException();
            else
            {
                foreach (Asistencia asistencia in asistenciaList)
                {
                    Console.WriteLine(asistencia.ToString());
                }
            }
        }
        static string IngresarFecha()
        {
            bool _continuar;
            do
            {
                Console.Clear();
                Console.WriteLine("A continuación ingrese el año:");
                if (int.TryParse(Console.ReadLine(), out _año) && Validaciones.ValidarLimite(0, 2022, _año))
                {
                    _continuar = false;
                }
                else
                {
                    Console.WriteLine("Ha ingresado un valor incorrecto, intente de nuevo.");
                    _continuar = true;
                }
            } while (_continuar);
            do
            {
                Console.Clear();
                Console.WriteLine("A continuación ingrese el mes:");
                if (int.TryParse(Console.ReadLine(), out _mes) && Validaciones.ValidarLimite(1, 12, _mes))
                {
                    _continuar = false;
                }
                else
                {
                    Console.WriteLine("Ha ingresado un valor incorrecto, intente de nuevo.");
                    _continuar = true;
                }
            } while (_continuar);
            do
            {
                Console.Clear();
                Console.WriteLine("A continuación ingrese el día:");
                if (int.TryParse(Console.ReadLine(), out _dia) && Validaciones.ValidarLimite(1, 31, _dia))
                {
                    _continuar = false;
                }
                else
                {
                    Console.WriteLine("Ha ingresado un valor incorrecto, intente de nuevo.");
                    _continuar = true;
                }
            } while (_continuar);
            return _año.ToString() + "-" + _mes.ToString() + "-" + _dia.ToString();
        }
    }

}