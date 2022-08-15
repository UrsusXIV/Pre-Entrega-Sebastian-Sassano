using ProyectoFinalB.Modells;
using ProyectoFinalB.Repository;

string logContraseña = string.Empty; // Variable a utilizar con el usuario, se comparara con lo que llega de la BBDD

string logUsuario = string.Empty; // Variable a utilizar con el usuario, se compara con lo que llega de la BBDD

bool flagLoggin = false;

// El Programa solo cumple las funciones basicas de prueba. Traer usuario e inicio de sesion.
// El Programa final no se realizara en consola.

Console.WriteLine("Preentrega Proyecto Final.");

// Consulta de Productos en la DDBB

List<ClaseProducto> Producto;

ProductoHandler productoHandler = new ProductoHandler();

Producto = productoHandler.traerProductos();

foreach (var cadaProducto in Producto)
{

    Console.WriteLine($"PRODUCTOS: {cadaProducto.getDescripciones()}");
    Console.WriteLine($"PRECIO: {cadaProducto.getPrecioVenta()}");
}

Console.WriteLine("READKEY STOP.-\n\n");

Console.ReadKey();


// Consulta de Productos Vendidos en la DDBB

List<ClaseProductoVendido> ProductoVendido;

ProductoVendidoHandler handlerProductoVendido = new ProductoVendidoHandler();

ProductoVendido = handlerProductoVendido.traerProductosVendidos();

foreach(var cadaProductoVendido in ProductoVendido)
{
    Console.WriteLine($"PRODUCTO {cadaProductoVendido.getDescripciones()}");

    Console.WriteLine($"ID DEL PRODUCTO: {cadaProductoVendido.getId()}");

    Console.WriteLine($"ID VENTA: {cadaProductoVendido.getIdVenta()}");

    Console.WriteLine($"STOCK: {cadaProductoVendido.getStock()}");

}

Console.WriteLine("READKEY STOP.-\n\n");

Console.ReadKey();

// Consulta de Usuarios en la BBDD

List<ClaseUsuario> Usuarios;

UsuarioHandler UsuariosBBDD = new UsuarioHandler();

Usuarios = UsuariosBBDD.traerUsuarios();

foreach (var cadaUsaurio in Usuarios)
{
    Console.WriteLine($"ID:{cadaUsaurio.getId()}");

    Console.WriteLine($"USUARIO: {cadaUsaurio.getNombreUsuario()}");

    Console.WriteLine($"NOMBRE: {cadaUsaurio.getNombre()}");

    Console.WriteLine($"APELLIDO: {cadaUsaurio.getApellido()}");

    Console.WriteLine($"CONTRASEÑA {cadaUsaurio.getContraseña()}");

    Console.WriteLine($"EMAIL {cadaUsaurio.getMail()}");

}

Console.WriteLine("READKEY STOP.-\n\n");

Console.ReadKey();

// Traer Venta desde la BBDD

List<ClaseVenta> Venta;

VentaHandler handlerVentas = new VentaHandler();

Venta = handlerVentas.traerVenta();

foreach(var cadaVenta in Venta)
{
    Console.WriteLine($"ID VENTA: {cadaVenta.getId()}");
}
Console.WriteLine("Fin de la consulta");

Console.WriteLine("READKEY STOP.-\n\n");

Console.ReadKey();

// Prueba de inicio de sesion

while(flagLoggin == false) // LOOP: Solo se saldra de el al loggearse de manera correcta
{
    List<ClaseUsuario> validacionDeDatos;

    Console.WriteLine("Introduzca su email");

    logUsuario = Console.ReadLine();

    Console.WriteLine("Introduzca su contraseña");

    logContraseña = Console.ReadLine();

    try
    {
        validacionDeDatos = UsuariosBBDD.funcionLog(logUsuario);
    }
    catch (Exception ex)
    {
        Console.WriteLine("Fallo");
        validacionDeDatos=new List<ClaseUsuario>();
    }

    foreach(var passValida in validacionDeDatos)
    {
        string passwordValida = passValida.getContraseña();

        if (passwordValida == logContraseña)
        {

            Console.WriteLine("LOGGINS SUCCESFULL");

            flagLoggin = true;

        }
        else
        {
            Console.WriteLine("Contraseña no valida");
        }

    }
}


