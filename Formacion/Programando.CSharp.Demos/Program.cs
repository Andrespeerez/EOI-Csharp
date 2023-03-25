using System;
using Universidad;

namespace Programando.CSharp.Demos
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.Clear();
            //DeclaracionVariables();
            //ConversionVariables();
            //EjemplosConsole();
            //SecuenciasControl();
            SecuenciasControl2();

        }

        static void DeclaracionVariables()
        {
            // Las variables de tipo referencia el valor predeterminado es NULL
            // las variables de tipo valor, el valor predeterminado es 0
            string texto; // Null
            string otroTexto = "Hola Mundo !!!";
            int numero = 214;
            numero++; // añade 1 a numero
            System.Int32 numero2 = 142;
            Int64 numero3 = 5228424589455577941;
            int otroNumero; // 0

            // int? es distinto de int
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
            ((Alumno)alumno2).name  = "Andres"; // Esto es una conversion!!


            dynamic alumno3 = new Alumno();
            alumno3.name = "Andres";
            alumno3 = 10;

            Console.WriteLine("Tipo de la variable 1: " + alumno1.GetType());
            Console.WriteLine("Tipo de la variable 2: " + alumno2.GetType());
            Console.WriteLine("Tipo de la variable 3: " + alumno.GetType());
        }

        static void ConversionVariables()
        {
            // 0 - 255
            byte var1 = 200;
            int var2 = 90;
            string var3 = "45";

            // ToString() convierte a texto cualquir valor númerico
            // o muestra el nombre del objeto.
            var3 = var1.ToString();


            //Conversión con TRYPARSE
            bool resultado = byte.TryParse(var3, out var1);
            resultado = byte.TryParse(var3, out _);

            Console.Clear();
            Console.WriteLine("Resultado: {0}", resultado.ToString());
            Console.WriteLine("Var1: {0}", var1.ToString());
            //Console.Write("L1 \nL2" + Environment.NewLine + "L3");
            Console.ReadKey();


            var1 = Convert.ToByte(var3);

            // Conversión con PARSE
            var1 = byte.Parse(var3);

            //Conversión implicita
            var2 = var1;

            //Conversión explicita
            var1 = (byte)var2;

            //Conversión utilizando el Objeto CONVERT
            var1 = Convert.ToByte(var2);
        }

        static void EjemplosConsole()
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Clear();

            var tecla = Console.ReadKey();
            Console.WriteLine($"Pulso {tecla.KeyChar.ToString()}");

            Console.Write("Dime algo: ");
            string respuesta = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write($"Respueta: ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write($"{respuesta}");
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        static void SecuenciasControl()
        {
            // tres formas de asignar valores
            var reserva = new Reserva();
            reserva.id = "1050CA";
            reserva.cliente = "Andres Perez";

            var reserva2 = new Reserva() {
                id = "1066HC",
                cliente = "Ana García",
            };
            
            var reserva3 = new Reserva();

            Console.Write("ID Reserva : ");
            reserva3.id = Console.ReadLine();

            Console.Write("Cliente Reserva : ");
            reserva3.cliente = Console.ReadLine();

            // 100: individual, 200: doble, 300: junior Suite, 400: suite
            Console.Write("Tipo de habitación : ");

            //int.TryParse(Console.ReadLine(), out reserva3.tipo);

            // La linea anterior hay que validarla, por eso no es valida
            // 100, 200, 300, 400
            string valor = Console.ReadLine();

            // Asignación con if, else if
            if(valor == "100")
            {
                reserva3.tipo = 100;
            }
            else if(valor == "200")
            {
                reserva3.tipo = 200;
            }
            else if(valor == "300")
            {
                reserva3.tipo = 300;
            }
            else if(valor == "400")
            {
                reserva3.tipo = 400;
            }
            else 
            {
                reserva3.tipo = -1;
            }

            // asignacion con if, elseif, abreviada
            if(valor == "100") reserva3.tipo = 100;
            else if(valor == "200") reserva3.tipo = 200;
            else if(valor == "300") reserva3.tipo = 300;
            else if(valor == "400") reserva3.tipo = 400;
            else reserva3.tipo = -1;

            // asignación con switch
            switch(valor)
            {
                case "100":
                    reserva3.tipo = 100;
                    break;
                case "200":
                    reserva3.tipo = 200;
                    break;
                case "300":
                    reserva3.tipo = 300;
                    break;
                case "400":
                    reserva3.tipo = 400;
                    break;
                default:
                    reserva3.tipo = -1;
                    break;
            }

            Console.Write("Fuma? (Si/No) : ");
            string valor2 = Console.ReadLine();

            switch(valor2.ToLower())
            {
                case "si":
                    reserva3.fumador = true;
                    break;
                case "no":
                    reserva3.fumador = false;
                    break;
            }

            // MOSTRAR EN PANTALLA LA RESERVA:
            Console.Clear();

            Console.WriteLine($"ID                 : {reserva3.id} \nNombre             : {reserva3.cliente}");
            
            // 100: individual, 200: doble, 300: junior Suite, 400: suite
            Console.Write($"Tipo de habitación :");
            if(reserva3.tipo == 100)      Console.Write(" individual");
            else if(reserva3.tipo == 200) Console.Write(" doble");
            else if(reserva3.tipo == 300) Console.Write(" junior suite");
            else if(reserva3.tipo == 400) Console.Write(" suite\n");

            Console.Write($"Fumador            :");
            switch(reserva3.fumador)
            {
                case true:
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write(" Verdadero\n");
                    break;
                case false:
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write($" Falso\n");
                    break;
            }

            Console.ForegroundColor = ConsoleColor.White;


        }

        static void SecuenciasControl2()
        {

            int[] nums = new int[2] {5, -43}; // limitando a 2 máximo
            int[] numeros = {10, 95, -2, 35, 118, 72, -52};
            string[] frutas = {"naranja", "limón", "lima", "pomelo"};
            object[] objectos = {10, "naranja", new Alumno()};

            for (int i = 0; i < frutas.Length; i++)
            {
                Console.WriteLine($"Fruta {i} : {frutas[i]}");
            }

            foreach(var item in objectos)
            {
                Console.WriteLine(item);
            }



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



    CONVERSION DE TIPOS DE DATOS:

    - Explicito: Cuando conviertes variables de mayor # bytes. long -> int
    long b = 5;
    int a = (int) b;
    // Peligroso! 
    int a = 1500;
    byte b = (byte) a; // esto devuelve 220
    // 1500 = 10111011100
    // 220  =    11011100  


    - Implitico: Cuando pasas de variables de menor # de bytes. int -> long
    long b;
    int a = 5;
    b = a; // 5 ya es un long

    - usando Convert:
    int a = 1500;
    byte b = Convert.toByte(a) // devolvería excepción porque no es posible

    - Convirtiendo Alfanuméricos:
    string var3 = "45";
    int var1;
    // dos opciones que podrían dar error
    var1 = Convert.toInt(var3);
    var1 = int.Parse("89");
    // opción que no da error, devuelve falso si no lo hace bien
    bool resultado = int.TryParse(var3, out var1);

    

*/

