using System;
using System.Collections.Generic;
using System.Text;

namespace MetodyObliczeniowe
{
    //Klasa obsługująca podstawowe operacje na wielomianach.
    public class Polynomial
    {
        //Lista współczynników przy kolejnych stopniach zmiennej.
        List<double> factors = new List<double>();

        //Konstruktor przyjmuje współczynniki.
        public Polynomial(params double[] factors)
        {
            foreach (double factor in factors)
            {
                //Ustawia je od końca, tak by współczynnik przy zmiennej zerowego stopnia miał indeks 0.
                this.factors.Insert(0, factor);
            }
        }

        //Utworzenie kopii.
        public Polynomial copy()
        {
            List<double> f1 = new List<double>(factors);
            f1.Reverse();
            return new Polynomial(f1.ToArray());
        }

        //Wypisanie wielomianu.
        public override string ToString()
        {
            string polynomial = "";
            for (int i = factors.Count - 1; i > 0; i--)
            {
                polynomial += factors[i] + "x^" + i + " + ";
            }
            return polynomial + factors[0];
        }

        //Operator dodawania z liczbami.
        public static Polynomial operator + (Polynomial polynomial, double value)
        {
            polynomial.factors[0] = polynomial.factors[0] + value;
            return polynomial;
        }

        //Przemienność dodawania.
        public static Polynomial operator + (double value, Polynomial polynomial)
        {
            return polynomial + value;
        }

        //Operator dodawania z innymi wielomianami.
        public static Polynomial operator + (Polynomial polynomial1, Polynomial polynomial2)
        {

            Polynomial p1 = polynomial1.factors.Count >= polynomial2.factors.Count ? polynomial1.copy() : polynomial2.copy();
            Polynomial p2 = polynomial1.factors.Count < polynomial2.factors.Count ? polynomial1.copy() : polynomial2.copy();

            for (int i = 0; i < p2.factors.Count; i++)
                p1.factors[i] += p2.factors[i];

            return p1;
        }

        //Operator mnożenia z liczbami.
        public static Polynomial operator *(Polynomial polynomial, double value)
        {

            Polynomial p = polynomial.copy();
            for (int i = 0; i < p.factors.Count; i++)
            {
                p.factors[i] = p.factors[i] * value;
            }

            return p;
        }

        //Przemienność mnożenia.
        public static Polynomial operator *(double value, Polynomial polynomial)
        {
            return polynomial * value;
        }

        //Operator mnożenia z innymi wielomianami.
        public static Polynomial operator * (Polynomial polynomial1, Polynomial polynomial2)
        {

            Polynomial p = new Polynomial(0);
            for (int i = 0; i < polynomial1.factors.Count; i++)
            {
                for (int j = 0; j < polynomial2.factors.Count; j++)
                {
                    if (p.factors.Count - 1 < i + j)
                        p.factors.Add(0);
                    p.factors[i + j] += polynomial1.factors[i] * polynomial2.factors[j];
                }
            }

            return p;
        }

        //Operator dzielenia przez liczbę.
        public static Polynomial operator /(Polynomial polynomial, double value)
        {

            Polynomial p = polynomial.copy();
            for (int i = 0; i < p.factors.Count; i++)
            {
                p.factors[i] = p.factors[i] / value;
            }

            return p;
        }

    }
}
