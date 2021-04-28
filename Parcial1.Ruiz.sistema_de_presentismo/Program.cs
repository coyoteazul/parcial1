using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using lib_Presentismo;
using consoleGetters;


namespace Parcial1.Ruiz.sistema_de_presentismo
{
    public class Program
    {
        private static Presentismo _presentismo;

        static Program()
        {
            _presentismo = new Presentismo();
        }
        // modificar lo que corresponda para que solo finalice el
        // programa si el usuario presiona X en el menú
        static void Main(string[] args)
        {
            Preceptor preceptorActivo = _presentismo.GetPreceptorActivo();

            bool continuar = true;
            while (continuar) { 
                DesplegarOpcionesMenu();
                string opcionMenu = Getters.GetStringInput(""); // mensaje vacio porque las opciones las muetra DesplegarOpcionesMenu
                switch (opcionMenu)
                {
                    case "1":
                        TomarAsistencia(preceptorActivo);
                        break;
                    case "2":
                        MostrarAsistencia();
                        break;
                    case "X":
                        // SALIR
                        continuar = false;
                        break;
                    default:
                        break;
                }
            }
        }
        static void DesplegarOpcionesMenu()
        {
            Console.WriteLine("1) Tomar Asistencia");
            Console.WriteLine("2) Mostrar Asistencia");
            Console.WriteLine("X: Terminar");
        }
        static void TomarAsistencia(Preceptor p)
        {
            List<Asistencia> asistenciasNuevas = new List<Asistencia>();
            string dateRef = Getters.GetDateInput("Ingresa la fecha para tomar asistencias").ToString("yyyy-MM-dd");

            foreach (Alumno alumn in _presentismo.GetListaAlumnos())
            {

                if (alumn is AlumnoRegular)
                {
                    string input = Getters.GetStringInput("El alumno" + alumn.ToString() + " esta presente? (Y/N)");
                    switch (input)
                    {
                        case "y":
                        case "Y":
                            asistenciasNuevas.Add(new Asistencia(dateRef, p, alumn, true));
                            break;
                        case "n":
                        case "N":
                            asistenciasNuevas.Add(new Asistencia(dateRef, p, alumn, false));
                            break;
                        default:
                            Console.WriteLine("Opcion invalida. Regresando al menu");
                            break;
                    }
                }                
            }

            try
            {
                _presentismo.AgregarAsistencia(asistenciasNuevas);
            }
            catch (Presentismo.AsistenciaInconsistenteException)
            {
                Console.WriteLine("La cantidad de asistencias no es la misma que la cantidad de alumnos");
            }
            catch (Presentismo.FechasDesigualesException)
            {
                Console.WriteLine("Las asistencias deben tener la misma fecha");
            }
            catch (Presentismo.AsistenciaExistenteEseDiaException e)
            {
                Console.WriteLine(e.Message);
            }
            

            // Ingreso fecha
            // Listar los alumnos
            // para cada alumno solo preguntar si está presente
            // agrego la lista de asistencia
            // Error: mostrar el error y que luego muestre el menú nuevamente
        }
        static void MostrarAsistencia()
        {
            string dateRef = Getters.GetDateInput("Ingresa la fecha a mostrar").ToString("yyyy-MM-dd");
            try
            {
                foreach (Asistencia i in _presentismo.GetAsistenciasPorFecha(dateRef))
                {
                    Console.WriteLine(i.ToString());
                }
            }
            catch (Presentismo.SinAsistenciasException)
            {
                Console.WriteLine("No hay registros para la fecha " + dateRef);
            }
            



            // ingreso fecha
            // muestro el toString de cada asistencia


        }
    }

}
