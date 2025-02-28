
class Campaña_de_Vacunación
{
    static void Main()
    {
        // Este Método es  para mostrar carátula
        MostrarCaratula();

        // Esta Lista para mostrar los  nombres de ciudadanos 
        List<string> nombres = new List<string>
        {
            "Juan Pérez", "María López", "Carlos Gómez", "Ana Torres", "Luis Ramírez",
            "Sofía Herrera", "Pedro Castillo", "Gabriela Muñoz", "Ricardo Vargas", "Elena Ríos",
            "José Navarro", "Marta Castro", "Daniel Salazar", "Carmen Ortega", "Fernando Méndez",
            "Laura Acosta", "Alejandro Paredes", "Paola Serrano", "Miguel Espinoza", "Johnny Grefa"
        };

        // Generamos una lista de 500 ciudadanos con identificadores únicos (ID y Nombre)
        Dictionary<int, string> ciudadanos = new Dictionary<int, string>();
        for (int i = 1; i <= 500; i++)
        {
            string nombre = nombres[i % nombres.Count] + $" #{i}"; // Asignamos un nombre repetido con número único
            ciudadanos.Add(i, nombre);
        }

        // Este es un conjuntos de vacunados
        HashSet<int> vacunadosPfizer = new HashSet<int>(Enumerable.Range(1, 75));
        HashSet<int> vacunadosAstraZeneca = new HashSet<int>(Enumerable.Range(50, 75)); // Se solapan con Pfizer

        //Ahi creamos un Diccionario de categorías de vacunación
        Dictionary<string, List<int>> categorias = new Dictionary<string, List<int>>
        {
            { "No vacunados", ciudadanos.Keys.Except(vacunadosPfizer).Except(vacunadosAstraZeneca).ToList() },
            { "Vacunados con ambas vacunas", vacunadosPfizer.Intersect(vacunadosAstraZeneca).ToList() },
            { "Vacunados solo con Pfizer", vacunadosPfizer.Except(vacunadosAstraZeneca).ToList() },
            { "Vacunados solo con AstraZeneca", vacunadosAstraZeneca.Except(vacunadosPfizer).ToList() }
        };

        // Mostramos el  total de ciudadanos regisrados
        Console.WriteLine("================================================================\n");

        Console.WriteLine($"TOTAL DE CIUDADANOS REGISTADOS: {ciudadanos.Count}");
        
        Console.WriteLine("================================================================\n");

        // Mostramos resultados
        foreach (var categoria in categorias)
        {
            MostrarResultados(categoria.Key, categoria.Value.Count);
            MostrarPrimeros(categoria.Key, categoria.Value, ciudadanos);
        }
    }

    // Método para mostrar carátula en consola
    static void MostrarCaratula()
    {
        Console.WriteLine("===================================================================\n ");
        Console.WriteLine("              UNIVERSIDAD ESTATAL AMAZÓNICA           ");
        Console.WriteLine("===================================================================\n ");
        Console.WriteLine("              Asignatura: Estructura de Datos          ");
        Console.WriteLine("              Docente: Msc. Edgar Nieto");
        Console.WriteLine("              Estudiante: Johnny Guillermo Grefa Calapucha");
        Console.WriteLine("===================================================================\n ");
        Console.WriteLine("             Tema: Análisis de Campaña de Vacunación  COVID-19");
        Console.WriteLine("             Facultad de Ciencias de la Vida       ");
        Console.WriteLine("             Fecha: 22 de Febrero de 2025         ");
        Console.WriteLine("===================================================================\n");
        Console.WriteLine("              Paralelo B                 ");
        Console.WriteLine("===================================================================\n");
    }

    // Método para mostrar la cantidad de ciudadanos por categoría
    static void MostrarResultados(string categoria, int cantidad)
    {
        Console.WriteLine($"{categoria}: {cantidad} ciudadanos\n");
    }

    // Método para mostrar los primeros 10 ciudadanos por categoría con sus nombres
    static void MostrarPrimeros(string categoria, List<int> lista, Dictionary<int, string> ciudadanos)
    {
        Console.WriteLine($"\nPrimeros 10 ciudadanos en la categoría '{categoria}':");
        foreach (var id in lista.Take(10))
        {
            Console.WriteLine($"ID: {id}, Nombre: {ciudadanos[id]}");
        }
        Console.WriteLine("------------------------------------------------------\n");
    }
}





 