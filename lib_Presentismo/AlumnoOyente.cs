using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lib_Presentismo
{
    public class AlumnoOyente : Alumno
    {
        public AlumnoOyente(int registro, string nombre, string apellido ) : 
            base(nombre, apellido, registro)
        {
        }
    }
}
