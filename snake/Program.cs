using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace snake
{
    class Program
    {
        static bool CheckGeneralt(int x, int y)
        {
            Kepernyo kepernyo = new Kepernyo();
            Jatekos jatekos = new Jatekos();
            if (kepernyo.GetGeneralt() == 1)
            {
                return true;
            }
            else
            {
                if (jatekos.GetXPoz() == x && jatekos.GetYPoz() == y)
                {
                    return false;
                }
                else
                {
                    return true;

                }
            }
        }

        static void PalyaGeneralas() // Pálya generálása
        {
            Kepernyo kepernyo = new Kepernyo();
            Random rnd = new Random();
            kepernyo.SetGeneralt(kepernyo.GetGeneralt() + 1);

            for (int x = 0; x < kepernyo.GetXMeret(); x++)
            {
                for (int y = 0; y < kepernyo.GetYMeret(); y++)
                {
                    if (CheckGeneralt(x,y)) // Ha nem az első generálás, akkor a játékos alá nem generálunk semmit
                    {
                    // Sarkok
                        if (y == 0 && x == 0)
                        {
                            kepernyo.SetPalya(x, y, "╔"); 
                        }
                        else if (x == 0 && y == kepernyo.GetYMeret() - 1)
                        {
                            kepernyo.SetPalya(x, y, "╗");
                        }
                        else if (x == kepernyo.GetXMeret() - 1 && y == 0)
                        {
                            kepernyo.SetPalya(x, y, "╚");
                        }
                        else if (x == kepernyo.GetXMeret() - 1 && y == kepernyo.GetYMeret() -1)
                        {
                            kepernyo.SetPalya(x, y, "╝");
                        }
                        else
                        {
                            if (x == 0 || x == kepernyo.GetXMeret() - 1)
                            {
                                kepernyo.SetPalya(x, y, "═");
                            }
                            else
                            {
                                if (y == 0 || y == kepernyo.GetYMeret() - 1)
                                {
                                    kepernyo.SetPalya(x, y, "║");
                                }
                                else
                                {
                                    if (rnd.Next(0, 10) == 1) {
                                      kepernyo.SetPalya(x, y, "W"); // Random fal
                                    }
                                    else
                                    {
                                        kepernyo.SetPalya(x, y, " "); // Üres terület
                                    }
                                }
                            }

                        }
                     }
                }
            }
        }
        static void Main(string[] args)
        {
            // Kurzor kilövése
            Console.CursorVisible = false;

            // Deklarálás
            ConsoleKeyInfo key;
            bool megyajatek = true;
            bool bevitel = false;
            Kepernyo kepernyo = new Kepernyo(); // Képernyő kezelő
            Jatekos jatekos = new Jatekos(); // Játékos kezelő

            kepernyo.InitPalya(24,79); // Játékterület mérete
            PalyaGeneralas(); // Pálya generálása
            jatekos.InitJatekos(); // Játékos létrehozása
            


            while (megyajatek == true)
            {
                if (jatekos.GetValtozott()) // Képernyő kiiratása ha változott
                {
                    kepernyo.Kiirat();
                }
                
                bevitel = false;
                while (bevitel == false) // Ameddig nem érkezik elfogadható key
                {
                    key = Console.ReadKey();

                    if (key.Key == ConsoleKey.UpArrow) // Fel
                    {
                        jatekos.SetXPoz(jatekos.GetXPoz() - 1);
                        bevitel = true;
                    }
                    else if (key.Key == ConsoleKey.DownArrow) // Le
                    {
                        jatekos.SetXPoz(jatekos.GetXPoz() + 1);
                        bevitel = true;
                    }
                    else if (key.Key == ConsoleKey.RightArrow) // Jobbra
                    {
                        jatekos.SetYPoz(jatekos.GetYPoz() + 1);
                        bevitel = true;
                    }
                    else if (key.Key == ConsoleKey.LeftArrow) // Balra
                    {
                        jatekos.SetYPoz(jatekos.GetYPoz() - 1);
                        bevitel = true;
                    }
                    else if (key.Key == ConsoleKey.Escape)
                    {
                        megyajatek = false;
                        bevitel = true;
                    }
                    else if (key.Key == ConsoleKey.Enter) // Új pálya generálása [Enter]
                    {
                        PalyaGeneralas();
                        jatekos.SetValtozott(true);
                        bevitel = true;
                    }

                    Console.Write("\b \b"); // Input write törlés
                    
                }
            }
            
        }
    }
}
