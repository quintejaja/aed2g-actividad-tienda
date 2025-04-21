namespace Tienda
{
    internal class Program
    {
        static void Main(string[] args)
        {
            PrecargarDatos();

            Cliente cliente = new Cliente("Juan", "juan@mail.com", null);
            Carrito carrito = new Carrito(cliente);
            Orden orden = null; 

            int opcion;
            do
            {
                opcion = Menu();

                switch (opcion)
                {
                    case 1:
                        Console.WriteLine("Ingrese el nombre del producto que quiera modificar:");
                        string nombreProd = Console.ReadLine();
                        Producto.ModificarProducto(nombreProd);
                        break;

                    case 2:
                        GestionarCarrito(carrito);
                        break;

                    case 3:
                        Console.Write("Ingrese la dirección de envío: ");
                        string direccion = Console.ReadLine();
                        orden = carrito.RealizarOrden(direccion);
                        break;

                    case 4:
                        if (orden != null)
                        {
                            orden.ConfirmarOrden();
                        }
                        else
                        {
                            Console.WriteLine("Primero debe finalizar una compra.");
                        }
                        break;
                }

                Console.WriteLine("\n\nToque una tecla para continuar..");
                Console.ReadKey();

            } while (opcion != 0);

            Console.ReadKey();
        }

        static void PrecargarDatos()
        {
            Categoria c1 = new Categoria("Comida", "Producto comestible.");
            Categoria c2 = new Categoria("Bebida", "Producto bebible.");
            Categoria c3 = new Categoria("Cosmetico", "Cosmetico amigo te lo dice el nombre.");

            Producto p1 = new Producto("Ala", "alaaa", 5000, c1, 3);
            p1.Guardar();
        }

        private static int Menu()
        {
            int opcion;

            Console.WriteLine("==== MENÚ DE LA TIENDA ====\n");
            Console.WriteLine("1 - Modificar un producto");
            Console.WriteLine("2 - Gestionar carrito de compras");
            Console.WriteLine("3 - Finalizar compra");
            Console.WriteLine("4 - Confirmar orden");
            Console.WriteLine("0 - Salir\n");

            opcion = Validaciones.LeerInt(0, 4);
            return opcion;
        }

        private static void GestionarCarrito(Carrito carrito)
        {
            Console.WriteLine("1 - Agregar producto");
            Console.WriteLine("2 - Eliminar producto");
            Console.WriteLine("3 - Ver total del carrito");
            Console.WriteLine("4 - Mostrar productos del carrito");
            Console.Write("Seleccione una opción: ");
            string subopcion = Console.ReadLine();

            if (subopcion == "1")
            {
                Console.Write("Ingrese el nombre del producto a agregar: ");
                string nombreAgregar = Console.ReadLine().Trim();

                Producto pAgregar = Producto.Productos.Find(p => p.Nombre.ToLower() == nombreAgregar.ToLower());
                if (pAgregar != null)
                    carrito.AgregarProductoAlCarrito(pAgregar);
                else
                    Console.WriteLine("Producto no encontrado.");
            }
            else if (subopcion == "2")
            {
                Console.Write("Ingrese el nombre del producto a eliminar: ");
                string nombreEliminar = Console.ReadLine().Trim();
                carrito.EliminarProductoDelCarrito(nombreEliminar);
            }
            else if (subopcion == "3")
            {
                Console.WriteLine("Total del carrito: " + carrito.CalcularTotal());
            }
            else if (subopcion == "4")
            {
                carrito.MostrarCarrito();
            }
        }
    }
}
