using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tienda
{
    public class Producto
    {
        private static List<Producto> productos = new List<Producto>();
        private string nombre;
        private string descripcion;
        private int precio;
        private Categoria categoria;
        private int cantidadEnInventario;

        public static List<Producto> Productos { get => productos; set => productos = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }
        public int Precio { get => precio; set => precio = value; }
        public int CantidadEnInventario { get => cantidadEnInventario; set => cantidadEnInventario = value; }
        internal Categoria Categoria { get => categoria; set => categoria = value; }

        public Producto(string nombre, string descripcion, int precio, Categoria categoria, int cantidadEnInventario) 
        {
            this.nombre = nombre;
            this.descripcion = descripcion;
            this.precio = precio;
            this.categoria = categoria;
            this.cantidadEnInventario = cantidadEnInventario;
        }

        public Producto() 
        {
            nombre = "";
            descripcion = "";
            precio = 0;
            categoria = null;
            cantidadEnInventario = 0;
        }

        public override string ToString()
        {
            return "\nNombre: " + this.nombre +
                    "\nDescripción: " + this.descripcion +
                    "\nPrecio: " + this.precio +
                    "\nCategoria: " + this.Categoria.Nombre +
                    "\nCantidad en inventario: " + this.cantidadEnInventario;
        }

        public void Guardar()
        {
            Producto.Productos.Add(this);
        }


        //En la clase producto necesitaremos actualizar la cantidad en inventario y modificar el precio.

        public static void ModificarProducto(string nombre)
        {
            nombre = nombre.ToLower().Trim();
            Producto seleccionado = null;

            foreach (Producto p in Producto.Productos)
            {
                if (p.Nombre.ToLower().Trim() == nombre)
                {
                    seleccionado = p;
                    break; // Salimos del bucle porque ya encontramos el producto
                }
            }

            if (seleccionado != null)
            {
                Console.WriteLine($"¿Usted desea modificar el producto {seleccionado.Nombre}? S/N");
                string respuesta = Console.ReadLine()?.ToLower().Trim();

                if (respuesta == "s")
                {
                    Console.Write("\nIngrese la nueva cantidad en inventario: ");
                    seleccionado.CantidadEnInventario = int.Parse(Console.ReadLine());

                    Console.Write("\nIngrese el nuevo precio: ");
                    seleccionado.Precio = int.Parse(Console.ReadLine());

                    Console.WriteLine("\nDatos del producto actualizados:");
                    Console.WriteLine(seleccionado.ToString());
                }
                else
                {
                    Console.WriteLine("No se han realizado modificaciones.");
                }
            }
            else
            {
                Console.WriteLine("No se ha encontrado el producto buscado.");
            }
        }

    }
}
