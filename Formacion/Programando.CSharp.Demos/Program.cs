using System;
using Universidad;

namespace Programando.CSharp.Demos
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Las variables de tipo referencia el valor predeterminado es NULL
            // las variables de tipo valor, el valor predeterminado es 0
            string texto; // Null
            string otroTexto = "Hola Mundo !!!";
            int numero = 214;
            System.Int32 numero2 = 142;
            Int64 numero3 = 5228424589455577941;
            int otroNumero; // 0

            // int es distinto de int?
            int? otroNumero2 = null; // int? permite que sea nuleable

            decimal a, b, c;

            // instanciar objetos
            Alumno alumno = new Alumno();
            alumno.name = "Andres";

            var alumno1 = new Alumno(); // este tipo de variable puede ser cualquier tipo 

            var v = 10;
            v = 95;
            var h = "Hola mundo";

            // Object es la clase maestra de el resto de variables
            // esta cambia en el transcurso de la ejecucion
            Object alumno2 = new Alumno();
            // alumno2.name = "andres"; // esto no se puede hacer
            alumno2 = 12;
            alumno2 = "hola";

            dynamic alumno3 = new Alumno();
            alumno3.name = "Andres";
            alumno3 = 10;

            Console.WriteLine("Tipo de la variable 1: " + alumno1.GetType());
            Console.WriteLine("Tipo de la variable 2: " + alumno2.GetType());
            Console.WriteLine("Tipo de la variable 3: " + alumno.GetType());



        }
    }
}

namespace Universidad
{

    public class Alumno
    {
        public string name;
        public string apellidos;
        public int edad;
    }

    ///<summary>
    /// Un ejemplo de clase estática, implementando patrón de diseño SINGLETON
    ///</summary>
    public static class Profesor
    {
        
        public static void Demo()
        {
            Console.WriteLine("Demo de Profesor");
        }

    }

}


/*
    SINGLETON

El patrón de diseño singleton es una clase de la cual solo existe una única instancia.

Se carga una sola vez de forma global, ahorrando espacio en memoria y mejorando el
rendimiento de las aplicaciones.

En el ejemplo anterior, Alumno es una clase que necesita ser instanciada. Por otro lado,
Console es una clase estatica (singleton)

    ///<summary>
    /// Un ejemplo de clase estática, implementando patrón de diseño SINGLETON
    ///</summary>
    public static class Profesor
    {
        public static void Demo()
        {
            Console.WriteLine("Demo de Profesor");
        }

    }

Podemos tener clases no estaticas que contengan métodos que si sean estáticos. En ese caso
para invocar los métodos se debe hacer a través de la clase y no de la instancia.



*/

