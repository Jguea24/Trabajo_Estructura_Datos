using System;
using System.Collections.Generic;

class Program
{
    // Método para verificar si las etiquetas HTML están correctamente anidadas
    static bool VerificarEtiquetasHTML(string html)
    {
        // Pila para almacenar las etiquetas de apertura
        Stack<string> pila = new Stack<string>();
        int i = 0;

        while (i < html.Length)
        {
            if (html[i] == '<')
            {
                // Encontrar el cierre de la etiqueta '>'
                int cierre = html.IndexOf('>', i);
                if (cierre == -1) return false; // No se cerró la etiqueta

                // Extraer el contenido de la etiqueta
                string etiqueta = html.Substring(i + 1, cierre - i - 1);

                // Verificar si es una etiqueta de cierre
                if (etiqueta.StartsWith("/"))
                {
                    // Si no hay etiquetas de apertura en la pila, es incorrecto
                    if (pila.Count == 0) return false;

                    // Obtener la última etiqueta de apertura de la pila
                    string etiquetaApertura = pila.Pop();

                    // Comparar etiquetas de cierre y apertura
                    if ($"/{etiquetaApertura}" != etiqueta)
                    {
                        return false; // Etiquetas no coinciden
                    }
                }
                else
                {
                    // Si es una etiqueta de apertura, agregarla a la pila
                    pila.Push(etiqueta);
                }

                // Mover el índice al final de la etiqueta
                i = cierre;
            }
            i++;
        }

        // Si la pila está vacía, las etiquetas están correctamente anidadas
        return pila.Count == 0;
    }

    static void Main(string[] args)
    {
        // Ejemplos de entrada
        string html1 = "<html><body><h1>Hola</h1></body></html>";
        string html2 = "<html><body><h1>Hola</body></html>";
        string html3 = "<html><body><h1>Hola</h2></body></html>";

        // Verificar cada entrada y mostrar resultados
        Console.WriteLine(VerificarEtiquetasHTML(html1) ? "HTML correcto" : "HTML incorrecto");
        Console.WriteLine(VerificarEtiquetasHTML(html2) ? "HTML correcto" : "HTML incorrecto");
        Console.WriteLine(VerificarEtiquetasHTML(html3) ? "HTML correcto" : "HTML incorrecto");
    }
}
