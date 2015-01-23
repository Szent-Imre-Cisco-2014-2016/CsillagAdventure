using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace snake
{
    class Kepernyo
    {
       static string[][] _palya; // Pálya szerkezete
       static int _generalt = 0;
       static int _xmeret; // Pálya X mérete
       static int _ymeret; // Pálya Y mérete
       

       public void InitPalya(int x_max, int y_max) // Pálya létének megalkotása, tömbök létrehozása
       {
           _palya = new string[x_max][];
           _xmeret = x_max;
           _ymeret = y_max;
           for (int x = 0; x < x_max; x++)
           {
               _palya[x] = new string[y_max];
           }
       }

       public int GetYMeret()
       {
           return _ymeret;
       }

       public int GetXMeret()
       {
           return _xmeret;
       }

       public void SetGeneralt(int generalt)
       {
           _generalt = generalt;
       }

       public int GetGeneralt()
       {
           return _generalt;
       }

       public void SetPalya(int x, int y, string adat)
       {
           _palya[x][y] = adat;
       }

       public string GetPalya(int x, int y)
       {
           return _palya[x][y];
       }

        public void Kiirat()
        {
            Console.Clear(); // Töröljük az elöző kiiratásokat
            Jatekos jatekos = new Jatekos();
            jatekos.SetValtozott(false); // Ha idáig eljut a program, akkor true, szóval rakjuk false-ra
            int jatekos_x = jatekos.GetXPoz(); // Játékos X poz
            int jatekos_y = jatekos.GetYPoz(); // Játékos Y poz

            for (int x = 0; x < _xmeret; x++)
            {
                for (int y = 0; y < _ymeret; y++)
                {
                    if (x == jatekos_x && y == jatekos_y) // Játékos kiiratása, színesen
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write("*");
                        Console.ForegroundColor = ConsoleColor.Gray;
                    }
                    else // Pálya elem kiiratása
                    {
                        Console.Write(_palya[x][y]);
                    }
                }
                Console.WriteLine(); // Következő sor
            }

        }
    }
}
