using System;

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

        public static void Cramer()
        {
            double[,] factorTab = { { 7.5, 9, 3 }, { 15, 3, 4 }, { 30, 6, 6 } };
            double[] freeTab = { 9.5, 5.5, 4.5 };
            int n = (int)Math.Sqrt(factorTab.Length);

            double W = Sarrus(factorTab);

            for (int i = 0; i < n; i++)
            {
                double[,] newTab = new double[n,n];
                for (int j = 0; j < n; j++)
                    for (int k = 0; k < n; k++)
                        newTab[j, k] = factorTab[j, k];
                for (int j = 0; j < n; j++)
                    newTab[j, i] = freeTab[j];

                Console.WriteLine("x"+(i+1)+" = "+(Sarrus(newTab)/W)+"\n");
            }

        }

        public static double Sarrus(double[,] tab)
        {
            int n = (int)Math.Sqrt(tab.Length);

            double[] positiveProduct = new double[n];
            double[] negativeProduct = new double[n];


            for (int i = 0; i < n; i++)
            {
                positiveProduct[i] = 1;
                for (int j = 0; j < n; j++)
                {
                    int k = i + j;
                    if (k >= n)
                        k = k - 3;
                    positiveProduct[i] = positiveProduct[i] * tab[k, j];
                    Console.Write(tab[k, j]);
                    if (j != n - 1)
                        Console.Write("*");
                }
                if(i != n - 1)
                    Console.Write(" + ");
            }

            for (int i = 0; i < n; i++)
            {
                Console.Write(" - ");
                negativeProduct[i] = 1;
                for (int j = n - 1; j >= 0; j--)
                {
                    int k = i - j - 1;
                    if (k < 0 )
                        k = k + n;
                    negativeProduct[i] = negativeProduct[i] * tab[k, j];
                    Console.Write(tab[k, j]);
                    if (j != 0)
                        Console.Write("*");
                }
            }

            Console.Write(" = \n = ");

            for (int i = 0; i < n; i++)
            {
                Console.Write(positiveProduct[i]);
                if (i != n - 1)
                    Console.Write(" + ");
            }

            for (int i = 0; i < n; i++)
            {
                Console.Write(" - ");
                Console.Write(negativeProduct[i]);
            }

            for (int i = 1; i < n; i++)
            {
                positiveProduct[0] += positiveProduct[i];
                negativeProduct[0] += negativeProduct[i];
            }

            Console.Write(" = \n = " + positiveProduct[0] + " - " + negativeProduct[0] + " = " + (positiveProduct[0] - negativeProduct[0]) + "\n");


            return (positiveProduct[0] - negativeProduct[0]);
        }
    }
}
