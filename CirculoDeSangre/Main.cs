using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Toda la documentacion del proyecto esta en el ReadMe asociado al repo.

namespace CirculoDeSangre
{
    internal class Principal
    {
        static void Main()
        {
            Asociado.CargarAsociados();
            MenuServices.Menu();

            Console.ReadKey();
        }
    }
}