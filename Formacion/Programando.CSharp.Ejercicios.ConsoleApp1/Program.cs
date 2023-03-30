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
            //ConsultasBasicas();
            Ejercicios();
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

            var r6d = DataLists.ListaProductos
                .Where(r => r.Id == 4)
                .FirstOrDefault(); // Devuelve el primer registro que encuentre o null si no existe

            // paginación se realizaría en la base de datos
            var listaProd1 = DataLists.ListaProductos
                .OrderBy(r => r.Descripcion)
                .Skip(5)  // salta los 5 primeros
                .Take(5) // toma los 5 siguientes
                .Select(r => r);

            // paginación se realizaría en el equipo
            var listaProd2 = DataLists.ListaProductos
                .OrderBy(r => r.Descripcion)
                .Select(r => r)
                .Skip(5)  // salta los 5 primeros
                .Take(5); // toma los 5 siguientes

        }

        static void Ejercicios()
        {
            // Listado de clientes mayores de 30 años
            Console.WriteLine("\n");
            var hoy = DateTime.Now;

            var clientesMayor40 = DataLists.ListaClientes
                .Where(r => (hoy.Subtract(r.FechaNac).Days / 365 > 40))
                .Select(r => r);

            foreach (var item in clientesMayor40)
            {
                Console.WriteLine($"{item.Nombre}  {item.FechaNac}");
            }

            /*
                Carlos Gonzalez Rodriguez  10/10/1980 0:00:00
                Luis Gomez Fernandez  20/04/1961 0:00:00
                Ana Lopez Diaz   15/01/1947 0:00:00
                Fernando Martinez Perez  05/08/1981 0:00:00
                Lucia Garcia Sanchez  03/11/1973 0:00:00
            */

            // Listado de productos que comiencen por la letra C ordenados por precio
            Console.WriteLine("\n");
            var productosOrdenadosPrecio = from r in DataLists.ListaProductos
                                           where r.Descripcion.ToLower().StartsWith("c")
                                           orderby r.Precio descending
                                           select r;

            foreach (var item in productosOrdenadosPrecio)
            {
                Console.WriteLine($"ID {item.Id} : Descripcion {item.Descripcion}  : Precio {item.Precio}");
            }

            /*
                ID 2 : Descripcion Cuaderno grande   : Precio 1,5
                ID 7 : Descripcion Cinta adhesiva    : Precio 1,1
                ID 3 : Descripcion Cuaderno pequeño  : Precio 1
            */

            // Preguntar por el ID de un pedido y listar el contenido de los productos
            // vamos a preguntar por el pedido Id = 1
            Console.WriteLine("\nInserta un número de pedido:  ");
            string Id = Console.ReadLine();
            var productosEnPedidos = from r in DataLists.ListaLineasPedido
                                    join r2 in DataLists.ListaProductos
                                    on r.IdProducto equals r2.Id
                                    where r.IdPedido == int.Parse(Id)
                                    select new
                                    {
                                        IdPedido = r.IdPedido,
                                        IdProducto = r2.Id,
                                        Descripcion = r2.Descripcion,
                                        Precio = r2.Precio,
                                        Cantidad = r.Cantidad,
                                    };

            foreach (var item in productosEnPedidos)
            {
                Console.WriteLine($"ID de pedido   :   {item.IdPedido}  :  Producto  => {item.Descripcion} Cant. {item.Cantidad}");
            }
            /*
                ID de pedido   :   1  :  Producto  => Boligrafo Cant. 9
                ID de pedido   :   1  :  Producto  => Cuaderno pequeño Cant. 7
                ID de pedido   :   1  :  Producto  => Grapadora Cant. 2
                ID de pedido   :   1  :  Producto  => Cinta adhesiva Cant. 2
            */


            // Preguntar por el ID de un pedido y mostrar el total del importe
            Console.WriteLine("\n");
            float preciototal = 0;
            foreach (var item in productosEnPedidos)
            {
                preciototal += item.Precio * item.Cantidad;
            }
            Console.WriteLine($"El pedido con Id {Id} tiene un precio total de {preciototal} euros");
            // El pedido con Id 1 tiene un precio total de 22,85 euros

            // Listado de pedidos que contengan Lapicero (11)
            Console.WriteLine("\n");
            var pedidosDeLapiceros = from r in DataLists.ListaLineasPedido
                                     join o in DataLists.ListaProductos
                                     on r.IdProducto equals o.Id
                                     where o.Descripcion.ToLower().Contains("lapicero")
                                     select new
                                     {
                                         IdPedido = r.IdPedido,
                                         Cantidad = r.Cantidad,
                                     };

            foreach (var item in pedidosDeLapiceros)
            {
                Console.WriteLine($"El pedido con ID : {item.IdPedido} compró {item.Cantidad} lapiceros");
            }
            /*
                El pedido con ID : 2 compró 15 lapiceros
                El pedido con ID : 7 compró 2 lapiceros
                El pedido con ID : 10 compró 10 lapiceros
             */


            // Cantidad de pedidos que contengan Cuaderno Grande
            Console.WriteLine("\n");
            var pedidosCuardernoGrande = from r in DataLists.ListaLineasPedido
                                         join r2 in DataLists.ListaProductos
                                         on r.IdProducto equals r2.Id
                                         where r2.Descripcion.ToLower() == "cuaderno grande"
                                         select new
                                         {
                                             IdPedido = r.IdPedido,
                                             Cantidad = r.Cantidad,
                                         };

            Console.WriteLine($"Pedidos que pidieron Cuaderno Grande  :   {pedidosCuardernoGrande.Count()}");
            // Pedidos que pidieron Cuaderno Grande  :   4

            // Unidades vendidas de Cuaderno Pequeño
            Console.WriteLine("\n");
            var pedidosCuardernoPequeño = from r in DataLists.ListaLineasPedido
                                          join r2 in DataLists.ListaProductos
                                          on r.IdProducto equals r2.Id
                                          where r2.Descripcion.ToLower() == "cuaderno pequeño"
                                          select r;

            

            Console.WriteLine($"Cantidad de Cuadernos pequeños vendidos  :  {pedidosCuardernoPequeño.Sum(r => r.Cantidad)}");
            // Cantidad de Cuadernos pequeños vendidos  :  18

            // El pedido que más unidades contiene
            // ATASCADO, demasiado CODIGO para algo tan simple
            Console.WriteLine("\n");
            var todosPedidos = from r in DataLists.ListaLineasPedido
                               select new
                               {
                                   id = r.IdPedido,
                                   cantidad = r.Cantidad,
                               };



            var IdViejo = 1;
            var cantidad = 0;
            List<Dictionary<String, int>> pedidosCantidad = new List<Dictionary<String, int>>();
            foreach (var item in todosPedidos)
            {
                var IdPedido = item.id;
                if (IdPedido == IdViejo)
                {
                    cantidad += item.cantidad;
                }
                else if (IdPedido != IdViejo)
                {
                    pedidosCantidad.Add(new Dictionary<string, int>
                    {
                        ["Id"] = IdViejo,
                        ["cantidad"] = cantidad,
                    });
                    cantidad = item.cantidad;
                    IdViejo++;
                }

            }
            pedidosCantidad.Add(new Dictionary<string, int> // última ejecución de cierre
            {
                ["Id"] = IdViejo,
                ["cantidad"] = cantidad,
            });

            var oList = pedidosCantidad.OrderByDescending(r => r["cantidad"]);

            Console.WriteLine($"El pedido {oList.First()["Id"]} contiene un total de {oList.First()["cantidad"]}");
            // El pedido 6 contiene un total de 27

            // Listado de pedidos ordenado por fecha
            Console.WriteLine("\n");
            var pedidosOrdenados = from r in DataLists.ListaPedidos
                                   orderby r.FechaPedido descending
                                   select r;

            foreach (var item in pedidosOrdenados)
            {
                Console.WriteLine($"Pedido {item.Id} - Fecha : {item.FechaPedido}");
            }
            /*
                Pedido 10 - Fecha : 29/11/2013 0:00:00
                Pedido 9 - Fecha : 22/11/2013 0:00:00
                Pedido 12 - Fecha : 11/11/2013 0:00:00
                Pedido 8 - Fecha : 08/11/2013 0:00:00
                Pedido 4 - Fecha : 05/11/2013 0:00:00
                Pedido 11 - Fecha : 19/10/2013 0:00:00
                Pedido 3 - Fecha : 12/10/2013 0:00:00
                Pedido 2 - Fecha : 08/10/2013 0:00:00
                Pedido 5 - Fecha : 04/10/2013 0:00:00
                Pedido 1 - Fecha : 01/10/2013 0:00:00
                Pedido 7 - Fecha : 01/10/2013 0:00:00
                Pedido 6 - Fecha : 09/07/2013 0:00:00
             */

        }
    }

}
