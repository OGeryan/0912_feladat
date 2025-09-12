namespace _0912_feladat
{
    internal class Program
    {
        static void Main(string[] args)
        {
            F14();
        }

        static string AskForString(string q)
        {
            string? input = null;
            while (input is null)
            {
                try
                {
                    Console.WriteLine(q);
                    input = Console.ReadLine()!;
                }
                catch (Exception)
                {
                    Console.WriteLine("rossz a szöveged tesókácskám");
                }
            }
            return input;
        }
        static int AskForInt(string q)
        {
            int? Input = null;
            while (Input is null)
            {
                try
                {
                    Console.WriteLine(q);
                    Input = int.Parse(Console.ReadLine()!);
                }
                catch (OverflowException)
                {
                    Console.WriteLine("túl sok ez szar");
                }
                catch (FormatException)
                {
                    Console.WriteLine("magyarul");
                }
            }
            return Input.Value;
        }
        static double AskForDouble(string q)
        {
            double? Input = null;
            while (Input is null)
            {
                try
                {
                    Console.WriteLine(q);
                    Input = double.Parse(Console.ReadLine()!);
                }
                catch (FormatException)
                {
                    Console.WriteLine("hát ez nem szám");
                }
                catch (OverflowException)
                {
                    Console.WriteLine("túl sok ez szar");
                }
            }
            return (double)Input;
        }

        static void F1()
        {
            Console.WriteLine("Hello world!");
        }
        static void F2()
        {
            string InputName = AskForString("add név: ");
            Console.WriteLine("sziamia " + InputName);
        }

        static void F3()
        {
            int InputN = AskForInt("adj egy számot kétszerezésre: ");
            Console.WriteLine(InputN * 2);

        }

        static void F4()
        {
            int InputN = AskForInt("egy számon dolgozunk: ");
            InputN = int.Parse(Console.ReadLine()!);
            Console.WriteLine(InputN + 2);
            Console.WriteLine(InputN - 2);
            Console.WriteLine(InputN * 2);
            Console.WriteLine(InputN / 2);
        }
        static void F5()
        {
            int InputN1 = AskForInt("első szám: ");
            int InputN2 = AskForInt("második szám: ");

            Console.WriteLine((InputN1 > InputN2) ? InputN1 : InputN2);
        }

        static void F6()
        {
            int InputN1 = AskForInt("első szám: ");
            int InputN2 = AskForInt("második szám: ");
            int InputN3 = AskForInt("harmadik szám: ");
            int minimum = InputN1;
            if (InputN1 < InputN2 && InputN1 < InputN3)
            {
                minimum = InputN1;
            }
            else if (InputN2 < InputN1 && InputN2 < InputN3)
            {
                minimum = InputN2;
            }
            else
            {
                minimum = InputN3;
            }
            Console.WriteLine("legkisebb: " + minimum);
        }
        static void F7()
        {
            int InputN1 = AskForInt("első szám: ");
            int InputN2 = AskForInt("második szám: ");
            int InputN3 = AskForInt("harmadik szám: ");
            if (InputN1 + InputN2 <= InputN3
                || InputN1 + InputN3 <= InputN2
                || InputN2 + InputN3 <= InputN1)
            {
                Console.WriteLine("rósz");
            }
            else
            {
                Console.WriteLine("jó háromszög");
            }
        }

        static void F8()
        {
            int InputN1 = AskForInt("első szám: ");
            int InputN2 = AskForInt("második szám: ");
            Console.WriteLine("mértani: " + Math.Sqrt(InputN1 * InputN2));
            Console.WriteLine("számtani:" + (float)(InputN1 + InputN2) / 2);
        }
        static void F9()
        {
            double InputD1 = AskForDouble("másodfokú a: ");
            double InputD2 = AskForDouble("másodfokú b: ");
            double InputD3 = AskForDouble("másodfokú c: ");
            double Quadr_r = (double)InputD2 * (double)InputD2 - 4 * (double)InputD1 * (double)InputD3;
            if (Quadr_r < 0)
            {
                Console.WriteLine("megoldás nono");
            }
            else
            {
                Console.WriteLine("megoldás yesyes");
            }
        }

        static void F10()
        {
            double InputD1 = AskForDouble("másodfokú a: ");
            double InputD2 = AskForDouble("másodfokú b: ");
            double InputD3 = AskForDouble("másodfokú c: ");
            double Quadr_r = InputD2 * InputD2 - 4 * InputD1 * InputD3;
            if (Quadr_r < 0)
            {
                Console.WriteLine("rósz");
                return;
            }
            double Quadr_1 = (-InputD2 + Math.Sqrt(Quadr_r)) / 2.0 * InputD1;
            double Quadr_2 = (-InputD2 - Math.Sqrt(Quadr_r)) / 2.0 * InputD1;
            Console.WriteLine($"i1: {Quadr_1}");
            Console.WriteLine($"i2: {Quadr_2}");
        }

        static void F11()
        {
            double InputD1 = AskForDouble("befogó 1: ");
            double InputD2 = AskForDouble("befogó 2: ");
            double Pythagoras = Math.Sqrt(InputD1 * InputD1) + (InputD2 * InputD2);
            Console.WriteLine($"pitagorasz miatt: {Pythagoras:f2}");
        }


        static void F12()
        {
            double InputD1 = AskForDouble("él 1: ");
            double InputD2 = AskForDouble("él 2: ");
            double InputD3 = AskForDouble("él 2: ");
            double Surface = 2 * (InputD1 * InputD2 + InputD2 * InputD3 + InputD1 * InputD3);
            double Volume = InputD1 * InputD2 * InputD3;

            Console.WriteLine("felszín: " + Surface);
            Console.WriteLine("térfogat: " + Volume);
        }
        static void F13()
        {
            double InputD1 = AskForDouble("átmérőt a körnek: ");
            double Circumference = 2.0 * Math.PI * InputD1 / 2.0;
            double Area = Math.Pow(InputD1 / 2.0, 2.0) * Math.PI;
        }
        static void F14()
        {
            double InputD1 = AskForDouble("körív sugara: ");
            double InputD2 = AskForDouble("középponti szög: ");
            double? Area = (Math.Pow(InputD1, 2.0) / 360) * InputD2 * Math.PI;
            double? I = (InputD2 / 360.0) * Math.PI * 2 * InputD1;
            Console.WriteLine($"körcikk területe: {Area}");
            Console.WriteLine($"körív hossza: {I}");
        }
    }
}
