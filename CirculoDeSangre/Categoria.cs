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

        //Se agrega una lista de tipos y montos por index de cliente.
        public static List<Categoria> Cate = new List<Categoria>()
        {
            new Categoria () {Tipo = "Pasivo", CuotaMonto = 78740.25},
            new Categoria () {Tipo = "Pasivo", CuotaMonto = 78740.25},
            new Categoria () {Tipo = "Activo", CuotaMonto = 13250.45},
            new Categoria () {Tipo = "Pasivo", CuotaMonto = 78740.25},
            new Categoria () {Tipo = "Activo", CuotaMonto = 13250.45},
            new Categoria () {Tipo = "Activo", CuotaMonto = 13250.45},
            new Categoria () {Tipo = "Activo", CuotaMonto = 13250.45}
        };
        public string Tipo { get; set; }
        public double CuotaMonto { get; set; }

        //En este metodo lo que hacemos es calcular la categoria del usuario.
        //Basicamente restamos la fecha actual y la fecha de nacimiento dividiendolo por 365.
        //Luego lo guardamos en una lista.
        public static void CalculoCategoria(string nacimiento, char enfermedad)
        {

            string cat="A";
            double monto = 0;

            //Con este if verificamos si el usuario ingreso un dato correcto

                TimeSpan diasEnteros = DateTime.Now.Subtract(DateTime.Parse(nacimiento));

                int edad = diasEnteros.Days / 365;
                Console.WriteLine(edad);

                if (edad >= 18 && edad <= 56 && enfermedad == 'n')
                {
                    cat = "Activo";
                    monto = 13250.45;
                }
                else if (edad >= 18 && edad <= 56 && enfermedad == 'S')
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
        }
    }
}
