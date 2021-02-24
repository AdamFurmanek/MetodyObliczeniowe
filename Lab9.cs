using System;

namespace MetodyObliczeniowe
{
    class Lab9
    {
        static double Function(double x)
        {
            return (x * x * x * x) + (2 * x * x * x) - (x * x) - (4 * x) + (1);
        }
        public static void Fibonacci()
        {
            double a = -3;
            double b = 2.8;

            double epsilon = 0.001;

            Console.WriteLine("a = "+a+"; b = "+b+"; epsilon = "+epsilon+"\n");

            int n = 1;
            double x1, x2;

            while ((b - a) / FibonacciFunction(n) >= 2*epsilon)
                n++;

            x1 = b - (((double)FibonacciFunction(n - 1) / FibonacciFunction(n)) * (b - a));
            x2 = a + (((double)FibonacciFunction(n - 1) / FibonacciFunction(n)) * (b - a));

            do
            {
                Console.WriteLine("n = "+n);
                if (Function(x1) < Function(x2))
                {
                    b = x2;
                    x2 = x1;
                    n = n - 1;
                    x1 = b - ((double)FibonacciFunction(n - 1) / FibonacciFunction(n) * (b - a));
                }
                else
                {
                    a = x1;
                    x1 = x2;
                    n = n - 1;
                    x2 = a + ((double)FibonacciFunction(n - 1) / FibonacciFunction(n) * (b - a));
                }
                Console.WriteLine("x1 = "+x1);
                Console.WriteLine("x2 = "+x2);
            } while (Math.Abs(x2 - x1) > epsilon && n >= 2);

        }

        static int FibonacciFunction(int n)
        {
            if (n == 0)
                return 0;

            int F0 = 0;
            int F1 = 1;
            for(int i = 1; i < n; i++)
            {
                F1 = F0 + F1;
                F0 = F1 - F0;
            }
            return F1;
        }
    }
}
