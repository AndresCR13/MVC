using System.ComponentModel.DataAnnotations;


namespace Models.ACME
{
    public class ClsProducto
    {
        [Display(Name = "ID")]
        public static int IdProdructo { get; set; }
        public static int IdCategoria { get; set; }

        [Required(ErrorMessage = "El nombre del producto es obligatorio.")]
        [Display(Name = "Nombre Producto")]
        public static  string Nombre { get; set;} = string.Empty;


        [Required(ErrorMessage = "La Marca del producto es obligatorio.")]
        [Display(Name = "Marca Producto")]
        public static string Marca { get; set;} = string.Empty;


        [Required(ErrorMessage = "Digite la cantidad en stock")]
        [Display(Name = "Stock")]
        public static int Stock { get; set;}


        [Required(ErrorMessage = "Digite precio de venta.")]
        [Display(Name = "Precio Venta")]
        public static int PrecioVenta { get; set;}

        [Required(ErrorMessage = "Digite precio de compra.")]
        [Display(Name = "Precio compra")]
        public static int PrecioCompra { get; set;}


        [Required(ErrorMessage = "Debe ingresar la fecha de vencimiento")]
        [Display(Name = "Fecha de vencimiento ")]
        public static DateTime FechaVencimiento { get; set; }

        public ClsProducto(int idProdructo, int idCategoria, string nombre, string marca, int stock, int precioVenta, int precioCompra, DateTime fechaVencimiento)
        {
            IdProdructo = idProdructo;
            IdCategoria = idCategoria;
            Nombre = nombre;
            Marca = marca;
            Stock = stock;
            PrecioVenta = precioVenta;
            PrecioCompra = precioCompra;
            FechaVencimiento = fechaVencimiento;
        }
        public ClsProducto() { }
    }
}