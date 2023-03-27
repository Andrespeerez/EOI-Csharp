using System;

namespace Programando.CSharp.Demos
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.Clear();

            // de tipo referencia
            var alumno = new Alumno();
            var alumno2 = new Alumno("Andres");
            var alumno3 = new Alumno("Andres", "Perez", 29);

            alumno.Nombre = "Rodrigo";
            alumno.Edad = 25;
            alumno.Apellidos = "Diaz de Vivar";
            Console.WriteLine($"{alumno.Nombre} {alumno.Apellidos} tiene {alumno.Edad} años");

        }

    }

    // Tipo referencia
    public class Persona
    {
        public string nombre = "";
        public int edad = 0;
        
    }

    // Tipo valor!!!
    public struct Persona2
    {
        public string nombre = "";
        public int edad = 0;

        public Persona2()
        {

        }
        
    }

    public class Demo
    {

        public void Transforma(ref int a, out int b)
        {
            Console.WriteLine($"Transformando Datos");
            a = a * 10;

            // al poner out debemos asignar si o si el valor antes de usar b
            // se puede el valor que tenía de entrada sin poder usarlo
            b = 0;
            b = a * 20;

            Console.WriteLine($"Valor A : {a}");
            Console.WriteLine($"Valor B : {b}");

        }

        // persona es tipo referencia (class)
        public bool Transforma(Persona p)
        {
            p.nombre = "Julian";
            p.edad = 27;

            return true;
        }

        // persona 2 es tipo valor (struct)
        public bool Transforma(Persona2 p)
        {
            p.nombre = "Julian";
            p.edad = 27;

            return true;
        }

        // persona 2 es tipo valor (struct)
        public bool Transforma(ref Persona2 p)
        {
            p.nombre = "Julian";
            p.edad = 27;

            return true;
        }


    }

    public class Alumno 
    {
        // Miembro : Variables
        private string nombre;
        private string apellidos;
        private int edad;

        // propiedades (dan acceso a las variables)
        public string Nombre
        {
            get
            {
                return nombre.Trim().ToLower();
            }

            set
            {
                this.nombre = value;
            } 
        }

        public int Edad 
        {
            get { 
                return edad; 
            }

            set { 
                if (value < 0 || value > 120)
                { 
                    this.edad = 0;
                } else {
                    this.edad = value;
                }
            }
        }

        public string Apellidos
        {
            get => apellidos.Trim().ToLower();
            set => this.apellidos = value;
        }
        
        // esta propiedad se comporta como una variable
        // no requiere declarar this.curso
        public string Curso { get; set; }

        public void MetodoUno()
        {

        }
        
        public int MetodoDos()
        {

            return 0;
        }

        public int MetodoTres(int param1 = 29, string param2 = "Borja")
        {
            this.nombre = param2;
            this.edad = param1;


            return 0;
        }

        public int Suma(int param1, int param2)
        {
            return param1+param2;
        }


        // Miembro : Metodo o funcion constructora
        // es publico, no tiene tipo y se llama = que la clase
        // no se puede invocar, se ejecuta al crear el objeto
        public Alumno()
        {
            this.Inicializa();
        }

        public Alumno(string nombre)
        {
            this.nombre = nombre;
        }

        public Alumno(string n, string a, int e)
        {
            this.nombre = n;
            this.apellidos = a;
            this.edad = e;

        }

        // Miembro : metodo o funcion destructora
        // no se puede invocar, se ejecutara automaticamente, no tiene parametros
        ~Alumno()
        {
            System.Diagnostics.Debug.WriteLine("Destrucción de objeto Alumno");
            this.nombre = null;
            this.apellidos = null;
            
        }

        private void Inicializa(string nombre = "", string apellidos = "", int edad = 0)
        {
            this.nombre = nombre;
            this.apellidos = apellidos;
            this.edad = edad;
        }

    }

}