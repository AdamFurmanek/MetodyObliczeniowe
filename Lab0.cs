using System;

namespace MetodyObliczeniowe
{
    //Schemat Hornera.
    class Lab0
    {
        public static void Horner()
        {
            double[] w = { -6, 2, 1, 12, -2.5, 30 };

            double x = 3.5;

            double a = 0;
            double b = 0;

            for (int i = 0; i < w.Length; i++)
            {
                b = w[i] + a;
                a = b * x;
            }

            Console.WriteLine(b);
        }


    }
}
