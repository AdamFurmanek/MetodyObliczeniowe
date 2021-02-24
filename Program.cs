
namespace MetodyObliczeniowe
{
    class Program
    {
        static void Main(string[] args)
        {
            Fraction fr = new Fraction(14, 56);
            System.Console.WriteLine(fr);
            fr.shortening();
            System.Console.WriteLine(fr);
            fr += 2;
            System.Console.WriteLine(fr);
            fr += new Fraction(1, 2);
            System.Console.WriteLine(fr);
            fr += new Fraction(-1, 2);
            System.Console.WriteLine(fr);
            fr += new Fraction(3, 4);
            System.Console.WriteLine(fr);

        }

    }
}
