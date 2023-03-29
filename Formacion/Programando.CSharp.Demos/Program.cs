using System.Collections;
using System.Collections.Generic;

namespace Programando.CSharp.Demos
{
    public class Program
    {
        public static void Main(string[] args)
        {
            ArrayList();

            Hashtable();

            List();

            Dictionary();

        }


        public static void ArrayList()
        {
            // Instanciar
            ArrayList array = new ArrayList();          // Lista de Objects

            // Limpiar y eliminar los elementos
            array.Clear();

            // Añedir elementos al array
            array.Add(0);
            array.Add("hola");
            array.Add(new { Nombre = "Andres", Apellidos = "Perez" });
            array.Add(new Alumno());

            // Añadir los elementos de otra colección
            var colores = new String[] { "azul", "rojo", "verde", "amarillo" };
            array.AddRange(colores);

            // Añadir elementos a partir de una posicion
            array.Insert(4, "blanco");

            // Numero de elementos del ArrayList
            Console.WriteLine($"Numero de elementos : {array.Count}");

            // Eliminar elementos 
            array.Remove("amarillo");
            array.RemoveAt(4);
            array.RemoveRange(2, 2); // desde el 2, dos elementos

            // Saber si un elemento esta contenido
            Console.WriteLine($"Contiene el item rojo? : {array.Contains("rojo")}");

            // Ordenar los elementos
            //array.Sort();

            // Invertir el orden

            //array.Reverse();
 
            // Recorrer el ArrayList
            foreach(var item in array)
            {
                Console.WriteLine($"Item : {item.GetType()}");
            }

            for (int i = 0; i < array.Count; i++)
            {
                Console.WriteLine($"Item {i} : {array[i].GetType()}");
            }

        }

        public static void Hashtable()
        {
            // Instanciar
            var ht = new Hashtable(); // Diccionario de Object/Object (clave/valor)

            // Eliminar todos los elementos
            ht.Clear();

            // Añadir elementos
            ht.Add(1200, "Andres Perez");
            ht.Add("ANATR", "Ana Trujillo");
            ht.Add("Alumno1", new Alumno());

            // Numero de elementos
            Console.WriteLine($"Numero de elementos : {ht.Count}");

            // Eliminar elementos
            ht.Remove(1200);

            // Recorrer el Hashtable
            foreach (var clave in ht.Keys)
            {
                Console.WriteLine($"{clave} : {ht[clave]}");
            }
        }

        public static void List() 
        {
            // Crear una lista
            List<string> list = new List<string>();
            List<string> list1 = new();
            var list2 = new List<string>();

            // Eliminar los elementos
            list.Clear();

            // Añadir elementos
            list.Add("Hola");
            list.Add("Andres Perez");
            list.Add("Borja");

            list1.Add("naranja");
            list1.Add("limón");
            list1.Add("melón");
            list1.Add("manzana");
            list1.Add("ciruela");

            list.AddRange(new List<string>(list1));

            // Obtener el número de elementos
            Console.WriteLine($"Numero de elementos  :  {list.Count}");

            // Eliminar elementos
            list.Remove("limón");
            list.RemoveAt(3);
            list.RemoveRange(2, 2);

            // Ordenar los elementos
            list.Sort();

            // Invertir el orden
            list.Reverse();

            // Convertir un un array de Object[]
            var nuevoarray = list.ToArray();

            // Recorrer el list
            foreach (var item in nuevoarray)
            { 
                Console.WriteLine($" Item {list.IndexOf(item)}  :  {item}");
            }

            for (var i = 0; i < list.Count; i++)
            {
                Console.WriteLine($" Item {i}  :  {list[i]}");
            }

        }

        public static void Dictionary()
        {
            // Crear un diccionario
            Dictionary<int, string> dictionary = new Dictionary<int, string>();
            Dictionary<int, string> dictionary1 = new(); // forma nueva en net 7.0
            var dictionary2 = new Dictionary<int, string>();

            // Eliminar los elementos
            dictionary.Clear();

            // Añadir elementos
            dictionary.Add(3, "Hola");
            dictionary.Add(4, "Borja");
            dictionary.TryAdd(4, "Andres");
            dictionary.Add(5, "Ana");

            // Contar elementos
            Console.WriteLine($"Numero de elementos  :  {dictionary.Count}");

            // Eliminar elemento
            dictionary.Remove(3);

            // Recorrer el diccionario
            foreach (var item in dictionary.Keys) 
            { 
                Console.WriteLine($"   {item}  :  {dictionary[item]}");
            }


        }

    }

    public class Alumno
    {
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public int Edad { get; set; }
    }

}