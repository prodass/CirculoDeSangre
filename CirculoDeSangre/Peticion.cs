using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CirculoDeSangre
{
    public class Peticion
    {
        public static List<Peticion> Peticiones = new List<Peticion>()
        {
            new Peticion() {FechaPeticion = "15/05/2022" , CantDonantes = 1 , FechaLimite = "18/05/2022", GrupoSanguineoPet = "A"}
        };
        public string FechaPeticion { get; set; }
        public int CantDonantes { get; set; }
        public string FechaLimite { get; set; }
        public string GrupoSanguineoPet { get; set; }

        public static void RegistrarPeticion() //Pensar otro nombre
        {
            int cantidad;
            string fechaLimite,fecha = DateTime.Now.ToString("dd/MM/yyyy"), cantidadStr, respStr, grupoSanguineo;
            char resp;
            Console.WriteLine($"\n[+] Peticion ID: 00{Peticiones.Count()}\tFecha: {fecha}");

            Console.Write("[-] Ingrese el tipo de sangre necesario: ");
            grupoSanguineo = Console.ReadLine();
            grupoSanguineo = PeticionesValidator.GrupoSanguineoVal(grupoSanguineo);

            Console.Write("[-] Ingrese la cantidad de donantes: ");
            cantidadStr = Console.ReadLine();
            cantidad = PeticionesValidator.CantidadVal(cantidadStr);
            cantidad = PeticionesValidator.CantidadPetVal(cantidad, grupoSanguineo);

            Console.Write($"[-] Ingrese una fecha limite no mayor a 30 dias de la fecha actual ({DateTime.Now.ToString("dd-MM-yyyy")}): ");
            fechaLimite = Console.ReadLine();
            fechaLimite = PeticionesValidator.FechaLimiteVal(fechaLimite);
            if (cantidad != 0)
            {
                Console.Write($"\n[+] Esta seguro de registrar la nueva peticion N°00{Peticiones.Count()} cuya fecha limite es el {fechaLimite} con {cantidad} donantes? (S/n): ");
                respStr = Console.ReadLine();
                resp = GlobalValidator.ValidacionSn(respStr);
                
                if (resp == 'S')
                {
                    Console.WriteLine("\n[!] El registro se ha realizado correctamente!");
                    Peticiones.Add(new Peticion { FechaPeticion = DateTime.Now.ToString("dd/MM/yyyy"), CantDonantes = cantidad, FechaLimite = fechaLimite, GrupoSanguineoPet = grupoSanguineo });

                    Console.WriteLine($"\n\t- Seleccion de fechas para {cantidad} donante/s - ");
                    PeticionesValidator.DonadoresFechas(fecha,fechaLimite);
                    
                }
                else
                {
                    Console.WriteLine("[!] Se ha cancelado el registro!\n");
                    MenuServices.Volver();
                }
            }
            else
            {
                Console.WriteLine("[!] Se ha cancelado el registro debido a que no hay asociados!\n");
                MenuServices.Volver();
            }


        }

        public static void MostrarPeticiones()
        {
            for (int i = 0; i < Peticiones.Count(); i++)
            {
                Console.WriteLine($"\n[+] Peticion N°00{i} se registro el {Peticiones[i].FechaPeticion} cuya fecha limite es {Peticiones[i].FechaLimite} solicitando {Peticiones[i].CantDonantes} asociado/s.");
            }
        }
    }
}
