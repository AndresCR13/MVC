using Models.ACME;
using DataAccess.ACME;

namespace Services.ACME
{
    public class ProductoService
    {
        public bool crear(ClsProducto clsProducto)
        { 
            ProductoDA productoDA = new ProductoDA();

            try
            {
                productoDA.Insertar(clsProducto);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public ClsProducto? BuscarFiltro(int IdProducto)
        {

            ProductoDA? productoDA = new ProductoDA();
            try
            {
                return productoDA.ConsultarProductoFiltro( IdProducto);
            }
            catch (Exception)
            {
                return null;
               
            }
        }

        public List<ClsProducto>? Buscar()
        {

            ProductoDA? productoDA = new ProductoDA();
            try
            {
                return productoDA.Consultar();
            }
            catch (Exception)
            {
                return null;

            }
        }


    }
}
