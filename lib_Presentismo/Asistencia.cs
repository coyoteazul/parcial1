using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lib_Presentismo
{
    public class Asistencia
    {
        private string _fechaAsistencia;
        private DateTime _fechaHoraReal;
        private Preceptor _preceptor;
        private Alumno _alumno;
        private bool _estaPresente;

        public Asistencia(string _fechaAsistencia, Preceptor _preceptor, Alumno _alumno, bool _estaPresente)
        {
            this._fechaAsistencia = _fechaAsistencia;
            this._preceptor = _preceptor;
            this._alumno = _alumno;
            this._estaPresente = _estaPresente;

            this._fechaHoraReal = DateTime.Now;
        }

        public string FechaAsistencia { get => _fechaAsistencia;}

        public override bool Equals(object obj)
        {
            return obj is Asistencia asistencia &&
                   _fechaAsistencia == asistencia._fechaAsistencia &&
                   EqualityComparer<Alumno>.Default.Equals(_alumno, asistencia._alumno);
        }

        public override string ToString()
        {
            return string.Format("{0} {1} está presente {2} por {3} registrado el {4}", 
                this._fechaAsistencia,
                _alumno.ToString(),
                (_estaPresente ? "Si" : "No"),
                _preceptor.ToString(),
                this._fechaHoraReal.ToString("yyyy-MM-dd"));
        }

        
    }

}
