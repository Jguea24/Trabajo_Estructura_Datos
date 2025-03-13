

/// Clase que representa un catálogo de revistas.
/// Permite buscar títulos de revistas mediante búsqueda recursiva e iterativa.

class CatalogoRevistas
{
    // Lista estática que almacena los títulos de las revistas disponibles en el catálogo.
    static List<string> catalogo = new List<string>
    {
        "National Geographic", "Scientific American", "Time", "Forbes",
        "Nature", "The Economist", "Popular Science", "Harvard Business Review",
        "PC Magazine", "MIT Technology Review"
    };
   
    // Método principal que muestra un menú interactivo para buscar revistas.
    static void Main()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("       Universidad Estatal Amazonica  \n    ");

            Console.WriteLine("       Asignatura: Estructura de Datos  \n  ");

            Console.WriteLine("       Programdo por: Johnny Grefa  \n      ");
            
            Console.WriteLine("      CATÁLOGO DE REVISTAS \n");
          
            Console.WriteLine("1. Buscar título (Búsqueda Recursiva) \n");

            Console.WriteLine("2. Buscar título (Búsqueda Iterativa)\n");

            Console.WriteLine("3. Mostrar todos los títulos \n");

            Console.WriteLine("4. Salir\n");

            Console.Write("Seleccione una opción:  ");

            string opcion = Console.ReadLine();

            if (opcion == "4") break;

            switch (opcion)
            {
                case "1":
                case "2":
                    Console.Write("Ingrese el título de la revista a buscar: ");

                    string titulo = Console.ReadLine();

                    bool encontrado = opcion == "1" ? BuscarRecursivo(titulo, 0) : BuscarIterativo(titulo);

                    Console.WriteLine(encontrado ? "✅ Título encontrado" : "❌ Título no encontrado");
                    break;

                case "3":
                    MostrarCatalogo();
                    break;
                default:
                    Console.WriteLine("⚠️ Opción no válida. Intente de nuevo.");
                    break;
            }
            
            Console.WriteLine("\nPresione cualquier tecla para continuar...");
            Console.ReadKey();
        }
    }

    
    //Método que realiza una búsqueda recursiva de un título en el catálogo.
    
    // Verdadero si el título es encontrado, falso en caso contrario
    static bool BuscarRecursivo(string titulo, int indice)
    {
        if (indice >= catalogo.Count) return false;
        if (catalogo[indice].Equals(titulo, StringComparison.OrdinalIgnoreCase)) return true;
        return BuscarRecursivo(titulo, indice + 1);
    }

   
    // Método que realiza una búsqueda iterativa de un título en el catálogo.
    //Verdadero si el título es encontrado, falso en caso contrario.
    static bool BuscarIterativo(string titulo)
    {
        foreach (var revista in catalogo)
        {
            if (revista.Equals(titulo, StringComparison.OrdinalIgnoreCase)) return true;
        }
        return false;
    }


    // Método que muestra la lista de revistas disponibles en el catálogo.
    static void MostrarCatalogo()
    {
        Console.WriteLine("\n📚 Lista de revistas disponibles:");
        foreach (var revista in catalogo)
        {
            Console.WriteLine("- " + revista);
        }
    }
}
