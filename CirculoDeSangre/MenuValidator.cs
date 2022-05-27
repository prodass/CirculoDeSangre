using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CirculoDeSangre
{
    internal class MenuValidator
    {
        public int ValidacionMenu(string valor)
        {
            int ingreso;
            while (!Regex.Match(valor, @"^\d{1}$").Success)
            {
                Console.Write("[+] Ingrese nuevamente un valor numerico correcto: ");
                valor = Console.ReadLine();
            }
            ingreso = Int32.Parse(valor);
            while (ingreso < 0 || ingreso > 3)
            {
                Console.Write("[+] Ingrese nuevamente un valor numerico correcto: ");
                ingreso = Int32.Parse(Console.ReadLine());
            }

            return ingreso;
        }
    }
}
