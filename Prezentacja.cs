using System;

namespace MetodyObliczeniowe
{
    class Prezentacja
    {

        public static void MonteCarlo()
        {
            Random random = new Random();

            int liczbaPunktow = 10000;
            int poleKola = 0;
            double x, y, r;
            for(int i = 0; i < liczbaPunktow; i++)
            {
                x = random.NextDouble() - 0.5;
                y = random.NextDouble() - 0.5;
                r = Math.Sqrt(x*x+y*y);
                if (r <= 0.5)
                    poleKola++;
            }
            Console.WriteLine("Liczba punktów: " + liczbaPunktow);
            Console.WriteLine("Liczba punktów w kole: " + poleKola);
            Console.WriteLine("Oszacowane PI: "+(double)4 *poleKola/liczbaPunktow);

        }

    }
}
