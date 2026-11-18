using System;
using System.Collections.Generic;
using System.Globalization;
using CarteleraCine;

namespace CarteleraCine
{
    public class Program
    {
        static FuncionRepositorio repositorio = new FuncionRepositorio();

        public static void Main(string[] args)
        {
            bool continuar = true;

            while (continuar)
            {
                Console.WriteLine("\n===== CARTELERA DE CINE =====");
                Console.WriteLine("1. Registrar funcion");
                Console.WriteLine("2. Listar funciones");
                Console.WriteLine("3. Buscar funcion por ID");
                Console.WriteLine("4. Actualizar precio");
                Console.WriteLine("5. Eliminar funcion");
                Console.WriteLine("6. Salir");
                Console.Write("Seleccione una opcion: ");

                int opcion = int.Parse(Console.ReadLine());

                switch (opcion)
                {
                    case 1:
                        RegistrarFuncion();
                        break;

                    case 2:
                        ListarFunciones();
                        break;

                    case 3:
                        BuscarFuncion();
                        break;

                    case 4:
                        ActualizarPrecio();
                        break;

                    case 5:
                        EliminarFuncion();
                        break;

                    case 6:
                        continuar = false;
                        Console.WriteLine("Gracias por utilizar el sistema.");
                        break;

                    default:
                        Console.WriteLine("Opcion no valida.");
                        break;
                }
            }
        }

        static void RegistrarFuncion()
        {
            Funcion funcion = new Funcion();

            Console.Write("Nombre de la pelicula: ");
            funcion.Pelicula = Console.ReadLine();

            Console.Write("Sala: ");
            funcion.Sala = Console.ReadLine();

            Console.Write("Precio: ");
            funcion.Precio = decimal.Parse(Console.ReadLine());

            repositorio.Insertar(funcion);

            Console.WriteLine("Funcion agregada correctamente.");
        }

        static void ListarFunciones()
        {
            List<Funcion> funciones = repositorio.ListarTodos();

            decimal total = 0;

            Console.WriteLine("\n===== FUNCIONES REGISTRADAS =====");

            foreach (Funcion funcion in funciones)
            {
                Console.WriteLine(funcion);
                total += funcion.Precio;
            }

            Console.WriteLine("TOTAL DE PRECIOS: Q " +
                total.ToString("F2", CultureInfo.InvariantCulture));
        }

        static void BuscarFuncion()
        {
            Console.Write("Ingrese el ID de la funcion: ");
            int id = int.Parse(Console.ReadLine());

            Funcion funcion = repositorio.BuscarPorId(id);

            if (funcion != null)
            {
                Console.WriteLine(funcion);
            }
            else
            {
                Console.WriteLine("Funcion no encontrada.");
            }
        }

        static void ActualizarPrecio()
        {
            Console.Write("Ingrese el ID de la funcion: ");
            int id = int.Parse(Console.ReadLine());

            Funcion funcion = repositorio.BuscarPorId(id);

            if (funcion != null)
            {
                Console.Write("Ingrese el nuevo precio: ");
                funcion.Precio = decimal.Parse(Console.ReadLine());

                repositorio.Actualizar(funcion);

                Console.WriteLine("Precio actualizado correctamente.");
            }
            else
            {
                Console.WriteLine("Funcion no encontrada.");
            }
        }

        static void EliminarFuncion()
        {
            Console.Write("Ingrese el ID de la funcion: ");
            int id = int.Parse(Console.ReadLine());

            repositorio.Eliminar(id);

            Console.WriteLine("Funcion eliminada correctamente.");
        }
    }
}