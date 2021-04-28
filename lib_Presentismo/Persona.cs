using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lib_Presentismo
{
    public abstract class Persona
    {
        protected string _nombre;
        protected string _apellido;

        protected Persona (string nombre, string apellido)
        {
            this._nombre = nombre;
            this._apellido = apellido;
        }

        public override string ToString()
        {
            return base.ToString();
        }

        internal abstract string Display();
    }
}
