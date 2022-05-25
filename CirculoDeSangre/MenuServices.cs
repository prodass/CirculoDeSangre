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
            Console.WriteLine("\n--------------------------");
            Console.WriteLine("- 1. Alta de Asociado.");
            Console.WriteLine("- 2. Lista de Asociados.");
            Console.WriteLine("- 3. Gestionar Peticion.");
            Console.WriteLine("- 0. Salir.");
            Console.WriteLine("--------------------------");

            Console.Write("+ Ingrese su respuesta: ");
            valor = Console.ReadLine();
            ingreso = validacion.ValidacionMenu(valor);

            Opciones(ingreso);
        }

        public static void Opciones(int resp)
        {
            MenuValidator validacion = new MenuValidator();
            string valor;
            int ingreso;
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
                case 3:
                    Console.WriteLine("\t- Circulo de Sangre -");
                    Console.WriteLine("\n Gestion de Peticiones ");
                    Console.WriteLine("--------------------------");
                    Console.WriteLine("- 1. Mostrar Peticiones.");
                    Console.WriteLine("- 2. Mostrar lista de prioridad.");
                    Console.WriteLine("- 3. Registrar nueva peticion.");
                    Console.WriteLine("- 0. Volver.");
                    Console.WriteLine("--------------------------");

                    Console.Write("+ Ingrese su respuesta: ");
                    valor = Console.ReadLine();
                    ingreso = validacion.ValidacionMenu(valor);
                    switch (ingreso)
                    {
                        case 1:
                            Console.Clear();
                            Console.WriteLine("\t - Lista de Peticiones -");
                            Donacion.MostrarPeticiones();
                            Volver();
                            break;

                        case 2:
                            Console.Clear();
                            Console.WriteLine("\t - Listas de Prioridad -");
                            Donacion.ListaDePrioridad();
                            Volver();
                            break;

                        case 3:
                            Console.Clear();
                            Console.WriteLine("\t - Registro de Peticiones -");
                            Donacion.RegistrarPeticion();
                            Volver();
                            break;

                        case 0:
                            Console.Clear();
                            Menu();
                            break;

                        default:
                            break;
                    }

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
