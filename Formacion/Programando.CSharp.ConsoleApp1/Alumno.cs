namespace Programando.CSharp.ConsoleApp1.Model
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