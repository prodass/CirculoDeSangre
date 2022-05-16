using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CirculoDeSangre
{
    public class PeticionesValidator
    {
        public static int CantidadVal(string cantidadStr)
        {
            int cantidad;
            while (!Regex.Match(cantidadStr.ToString(), @"^\d{1}$|^\d{2}$").Success)
            {
                Console.Write("+ Ingrese correctamente un numero valido: ");
                cantidadStr = Console.ReadLine();
            }
            cantidad = Int32.Parse(cantidadStr);
            while (cantidad < 0 && cantidad > 10)
            {
                Console.WriteLine("+ Ingrese una cantidad dentro del rango valido: ");
                cantidad = Int32.Parse(Console.ReadLine());
            }

            return cantidad;
        }
        public static int CantidadPetVal(int cantidad, string grupoSanguineo)
        {
            int cont=0;
            for (int i = 0; i < Asociado.listaAsociado.Count; i++)
            {
                if (Categoria.Cate[i].Tipo == "Activo")
                {
                    if(Asociado.listaAsociado[i].GrupoSanguineo == grupoSanguineo)
                    {
                        cont++;
                    }
                }
            }
            while (cont < cantidad)
            {
                Console.WriteLine($"\n+ Se ha ingresado una cantidad de sangre factor '{grupoSanguineo}' superior a la disponible, hay {cont} asociado{@"\s"} disponible{@"\s"}!\n+ Se ha asignado automaticamente los asociados disponibles.\n");
                cantidad = cont;
            }
            return cantidad;
        }
        
        public static string FechaLimiteVal(string fechaLimite)
        {
            int dia, mes, ano;
            string[] naci;
            bool resp = false;

            while (resp == false)
            {
                while (!Regex.Match(fechaLimite, @"^\d{2}\-\d{2}\-\d{4}$").Success)
                {
                    Console.Write("+ Ingrese correctamente la fecha limite: ");
                    fechaLimite = Console.ReadLine();
                }

                naci = fechaLimite.Split('\u002D');

                dia = Int32.Parse(naci[0]);
                mes = Int32.Parse(naci[1]);
                ano = Int32.Parse(naci[2]);

                if (dia < 01 || dia > 31)
                {
                    Console.Write("+ El dia esta incorrecto, ingrese nuevamente su fecha (dd-mm-aaaa): ");
                    Array.Clear(naci, 0, naci.Length);
                    fechaLimite = Console.ReadLine();

                }
                else if (mes < 01 || mes > 12)
                {
                    Console.Write("+ El mes esta incorrecto, ingrese nuevamente su fecha (dd-mm-aaaa): ");
                    Array.Clear(naci, 0, naci.Length);
                    fechaLimite = Console.ReadLine();

                }
                else if (ano <= DateTime.Today.Year - 120 || ano > DateTime.Today.Year)
                {
                    Console.Write("+ El Año esta incorrecto, ingrese nuevamente su fecha (dd-mm-aaaa): ");
                    Array.Clear(naci, 0, naci.Length);
                    fechaLimite = Console.ReadLine();

                }
                else
                {
                    resp = true;
                } //VALIDACION DE FORMATO
            }

            int res = (DateTime.Today - DateTime.Parse(fechaLimite)).Days;

            while (res < -31 || res > 0)
            {
                Console.Write("+ Usted ingreso una fecha mayor a un mes de la establecida, por favor, ingrese una nueva: ");
                fechaLimite = Console.ReadLine();
                res = (DateTime.Today - DateTime.Parse(fechaLimite)).Days;
            }

            return fechaLimite;
        }
    }
}
