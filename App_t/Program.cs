using System;
using System.Collections.Generic;
using System.Linq;

namespace ManejoDeDatos
{
    class Program
    {
        static void Main(string[] args)
        {
            // Crear una lista para almacenar los números reales
            List<double> numeros = new List<double>();

            // Pedir al usuario que ingrese los números
            Console.WriteLine("n\ Ingrese números reales: ");
            string entrada;
            while ((entrada = Console.ReadLine()) != "")
            {
                if (double.TryParse(entrada, out double numero))
                {
                    numeros.Add(numero);
                }
                else
                {
                    Console.WriteLine("Entrada inválida. Ingrese un número real.");
                }
            }

            // Calcular el promedio
            double promedio = numeros.Average();

            // Crear listas para los números menores o iguales y mayores al promedio
            List<double> menoresIguales = numeros.Where(n => n <= promedio).ToList();
            List<double> mayores = numeros.Where(n => n > promedio).ToList();

            // Mostrar los resultados
            Console.WriteLine("\nDatos cargados en la lista principal:");
            foreach (double numero in numeros)
            {
                Console.WriteLine(numero);
            }

            Console.WriteLine("\nPromedio: " + promedio);

            Console.WriteLine("\nDatos menores o iguales al promedio:");
            foreach (double numero in menoresIguales)
            {
                Console.WriteLine(numero);
            }

            Console.WriteLine("\nDatos mayores al promedio:");
            foreach (double numero in mayores)
            {
                Console.WriteLine(numero);
            }
        }
    }
}