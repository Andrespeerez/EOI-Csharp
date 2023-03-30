using System;
using System.Collections.Generic;
using System.Linq;

namespace Programando.CSharp.Ejercicios.ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Clear();
            ConsultasBasicas();
        }

        static void ConsultasBasicas()
        {
            //   T-SQL : SELECT * FROM dbo.ListaProductos

            // Metodos de LINQ
            var r1a = DataLists.ListaProductos
                .Select(r => r);

            // Expresion de LINQ
            var r1b = from r in DataLists.ListaProductos 
                      select r;      

            foreach(Producto item in r1a)
            {
                Console.WriteLine($"{item.Id}  : {item.Descripcion} ");
            }

            

            // Metodos de LINQ
            var r2a = DataLists.ListaClientes
                .Select(r => r.Nombre);

            // Expresion de LINQ
            var r2b = from r in DataLists.ListaClientes
                      select r.Nombre;

            foreach (string item in r2b)
            {
                Console.WriteLine($"{item} ");
            }

            //   T-SQL : SELECT id, nombre FROM dbo.ListaClientes

            // Metodos de LINQ
            var r3a = DataLists.ListaClientes
                .Select(r => new { r.Id, r.Nombre });

            // Expresion de LINQ
            var r3b = from r in DataLists.ListaClientes
                      select new { r.Id, r.Nombre };

            foreach (var item in r3b)
            {
                Console.WriteLine($"{item.Id} --- {item.Nombre}");
            }

            //   T-SQL : SELECT id AS Code, Nombre AS NombreCompleto FROM dbo.ListaClientes

            // Metodos de LINQ
            var r3c  = DataLists.ListaClientes
                .Select(r => new { Code = r.Id, NombreCompleto = r.Nombre });

            foreach (var item in r3c)
            {
                Console.WriteLine($"{item.Code} --- {item.NombreCompleto}");
            }



            //   T-SQL : SELECT descripcion FROM dbo.ListaProductos WHERE precio < 0.90

            // Metodo de LINQ
            var r4a = DataLists.ListaProductos
                .Where(r => r.Precio < 0.90)
                .Select(r => r.Descripcion);

            // Expresión LINQ
            var r4b = from r in DataLists.ListaProductos
                      where r.Precio < 0.90
                      select r.Descripcion;

            foreach (var item in r4a)
            {
                Console.WriteLine($"{item}");
            }



            //   T-SQL : SELECT descripcion FROM dbo.ListaProductos WHERE precio < 0.90 ORDER BY Description

            // Metodo de LINQ
            var r5a = DataLists.ListaProductos
                .Where(r => r.Precio < 0.90)
                .OrderBy(r => r.Descripcion)
                //.OrderByDescending(r => r.Descripcion)
                .Select(r => r.Descripcion);

            // Expresión LINQ
            var r5b = from r in DataLists.ListaProductos
                      where r.Precio < 0.90
                      orderby r.Descripcion
                      //orderby r.Descripcion descending
                      select r.Descripcion;

            foreach (var item in r5b)
            {
                Console.WriteLine($"{item}");
            }


            // Otros ejemplos

            // Contains -> Contiene, StartsWith -> Empieza, EndsWith -> Termina

            var r6a = DataLists.ListaProductos
                .Where(r => r.Descripcion.ToLower().Contains("oli"))
                .Select(r => r.Descripcion);

            var r6b = DataLists.ListaProductos
                .Where(r => r.Descripcion.ToLower().StartsWith("bol"))
                .Select(r => r.Descripcion);

            var r6c = DataLists.ListaProductos
                .Where(r => r.Descripcion.ToLower().EndsWith("afo"))
                .Select(r => r.Descripcion);

            foreach (var item in r6a) 
            {
                Console.WriteLine($"{item}");
            }

            foreach (var item in r6b)
            {
                Console.WriteLine($"{item}");
            }

            foreach (var item in r6c)
            {
                Console.WriteLine($"{item}");
            }

            // Funciones de agregacion
            //  Count       -> Cuenta elementos
            //  Distinct    -> si se repiten, solo 1 vex
            //  Max         -> valor máximo
            //  Min         -> valor mínimo
            //  Sum         -> suma
            //  Average     -> media valores
            //  Aggregate   -> aplica una fórmula o método de agregación


        }
    }

}
