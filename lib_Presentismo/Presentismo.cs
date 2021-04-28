using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lib_Presentismo
{
    public class Presentismo
    {
        private List<Preceptor> _preceptores;
        private List<Alumno> _alumnos;
        private List<Asistencia> _asistencias;

        public Presentismo()
        {
            _alumnos = new List<Alumno>();
            _asistencias = new List<Asistencia>();
            _preceptores = new List<Preceptor>();

            _preceptores.Add(new Preceptor(5, "Jorgelina", "Ramos", true));
            _preceptores.Add(new Preceptor(6, "Juan", "Gutierrez", false));

            _alumnos.Add(new AlumnoRegular(123, "Carlos", "Juárez", "cj@gmail.com"));
            _alumnos.Add(new AlumnoRegular(124, "Carla", "Jaime", "carla@gmail.com"));
            _alumnos.Add(new AlumnoOyente(320, "Ramona", "Vals"));
            _alumnos.Add(new AlumnoOyente(321, "Alejandro", "Medina"));
        }


        private bool AsistenciaRegistrada (string fecha)
        {
            foreach (Asistencia i in _asistencias)
            {
                if (i.FechaAsistencia.Equals(fecha))
                    return true;
            }
            return false;
        }

        private int GetCantidadAlumnosRegulares()
        {
            int count = 0;
            foreach (Alumno i in this._alumnos)
            {
                if (i is AlumnoRegular)
                    count++;
            }

            return count;
        }

        public Preceptor GetPreceptorActivo()
        {
            foreach (Preceptor i in this._preceptores)
            {
                if (i.Activo)
                    return i;
            }

            return null;
        }

        public List<Alumno> GetListaAlumnos()
        {
            return this._alumnos;
        }


        public void AgregarAsistencia(List<Asistencia> nuevasAsistencias)
        {
            if (GetCantidadAlumnosRegulares() != nuevasAsistencias.Count)
            {
                throw new AsistenciaInconsistenteException();
            }


            string dateRef = nuevasAsistencias.First().FechaAsistencia;
            foreach (Asistencia i in nuevasAsistencias)
            {
                if (i.FechaAsistencia != dateRef)
                {
                    throw new FechasDesigualesException();
                }

                foreach (Asistencia e in this._asistencias)
                {
                    if (i.Equals(e))
                    {
                        throw new AsistenciaExistenteEseDiaException("Ya existia " + i.ToString());
                    }
                }
            }

            this._asistencias.AddRange(nuevasAsistencias);
        }

        /// <summary>
        /// Muestra las asistencias por fecha
        /// </summary>
        /// <exception cref="SinAsistenciasException">Si no hay asistencias con esa fecha </returns>
        public List<Asistencia> GetAsistenciasPorFecha(string fecha)
        {
            List<Asistencia> retorno = new List<Asistencia>();

            foreach (Asistencia i in this._asistencias)
            {
                if (i.FechaAsistencia == fecha)
                    retorno.Add(i);
            }

            if (retorno.Count == 0)
            {
                throw new SinAsistenciasException();
            }

            return retorno;
        }

        


        public class AsistenciaExistenteEseDiaException : Exception
        {
            public AsistenciaExistenteEseDiaException(string mensaje) : base(mensaje) { }
        }

        public class AsistenciaInconsistenteException : Exception
        {

        }

        public class FechasDesigualesException : Exception
        {

        }

        public class SinAsistenciasException : Exception
        {

        }
    }
}
