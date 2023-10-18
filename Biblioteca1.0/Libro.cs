using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca1._0
{
    internal class Libro
    {
        //Campos estaticos para contadores

        public static int TotalLibros = 0;
        public static int TotalCopias = 0;

        //Propiedades del Libro

        private string _Isbn;
        private string _Titulo;
        private string _Autor;
        private bool _Estado;
        private int _CopiasDisponibles;
        private int _CopiasPrestadas;

        //Getters y Setters
        public int CopiasPrestadas
        {
            get { return _CopiasPrestadas; }
            set { _CopiasPrestadas = value; }
        }


        public int CopiasDisponibles
        {
            get { return _CopiasDisponibles; }
            set { _CopiasDisponibles = value; }
        }


        public bool Estado
        {
            get { return _Estado; }
            set { _Estado = value; }
        }


        public string Autor
        {
            get { return _Autor; }
            set { _Autor = value; }
        }



        public string Titulo
        {
            get { return _Titulo; }
            set { _Titulo = value; }
        }


        public string Isbn
        {
            get { return _Isbn; }
            set { _Isbn = value; }
        }

        //Constructores

        public Libro()
        {
            TotalLibros++;
        }

        public Libro(string Isbn, string Titulo, string Autor, int Copias)
        {
            this._Isbn = Isbn;
            this._Titulo = Titulo;
            this._Autor = Autor;
            this._Estado = true;
            this._CopiasDisponibles = Copias;
            TotalLibros++;
            TotalCopias += Copias;
        }

        //Metodos de Negocio
        public bool Prestamo()
        {
            if (_CopiasDisponibles > 0)
            {
                _CopiasPrestadas++;
                _CopiasDisponibles--;
                return true;

            }
            return false;
        }

        public bool Devolucion()
        {
            if (_CopiasPrestadas > 0)
            {
                _CopiasPrestadas--;
                _CopiasDisponibles++;
                return true;
            }
            return false;
        }

        public bool Inactivar()
        {
            if (_CopiasPrestadas == 0)
            {
                _Estado = false;
                return true;
            }
            return false;
        }

        public void Mostrar_Libros(bool EstadoConsulta)
        {
            if (_Estado == EstadoConsulta)
            {
                Console.WriteLine("ISBN:" + _Isbn);
                Console.WriteLine("Titulo:" + _Titulo);
                Console.WriteLine("Autor:" + _Autor);
                Console.WriteLine("Estado" + _Estado);
                Console.WriteLine("Copias Disponibles" + _CopiasDisponibles);
                Console.WriteLine("Copias Prestadas" + _CopiasPrestadas);
            }
        }

        public void MostraLibro(string IsbnBusqueda)
        {
            if (_Isbn == IsbnBusqueda)
            {
                Console.WriteLine("ISBN:" + _Isbn);
                Console.WriteLine("Titulo:" + _Titulo);
                Console.WriteLine("Autor:" + _Autor);
                Console.WriteLine("Estado" + _Estado);
                Console.WriteLine("Copias Disponibles" + _CopiasDisponibles);
                Console.WriteLine("Copias Prestadas" + _CopiasPrestadas);
            }
            else
            {
                Console.WriteLine("No se encontro el Libro con ese ISBN");
            }

        }

        public static void Informativo()
        {
            Console.WriteLine("Total de Libros:" + Libro.TotalLibros);
            Console.WriteLine("Total de Copias:" + Libro.TotalCopias);
        }


    }


}

