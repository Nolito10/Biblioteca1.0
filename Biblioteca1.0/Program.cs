using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca1._0
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Libro> libros = new List<Libro>();

            bool salir = false;
            while (!salir)
            {
                Console.WriteLine("Menú:");
                Console.WriteLine("1. Agregar libro");
                Console.WriteLine("2. Prestar libro");
                Console.WriteLine("3. Devolver libro");
                Console.WriteLine("4. Inactivar libro");
                Console.WriteLine("5. Mostrar libros activos");
                Console.WriteLine("6. Mostrar libro por ISBN");
                Console.WriteLine("7. Información general");
                Console.WriteLine("8. Salir");

                Console.Write("Ingrese una opción: ");
                int opcion = int.Parse(Console.ReadLine());

                switch (opcion)
                {
                    case 1:
                        // Agregar libro
                        Console.Write("ISBN: ");
                        string _isbn = Console.ReadLine();
                        Console.Write("Título: ");
                        string _titulo = Console.ReadLine();
                        Console.Write("Autor:");
                        string _autor = Console.ReadLine();
                        Console.Write("Número de copias: ");
                        int _numCopias = int.Parse(Console.ReadLine());

                        Libro libro = new Libro(_isbn, _titulo, _autor, _numCopias);
                        libros.Add(libro);
                        break;
                    case 2:
                        //prestar libro
                        Console.Write("Ingrese el ISBN del libro a prestar: ");
                        string isbnPrestamo = Console.ReadLine();

                        Libro libroPrestamo = libros.Find(x => x.Isbn == isbnPrestamo);
                        if (libroPrestamo != null)
                        {
                            if (libroPrestamo.Prestamo())
                            {
                                Console.WriteLine("Préstamo realizado");
                            }
                            else
                            {
                                Console.WriteLine("No hay copias disponibles para prestar");
                            }
                        }
                        else
                        {
                            Console.WriteLine("No se encontró el libro con ese ISBN");
                        }
                        break;

                    case 3:
                        //Devolver libro
                        Console.Write("Ingrese el ISBN del libro a devolver: ");
                        string isbnDevolucion = Console.ReadLine();

                        Libro libroDevolucion = libros.Find(x => x.Isbn == isbnDevolucion);
                        if (libroDevolucion != null)
                        {
                            if (libroDevolucion.Devolucion())
                            {
                                Console.WriteLine("Devolución realizada");
                            }
                            else
                            {
                                Console.WriteLine("Este libro no está prestado actualmente");
                            }
                        }
                        else
                        {
                            Console.WriteLine("No se encontró el libro con ese ISBN");
                        }

                        break;
                    case 4:
                        //Inactivar libro
                        Console.Write("Ingrese el ISBN del libro a inactivar: ");
                        string isbnInactivar = Console.ReadLine();

                        Libro libroInactivar = libros.Find(x => x.Isbn == isbnInactivar);
                        if (libroInactivar != null)
                        {
                            if (libroInactivar.Inactivar())
                            {
                                Console.WriteLine("Libro inactivado");
                            }
                            else
                            {
                                Console.WriteLine("No se puede inactivar porque tiene copias prestadas");
                            }
                        }
                        else
                        {
                            Console.WriteLine("No se encontró el libro con ese ISBN");
                        }

                        break;
                    case 5:
                        //Mostrar libros activos
                        foreach (Libro Libro in libros)
                        {
                            if (Libro.Estado)
                            {
                                Libro.Mostrar_Libros(true);
                            }
                        }

                        break;
                    case 6:
                        // Mostrar libro por ISBN
                        Console.Write("Ingrese el ISBN a buscar: ");
                        string isbnBusqueda = Console.ReadLine();

                        Libro libroEncontrado = libros.Find(x => x.Isbn == isbnBusqueda);
                        if (libroEncontrado != null)
                        {
                            libroEncontrado.MostraLibro(isbnBusqueda);
                        }
                        else
                        {
                            Console.WriteLine("No se encontró el libro con ese ISBN");
                        }

                        break;
                    case 7:
                        Libro.Informativo();
                        break;
                    case 8:

                        salir = true;
                        break;

                    default:
                        Console.WriteLine(" ¡HERROR!, OPCION FUERA DE RANGO."); break;

                }

            }
        }
    }

}
