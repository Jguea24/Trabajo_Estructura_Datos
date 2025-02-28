
class Traducctor_Ingles_Espanol
{
    static Dictionary<string, string> englishToSpanish = new Dictionary<string, string>
    {
        {"time", "tiempo"},
        {"person", "persona"},
        {"they work", "trabajan"},
        {"have", "tener"},
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
        {"woman", "mujer"},
        {"place", "lugar"},
        {"work", "trabajo"},
        {"week", "semana"},
        {"case", "caso"},
        {"point", "punto/tema"},
        {"government", "gobierno"},
        {"company", "empresa/compañía"}
    };

    static Dictionary<string, string> spanishToEnglish = new Dictionary<string, string>
    {
        {"tiempo", "time"},
        {"persona", "person"},
        {"año", "year"},
        {"camino", "way"},
        {"forma", "way"},
        {"día", "day"},
        {"cosa", "thing"},
        {"hombre", "man"},
        {"mundo", "world"},
        {"vida", "life"},
        {"mano", "hand"},
        {"parte", "part"},
        {"niño", "child"},
        {"niña", "child"},
        {"ojo", "eye"},
        {"mujer", "woman"},
        {"lugar", "place"},
        {"trabajo", "work"},
        {"semana", "week"},
        {"caso", "case"},
        {"punto", "point"},
        {"tema", "point"},
        {"gobierno", "government"},
        {"empresa", "company"},
        {"compañía", "company"}
    };

    static void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("=========================== MENU ======================\n");
            Console.WriteLine("=======================================================");
            Console.WriteLine("1. Traducir una frase\n");
            Console.WriteLine("2. Ingresar más palabras al diccionario\n");
            Console.WriteLine("0. Salir \n");
            Console.Write("Seleccione una opción: ");
            string option = Console.ReadLine();

            if (option == "1")
            {
                TranslatePhrase();
            }
            else if (option == "2")
            {
                AddWordToDictionary();
            }
            else if (option == "0")
            {
                break;
            }
            else
            {
                Console.WriteLine("Opción no válida. Intente de nuevo.");
            }
        }
    }

    static void TranslatePhrase()
    {
        Console.Write("Ingrese la frase: ");
        string phrase = Console.ReadLine();
        string[] words = phrase.Split(' ');
        string translatedPhrase = "";

        foreach (string word in words)
        {
            string cleanedWord = word.ToLower().Trim(new char[] { '.', ',', '!', '?' });
            if (englishToSpanish.ContainsKey(cleanedWord))
            {
                translatedPhrase += englishToSpanish[cleanedWord] + " ";
            }
            else if (spanishToEnglish.ContainsKey(cleanedWord))
            {
                translatedPhrase += spanishToEnglish[cleanedWord] + " ";
            }
            else
            {
                translatedPhrase += word + " ";
            }
        }

        Console.WriteLine("Su frase traducida es: " + translatedPhrase.Trim());
    }

    static void AddWordToDictionary()
    {
        Console.Write("Ingrese la palabra en inglés: ");
        string englishWord = Console.ReadLine().ToLower();
        Console.Write("Ingrese la traducción en español: ");
        string spanishWord = Console.ReadLine().ToLower();

        if (!englishToSpanish.ContainsKey(englishWord))
        {
            englishToSpanish.Add(englishWord, spanishWord);
            spanishToEnglish.Add(spanishWord, englishWord);
            Console.WriteLine("Palabra agregada correctamente.");
        }
        else
        {
            Console.WriteLine("La palabra ya existe en el diccionario.");
        }
    }
}