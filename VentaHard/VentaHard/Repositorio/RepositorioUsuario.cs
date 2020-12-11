using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using VentaHard.Entities;

namespace VentaHard.Repositorio
{
    public class RepositorioUsuario
    {
        /// <summary>
        /// Devuelve todos los Usuarios de la base de datos
        /// </summary>
        /// <returns></returns>
        public List<Usuario> GetAll()
        {
            List<Usuario> listaDeUsuarios = new List<Usuario>();
            string cadena = "Data Source = " + Path.Combine(Directory.GetCurrentDirectory(), "Datos\\Datos.db");
            var conexion = new SQLiteConnection(cadena);
            conexion.Open();
            var command = conexion.CreateCommand();
            string instruccion = @"SELECT   IdUsuario, 
                                            NombreUsuario, 
                                            Telefono 
                                            FROM Usuarios
                                            Where Activo = 1";
            command.CommandText = instruccion;
            var reader = command.ExecuteReader();
            while (reader.Read())
            {
                var Usuario = new Usuario();
                Usuario.IdUsuario = Convert.ToInt32(reader["IdUsuario"]);
                Usuario.NombreUsuario = reader["NombreUsuario"].ToString();
                Usuario.Telefono = reader["Telefono"].ToString();
                listaDeUsuarios.Add(Usuario);
            }
            conexion.Close();
            return listaDeUsuarios;
        }

        /// <summary>
        /// Crea un usuario en la Base de datos
        /// </summary>
        /// <param name="usuario"></param>
        public void AltaUsuario(Usuario usuario)
        {
            string cadena = "Data Source = " + Path.Combine(Directory.GetCurrentDirectory(), "Datos\\Datos.db");
            var conexion = new SQLiteConnection(cadena);
            conexion.Open();
            var command = conexion.CreateCommand();
            command.CommandText = @"INSERT INTO 
                                    Usuarios (NombreUsuario, Telefono) 
                                    VALUES (@nombre, @telefono)";

            command.Parameters.AddWithValue("@nombre", usuario.NombreUsuario);
            command.Parameters.AddWithValue("@telefono", usuario.Telefono);            
            command.ExecuteNonQuery();
            conexion.Close();
        }

        /// <summary>
        /// Obtiene un usuario del base de datos
        /// </summary>
        /// <param name="idUsuario"></param>
        /// <returns></returns>
        public Usuario GetUsuario(int idUsuario)
        {
            var usuario = new Usuario();
            string cadena = "Data Source = " + Path.Combine(Directory.GetCurrentDirectory(), "Datos\\Datos.db");
            var conexion = new SQLiteConnection(cadena);
            conexion.Open();
            var command = conexion.CreateCommand();
            string instruccion = @"SELECT IdUsuario, NombreUsuario, Telefono 
                                   FROM Usuarios
                                   Where Activo = 1 AND IdUsuario = @idUsuario";
            command.CommandText = instruccion;
            command.Parameters.AddWithValue("@idUsuario", idUsuario);
            var reader = command.ExecuteReader();

            while (reader.Read())
            {
                usuario.IdUsuario = Convert.ToInt32(reader["IdUsuario"]);
                usuario.NombreUsuario = reader["NombreUsuario"].ToString();
                usuario.Telefono = reader["Telefono"].ToString();                
            }
            conexion.Close();

            return usuario;
        }

        /// <summary>
        /// Permite Modificar un usuario dado en Una base de Datos
        /// </summary>
        /// <param name="usuario"></param>
        public void ModificarUsuario(Usuario usuario)
        {
            string cadena = "Data Source = " + Path.Combine(Directory.GetCurrentDirectory(), "Datos\\Datos.db");
            var conexion = new SQLiteConnection(cadena);
            conexion.Open();
            var command = conexion.CreateCommand();
            command.CommandText = @"UPDATE Usuarios 
                                    SET NombreUsuario = @nombreUsuario, Telefono = @telefono                                        
                                    WHERE IdUsuario = @idUsuario";
            command.Parameters.AddWithValue("@nombreUsuario", usuario.NombreUsuario);
            command.Parameters.AddWithValue("@telefono", usuario.Telefono);
            command.Parameters.AddWithValue("@idUsuario", usuario.IdUsuario);
            
            command.ExecuteNonQuery();
            conexion.Close();
        }

        /// <summary>
        /// Permite eliminar un Usuario de la base de datos
        /// </summary>
        /// <param name="idUsuario"></param>
        public void EliminarUsuario(int idUsuario)
        {
            string cadena = "Data Source = " + Path.Combine(Directory.GetCurrentDirectory(), "Datos\\Datos.db");
            var conexion = new SQLiteConnection(cadena);
            conexion.Open();
            var command = conexion.CreateCommand();
            command.CommandText = @"UPDATE Usuarios 
                                    SET Activo = 0
                                    WHERE IdUsuario = @idUsuario;";
            command.Parameters.AddWithValue("@IdUsuario", idUsuario);
            command.ExecuteNonQuery();
            conexion.Close();
        }
       
    }
}
