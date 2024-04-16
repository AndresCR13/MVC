using Microsoft.Data.SqlClient;

namespace DataAccess.ACME
{
    public class Conexion
    {
        private readonly string?_cadenaConexion;

        public Conexion() 
        {
            string? CadenaConexion;

            // obtener cadena de conexion desde variable de entorno 
            CadenaConexion = Environment.GetEnvironmentVariable("SQLserverXE");
           
            _cadenaConexion = CadenaConexion;
        
        }

        public SqlConnection Conectar()
        {
            SqlConnection sqlconn;

            // instanciar la conexion obtenida

            sqlconn = new SqlConnection(_cadenaConexion);

            return sqlconn;
        }
    }
}
