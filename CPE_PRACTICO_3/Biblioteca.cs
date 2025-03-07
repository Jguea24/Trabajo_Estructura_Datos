
// Definición de la clase Libro que representa un libro con sus atributos
public class Libro
{
    public string Titulo { get; set; }
    public string Autor { get; set; }
    public int AnioPublicacion { get; set; }

    // Constructor para inicializar un objeto Libro
    public Libro(string titulo, string autor, int anioPublicacion)
    {
        Titulo = titulo;
        Autor = autor;
        AnioPublicacion = anioPublicacion;
    }

    // Método para mostrar la información del libro
    public override string ToString()
    {
        return $"Título: {Titulo}, Autor: {Autor}, Año de Publicación: {AnioPublicacion}";
    }
}

public class Biblioteca
{
    // Diccionario para almacenar los libros, donde la clave es el ISBN
    private Dictionary<string, Libro> libros = new Dictionary<string, Libro>();

    // HashSet para almacenar los títulos de los libros y optimizar la búsqueda
    private HashSet<string> titulosLibros = new HashSet<string>();

    // Método para agregar un libro a la biblioteca
    public void AgregarLibro(string isbn, string titulo, string autor, int anioPublicacion)
    {
        // Verificar si el ISBN ya existe en la biblioteca
        if (libros.ContainsKey(isbn))
        {
            Console.WriteLine("Error: El libro con este ISBN ya existe en la biblioteca.");
            return;
        }

        // Crear un nuevo objeto Libro
        Libro nuevoLibro = new Libro(titulo, autor, anioPublicacion);

        // Agregar el libro al diccionario
        libros[isbn] = nuevoLibro;

        // Agregar el título del libro al HashSet para búsqueda optimizada
        titulosLibros.Add(titulo);

        Console.WriteLine("Libro agregado correctamente.");
    }

    // Método para buscar un libro por su ISBN
    public void BuscarLibroPorISBN(string isbn)
    {
        if (libros.TryGetValue(isbn, out Libro libro))
        {
            Console.WriteLine("Libro encontrado:");
            Console.WriteLine(libro);
        }
        else
        {
            Console.WriteLine("Libro no encontrado.");
        }
    }

    // Método para buscar un libro por su título
    public void BuscarLibroPorTitulo(string titulo)
    {
        if (titulosLibros.Contains(titulo))
        {
            Console.WriteLine("Libro encontrado por título:");
            foreach (var libro in libros.Values)
            {
                if (libro.Titulo == titulo)
                {
                    Console.WriteLine(libro);
                    break;
                }
            }
        }
        else
        {
            Console.WriteLine("Libro no encontrado.");
        }
    }

    // Método para mostrar todos los libros en la biblioteca
    public void MostrarTodosLosLibros()
    {
        if (libros.Count == 0)
        {
            Console.WriteLine("No hay libros en la biblioteca.");
            return;
        }

        Console.WriteLine("Libros en la biblioteca:");
        foreach (var isbn in libros.Keys)
        {
            Console.WriteLine($"ISBN: {isbn}, {libros[isbn]}");
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Crear una instancia de la biblioteca
        Biblioteca biblioteca = new Biblioteca();

        // Agregar algunos libros a la biblioteca
        biblioteca.AgregarLibro("978-0134685991", "Clean Code", "Robert C. Martin", 2008);
        biblioteca.AgregarLibro("978-0201633610", "Design Patterns", "Erich Gamma", 1994);
        biblioteca.AgregarLibro("978-0321125217", "Domain-Driven Design", "Eric Evans", 2003);

        // Mostrar todos los libros en la biblioteca
        biblioteca.MostrarTodosLosLibros();

        // Buscar un libro por ISBN
        Console.WriteLine("\nBuscando libro por ISBN:");
        biblioteca.BuscarLibroPorISBN("978-0134685991");

        // Buscar un libro por título
        Console.WriteLine("\nBuscando libro por título:");
        biblioteca.BuscarLibroPorTitulo("Design Patterns");

        // Intentar agregar un libro con un ISBN duplicado
        Console.WriteLine("\nIntentando agregar un libro con ISBN duplicado:");
        biblioteca.AgregarLibro("978-0134685991", "Another Book", "Another Author", 2020);
    }
}