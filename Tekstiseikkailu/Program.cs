using System;

namespace Tekstiseikkailu
{
    class Program
    {
        // Tämä on ohjelman runko ja ajetaan ekana
        static void Main(string[] args)
        {
            while (true)
            {

                Pelimoottori.KirjoitaRuuudulle(
                    "Moi, Tervetuloa meidän peliin.\n" +
                    "Tee ensin tyyppi.\n" +
                    "Kerro sun tyypin nimi.");

                Tyyppi.TeeTyyppi();

                Pelimoottori.KirjoitaRuuudulle(
                    "Moi " + Tyyppi.nimi);

                Pelimoottori.KirjoitaRuuudulle(
                    "Voit koska tahansa tarkastella hahmoasi kirjoittamalla 'c'\n" + 
                    "Näet silloin seuraavan ruudun:");

                Tyyppi.EsittelyTyyppi();

                Pelimoottori.KirjoitaRuuudulle("Aloitamme nyt pelin arpomalla aloitushuoneen");

                Pelimoottori.Pysäytä();
                Pelimoottori.SiivoaRuutu();

                Pelimoottori.LataaHuoneet(new Armeija(), new Aarrearkku());

                while (Pelimoottori.Tarkista())
                {
                    
                    if (!Pelimoottori.SatunnainenHuone())
                    {
                        Pelimoottori.KirjoitaRuuudulle("Pelasit kaikki huoneet läpi, onneksi olkoon!");
                        Pelimoottori.Pysäytä();
                        break;
                    }
                    Pelimoottori.Pysäytä();
                    Pelimoottori.SiivoaRuutu();
                }

                Pelimoottori.KirjoitaRuuudulle("Peli loppui");

                string syöte = Pelimoottori.Kysy("Syötä 'q' lopettaaksesi, muuten alkaa uusi peli:");
                if (syöte == "q")
                {
                    break;
                }

                Pelimoottori.RuutuVaihto();
            }
        }
    }
}
