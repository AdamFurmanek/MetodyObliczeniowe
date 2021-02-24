using System;

namespace MetodyObliczeniowe
{
    class Lab8
    {
        static double Function(double x, double y)
        {
            return x * x * 0.2 + y * y;
        }

        public static void Euler()
        {
            double a = 0;
            double b = 1;
            double h = 0.1;
            double x = a;
            double y = 0.8;
            double deltaY = 0;

            int length = (int)Math.Round((b / h),2)+1;
            double[,] array = new double[length, 4];

            for(int i = 0; i < length; i++)
            {
                array[i, 0] = h * i;
                array[i, 1] = y + deltaY;
                array[i, 2] = Function(array[i, 0], array[i, 1]);
                array[i, 3] = h * array[i, 2];
                y = array[i, 1];
                deltaY = array[i, 3];
            }

            for(int i = 0; i< length; i++)
            {
                for(int j = 0; j < 4; j++)
                {
                    Console.Write(Math.Round(array[i,j],5)+"  ");
                }
                Console.WriteLine();
            }
        }

        public static void RK4()
        {
            double a = 0;
            double b = 1;
            double h = 0.1;
            double x = a;
            double y = 0.8;

            int length = ((int)Math.Round((b / h), 2) + 1)*4;
            double[,] array = new double[length, 4];
            double[] deltaY = new double[length];
            deltaY[0] = 0;

            for (int i = 0; i < length/4; i++)
            {
                y += deltaY[i];

                array[i * 4, 0] = x;
                array[i * 4, 1] = y;
                array[i * 4, 2] = Function(array[i * 4, 0], array[i * 4, 1]) *h;
                array[i * 4, 3] = array[0 + i * 4, 2];

                array[1 + i * 4, 0] = x + h / 2;
                array[1 + i * 4, 1] = y + array[i * 4, 2] / 2;
                array[1 + i * 4, 2] = Function(array[1 + i * 4, 0], array[1 + i * 4, 1]) * h;
                array[1 + i * 4, 3] = 2 * array[1 + i * 4, 2];

                array[2 + i * 4, 0] = x + h / 2;
                array[2 + i * 4, 1] = y + array[1 + i * 4, 2] / 2;
                array[2 + i * 4, 2] = Function(array[2 + i * 4, 0], array[2 + i * 4, 1]) * h;
                array[2 + i * 4, 3] = 2 * array[2 + i * 4, 2];

                array[3 + i * 4, 0] = x + h;
                array[3 + i * 4, 1] = y + array[2 + i * 4, 2];
                array[3 + i * 4, 2] = Function(array[3 + i * 4, 0], array[3 + i * 4, 1]) * h;
                array[3 + i * 4, 3] = array[3 + i * 4, 2];

                x = array[3 + i * 4, 0];
                y = array[i * 4, 1];
                if(i<length-1)
                    deltaY[i+1] = (array[i * 4, 3] + array[1 + i * 4, 3] + array[2 + i * 4, 3] + array[3 + i * 4, 3]) / 6;

            }

            for (int i = 0; i < length; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    Console.Write(Math.Round(array[i, j], 5) + "  ");

                }
                Console.WriteLine();
                if ((i + 1) % 4 == 0)
                    Console.WriteLine("deltaY = "+Math.Round(deltaY[(i+1)/4], 5)+"\n");
            }

        }

    }
}
