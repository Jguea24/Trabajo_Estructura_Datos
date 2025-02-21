using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        // Creamos un conjunto  de 500 ciudadanos con identificadores del 1 al 500
        HashSet<int> ciudadanos = new HashSet<int>(Enumerable.Range(1, 500));

        // Creamos un conjunto de 75 ciudadanos vacunados con Pfizer (ID del 1 al 75)
        HashSet<int> vacunadosPfizer = new HashSet<int>(Enumerable.Range(1, 75));

        // Creamos un conjunto de 75 ciudadanos vacunados con AstraZeneca (ID del 76 al 150)
        HashSet<int> vacunadosAstraZeneca = new HashSet<int>(Enumerable.Range(76, 75));

        // Conjunto de ciudadanos que no se han vacunado
        var noVacunados = ciudadanos.Where(c => !vacunadosPfizer.Contains(c) && !vacunadosAstraZeneca.Contains(c)).ToList();

        // Conjunto de ciudadanos que han recibido las dos vacunas
        var vacunadosAmbas = vacunadosPfizer.Intersect(vacunadosAstraZeneca).ToList();

        // Conjunto de ciudadanos que solamente han recibido la vacuna de Pfizer
        var soloPfizer = vacunadosPfizer.Except(vacunadosAstraZeneca).ToList();

        // Conjunto de ciudadanos que solamente han recibido la vacuna de AstraZeneca
        var soloAstraZeneca = vacunadosAstraZeneca.Except(vacunadosPfizer).ToList();

        // Imprimir los resultados con la cantidad de ciudadanos por cada categoría
        Console.WriteLine("Total de ciudadanos no vacunados: " + noVacunados.Count);
        Console.WriteLine("Total de ciudadanos con ambas vacunas: " + vacunadosAmbas.Count);
        Console.WriteLine("Total de ciudadanos solo con Pfizer: " + soloPfizer.Count);
        Console.WriteLine("Total de ciudadanos solo con AstraZeneca: " + soloAstraZeneca.Count);
        
        // Mostrar los primeros 10 resultados de cada categoría para no saturar la salida
        Console.WriteLine("\nPrimeros 10 ciudadanos no vacunados: " + string.Join(", ", noVacunados.Take(10)));
        Console.WriteLine("Primeros 10 ciudadanos con ambas vacunas: \n" + string.Join(", ", vacunadosAmbas.Take(10)));
        Console.WriteLine("Primeros 10 ciudadanos solo con Pfizer: " + string.Join(", ", soloPfizer.Take(10)));
        Console.WriteLine("Primeros 10 ciudadanos solo con AstraZeneca: " + string.Join(", ", soloAstraZeneca.Take(10)));
    }
}
