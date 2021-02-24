using System;

namespace MetodyObliczeniowe
{
    class Lab7
    {
        static double Function(double x)
        {
            return x * x * x;
        }

        public static void Bisection()
        {
            double a = -10, b = 20;
            double r = 0.1;
            double c;
            double resultC, resultA;

            int counter = 0;
            while (true)
            {
                counter++;
                c = (a + b) / 2;
                Console.WriteLine("x1 = " + a + ", x2 = " + b + ", x=" + c);
                resultC = Function(c);
                Console.WriteLine("f(x) = f("+c+") = "+resultC);
                if (Math.Abs(resultC) < r)
                {
                    Console.WriteLine("|F(x)| < e");
                    break;
                }
                Console.WriteLine("|F(x)| > e");
                resultA = Function(a);
                Console.WriteLine("f(x1) = f(" + a + ") = " + resultA);
                if (resultA * resultC > 0)
                {
                    Console.WriteLine("f(x) * f(x1) > 0 -> x1 = x\n");
                    a = c;
                }
                else
                {
                    Console.WriteLine("f(x) * f(x1) < 0 -> x2 = x\n");
                    b = c;
                }
            }

            Console.WriteLine("x = " + c + "\nF(x) = " + resultC + "\nIterations:" + counter);
        }
    }
}
