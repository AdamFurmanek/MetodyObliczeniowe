using System;
using System.Collections.Generic;
using System.Text;

namespace MetodyObliczeniowe
{
    class Lab7
    {
        static double Function(double x)
        {
            return Math.Sin(0.5 * x) + 1 - x * x;
        }

        public static void Bisection()
        {
            double a = 0, b = 15;
            double r = 0.1;
            double c;
            double resultC, resultA;

            int counter = 0;
            while (true)
            {
                counter++;
                c = (a + b) / 2;
                resultC = Function(c);
                if (Math.Abs(resultC) < r)
                    break;
                resultA = Function(a);
                if (resultA * resultC > 0)
                    a = c;
                else
                    b = c;
            }

            Console.WriteLine("x = " + c + "\nF(x) = " + resultC + "\nIterations:" + counter);
        }
    }
}
