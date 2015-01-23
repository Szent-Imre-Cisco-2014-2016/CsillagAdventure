using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace snake
{
    class Jatekos
    {
        static int[] _jatekos = new int[2]; // Játékos pozíciója (0 = X, 1 = Y);
        static bool _valtozott = true; // Változott a játékos pozíciója?

        Random rnd = new Random();
        Kepernyo kepernyo = new Kepernyo();
        public bool check_post(string xy, int poz) // Fal van ott, ahova a játékos kíván menni?
        {
            if(xy == "x"){
                if (poz >= kepernyo.GetXMeret()-1 || poz == 0) // Ez biztos fal
                {
                    return false;
                }
                else
                {
                    if (kepernyo.GetPalya(poz, _jatekos[1]) == " ") // Szabad terület
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            else
            {
                if (poz >= kepernyo.GetYMeret()-1 || poz == 0) // Ez biztos fal
                {
                    return false;
                }
                else
                {
                    if (kepernyo.GetPalya(_jatekos[0], poz) == " ") // Szabad terület
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
        }

        public void InitJatekos() // Játékos létének megalkotása, tömbök létrehozása
        {
            bool mehet = false;
            while (mehet == false)
            {
                // Játékos kidobása random területre
                int random_x = rnd.Next(1, kepernyo.GetXMeret());
                int random_y = rnd.Next(1, kepernyo.GetYMeret());

                if (kepernyo.GetPalya(random_x, random_y) == " ") // Ha üres a terület, akkor oké
                {
                    mehet = true;
                    _jatekos[0] = random_x;
                    _jatekos[1] = random_y;
                }
            }

        }

        public bool GetValtozott()
        {
            return _valtozott;
        }

        public void SetValtozott(bool valtozott)
        {
            _valtozott = valtozott;
        }

        public void SetXPoz(int poz)
        {
            if (check_post("x", poz)) // Ha érvényes a lépés
            {
                _jatekos[0] = poz;
                _valtozott = true;
            }
        }

        public void SetYPoz(int poz)
        {
            if (check_post("y", poz)) // Ha érvényes a lépés
            {
                _jatekos[1] = poz;
                _valtozott = true;
            }  
        }

        public int GetXPoz()
        {
            return _jatekos[0];
        }
        
        public int GetYPoz(){
            return _jatekos[1];
        }
    }
}
