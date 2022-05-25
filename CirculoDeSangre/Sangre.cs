using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * Hay cuatro tipos de sangre:
 * A, B, AB y O.
 */


namespace CirculoDeSangre
{
    public class Sangre : Donacion
    {   
        public string GrupoSanguineo { get; set; }
    }
}
