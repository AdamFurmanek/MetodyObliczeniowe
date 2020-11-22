using System;
using System.Collections.Generic;
using System.Text;

namespace MetodyObliczeniowe
{
    class Lab3
    {
        //Interpolacja wielomianem Lagrange'a.
        public static void Lagrange()
        {
            //Tablice x oraz y.
            double[] xArray = { 1.27, 1.52, 1.77, 2.02, 2.27, 2.52, 2.77, 3.02, 3.27, 3.52, 3.77, 4.02 };
            double[] yArray = { 5.24229, 4.87329, 4.53329, 4.21893, 3.95735, 3.86962, 3.40313, 3.16658, 2.94454, 2.73548, 1, 0};

            //Końcowy wielomian.
            Polynomial result = new Polynomial(0);
            for(int i = 0; i < xArray.Length; i++)
            {
                //Częściowy wielomian. Na początku przyjmuje yn.
                Polynomial partialResult = new Polynomial(yArray[i]); ;
                for(int j = 0; j < xArray.Length; j++)
                {
                    if (i != j)
                    {
                        //Częściowy wynik mnożony przez licznik.
                        partialResult = partialResult * (new Polynomial(1, -xArray[j]));
                        //Częściowy wynik mnożony przez mianownik.
                        partialResult = partialResult / (xArray[i] - xArray[j]);
                    }
                }
                //Dodanie częściowego wyniku do końcowego.
                result += partialResult;
            }

            Console.WriteLine(result);
        }

        //Interpolacja wielomianem Newton'a.
        public static void Newton()
        {
            //Tablice x oraz y.
            double[] xArray = { 1.27, 1.52, 1.77, 2.02, 2.27, 2.52, 2.77, 3.02, 3.27, 3.52, 3.77, 4.02 };
            double[] yArray = { 5.24229, 4.87329, 4.53329, 4.21893, 3.95735, 3.86962, 3.40313, 3.16658, 2.94454, 2.73548, 1, 0 };

            //Obliczenie odległości między punktami.
            double h = xArray[1]-xArray[0];

            //Dwuwymiarowa tablica, w której będą obliczane delta y.
            double[,]yDeltaArray = new double[yArray.Length, yArray.Length];
            //Wszystkie y zostają wpisane do kolumny
            for(int i = 0; i < yArray.Length; i++)
                yDeltaArray[i, 0] = yArray[i];

            //Algorytm obliczania delta y.
            for (int k = 1; k < yArray.Length; k++)
                for (int i = yArray.Length - 1; i >= 0; i--)
                    for (int j = i - 1; j >= 0; j--)
                        yDeltaArray[j, k] = yDeltaArray[j + 1, k-1] - yDeltaArray[j, k-1];

            //Końcowy wielomian.
            Polynomial result = new Polynomial(0);
            result += yDeltaArray[0, 0];

            for(int i = 1; i < yArray.Length; i++)
            {
                //Częściowy wielomian. Na początku przyjmuje odpowiednią deltę y.
                Polynomial partialResult = new Polynomial(yDeltaArray[0,i]);
                //Częściowy wielomian dzielony przez n!*h^n.
                partialResult = partialResult / (Factorial(i) * Math.Pow(h, i));

                //Częściowy wielomian mnożony przez kolejne elementy x-xn.
                for(int j = 0; j < i; j++)
                {
                    partialResult = partialResult * (new Polynomial(1, -xArray[j]));
                }
                //Dodanie częściowego wielomianu do wyniku końcowego.
                result += partialResult;
            }
            Console.WriteLine(result);
        }

        //Silnia.
        public static double Factorial(int number)
        {
            if (number == 1)
                return 1;
            else
                return number * Factorial(number - 1);
        }


    }

}
