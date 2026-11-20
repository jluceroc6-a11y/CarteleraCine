using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;

namespace CarteleraCine
{
    public class FuncionRepositorio
    {
        private const string cadenaConexion =
            @"Server=(localdb)\MSSQLLocalDB;Database=CarteleraDB;Trusted_Connection=True;TrustServerCertificate=True;";

        public void Insertar(Funcion x)
        {
            using (SqlConnection conexion = new SqlConnection(cadenaConexion))
            {
                string consulta = "INSERT INTO Funciones (Pelicula, Sala, Precio) VALUES (@Pelicula, @Sala, @Precio)";

                using (SqlCommand comando = new SqlCommand(consulta, conexion))
                {
                    comando.Parameters.AddWithValue("@Pelicula", x.Pelicula);
                    comando.Parameters.AddWithValue("@Sala", x.Sala);

                    SqlParameter precio = comando.Parameters.Add("@Precio", SqlDbType.Decimal);
                    precio.Precision = 10;
                    precio.Scale = 2;
                    precio.Value = x.Precio;

                    conexion.Open();
                    comando.ExecuteNonQuery();
                }
            }
        }

        public List<Funcion> ListarTodos()
        {
            List<Funcion> funciones = new List<Funcion>();

            using (SqlConnection conexion = new SqlConnection(cadenaConexion))
            {
                string consulta = "SELECT * FROM Funciones ORDER BY Id";

                using (SqlCommand comando = new SqlCommand(consulta, conexion))
                {
                    conexion.Open();

                    using (SqlDataReader lector = comando.ExecuteReader())
                    {
                        while (lector.Read())
                        {
                            Funcion x = new Funcion();

                            x.Id = Convert.ToInt32(lector["Id"]);
                            x.Pelicula = lector["Pelicula"].ToString();
                            x.Sala = lector["Sala"].ToString();
                            x.Precio = Convert.ToDecimal(lector["Precio"]);

                            funciones.Add(x);
                        }
                    }
                }
            }

            return funciones;
        }

        public Funcion? BuscarPorId(int id)
        {
            using (SqlConnection conexion = new SqlConnection(cadenaConexion))
            {
                string consulta = "SELECT * FROM Funciones WHERE Id = @Id";

                using (SqlCommand comando = new SqlCommand(consulta, conexion))
                {
                    comando.Parameters.AddWithValue("@Id", id);

                    conexion.Open();

                    using (SqlDataReader lector = comando.ExecuteReader())
                    {
                        if (lector.Read())
                        {
                            Funcion x = new Funcion();

                            x.Id = Convert.ToInt32(lector["Id"]);
                            x.Pelicula = lector["Pelicula"].ToString();
                            x.Sala = lector["Sala"].ToString();
                            x.Precio = Convert.ToDecimal(lector["Precio"]);

                            return x;
                        }
                    }
                }
            }

            return null;
        }

        public bool Actualizar(Funcion x)
        {
            using (SqlConnection conexion = new SqlConnection(cadenaConexion))
            {
                string consulta = "UPDATE Funciones SET Precio = @Precio WHERE Id = @Id";

                using (SqlCommand comando = new SqlCommand(consulta, conexion))
                {
                    SqlParameter precio = comando.Parameters.Add("@Precio", SqlDbType.Decimal);
                    precio.Precision = 10;
                    precio.Scale = 2;
                    precio.Value = x.Precio;

                    comando.Parameters.AddWithValue("@Id", x.Id);

                    conexion.Open();

                    return comando.ExecuteNonQuery() == 1;
                }
            }
        }

        public bool Eliminar(int id)
        {
            using (SqlConnection conexion = new SqlConnection(cadenaConexion))
            {
                string consulta = "DELETE FROM Funciones WHERE Id = @Id";

                using (SqlCommand comando = new SqlCommand(consulta, conexion))
                {
                    comando.Parameters.AddWithValue("@Id", id);

                    conexion.Open();

                    return comando.ExecuteNonQuery() == 1;
                }
            }
        }
    }
}