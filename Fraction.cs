using System;
using System.Collections.Generic;
using System.Text;

namespace MetodyObliczeniowe
{
    class Fraction
    {
        public int numerator;
        public int denominator;

        public Fraction(int numerator, int denominator)
        {
            this.numerator = numerator;
            this.denominator = denominator;

            shortening();
        }

        public void shortening()
        {
            bool search = true;
            while (search)
            {
                int max = (numerator > denominator) ? numerator : denominator;
                search = false;

                for(int i = 2; i < max+1; i++)
                {
                    if (numerator % i == 0 && denominator % i == 0)
                    {
                        numerator = numerator / i;
                        denominator = denominator / i;
                        search = true;
                        break;
                    }
                }

                if (numerator == 1 || denominator == 1)
                    break;
            }
        }

        //Wypisanie wielomianu.
        public override string ToString()
        {
            if (denominator == 1)
                return numerator + "";
            else
                return numerator + "/" + denominator;
        }

        //Operator dodawania z liczbami.
        public static Fraction operator +(Fraction fraction, int value)
        {
            fraction.numerator += value*fraction.denominator;
            fraction.shortening();
            return fraction;
        }

        //Przemienność dodawania.
        public static Fraction operator +(int value, Fraction fraction)
        {
            fraction.numerator += value * fraction.denominator;
            fraction.shortening();
            return fraction;
        }

        //Operator dodawania z innymi wielomianami.
        public static Fraction operator +(Fraction fraction1, Fraction fraction2)
        {
            fraction2.numerator *= fraction1.denominator;
            fraction1.numerator *= fraction2.denominator;
            fraction1.denominator *= fraction2.denominator;

            return new Fraction(fraction1.numerator + fraction2.numerator, fraction1.denominator);
        }


    }
}
