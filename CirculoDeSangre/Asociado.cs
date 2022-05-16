using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CirculoDeSangre
{
    public class Asociado : Categoria
    {
        public static List<Asociado> listaAsociado = new List<Asociado>()
        {
            new Asociado() {Nombre = "Jose", Apellido = "Solis", DNI = 43209240, Nacimiento = "13-05-2001", Domicilio = "Los Andes", Localidad = "Brinkmann", Telefono = 3562523366, Mail = "mail", EnfermedadCronica = 'S', MedicacionNombre = "Refrianex", GrupoSanguineo = "A"},
            new Asociado() {Nombre = "Maria Rosa", Apellido = "Tomatis", DNI = 25297600, Nacimiento = "24-02-1948", Domicilio = "Las Heras", Localidad = "Brinkmann", Telefono = 3562874521, Mail = "mail", GrupoSanguineo = "O"},
            new Asociado() {Nombre = "Nico", Apellido = "Cabrera", DNI = 43329540, Nacimiento = "05-11-2000", Domicilio = "Belgrano", Localidad = "San Francisco", Telefono = 3564521456, Mail = "mail", GrupoSanguineo = "AB"},
            new Asociado() {Nombre = "Magu", Apellido = "Gomez", DNI = 43235490, Nacimiento = "15-08-2001", Domicilio = "Iturraspe", Localidad = "San Francisco", Telefono = 3562421234, Mail = "mail", GrupoSanguineo = "AB",EnfermedadCronica = 'S', MedicacionNombre = "Hibuprofeno"},
            new Asociado() {Nombre = "Matias", Apellido = "Trivisono", DNI = 41567590, Nacimiento = "21-04-2001", Domicilio = "25 de Mayo", Localidad = "San Francisco", Telefono = 356242345310, Mail = "mail", GrupoSanguineo = "B"},
            new Asociado() {Nombre = "Juampi", Apellido = "Bessone", DNI = 42195240, Nacimiento = "14-12-2001", Domicilio = "San Justo", Localidad = "San Francisco", Telefono = 3564521456, Mail = "mail", GrupoSanguineo = "O"},
            new Asociado() {Nombre = "Lautaro", Apellido = "Gomez", DNI = 41423510, Nacimiento = "12-11-2000", Domicilio = "Iturraspe Norte", Localidad = "San Francisco", Telefono = 3564521456, Mail = "mail", GrupoSanguineo = "A"},

        };

        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Nacimiento { get; set; }
        public long DNI { get; set; }
        public long Telefono { get; set; }
        public string Mail { get; set; }
        public string Domicilio { get; set; }
        public string Localidad { get; set; }
        public char EnfermedadCronica { get; set; } = 'n';
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
                Console.Write("- Ingrese su nombre (en caso de que tenga, agregar segundo nombre): ");
                nombre = Console.ReadLine();
                nombre = AsociadoValidators.NombreVal(nombre);

                Console.Write("- Ingrese su apellido (en caso de que tenga, agregar segundo apellido): ");
                apellido = Console.ReadLine();
                apellido = AsociadoValidators.ApellidoVal(apellido);

                Console.Write("- Ingrese su numero de documento: ");
                dniStr = Console.ReadLine();
                dni = AsociadoValidators.DniVal(dniStr);

                Console.Write("- Ingrese su fecha de nacimiento (dd-mm-aaaa): ");
                string nacimiento1 = Console.ReadLine();
                nacimiento = AsociadoValidators.ValidacionFecha(nacimiento1);

                Console.Write("- Ingrese domicilio (calle y numero): ");
                domicilio = Console.ReadLine();
                domicilio = AsociadoValidators.DomicilioVal(domicilio);
                
                Console.Write("- Ingrese localidad: ");
                localidad = Console.ReadLine();
                localidad = AsociadoValidators.LocalidadVal(localidad);

                Console.Write("- Ingrese su numero de telefono (caracteristica sin cero y numero sin 15): ");
                telefonoStr = Console.ReadLine();
                telefono = AsociadoValidators.TelefonoVal(telefonoStr);

                Console.Write("- Ingrese su mail (prueba@example.com): ");
                mail = Console.ReadLine();
                mail = AsociadoValidators.MailVal(mail);

                Console.Write("- Cuenta con una enfermedad cronica? (S/n): ");
                respuestaT = Console.ReadLine();
                enfermedadCronica = GlobalValidator.ValidacionSn(respuestaT);


                Console.Write("- Toma medicacion de forma permanente? (S/n): ");
                respuestaT = Console.ReadLine();
                medicacionPerm = GlobalValidator.ValidacionSn(respuestaT);
                medicacionNombre = AsociadoValidators.MedicacionNombreSet(medicacionPerm);
                

                Console.Write("- Ingrese grupo sanguineo (A, B, AB, O): ");
                grupoSanguineo = Console.ReadLine();
                grupoSanguineo = AsociadoValidators.GrupoSanguineoVal(grupoSanguineo);

                Console.Write("\n+ El asociado ingresado, acepta los terminos del circulo? (S/n): ");
                respuestaT = Console.ReadLine();
                respuesta = GlobalValidator.ValidacionSn(respuestaT);


                if (respuesta == 'S')
                {
                    listaAsociado.Add(new Asociado() { Nombre = nombre, Apellido = apellido, DNI = dni, Nacimiento = nacimiento, Domicilio = domicilio, Localidad = localidad, Telefono = telefono, Mail = mail, EnfermedadCronica = enfermedadCronica, MedicacionNombre = medicacionNombre, MedicacionPerm = medicacionPerm, GrupoSanguineo = grupoSanguineo });
                    Console.WriteLine("\n+ El asociado ha sido dado de alta!");
                    Console.Write("+ Desea ingresar un nuevo asociado? (S/n): ");
                    respuestaT = Console.ReadLine();
                    respuesta = GlobalValidator.ValidacionSn(respuestaT);
                    
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
                    Console.Write("+ El asociado no ha sido dado de alta.");
                    Console.WriteLine("+ Desea ingresar un nuevo asociado? (S/n): ");
                    respuestaT = Console.ReadLine();
                    respuesta = GlobalValidator.ValidacionSn(respuestaT);

                    i -= 1;
                }

            } while (respuesta == 'S');

        }
        public static void CargarAsociados()
        {
            Categoria cat = new Categoria();
            for (int i = 0; i < listaAsociado.Count; i++)
            {
                cat.CalculoCategoria(listaAsociado[i].Nacimiento, listaAsociado[i].EnfermedadCronica, listaAsociado[i].MedicacionPerm);
            }
        }
        public static void MostrarAsociados()
        {
            for (int i = 0; i < listaAsociado.Count; i++)
            {
                Console.WriteLine(listaAsociado[i]);
                Console.WriteLine("+ Se le ha asignado a este asociado la categoria de: {0}.", Cate[i].Tipo);
            }
        }
        public override string ToString()
        {
            return String.Format("Asociado {0} {1}.\n- Dni: {2}.\n- Nacimiento: {9}.\n- Grupo Sanguineo: {10}.\n- Telefono: {3}.\n- Mail: {4}\n- Domicilio: {5}, {6}.\n- Enfermedad cronica: {7}.\n- Medicacion: {8}.", Nombre.ToUpper()[0] + Nombre.Substring(1), Apellido.ToUpper()[0] + Apellido.Substring(1), DNI, Telefono, Mail, Domicilio.ToUpper()[0] + Domicilio.Substring(1), Localidad.ToUpper()[0] + Localidad.Substring(1), EnfermedadCronica, MedicacionNombre.ToUpper()[0] + MedicacionNombre.Substring(1), Nacimiento, GrupoSanguineo);
        }
    }
}
