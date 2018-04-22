using System;
using System.Collections.Generic;
using System.Text;

namespace Tekstiseikkailu
{
    public class Pelimoottori
    {
        static Random rnd = new Random();

        public static void KirjoitaRuuudulle(string teksti)
        {
            Console.WriteLine(teksti);
        }

        public static void RuutuVaihto()
        {
            Console.WriteLine("************************************************************************");
        }

        public static string Kysy(string kysymys)
        {
            Console.Write(kysymys);

            return Console.ReadLine();
        }

        public static string TeeValinta(params string[] valinnat)
        {
            int i;

            while (true) {
                RuutuVaihto();
                KirjoitaRuuudulle("Vaihtoehdot:");


                i = 1;
                foreach (string valinta in valinnat)
                {
                    KirjoitaRuuudulle("" + i + ": " + valinta);
                    i++;
                }
                string vastaus = Pelimoottori.Kysy("Mitä teet:").ToLower();

                int vastausLöyty = Array.IndexOf(valinnat, vastaus);
                if (vastausLöyty > -1)
                {
                    KirjoitaRuuudulle(" ");
                    return vastaus;
                }
                else if (int.TryParse(vastaus, out int temp))
                {
                    if (temp > 0 && temp <= valinnat.Length)
                    {
                        KirjoitaRuuudulle(" ");
                        return valinnat[temp-1];
                    }
                }
                else {
                    KirjoitaRuuudulle("Vaihtoehto ei kelpaa. Yritä uudelleen");
                }
            }
        }

        public static bool SuoritaHaaste(int kyky, int haastavuus)
        {
            KirjoitaRuuudulle("Suoritat haasteheiton. Haastavuus: " + haastavuus);
            int noppa = rnd.Next(1, 20);
            KirjoitaRuuudulle("Heitit " + noppa + " johon lisätään +" + kyky);
            return ((noppa + kyky) >= haastavuus);
        }

    }
}
