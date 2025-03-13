using System;

class Program {
    static void Main() {
        // Declarar y crear una matriz de 3x3
        int[,] matriz = new int[3, 3];

        // Asignar valores
        matriz[0, 0] = 1; matriz[0, 1] = 2; matriz[0, 2] = 3;
        matriz[1, 0] = 4; matriz[1, 1] = 5; matriz[1, 2] = 6;
        matriz[2, 0] = 7; matriz[2, 1] = 8; matriz[2, 2] = 9;

        // Mostrar la matriz
        for (int i = 0; i < matriz.GetLength(0); i++) {
            for (int j = 0; j < matriz.GetLength(1); j++) {
                Console.Write(matriz[i, j] + " ");
            }
            Console.WriteLine();
        }

        // Declarar e inicializar una matriz directamente
        int[,] otraMatriz = {
            {10, 20, 30},
            {40, 50, 60},
            {70, 80, 90}
        };

        // Imprimir un valor específico
        Console.WriteLine("Elemento en [1,2]: " + otraMatriz[1, 2]);
    }
}