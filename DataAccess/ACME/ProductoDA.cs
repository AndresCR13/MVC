using System.Data;
using Microsoft.Data.SqlClient;
using Models.ACME;

namespace DataAccess.ACME
{
    public class ProductoDA
    {
        private Conexion _Conexion = new Conexion();

        public void Insertar(ClsProducto clsProducto)
        {
            //instancia de conexion
            SqlConnection sqlConn = _Conexion.Conectar();
            SqlCommand sqlComm = new SqlCommand();

            try
            {
                sqlConn.Open();
                sqlComm.Connection = sqlConn;
                sqlComm.CommandType = CommandType.StoredProcedure;
                sqlComm.CommandText = "IngresarProducto";
                sqlComm.Parameters.Add(new SqlParameter("@Nombre", ClsProducto.Nombre));
                sqlComm.Parameters.Add(new SqlParameter("@Marca", ClsProducto.Marca));
                sqlComm.Parameters.Add(new SqlParameter("@Stock", ClsProducto.Stock));
                sqlComm.Parameters.Add(new SqlParameter("@PrecioCompra", ClsProducto.PrecioCompra));
                sqlComm.Parameters.Add(new SqlParameter("@PrecioVenta", ClsProducto.PrecioVenta));
                sqlComm.Parameters.Add(new SqlParameter("@FechaVencimiento", ClsProducto.FechaVencimiento));

                sqlComm.ExecuteNonQuery();
                sqlConn.Close();
            }
            catch (Exception ex)
            {

                throw new Exception("ProductoDA.Ingresar: " + ex.Message);
            }
            finally
            { 
                sqlConn.Dispose();
            
            }
        }
        public List<ClsProducto> Consultar()
        {
            //instancia de conexion
            SqlConnection sqlConn = _Conexion.Conectar();
            SqlDataReader sqlDataRead;
            SqlCommand sqlComm = new SqlCommand();

            List<ClsProducto>? listaProductos = new List<ClsProducto>();
            ClsProducto? clsProducto;

            try
            {
                sqlConn.Open();
                sqlComm.Connection = sqlConn;
                sqlComm.CommandType = CommandType.StoredProcedure;
                sqlComm.CommandText = "ConsultarProducto";


                sqlDataRead = sqlComm.ExecuteReader();

                while (sqlDataRead.Read())
                {
                    clsProducto = new();
                    ClsProducto.Nombre = sqlDataRead["Nombre"].ToString() ?? string.Empty;
                    ClsProducto.Marca = sqlDataRead["Marca"].ToString() ?? string.Empty; ;
                    ClsProducto.Stock = (int)sqlDataRead["Stock"];
                    if (sqlDataRead["PrecioCompra"] != DBNull.Value)
                    {
                        ClsProducto.PrecioCompra = (int)sqlDataRead["PrecioCompra"];
                    }
                    if (sqlDataRead["PrecioVenta"] != DBNull.Value)
                    {
                        ClsProducto.PrecioVenta = (int)sqlDataRead["PrecioVenta"];

                    }
                    if (sqlDataRead["FechaVencimiento"] != DBNull.Value)
                    {
                        ClsProducto.FechaVencimiento = (DateTime)sqlDataRead["FechaVencimiento"];
                    }
                    listaProductos.Add(clsProducto);
                }
                sqlConn.Close();

                return listaProductos;
            }
            catch (Exception ex)
            {

                throw new Exception("ProductoDA.Consultar: " + ex.Message);
            }
            finally
            {
                sqlConn.Dispose();

            }
        }
        public ClsProducto ConsultarProductoFiltro(int IdProducto)
        {
            //instancia de conexion
            SqlConnection sqlConn = _Conexion.Conectar();
            SqlDataReader sqlDataRead;
            SqlCommand sqlComm = new SqlCommand();

            sqlComm.Parameters.Add(new SqlParameter("@IdProducto", IdProducto));

            ClsProducto? clsProducto = null;

            try
            {
                sqlConn.Open();
                sqlComm.Connection = sqlConn;
                sqlComm.CommandType = CommandType.StoredProcedure;
                sqlComm.CommandText = "ConsultarProductoFiltro";


                sqlDataRead = sqlComm.ExecuteReader();

                while (sqlDataRead.Read())
                {
                    clsProducto = new();
                    ClsProducto.Nombre = sqlDataRead["Nombre"].ToString() ?? string.Empty;
                    ClsProducto.Marca = sqlDataRead["Marca"].ToString() ?? string.Empty; ;
                    ClsProducto.Stock = (int)sqlDataRead["Stock"];
                    if (sqlDataRead["PrecioCompra"] != DBNull.Value)
                    {
                        ClsProducto.PrecioCompra = (int)sqlDataRead["PrecioCompra"];
                    }
                    if (sqlDataRead["PrecioVenta"] != DBNull.Value)
                    {
                        ClsProducto.PrecioVenta = (int)sqlDataRead["PrecioVenta"];

                    }
                    if (sqlDataRead["FechaVencimiento"] != DBNull.Value)
                    {
                        ClsProducto.FechaVencimiento = (DateTime)sqlDataRead["FechaVencimiento"];
                    }
                    
                }
                sqlConn.Close();

                if (clsProducto == null)
                {
                    throw new Exception("ProductoDA.ConsultarProductoFiltro: El ID del producto no existe");
                }
                return clsProducto;
            }
            catch (Exception ex)
            {

                throw new Exception("ProductoDA.ConsultarProductoFiltro: " + ex.Message);
            }
            finally
            {
                sqlConn.Dispose();

            }


        }
    }
}
