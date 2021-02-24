using System;

namespace MetodyObliczeniowe
{
    class Lab5
    {
        public static void Taylor()
        {
            //Tablice x oraz y.
            double[] xArray = {1.4, 1.6, 1.8, 2.0, 2.2, 2.4, 2.6, 2.8, 3.0};
            double[] yArray = {0.146128, 0.20412, 2.55273, 0.30103, 0.342423, 0.380211, 0.417999, 0.45, 0.53};

            //Obliczenie odległości między punktami.
            double h = xArray[1] - xArray[0];

            //Dwuwymiarowa tablica, w której będą obliczane delta f.
            double[,] fDeltaArray = new double[yArray.Length, yArray.Length];
            //Wszystkie y zostają wpisane do kolumny
            for (int i = 0; i < yArray.Length; i++)
                fDeltaArray[i, 0] = yArray[i];

            //Algorytm obliczania delta f.
            for (int k = 1; k < yArray.Length; k++)
                for (int i = yArray.Length - 1; i >= 0; i--)
                    for (int j = i - 1; j >= 0; j--)
                        fDeltaArray[j, k] = fDeltaArray[j + 1, k - 1] - fDeltaArray[j, k - 1];

            //Wzór na pochodną 1 stopnia.
            double fx = 0;
            for (int i = 1, j = yArray.Length - 2; i < yArray.Length; i++, j--)
            {
                fx += ((1.0 / i) * fDeltaArray[j, i]);
            }

            Console.WriteLine(fx = fx * (1.0 / h));


        }

    }
}
