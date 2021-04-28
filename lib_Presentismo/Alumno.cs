using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lib_Presentismo
{
    public class Alumno : Persona
    {
        private int registro;

        protected Alumno(string nombre, string apellido, int registro) : 
            base (nombre, apellido)
        {
            this.registro = registro;
        }

        public override bool Equals(object obj)
        {
            return obj is Alumno alumno &&
                   registro == alumno.registro;
        }

        public override string ToString()
        {
            return string.Format("{0} ({1})", this._apellido, this.registro);
        }

        internal override string Display()
        {
            throw new NotImplementedException();
        }
    }
}
