using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lib_Presentismo
{
    public class Preceptor : Persona
    {
        private int _legajo;
        private bool _activo;

        public bool Activo { get => _activo;}

        public Preceptor(int legajo, string nombre, string apellido, bool activo) : 
            base(nombre, apellido)
        {
            this._legajo = legajo;
            this._activo = activo;
        }

        internal override string Display()
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            return string.Format("{0} - {1}", this._apellido, this._legajo);
        }
    }
}
