using ProyectoFinalB.Modells;
using System.Data.SqlClient;

namespace ProyectoFinalB.Repository
{
    public class ProductoVendidoHandler : DBHandler
    {
        public List<ClaseProductoVendido> traerProductosVendidos()
        {
            List<ClaseProductoVendido> listaProductosVendidos = new List<ClaseProductoVendido>();

            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                var selectQuery = "SELECT ProductoVendido.*,Producto.Descripciones FROM ProductoVendido INNER JOIN Producto ON Producto.Id = ProductoVendido.IdProducto";

                sqlConnection.Open();

                using (SqlCommand sqlCommand = new SqlCommand(selectQuery, sqlConnection))
                {
                    using (SqlDataReader dataReader = sqlCommand.ExecuteReader())
                    {
                        if (dataReader.HasRows)
                        {
                            while (dataReader.Read())
                            {
                                var parProductV = new ClaseProductoVendido();

                                parProductV.setId(Convert.ToInt32(dataReader["Id"]));

                                parProductV.setStock(Convert.ToInt32(dataReader["Stock"]));

                                parProductV.setIdVenta(Convert.ToInt32(dataReader["IdVenta"]));

                                parProductV.setDescripciones(Convert.ToString(dataReader["Descripciones"]));

                                listaProductosVendidos.Add(parProductV);


                            }
                        }
                    }
                }
                sqlConnection.Close();
            }
            return listaProductosVendidos;
        }

    }
}
