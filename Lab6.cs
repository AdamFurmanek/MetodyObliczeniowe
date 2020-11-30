using System;
using System.Collections.Generic;
using System.Text;

namespace MetodyObliczeniowe
{
    class Lab6
    {
        //Metoda Eliminacji Gaussa.
        public static void Gauss()
        {
            int n = 3;
            double[,] C = { { 0.34, 0.71, 0.63, 2.08}, { 0.71, -0.65, -0.17, 0.18 }, { 1.18, -2.35, 0.75, 1.28} };
            double[,] C2 = { { 0.34, 0.71, 0.63, 2.08 }, { 0.71, -0.65, -0.17, 0.18 }, { 1.18, -2.35, 0.75, 1.28 } };

            for (int s = 0; s < n-1; s++)
            {
                Console.WriteLine("Macierz dla s = "+(s+1)+"");

                // Algorytm liczący nową macierz.
                for(int  i = s + 1; i < n; i++)
                {
                    for(int j = s + 1; j < n+1; j++)
                    {
                        C2[i,j] = C[i,j] - (C[i,s]/C[s,s])*C[s,j];
                    }
                }

                // Wyzerowanie kolumny.
                for (int i = s; i < n-1; i++)
                {
                    C2[i+1, s]=0;
                }

                // Zapisanie nowej macierzy w miejsce starej.
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n + 1; j++)
                    {
                        C[i, j] = C2[i, j];
                    }
                }

                // Wyświetlenie nowej macierzy.
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n + 1; j++)
                    {
                        Console.Write(C[i, j] + "   ");
                    }
                    Console.WriteLine();
                }

                Console.WriteLine();
            }

            // Obliczenie układu równań.
            for(int i = n - 1; i >= 0; i--)
            {
                for (int j = i + 1; j < n; j++)
                    C[i, n] -= C[i, j];
                C[i, n] = (C[i, n]/C[i, i]);

                for(int j= 0; j < n; j++)
                {
                    C[j, i] = C[j, i]*C[i, n];
                }
            }

            Console.WriteLine("Wyniki:");

            // Wyświetlenie wyników
            for (int i = 0; i < n; i++)
            {
                    Console.WriteLine("x"+(i+1)+" = "+C[i, n]);
            }

        }
    }
}
