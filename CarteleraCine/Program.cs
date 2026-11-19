using System;
using System.Collections.Generic;
using System.Globalization;
using Microsoft.Data.SqlClient;

namespace CarteleraCine
{
    public class Program
    {
        static FuncionRepositorio repositorio = new FuncionRepositorio();

        public static void Main(string[] args)
        {
            bool continuar = true;

            do
            {
                Console.WriteLine("\n===== CARTELERA DE CINE =====");
                Console.WriteLine("1. Registrar funcion");
                Console.WriteLine("2. Listar funciones");
                Console.WriteLine("3. Buscar funcion por ID");
                Console.WriteLine("4. Actualizar precio");
                Console.WriteLine("5. Eliminar funcion");
                Console.WriteLine("6. Salir");
                Console.Write("Seleccione una opcion: ");

                if (!int.TryParse(Console.ReadLine(), out int opcion))
                {
                    Console.WriteLine("Opcion no valida.");
                    continue;
                }

                if (opcion < 1 || opcion > 6)
                {
                    Console.WriteLine("Opcion no valida.");
                    continue;
                }

                try
                {
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
                    }
                }
                catch (SqlException ex)
                {
                    Console.WriteLine("Error de base de datos: " + ex.Message);
                }

            } while (continuar);
        }

        static void RegistrarFuncion()
        {
            Funcion funcion = new Funcion();

            Console.Write("Nombre de la pelicula: ");
            funcion.Pelicula = Console.ReadLine();

            Console.Write("Sala: ");
            funcion.Sala = Console.ReadLine();

            Console.Write("Precio: ");
            string entradaPrecio = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(funcion.Pelicula) ||
                string.IsNullOrWhiteSpace(funcion.Sala) ||
                !decimal.TryParse(entradaPrecio, NumberStyles.Number,
                    CultureInfo.InvariantCulture, out decimal precio) ||
                precio <= 0)
            {
                Console.WriteLine("Datos inválidos.");
                return;
            }

            funcion.Precio = precio;

            repositorio.Insertar(funcion);

            Console.WriteLine("Función registrada.");
        }

        static void ListarFunciones()
        {
            List<Funcion> funciones = repositorio.ListarTodos();

            if (funciones.Count == 0)
            {
                Console.WriteLine("No hay funciones registradas.");
                return;
            }

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

            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("Id inválido.");
                return;
            }

            Funcion funcion = repositorio.BuscarPorId(id);

            if (funcion != null)
            {
                Console.WriteLine(funcion);
            }
            else
            {
                Console.WriteLine("No existe ese Id.");
            }
        }

        static void ActualizarPrecio()
        {
            Console.Write("Ingrese el ID de la funcion: ");

            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("Id inválido.");
                return;
            }

            Funcion funcion = repositorio.BuscarPorId(id);

            if (funcion == null)
            {
                Console.WriteLine("No existe ese Id.");
                return;
            }

            Console.Write("Ingrese el nuevo precio: ");

            if (!decimal.TryParse(Console.ReadLine(), NumberStyles.Number,
                CultureInfo.InvariantCulture, out decimal nuevoPrecio) ||
                nuevoPrecio <= 0)
            {
                Console.WriteLine("Precio inválido.");
                return;
            }

            funcion.Precio = nuevoPrecio;

            if (repositorio.Actualizar(funcion))
            {
                Console.WriteLine("Función actualizada.");
            }
            else
            {
                Console.WriteLine("No existe ese Id.");
            }
        }

        static void EliminarFuncion()
        {
            Console.Write("Ingrese el ID de la funcion: ");

            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("Id inválido.");
                return;
            }

            if (repositorio.Eliminar(id))
            {
                Console.WriteLine("Función eliminada.");
            }
            else
            {
                Console.WriteLine("No existe ese Id.");
            }
        }
    }
}
