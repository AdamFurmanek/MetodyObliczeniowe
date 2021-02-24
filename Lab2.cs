using System;

namespace MetodyObliczeniowe
{
    class Lab2
    {
        static double Function(double x)
        {
            return 5 * x * x * x * x + 19 * x * x * x + 13 * x * x - 5 * x + 11;
        }

        //Metoda Simpsona.
        public static void Simpson()
        {
            double a = 3; //dolna granica przedziału
            double b = 9; //górna granica przedziału
            int n = 6; //ilość przedziałów
            double h = (b - a) / n; //krok całkowania

            double result = Function(a) + Function(b);
            a += h;
            for (int counter = 1; a < b; a += h, counter++)
            {
                if (counter % 2 == 0)
                    result += Function(a) * 2;
                else
                    result += Function(a) * 4;
            }

            Console.WriteLine(result * h / 3);
        }

        //Metoda Trapezów.
        public static void MetodaTrapezow()
        {
            double a = 3; //dolna granica przedziału
            double b = 9; //górna granica przedziału
            int n = 6; //ilość przedziałów
            double h = (b - a) / n; //krok całkowania

            double result = (Function(a) + Function(b)) / 2;

            for (double a2 = a+h; a2 < b; a2 += h)
            {
                result += Function(a2);
            }

            Console.WriteLine(result * h);
        }
    }
}
