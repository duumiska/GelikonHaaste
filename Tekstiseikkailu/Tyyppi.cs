using System;
using System.Collections.Generic;
using System.Text;

namespace Tekstiseikkailu
{
    public class Tyyppi
    {
        public static string nimi = "";
        public static int taisteluvoima = 1;
        public static int ketteryys = 1;
        public static int näppäryys = 1;
        public static bool elossa = true;
        public static int pisteet = 0;


        public static void TeeTyyppi()
        {
            pisteet = 0;
            elossa = true;
            nimi = Pelimoottori.Kysy("Anna nimi: ");
        }

        public static void EsittelyTyyppi()
        {
            Pelimoottori.KirjoitaRuuudulle("------------------------------------------------------------------------------");
            Pelimoottori.KirjoitaRuuudulle("| Nimi:" + nimi + " pisteitä:" + pisteet + "/" + Pelimoottori.tavoite);
            Pelimoottori.KirjoitaRuuudulle("| Taisteluvoima:" + taisteluvoima);
            Pelimoottori.KirjoitaRuuudulle("| Ketteryys:" + taisteluvoima);
            Pelimoottori.KirjoitaRuuudulle("| Näppäryys:" + taisteluvoima);
            Pelimoottori.KirjoitaRuuudulle("------------------------------------------------------------------------------");
        }

        public static void Kuole()
        {
            elossa = false;
        }

    }
}
