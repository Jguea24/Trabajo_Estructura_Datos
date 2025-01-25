using System;
using System.Collections.Generic;

class Program
{
    // Método que verifica si una fórmula matemática está balanceada.
// Utiliza una pila para realizar un seguimiento de los símbolos de apertura y verificar su correspondencia con los de cierre.
static bool VerificarBalanceo(string formula)
    {
        Stack<char> pila = new Stack<char>();

        foreach (char c in formula)
        {
            if (c == '(' || c == '{' || c == '[')
            {
                pila.Push(c);
            }
            else if (c == ')' || c == '}' || c == ']')
            {
                if (pila.Count == 0)
                {
                    return false; // Falta un símbolo de apertura
                }

                char top = pila.Pop();

                if ((c == ')' && top != '(') ||
                    (c == '}' && top != '{') ||
                    (c == ']' && top != '['))
                {
                    return false; // Símbolos no coinciden
                }
            }
        }

        return pila.Count == 0; // Si la pila está vacía, está balanceada
    }

    static void Main(string[] args)
    {
        string formula = "{7+(8*5)-[(9-7)+(4+1)]}";
        bool resultado = VerificarBalanceo(formula);

        Console.WriteLine(resultado ? "Fórmula balanceada" : "Fórmula no balanceada");
    }
}