using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CirculoDeSangre
{
    public class Donacion : Peticion
    {
        public static List<Donacion> Donaciones = new List<Donacion>();
        

        public string Fecha { get; set; }
        public string Estado { get; set; }
        public string AsociadoID { get; set; }


        public static void ListaDePrioridad()
        {
            
            Console.WriteLine("\n-------------------------------");
            //Console.WriteLine(" ID |   DNI    | Asociado | \tGrupo sanguineo\tDonaciones-\n");
            for (int i = 0; i < Asociado.listaAsociado.Count(); i++)
            {
                if(Categoria.Cate[i].Tipo == "Activo")
                {
                    Console.WriteLine($"+ Asociado ID:{i}, {Asociado.listaAsociado[i].Nombre} {Asociado.listaAsociado[i].Apellido} - DNI: {Asociado.listaAsociado[i].DNI} - grupo sanguineo: {Asociado.listaAsociado[i].GrupoSanguineo}");
                }
            }
            Console.WriteLine("-------------------------------\n");
        }
    }
}

/*
 * Basicamente dentro de esta clase tenemos el metodo lista de prioridad el cual inicia yendo al metodo cargar asociado el cual carga todos los ultimos asociados
 * y muestra los asociados y su estado.
 */