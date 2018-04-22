using System;
using System.Collections.Generic;
using System.Text;

namespace Tekstiseikkailu
{
    public class Tyyppi
    {
        public static string nimi = "";
        public static int taisteluvoima = 1;
        public static bool elossa = true;


        public static void TeeTyyppi()
        {
            nimi = Pelimoottori.Kysy("Anna nimi: ");
        }

        public static void Kuole()
        {
            elossa = false;
        }

    }
}
