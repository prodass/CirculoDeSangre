using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CirculoDeSangre
{
    public class Socios : Categoria
    {
        public static List<Socios> listaSocio = new List<Socios>()
        {
            new Socios() {Nombre = "Jose", Apellido = "Solis", DNI = 43209240, Nacimiento = "13-05-2001", Domicilio = "Los Andes", Localidad = "Brinkmann", Telefono = 3562523366, Mail = "mail", EnfermedadCronica = 'S', MedicacionNombre = "Refrianex", GrupoSanguineo = "A"},
            new Socios() {Nombre = "Maria Rosa", Apellido = "Tomatis", DNI = 25297600, Nacimiento = "24-02-1948", Domicilio = "Las Heras", Localidad = "Brinkmann", Telefono = 3562874521, Mail = "mail", EnfermedadCronica = 'n', GrupoSanguineo = "A"},
            new Socios() {Nombre = "Nico", Apellido = "Cabrera", DNI = 43329540, Nacimiento = "05-11-2000", Domicilio = "Belgrano", Localidad = "San Francisco", Telefono = 3564521456, Mail = "mail", EnfermedadCronica = 'n', GrupoSanguineo = "A"}

        };

        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Nacimiento { get; set; }
        public long DNI { get; set; }
        public long Telefono { get; set; }
        public string Mail { get; set; }
        public string Domicilio { get; set; }
        public string Localidad { get; set; }
        public char EnfermedadCronica { get; set; }
        public string MedicacionNombre { get; set; } = "No toma";
        public char MedicacionPerm { get; set; } = 'n';

        public static void Alta()
        {
            string nombre, apellido, nacimiento, domicilio, localidad, mail, grupoSanguineo, medicacionNombre = "", dniStr, telefonoStr, respuestaT;
            char respuesta, enfermedadCronica, medicacionPerm;
            long dni, telefono;
            int i = 1;
            do
            {
                Console.WriteLine("Alta N°{0}:", i++);
                Console.Write("- Ingrese su nombre: ");
                nombre = Console.ReadLine();
                while (!Regex.Match(nombre, @"^[A-Za-z]+$|^[A-Za-z]+\s[A-Za-z]+$").Success)
                {
                    Console.Write("+ Ingrese nuevamente el nombre: ");
                    nombre = Console.ReadLine();
                } //Validacion

                Console.Write("- Ingrese su apellido: ");
                apellido = Console.ReadLine();
                while (!Regex.Match(apellido, @"^[A-Za-z]+$|^[A-Za-z]+\s[A-Za-z]+$").Success) // Validacion
                {
                    Console.Write("+ Ingrese nuevamente su apellido: ");
                    apellido = Console.ReadLine();
                }

                Console.Write("- Ingrese su numero de documento: "); //Si el doc es igual a uno ya ingresado se cancela.
                dniStr = Console.ReadLine();
                while (!Regex.Match(dniStr, @"^\d{8}$").Success)
                {
                    Console.Write("+ Ingrese nuevamente su numero de documento: ");
                    dniStr = Console.ReadLine();
                } //Se convierte DNI en string para validarlo.
                dni = long.Parse(dniStr); //Se vuelve dni a long.
                if (Proceso.ValidacionDNI(dni) == false)
                {
                    break;
                }

                Console.Write("- Ingrese su fecha de nacimiento (dd-mm-aaaa): ");
                string nacimiento1 = Console.ReadLine();
                nacimiento = Proceso.ValidacionFecha(nacimiento1);

                Console.Write("- Ingrese domicilio (calle y numero): ");
                domicilio = Console.ReadLine();
                while (!Regex.Match(domicilio, @"^[a-zA-Z]+\s[0-9]+$|^[a-zA-Z]+\s[a-zA-Z]+\s[0-9]+$").Success)
                {
                    Console.Write("+ Ingrese nuevamente el domicilio: ");
                    domicilio = Console.ReadLine();
                }
                //([A-Z][a-zA-Z]|([a-z]))+|(\s([A-Z][a-zA-Z]|([a-z])))+\s\d
                Console.Write("- Ingrese localidad: ");
                localidad = Console.ReadLine();
                while (!Regex.Match(localidad, @"^[a-zA-Z]+$|^[a-zA-Z]+\s[a-zA-Z]+$").Success)
                {
                    Console.Write("+ Ingrese nuevamente su localidad: ");
                    localidad = Console.ReadLine();
                }

                Console.Write("- Ingrese su numero de telefono (caracteristica sin cero y numero sin 15): ");
                telefonoStr = Console.ReadLine();
                while (!Regex.Match(telefonoStr, @"^\d{10}$").Success)
                {
                    Console.Write("+ Ingrese nuevamente su numero de telefono correctamente: ");
                    telefonoStr = Console.ReadLine();
                } //Se convierte telefono en string para validarlo.
                telefono = long.Parse(telefonoStr); //Se veuvle telefono a long

                Console.Write("- Ingrese su mail (prueba@example.com): ");
                mail = Console.ReadLine();
                while (!Regex.Match(mail, @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$").Success)
                {
                    Console.Write("+ Ingrese nuevamente su mail: ");
                    mail = Console.ReadLine();
                }

                Console.Write("- Cuenta con una enfermedad cronica? (S/n): ");
                respuestaT = Console.ReadLine();
                enfermedadCronica = Proceso.ValidacionSn(respuestaT);


                Console.Write("- Toma medicacion de forma permanente? (S/n): ");
                respuestaT = Console.ReadLine();
                medicacionPerm = Proceso.ValidacionSn(respuestaT);

                if (medicacionPerm == 'S')
                {
                    Console.Write("- Ingrese la medicacion que toma:");
                    medicacionNombre = Console.ReadLine();
                    while (!Regex.Match(medicacionNombre, @"^[a-zA-Z]+$|^[a-zA-Z]+\s[a-zA-Z]$").Success)
                    {
                        Console.Write("+ Ingrese nuevamente el domicilio: ");
                        medicacionNombre = Console.ReadLine();
                    } //Validacion
                } //Aca se ingresa el nombre de la medicacion en caso de que tome.
                else
                {
                    medicacionNombre = "No toma";
                }

                Console.Write("- Ingrese grupo sanguineo (A, B, AB, O): ");
                grupoSanguineo = Console.ReadLine();
                while (!Regex.Match(grupoSanguineo, @"^[A-Z]{1}$|^[A-Z]{2}$").Success)
                {
                    Console.Write("+ Ingrese nuevamente su grupo sanguineo: ");
                    grupoSanguineo = Console.ReadLine();
                }
                while (grupoSanguineo != "A" && grupoSanguineo != "B" && grupoSanguineo != "AB" && grupoSanguineo != "O")
                {
                    Console.Write("+ Ingrese nuevamente su grupo sanguineo: ");
                    grupoSanguineo = Console.ReadLine();
                }

                Console.Write("\n+ El asociado ingresado, acepta los terminos del circulo? (S/n): ");
                respuestaT = Console.ReadLine();
                respuesta = Proceso.ValidacionSn(respuestaT);


                if (respuesta == 'S')
                {
                    listaSocio.Add(new Socios() { Nombre = nombre, Apellido = apellido, DNI = dni, Nacimiento = nacimiento, Domicilio = domicilio, Localidad = localidad, Telefono = telefono, Mail = mail, EnfermedadCronica = enfermedadCronica, MedicacionNombre = medicacionNombre, MedicacionPerm = medicacionPerm, GrupoSanguineo = grupoSanguineo });
                    Console.Write("\n+ Desea ingresar un nuevo asociado? (S/n): ");
                    respuestaT = Console.ReadLine();
                    respuesta = Proceso.ValidacionSn(respuestaT);
                    if (respuesta == 'S')
                    {
                        Console.Clear();
                        Console.WriteLine("\t - Alta de asociados -");
                        respuesta = 'S';
                    }
                    else
                    {
                        Console.Clear();
                    }


                }
                else
                {
                    Console.Clear();
                    Console.Write("+ No se ha dado el alta al usuario."); //Trampita
                    Console.Write("\n+ Desea ingresar un nuevo asociado? (S/n): ");
                    respuestaT = Console.ReadLine();
                    respuesta = Proceso.ValidacionSn(respuestaT);

                    i -= 1;
                }

            } while (respuesta == 'S');

        }
        public static void Mostrar()
        {
            Categoria cat = new Categoria();
            for (int i = 0; i < listaSocio.Count; i++)
            {
                Console.WriteLine(listaSocio[i]);
                cat.Calculo(listaSocio[i].Nacimiento, listaSocio[i].EnfermedadCronica, listaSocio[i].MedicacionPerm);
            }
        }

        public override string ToString()
        {
            return String.Format("Asociado {0} {1}.\n- Dni: {2}.\n- Nacimiento: {9}.\n- Grupo Sanguineo: {10}.\n- Telefono: {3}.\n- Mail: {4}\n- Domicilio: {5}, {6}.\n- Enfermedad cronica: {7}.\n- Medicacion: {8}.", Nombre.ToUpper()[0] + Nombre.Substring(1), Apellido.ToUpper()[0] + Apellido.Substring(1), DNI, Telefono, Mail, Domicilio.ToUpper()[0] + Domicilio.Substring(1), Localidad.ToUpper()[0] + Localidad.Substring(1), EnfermedadCronica, MedicacionNombre.ToUpper()[0] + MedicacionNombre.Substring(1), Nacimiento, GrupoSanguineo);
        }
    }
}
