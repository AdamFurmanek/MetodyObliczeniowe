using System;
using System.Collections.Generic;
using System.Text;

namespace MetodyObliczeniowe
{
    class Lab4
    {

        // Aproksymacja metodą najmniejszych kwadratów.
        public static void MNK()
        {
            // Tablice x oraz y.
            double[] xArray = { 4.23, 1.40, 4.07, 2.93, 3.44, 1.09, 1.82, 2.43, 20, 30};
            double[] yArray = { 65.72, 58.05, 60.05, 55.79, 50.83, 47.69, 44.49, 59.74, 5, 6};
            int length = xArray.Length;
            // Tabela służąca do wyliczenia S0, S1, S2, T0, T1.
            double[,] table = new double[length + 1, 5];
            for (int i = 0; i < length; i++)
            {
                // Kolumna x^0.
                table[i, 0] = 1;
                // Kolumna x^1.
                table[i, 1] = xArray[i];
                // Kolumna x^2.
                table[i, 2] = xArray[i] * xArray[i];
                // Kolumna x^0 * y.
                table[i, 3] = yArray[i];
                // Kolumna x^1 * y.
                table[i, 4] = yArray[i] * xArray[i];
            }

            //Obliczenie sum poszczególnych kolumn i zapisanie do ostatniego wiersza.
            for(int i = 0; i < 5; i++)
            {
                double sum = 0;
                for (int j = 0; j < length; j++)
                {
                    sum += table[j, i];
                }
                table[length, i] = sum;
            }

            //Obliczenie równania i zapisanie współczynników do tablicy.
            double[] linearFunction = ComputeExuations(table[length, 0], table[length, 1], table[length, 3], table[length, 1], table[length, 2], table[length, 4]);

            Console.WriteLine("Q(x) = "+ linearFunction[0]+"x + "+ linearFunction[1]);

        }

        static double[] ComputeExuations(double X1, double Y1, double R1, double X2, double Y2, double R2)
        {
            // Równanie 1 -równanie 2
            double X3 = X1 - X2;
            double Y3 = Y1 - Y2;
            double R3 = R1 - R2;

            // Przerzucenie współczynnika przy y na drugą stronę.
            Y3 = -Y3;
            // Podzielenie prawej strony równania przez współczynnik przy x.
            Y3 = Y3 / X3;
            R3 = R3 / X3;

            // Wstawienie obliczonego x do równania 1.
            Y3 = Y3 * X1;
            R3 = R3 * X1;

            // Obliczenie y.
            double Y = (R1 - R3) / (Y1 + Y3);
            // Obliczenie x.
            double X = (R1 - Y1 * Y) / X1;

            double[] table = { Y, X };

            return table;
        }
    }
}

