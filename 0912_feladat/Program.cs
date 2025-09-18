using System.Collections;
using System.Drawing;
using System.Numerics;
namespace _0912_feladat
{
    internal class Program
    {
        static void Main(string[] args)
        {
            F31();
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
        static int AskForInt(string q, bool only_positive = false)
        {
            int? input = null;
            while (input is null || (only_positive && input.Value < 0))
            {
                try
                {
                    Console.WriteLine(q);
                    input = int.Parse(Console.ReadLine()!);
                    if ((only_positive && input.Value < 0))
                    {
                        Console.WriteLine("na hát ez biztos nem pozitív");
                    }
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
            return input.Value;
        }
        static double AskForDouble(string q, bool only_positive = false)
        {
            double? input = null;
            while (input is null || (only_positive && input.Value < 0))
            {
                try
                {
                    Console.WriteLine(q);
                    input = double.Parse(Console.ReadLine()!);
                    if ((only_positive && input.Value < 0))
                    {
                        Console.WriteLine("na hát ez biztos nem pozitív");
                    }
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
            return (double)input;
        }


        static Dictionary<Vector2, String> world = new Dictionary<Vector2, String>();
        static Dictionary<Vector2, ent_data> ent = new Dictionary<Vector2, ent_data>();

        struct ent_data
        {
            public string name;
            public string vis;
            public Vector2 pos;
            public int hp;
        };
        static Random rng = new Random();
        static int F0_Gamer()
        {
            
            string cmd = "";
            bool init = false;
            Vector2 mapsize = new Vector2(16, 16);
            do
            {
                Console.Clear();
                if (!init) //setup
                {
                    for (int x = 0; x <= mapsize.X; x++)
                    {
                        for (int y = 0; y <= mapsize.Y; y++)
                        {
                            string t = "grass";
                            int ran1 = rng.Next(3);
                            switch (ran1)
                            {
                                case 0:
                                    t = "grass";
                                    break;
                                case 1:
                                    t = "dirt";
                                    break;
                                case 2:
                                    t = "stone";
                                    break;
                                default:
                                    t = "grass";
                                    break;
                            }
                            world.Add(new Vector2((float)x, (float)y), t);
                            ent_data new_ent = new ent_data
                            {
                                name = "",
                                vis = " ",
                                pos = new Vector2((float)x, (float)y),
                                hp = 0
                            };
                            ent.Add(new Vector2((float)x, (float)y), new_ent);
                        }
                    }
                    init = true;
                    ent_data homonculus = new ent_data
                    {
                        name = "homonculus",
                        vis = "o",
                        pos = new Vector2(mapsize.X / 2, mapsize.Y / 2),
                        hp = 9
                    };
                    ent[homonculus.pos] = homonculus; //homonculus
                    Console.WriteLine("történet: a homonculus (o) elmenekült, tornyokkal le kell győznöd");
                    cmd = AskForString("írj be bármit ha mehet: ");
                }
                else
                {
                    void move_entity(ent_data e, Vector2 where)
                    {
                        double where_x = Math.Clamp(where.X, 0.0, mapsize.X);
                        double where_y = Math.Clamp(where.Y, 0.0, mapsize.Y);
                        Vector2 where_p = new Vector2((float)where_x, (float)where_y);
                        ent[e.pos] = new ent_data
                        {
                            name = "",
                            vis = " ",
                            pos = e.pos,
                            hp = 0,
                        };
                        e.pos = where_p;
                        ent[where] = e;
                    }

                    Dictionary<Vector2, ent_data> buffer = new Dictionary<Vector2, ent_data>(ent);
                    foreach (var v in world) //mozgás
                    {
                        Vector2 vector = (Vector2)(v.Key);
                        ent_data ent_at_v = buffer[vector];
                        switch (ent_at_v.name)
                        {
                            case "homonculus":
                                Vector2 movement = ent_at_v.pos + new Vector2(rng.Next(-1, 2), rng.Next(-1, 2));
                                move_entity(ent_at_v, movement);
                                break;
                            default:
                                break;
                        }
                    }
                    foreach (var v in world) //rajzolok
                    {
                        Vector2 vector = (Vector2)(v.Key);
                        Console.SetCursorPosition((int)vector.X, (int)vector.Y);
                        Console.ForegroundColor = ConsoleColor.Black;
                        switch (world[vector])
                        {
                            case "grass":
                                Console.BackgroundColor = ConsoleColor.Green;
                                break;
                            case "dirt":
                                Console.BackgroundColor = ConsoleColor.DarkYellow;
                                break;
                            case "stone":
                                Console.BackgroundColor = ConsoleColor.Gray;
                                break;
                            default:
                                Console.BackgroundColor = ConsoleColor.Green;
                                break;
                        }
                        Console.Write(ent[vector].vis);
                        Console.ResetColor();
                    }
                    Console.SetCursorPosition(0, (int)mapsize.Y + 1);
                    cmd = AskForString("parancs: ");
                }
            } while (cmd != "exit");

            return 0;
        }


        static void F1()
        {
            Console.WriteLine("Hello world!");
        }
        static void F2()
        {
            string inputName = AskForString("add név: ");
            Console.WriteLine("sziamia " + inputName);
        }

        static void F3()
        {
            int inputN = AskForInt("adj egy számot kétszerezésre: ");
            Console.WriteLine(inputN * 2);

        }

        static void F4()
        {
            int inputN = AskForInt("egy számon dolgozunk: ");
            inputN = int.Parse(Console.ReadLine()!);
            Console.WriteLine(inputN + 2);
            Console.WriteLine(inputN - 2);
            Console.WriteLine(inputN * 2);
            Console.WriteLine(inputN / 2);
        }
        static void F5()
        {
            int inputN1 = AskForInt("első szám: ");
            int inputN2 = AskForInt("második szám: ");

            Console.WriteLine((inputN1 > inputN2) ? inputN1 : inputN2);
        }

        static void F6()
        {
            int inputN1 = AskForInt("első szám: ");
            int inputN2 = AskForInt("második szám: ");
            int inputN3 = AskForInt("harmadik szám: ");
            int minimum = inputN1;
            if (inputN1 < inputN2 && inputN1 < inputN3)
            {
                minimum = inputN1;
            }
            else if (inputN2 < inputN1 && inputN2 < inputN3)
            {
                minimum = inputN2;
            }
            else
            {
                minimum = inputN3;
            }
            Console.WriteLine("legkisebb: " + minimum);
        }
        static void F7()
        {
            int inputN1 = AskForInt("első szám: ");
            int inputN2 = AskForInt("második szám: ");
            int inputN3 = AskForInt("harmadik szám: ");
            if (inputN1 + inputN2 <= inputN3
                || inputN1 + inputN3 <= inputN2
                || inputN2 + inputN3 <= inputN1)
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
            int inputN1 = AskForInt("első szám: ");
            int inputN2 = AskForInt("második szám: ");
            Console.WriteLine("mértani: " + Math.Sqrt(inputN1 * inputN2));
            Console.WriteLine("számtani:" + (float)(inputN1 + inputN2) / 2);
        }
        static void F9()
        {
            double inputD1 = AskForDouble("másodfokú a: ");
            double inputD2 = AskForDouble("másodfokú b: ");
            double inputD3 = AskForDouble("másodfokú c: ");
            double quadr_r = (double)inputD2 * (double)inputD2 - 4 * (double)inputD1 * (double)inputD3;
            if (quadr_r < 0)
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
            double inputD1 = AskForDouble("másodfokú a: ");
            double inputD2 = AskForDouble("másodfokú b: ");
            double inputD3 = AskForDouble("másodfokú c: ");
            double quadr_r = inputD2 * inputD2 - 4 * inputD1 * inputD3;
            if (quadr_r < 0)
            {
                Console.WriteLine("rósz");
                return;
            }
            double quadr_1 = (-inputD2 + Math.Sqrt(quadr_r)) / 2.0 * inputD1;
            double quadr_2 = (-inputD2 - Math.Sqrt(quadr_r)) / 2.0 * inputD1;
            Console.WriteLine($"i1: {quadr_1}");
            Console.WriteLine($"i2: {quadr_2}");
        }

        static void F11()
        {
            double inputD1 = AskForDouble("befogó 1: ");
            double inputD2 = AskForDouble("befogó 2: ");
            double pythagoras = Math.Sqrt(inputD1 * inputD1) + (inputD2 * inputD2);
            Console.WriteLine($"pitagorasz miatt: {pythagoras:f2}");
        }


        static void F12()
        {
            double inputD1 = AskForDouble("él 1: ");
            double inputD2 = AskForDouble("él 2: ");
            double inputD3 = AskForDouble("él 3: ");
            double surface = 2 * (inputD1 * inputD2 + inputD2 * inputD3 + inputD1 * inputD3);
            double volume = inputD1 * inputD2 * inputD3;

            Console.WriteLine("felszín: " + surface);
            Console.WriteLine("térfogat: " + volume);
        }
        static void F13()
        {
            double inputD1 = AskForDouble("átmérőt a körnek: ");
            double circumference = 2.0 * Math.PI * inputD1 / 2.0;
            double area = Math.Pow(inputD1 / 2.0, 2.0) * Math.PI;
        }
        static void F14()
        {
            double inputD1 = AskForDouble("körív sugara: ");
            double inputD2 = AskForDouble("középponti szög: ");
            double area = (Math.Pow(inputD1, 2.0) / 360) * inputD2 * Math.PI;
            double I = (inputD2 / 360.0) * Math.PI * 2 * inputD1;
            Console.WriteLine($"körcikk területe: {area}");
            Console.WriteLine($"körív hossza: {I}");
        }
        static void F15()
        {
            int n = AskForInt("eddig kiírom a számokat", true);
            int at = 0;
            while (at < n)
            {
                Console.Write(at + " ");
                at += 1;
            }
        }

        static void F16()
        {
            int n = AskForInt("eddig kiírom a számokat", true);
            int at = 0;
            while (at < n+1)
            {
                Console.Write(at + "\n");
                at += 1;
            }
        }

        static void F17()
        {
            int n = AskForInt("eddig kiírom az osztóit", true);
            int at = 1;
            while (at < n+1)
            {
                if (n % at == 0)
                { 
                    Console.Write(at + " ");
                }
                at += 1;
            }
        }

        static void F18()
        {
            int n = AskForInt("ennek a számnak az osztóoinak az összegét akarom kiiratni", true);
            int at = 1;
            int sum = 0;
            while (at < n+1)
            {
                if (n % at == 0)
                {
                    sum += at;
                }
                at += 1;
            }
            Console.WriteLine(sum);
        }

        static void F19()
        {
            int n = AskForInt("tökéletes szám checker", true);
            int at = 1;
            int sum = 0;
            while (at < n+1)
            {
                if (n % at == 0)
                {
                    sum += at;
                }
                at += 1;
            }
            Console.WriteLine((sum == n*2) ? "yes" : "no");
        }

        static void F20()
        {
            int n = AskForInt("hatványalap", true);
            int p = AskForInt("kitevő", true);
            int f = n;
            for (int i = 0; i < p-1; i++)
            {
                f *= n;
            }
            Console.WriteLine($"hatványérték: {f}");
        }

        static void F21()
        {
            AskForDouble("szerinted amit beírsz az pozitív?", true);
            Console.WriteLine("oké köszi");
        }

        static void F22()
        {
            double n = 0;
            double sum = 0.0;
            while (n < 10.0)
            { 
                n = AskForDouble("ez a szám kisebb lesz mint tíz?");
                sum += n;
            }
            Console.WriteLine($"oké ennek összege {sum}");
        }
        static void F23()
        {
            int n = AskForInt("ezt fogom ketté osztani");
            int n_div = n;
            string msg = $"{n} = ";
            while (n_div % 2 == 0)
            {
                msg += "2*";
                n_div /= 2;
            }
            msg += n_div;
            Console.WriteLine(msg);
        }

        static void F24()
        {
            string text = "";
            while (text.ToLower() != "alma")
            {
                text = AskForString("alma?? alma");
            }
            Console.WriteLine("Az alma gyümölcs!");
            
        }

        static void F25()
        {
            int n = AskForInt("egész számot kérek szépen");
            int n_sub = n;
            int mult = 0;
            string msg = $"{n} = ";
            while (n_sub >= 3)
            {
                mult += 1;
                n_sub -= 3;
            }
            msg += $"{mult}*3";
            if (n_sub > 0)
            {
                msg += $"+{n_sub}";
            }
            Console.WriteLine(msg);
        }

        static bool IsPrime(double n)
        {
            bool prime = true;
            for (int i = 2; i <= Math.Floor(Math.Sqrt(n)); ++i)
            {
                if (n % i == 0)
                {
                    prime = false;
                }
            }
            if (n == 1 || n == 2)
            {
                return false;
            }
            else
            {
                return prime;
            }
        }

        static void F26()
        {
            double n = Math.Abs(AskForDouble("ez vajon prím?"));
            bool prime = IsPrime(n);
            Console.WriteLine((prime) ? "ez ám príma" : "nem príma");
        }

        static void F27()
        {
            double n = AskForDouble("eddig akarom a prímeket kiírni");
            for (int i = 0; i <= n; i += 1)
            {
                if (IsPrime(i))
                {
                    Console.WriteLine($"{i} ");
                }
            }
        }
        static void F28()
        {
            double n = AskForDouble("eddig akarom a prímosztókat kiírni");
            for (int i = 0; i <= n; i += 1)
            {
                if (IsPrime(i) && n % i == 0)
                {
                    Console.WriteLine($"{i} ");
                }
            }
        }
        static void F29()
        {
            double n1 = AskForDouble("egy szám");
            double p = n1;
            string msg = $"{p} = ";
            while (!IsPrime(p))
            {
                int n = 2;
                while (p % n > 0)
                {
                    n += 1;
                }
                p /= n;
                msg += $"{n}*";
            }
            if (p != 0)
            {
                msg += $"{p}";
            }
            Console.WriteLine(msg);

        }

        static void F30()
        {
            double n1 = AskForDouble("egy szám");
            double n2 = AskForDouble("két szám");

            Console.WriteLine("lnko = " + LNKO(n1, n2));
        }

        static double LNKO(double n1, double n2)
        {
            double a = (n1 > n2) ? n1 : n2;
            double b = (n1 < n2) ? n1 : n2;
            double t = 0;
            while (b > 0)
            {
                t = b;
                b = a % b;
                a = t;
            }
            return a;
        }

        static void F31()
        {
            double n1 = AskForDouble("egy szám");
            double n2 = AskForDouble("két szám");
            Console.WriteLine("lkkt = " + (Math.Abs(n1*n2) / LNKO(n1, n2)));
        }


    }
}

