using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static Dictionary<string, string> englishToSpanish = new Dictionary<string, string>
    {
        {"time", "tiempo"},
        {"person", "persona"},
        {"year", "año"},
        {"way", "camino/forma"},
        {"day", "día"},
        {"thing", "cosa"},
        {"man", "hombre"},
        {"world", "mundo"},
        {"life", "vida"},
        {"hand", "mano"},
        {"part", "parte"},
        {"child", "niño/a"},
        {"eye", "ojo"},
        {"Hello how are you", "Hola como estas"},
        {"woman", "mujer"},
        {"place", "lugar"},
        {"work", "trabajo"},
        {"week", "semana"},
        {"case", "caso"},
        {"point", "punto/tema"},
        {"government", "gobierno"},
        {"company", "empresa/compañía"}
    };

    static Dictionary<string, string> spanishToEnglish = englishToSpanish.ToDictionary(kvp => kvp.Value.Split('/')[0], kvp => kvp.Key);

    static void Main()
    {
        while (true)
        {
            Console.WriteLine("MENU");
            Console.WriteLine("=======================================================");
            Console.WriteLine("1. Traducir una frase");
            Console.WriteLine("2. Ingresar más palabras al diccionario");
            Console.WriteLine("0. Salir");
            Console.Write("Seleccione una opción: ");
            string option = Console.ReadLine();

            switch (option)
            {
                case "1":
                    TranslatePhrase();
                    break;
                case "2":
                    AddWordToDictionary();
                    break;
                case "0":
                    return;
                default:
                    Console.WriteLine("Opción no válida. Intente de nuevo.");
                    break;
            }
        }
    }

    static void TranslatePhrase()
    {
        Console.Write("Ingrese la frase: ");
        string phrase = Console.ReadLine();
        string[] words = phrase.Split(' ');
        List<string> translatedWords = new List<string>();

        foreach (string word in words)
        {
            string cleanedWord = new string(word.ToLower().TrimEnd(' ', '.', ',', ';', '!', '?'));
            if (englishToSpanish.ContainsKey(cleanedWord))
            {
                translatedWords.Add(englishToSpanish[cleanedWord]);
            }
            else if (spanishToEnglish.ContainsKey(cleanedWord))
            {
                translatedWords.Add(spanishToEnglish[cleanedWord]);
            }
            else
            {
                translatedWords.Add(word);
            }
        }

        Console.WriteLine("Su frase traducida es: " + string.Join(" ", translatedWords));
    }

    static void AddWordToDictionary()
    {
        Console.Write("Ingrese la palabra en inglés: ");
        string englishWord = Console.ReadLine().ToLower();
        Console.Write("Ingrese la traducción al español: ");
        string spanishWord = Console.ReadLine().ToLower();

        if (!englishToSpanish.ContainsKey(englishWord))
        {
            englishToSpanish[englishWord] = spanishWord;
            if (!spanishToEnglish.ContainsKey(spanishWord))
            {
                spanishToEnglish[spanishWord] = englishWord;
            }
            Console.WriteLine("Palabra agregada correctamente.");
        }
        else
        {
            Console.WriteLine("La palabra ya existe en el diccionario.");
        }
    }
}
