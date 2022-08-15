using System.Data.SqlClient;
using ProyectoFinalB.Modells;


namespace ProyectoFinalB.Repository
{
    public class ProductoHandler : DBHandler
    {

        public List<ClaseProducto>traerProductos()
        {
            List<ClaseProducto> listaProductos = new List<ClaseProducto>();

            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                var selectQuery = "SELECT * FROM Producto";

                sqlConnection.Open();

                using (SqlCommand sqlCommand = new SqlCommand(selectQuery, sqlConnection))
                {
                    
                    
                   using(SqlDataReader dataReader = sqlCommand.ExecuteReader())
                    {
                        if (dataReader.HasRows)
                        {
                            while (dataReader.Read())
                            {
                                var parProduct = new ClaseProducto();

                                parProduct.setId(Convert.ToInt32(dataReader["Id"]));

                                parProduct.setDescripciones(Convert.ToString(dataReader["Descripciones"]));

                                parProduct.setCosto(Convert.ToDouble(dataReader["Costo"]));

                                parProduct.setPrecioVenta(Convert.ToDouble(dataReader["PrecioVenta"]));

                                parProduct.setStock(Convert.ToInt32(dataReader["Stock"]));

                                parProduct.setIdUsuario(Convert.ToInt32(dataReader["IdUsuario"]));

                                listaProductos.Add(parProduct);


                            }
                          
                        }


                    }


                    

                    // Todo: Añadir return
                }
                sqlConnection.Close();
            }
            return listaProductos;
        }

    }
}
