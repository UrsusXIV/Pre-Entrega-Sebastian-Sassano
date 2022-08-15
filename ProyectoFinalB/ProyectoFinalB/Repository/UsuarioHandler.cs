using ProyectoFinalB.Modells;
using System.Data.SqlClient;

namespace ProyectoFinalB.Repository
{
    public class UsuarioHandler : DBHandler
    {

        public List<ClaseUsuario> traerUsuarios()
        {
            List<ClaseUsuario> listaUsuarios = new List<ClaseUsuario>();

            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                var selectQuery = "SELECT * FROM Usuario";

                sqlConnection.Open();

                using (SqlCommand sqlCommand = new SqlCommand(selectQuery, sqlConnection))
                {
                    using (SqlDataReader dataReader = sqlCommand.ExecuteReader())
                    {
                        if (dataReader.HasRows)
                        {
                            while (dataReader.Read())
                            {
                                var parUsuario = new ClaseUsuario();

                                parUsuario.setId(Convert.ToInt32(dataReader["Id"]));

                                parUsuario.setNombre(Convert.ToString(dataReader["Nombre"]));

                                parUsuario.setApellido(Convert.ToString(dataReader["Apellido"]));

                                parUsuario.setNombreUsuario(Convert.ToString(dataReader["NombreUsuario"]));

                                parUsuario.setContraseña(Convert.ToString(dataReader["Contraseña"]));

                                parUsuario.setMail(Convert.ToString(dataReader["Mail"]));


                                listaUsuarios.Add(parUsuario);


                            }
                        }
                    }
                }
                sqlConnection.Close();
            }
            return listaUsuarios;
        }

        public List<ClaseUsuario> funcionLog(string mailCargado)
        {
            List<ClaseUsuario> validacionBasica = new List<ClaseUsuario>();

            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                var validacionQuery = $"SELECT Contraseña FROM Usuario WHERE Mail = '{mailCargado}'";

                sqlConnection.Open();

                using (SqlCommand sqlCommand = new SqlCommand(validacionQuery, sqlConnection))
                {
                    using(SqlDataReader dataReaderValidacion = sqlCommand.ExecuteReader())
                    {
                        if (dataReaderValidacion.HasRows)
                        {
                            while (dataReaderValidacion.Read())
                            {
                                var parLogValido = new ClaseUsuario();

                                parLogValido.setContraseña(Convert.ToString(dataReaderValidacion["Contraseña"]));

                                validacionBasica.Add(parLogValido);

                            }
                        }
                    }
                }
                sqlConnection.Close();
            }
            return validacionBasica;
        }
    }
}
