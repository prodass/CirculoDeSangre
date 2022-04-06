using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * Existen dos categorias: Activo y Pasivo.
 * Activo: Mayores a 18 y menores de 56 inclusive.
 * Pasivo: Menores de 18 y mayores de 56, con enfermedad cronica y tome medicamentos.
 * 
 * La cuota para activos va a ser de 13250.45k
 * La cuota para pasivos va a ser de 78740.25k
 */

namespace CirculoDeSangre
{
    public class Categoria : Sangre
    {
        public string Tipo { get; set; }
        public double CuotaMonto { get; set; }
        public static List<Categoria> Cate = new List<Categoria>(); //Se agrega una lista de tipos y montos por index de cliente.
        public void Calculo(string nacimiento, char enfermedad, char medicacionperm)
        {
            DateTime hoy = DateTime.Now; //Se calcula la edad extrayendo la fecha actual de la PC.
            DateTime tiempo = new DateTime(1800, 01, 01);
            string cat = "";
            double monto;

            if (DateTime.TryParse(nacimiento, out tiempo)) //Con este if verificamos si el usuario ingreso un dato correcto
            {

                TimeSpan diasEnteros = hoy.Subtract(tiempo);

                int edad = diasEnteros.Days / 365;

                if (edad >= 18 && edad <= 56 && enfermedad == 'n' && medicacionperm == 'n')
                {
                    cat = "Activo";
                    monto = 13250.45;
                }
                else if (edad >= 18 && edad <= 56 && enfermedad == 'S' && medicacionperm == 'S')
                {
                    cat = "Pasivo";
                    monto = 78740.25;
                }
                else
                {
                    cat = "Pasivo";
                    monto = 78740.25;
                }

                Cate.Add(new Categoria() { Tipo = cat, CuotaMonto = monto });
                Console.WriteLine("+ Se le ha asignado a este asociado la categoria de: {0}.\n", cat);
            }

        }
    }
}
