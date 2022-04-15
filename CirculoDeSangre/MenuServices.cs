using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CirculoDeSangre
{
    internal class MenuServices
    {
        public static void Menu()
        {
            MenuValidator validacion = new MenuValidator();
            string valor;
            int ingreso;
            Console.Clear();
            Console.WriteLine("\t- Circulo de Sangre -");
            Console.WriteLine("--------------------------");
            Console.WriteLine("- 1. Alta de Asociado.");
            Console.WriteLine("- 2. Lista de Asociados.");
            Console.WriteLine("- 0. Salir.");
            Console.WriteLine("--------------------------");

            Console.Write("+ Ingrese su respuesta: ");
            valor = Console.ReadLine();
            ingreso = validacion.ValidacionMenu(valor);

            Opciones(ingreso);
        }

        public static void Opciones(int resp)
        {
            Console.Clear();
            switch (resp)
            {
                case 1:
                    Console.WriteLine("\t - Alta de asociados -");
                    Asociado.Alta();
                    Volver();
                    break;
                case 2:
                    Console.WriteLine("\t - Lista de asociados -");
                    Asociado.MostrarAsociados();
                    Volver();
                    break;
                case 0:
                    Console.Write("Usted ha salido!");
                    break;
                default:
                    break;
            }
        }

        public static void Volver()
        {
            string respuestaT;
            char respuesta;

            Console.Write("+ Desea regresar al menu? (S/n): ");
            respuestaT = Console.ReadLine();
            respuesta = GlobalValidator.ValidacionSn(respuestaT);

            if (respuesta == 'S') { Menu(); }
            Console.Clear();
            Console.Write("+ Usted ha salido!");
        }

    }
}
