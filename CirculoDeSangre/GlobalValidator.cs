using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CirculoDeSangre
{
    internal class GlobalValidator
    {
        public static char ValidacionSn(string resp)
        {
            while (!Regex.Match(resp, @"^[A-Z]$|^[a-z]$").Success)
            {
                Console.Write("[+] Ingrese correctamente su respuesta: ");
                resp = Console.ReadLine();
            }
            while (char.Parse(resp) != 'S' && char.Parse(resp) != 'n')
            {
                Console.Write("[+] Ingrese correctamente su respuesta: ");
                resp = Console.ReadLine();
            }

            return char.Parse(resp);
        }
    }
}

