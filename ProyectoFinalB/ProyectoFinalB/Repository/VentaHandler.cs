using ProyectoFinalB.Modells;
using System.Data.SqlClient;

namespace ProyectoFinalB.Repository
{
    public class VentaHandler : DBHandler
    {
        public List<ClaseVenta> traerVenta()
        {
            List<ClaseVenta> listaVenta = new List<ClaseVenta>();

            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                var selectQuery = "SELECT * FROM Venta";

                sqlConnection.Open();

                using (SqlCommand sqlCommand = new SqlCommand(selectQuery, sqlConnection))
                {
                    using (SqlDataReader dataReader = sqlCommand.ExecuteReader())
                    {
                        if (dataReader.HasRows)
                        {
                            while (dataReader.Read())
                            {
                                var parVenta = new ClaseVenta();

                                parVenta.setId(Convert.ToInt32(dataReader["Id"]));

                                listaVenta.Add(parVenta);


                            }

                        }


                    }




                    // Todo: Añadir return
                }
                sqlConnection.Close();
            }
            return listaVenta;
        }

    }
}
