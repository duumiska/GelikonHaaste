using System;
using System.Collections.Generic;
using System.Text;
using Tekstiseikkailu.Huoneet;

namespace Tekstiseikkailu
{
    public class Pelimoottori
    {
        static Random rnd = new Random();
        static List<IHuone> huoneet;

        public static int tavoite = 10;

        public static void KirjoitaRuuudulle(string teksti)
        {
            Console.WriteLine(teksti);
        }

        public static void LataaHuoneet(params IHuone[] aloitushuoneet)
        {
            huoneet = new List<IHuone>(aloitushuoneet);
        }

        public static bool SatunnainenHuone()
        {
            if (huoneet.Count < 1)
            {
                return false;
            }
            int satunnainenHuone = rnd.Next(0, huoneet.Count);
            huoneet[satunnainenHuone].Aloita();
            //huoneet.RemoveAt(satunnainenHuone);
            return true;
        }

        public static bool Tarkista()
        {
            if(Tyyppi.pisteet >= tavoite)
            {
                KirjoitaRuuudulle("VOITTO! Sä voitit! Oot ihan paras <3");
                return false;
            }
            if(Tyyppi.elossa)
            {
                return true;
            }
            KirjoitaRuuudulle("Oi voi. Olet kuollut. Seikkailu päättyi tähän." +
                "Sait kuitenkin pisteitä " + Tyyppi.pisteet + "/" + tavoite);
            return false;
        }

        public static void RuutuVaihto()
        {
            Console.WriteLine("************************************************************************");
        }

        public static void SiivoaRuutu()
        {
            Console.Clear();
        }

        public static string Kysy(string kysymys)
        {
            Console.Write(kysymys);

            return Console.ReadLine();
        }

        public static void Pysäytä()
        {
            Console.WriteLine("(jatka painamalla mitä tahansa näppäintä)");
            Console.ReadKey();
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

                if(vastaus == "c")
                {
                    Tyyppi.EsittelyTyyppi();
                    continue;
                }

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
