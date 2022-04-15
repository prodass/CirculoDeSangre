using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace CirculoDeSangre
{
    internal class AsociadoValidators
    {
        public static string NombreVal(string nombre)
        {
            //El nombre debe ser LETRAS may o min desde 3 a 10 caracteres con no mas de un espacio.
            //Y considerando que la persona puede tener HASTA 2 nombres.
            while (!Regex.Match(nombre, @"^[A-Za-z]{3,10}$|^[A-Za-z]{3,10}\s[A-Za-z]{3,10}$").Success) 
            {
                Console.Write("+ Ingrese nuevamente el nombre: ");
                nombre = Console.ReadLine();
            }

            return nombre;
        }

        public static string ApellidoVal(string apellido)
        {
            //El apellido deben ser LETRAS may o min desde 3 a 10 caracteres con no mas de un espacio.
            //Y considerando que la persona puede tener HASTA 2 apellidos.
            while (!Regex.Match(apellido, @"^[A-Za-z]{2,10}$|^[A-Za-z]{2,10}\s[A-Za-z]{2,10}$").Success)
            {
                Console.Write("+ Ingrese nuevamente su apellido: ");
                apellido = Console.ReadLine();
            }

            return apellido;
        }

        public static long DniVal(string dniStr)
        {
            long dni;

            //El dni ingresa como string para validar su formato. Este deben ser 8 NUMEROS.
            while (!Regex.Match(dniStr, @"^\d{8}$").Success)
            {
                Console.Write("+ Ingrese nuevamente su numero de documento: ");
                dniStr = Console.ReadLine();
            }

            //Se vuelve dni a long.
            dni = long.Parse(dniStr);

            //Valida que el numero de documento ingresado no coincida con el de un asociado ya registrado.
            while (VerificacionDni(dni) == true) 
            {
                Console.Write("+ Ingrese nuevamente su numero de documento: ");
                dni = long.Parse(Console.ReadLine());
                VerificacionDni(dni);
            }

            return dni;
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

        public static string DomicilioVal(string domicilio)
        {
            //En esta validacion consideramos que el asociado tendra una calle con numero y no vive en un departamento con numero de piso y de departamento.
            //Ademas de que este deben ser letras y numeros respectivamente, cuyas letras debe tener de 3 a 15 caracteres con no mas de un espacio.
            while (!Regex.Match(domicilio, @"^[a-zA-Z]{3,15}\s[0-9]+$|^[a-zA-Z]{3,15}\s[a-zA-Z]{3,15}\s[0-9]+$").Success)
            {
                Console.Write("+ Ingrese nuevamente el domicilio: ");
                domicilio = Console.ReadLine();
            }

            return domicilio;
        }

        public static string LocalidadVal(string localidad)
        {
            //La localidad deben ser letras de 3 a 15 caracteres con no mas de un espacio.
            while (!Regex.Match(localidad, @"^[a-zA-Z]{3,15}$|^[a-zA-Z]{3,15}\s[a-zA-Z]{3,15}$").Success) // Validacion de formato.
            {
                Console.Write("+ Ingrese nuevamente su localidad: ");
                localidad = Console.ReadLine();
            }

            return localidad;
        }

        public static long TelefonoVal(string telefonoStr)
        {
            //Se convierte telefono en string para validarlo.
            //Consideramos que el telefono es argentino.
            while (!Regex.Match(telefonoStr, @"^\d{10}$").Success)
            {
                Console.Write("+ Ingrese nuevamente su numero de telefono correctamente: ");
                telefonoStr = Console.ReadLine();
            }

            //Se veuvle telefono a long
            long telefono = long.Parse(telefonoStr); 

            return telefono;
        }

        public static string MailVal(string mail)
        {
            while (!Regex.Match(mail, @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$").Success) 
            {
                Console.Write("+ Ingrese nuevamente su mail: ");
                mail = Console.ReadLine();
            }

            return mail;
        }

        public static string MedicacionNombreSet(char medicacionPerm)
        {
            string medicacionNombre;

            if (medicacionPerm == 'S')
            {
                Console.Write("+ Ingrese la medicacion que toma: ");
                medicacionNombre = Console.ReadLine();

                //Para la validacion consideramos que el nombre del medicamento son solo letras de 3 a 15 caracteres con maximo un espacio.
                while (!Regex.Match(medicacionNombre, @"^[a-zA-Z]{3,15}$|^[a-zA-Z]{3,15}\s[a-zA-Z]{3,15}$").Success) 
                {
                    Console.Write("+ Ingrese nuevamente el nombre de la medicacion: ");
                    medicacionNombre = Console.ReadLine();
                }
            }
            else { medicacionNombre = "No toma."; }

            return medicacionNombre;
        }

        public static string GrupoSanguineoVal(string grupoSanguineo)
        {
            while (!Regex.Match(grupoSanguineo, @"^[A-Z]{1}$|^[A-Z]{2}$").Success) // Validacion de formato.
            {
                Console.Write("+ Ingrese nuevamente su grupo sanguineo: ");
                grupoSanguineo = Console.ReadLine();
            }
            while (grupoSanguineo != "A" && grupoSanguineo != "B" && grupoSanguineo != "AB" && grupoSanguineo != "O")
            {
                Console.Write("+ Ingrese nuevamente un grupo sanguineo aceptado: ");
                grupoSanguineo = Console.ReadLine();
            }

            return grupoSanguineo;
        }

        public static bool VerificacionDni(long dni)
        {
            for (int i = 0; i < Asociado.listaAsociado.Count; i++)
            {
                if (dni == Asociado.listaAsociado[i].DNI)
                {
                    Console.WriteLine("+ El dni ingresado coincide con el del asociado/a {0} {1}!", Asociado.listaAsociado[i].Nombre, Asociado.listaAsociado[i].Apellido);
                    return true;
                }

            }

            return false;
        }
    }
}
