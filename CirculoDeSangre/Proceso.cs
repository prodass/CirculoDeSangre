using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CirculoDeSangre
{
    internal class Proceso
    {
        public static void Menu()
        {
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
            while (!Regex.Match(valor, @"^\d{1}$").Success)
            {
                Console.Write("+ Ingrese nuevamente un valor numerico correcto: ");
                valor = Console.ReadLine();
            }
            ingreso = Int32.Parse(valor);
            while (ingreso < 0 || ingreso > 2)
            {
                Console.Write("+ Ingrese nuevamente un valor numerico correcto: ");
                ingreso = Int32.Parse(Console.ReadLine());
            }

            Opciones(ingreso);
        }
        public static void Opciones(int resp)
        {
            Console.Clear();
            switch (resp)
            {
                case 1:
                    Console.WriteLine("\t - Alta de asociados -");
                    Socios.Alta();
                    Volver();
                    break;
                case 2:
                    Console.WriteLine("\t - Lista de asociados -");
                    Socios.Mostrar();
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
            respuesta = ValidacionSn(respuestaT);

            if (respuesta == 'S') { Menu(); }
            Console.Clear();
            Console.Write("+ Usted ha salido!");
        }
        public static char ValidacionSn(string resp)
        {
            while (!Regex.Match(resp, @"^[A-Z]$|^[a-z]$").Success)
            {
                Console.Write("+ Ingrese correctamente su respuesta: ");
                resp = Console.ReadLine();
            }
            while (char.Parse(resp) != 'S' && char.Parse(resp) != 'n')
            {
                Console.Write("+ Ingrese correctamente su respuesta: ");
                resp = Console.ReadLine();
            }

            return char.Parse(resp);
        }
        public static string ValidacionFecha(string nacimiento)
        {
            int dia, mes, ano;
            string[] naci;
            bool resp = false;

            while (resp == false)
            {
                while (!Regex.Match(nacimiento, @"^\d{2}\-\d{2}\-\d{4}$").Success)
                {
                    Console.Write("+ Ingrese correctamente la fecha de nacimiento: ");
                    nacimiento = Console.ReadLine();
                } //Validacion

                naci = nacimiento.Split('\u002D');
                dia = Int32.Parse(naci[0]);
                mes = Int32.Parse(naci[1]);
                ano = Int32.Parse(naci[2]);
                if (dia < 01 || dia > 31)
                {
                    Console.Write("+ El dia esta incorrecto, ingrese nuevamente su fecha (dd-mm-aaaa): ");
                    Array.Clear(naci, 0, naci.Length);
                    nacimiento = Console.ReadLine();

                }
                else if (mes < 01 || mes > 12)
                {
                    Console.Write("+ El mes esta incorrecto, ingrese nuevamente su fecha (dd-mm-aaaa): ");
                    Array.Clear(naci, 0, naci.Length);
                    nacimiento = Console.ReadLine();

                }
                else if (ano <= DateTime.Today.Year - 120 || ano > DateTime.Today.Year)
                {
                    Console.Write("+ El Año esta incorrecto, ingrese nuevamente su fecha (dd-mm-aaaa): ");
                    Array.Clear(naci, 0, naci.Length);
                    nacimiento = Console.ReadLine();

                }
                else
                {
                    resp = true;
                }

            }
            return nacimiento;
        }
        public static bool ValidacionDNI(long dni)
        {
            for (int i = 0; i < Socios.listaSocio.Count; i++)
            {
                if (dni == Socios.listaSocio[i].DNI)
                {
                    Console.WriteLine("\n+ El dni ingresado coincide con el del asociado/a {0} {1}!\n Se cancela el alta.\n", Socios.listaSocio[i].Nombre, Socios.listaSocio[i].Apellido);
                    return false;
                }

            }

            return true;
        }
    }
}

