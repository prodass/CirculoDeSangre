using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CirculoDeSangre
{
    internal class Cuota : Cobro
    {
        public int Numero { get; set; }
        public char Estado { get; set; }
        public double MontoTotal { get; set; }
        public int Periodo { get; set; }
    }
}
