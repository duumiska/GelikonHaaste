using System;
using System.Collections.Generic;
using System.Text;
using Tekstiseikkailu.Huoneet;

namespace Tekstiseikkailu
{
    class Aarrearkku : IHuone
    {

        public void Aloita()
        {
            bool ansa = true;
            Pelimoottori.RuutuVaihto();
            Pelimoottori.KirjoitaRuuudulle(
                "Tulet huoneeseen missä on aarrearkku.\n");

            bool valmis = false;
            while (!valmis)
            {

                string vastaus = Pelimoottori.TeeValinta("avaa arkku", "tutki", "mene pois");

                switch (vastaus)
                {
                    case "avaa arkku":
                        if (ansa)
                        {
                            Pelimoottori.KirjoitaRuuudulle("Avaat arkun ahneuksissasi ja laukaiset ansan.");
                            Pelimoottori.KirjoitaRuuudulle("Katosta tulee kohti tulipallo ja koitat väistää sitä.");
                            if (!Pelimoottori.SuoritaHaaste(Tyyppi.ketteryys, 10))
                            {
                                Tyyppi.Kuole();
                                Pelimoottori.KirjoitaRuuudulle("Et ehdi tulipallon alta pois ja muutut tuhkaksi, Hei hei.");
                                valmis = true;
                                break;
                            }
                            else
                            {
                                Tyyppi.pisteet += 2;
                                Pelimoottori.KirjoitaRuuudulle("Huh, väistät tulipallon juuri ja juuri.");
                                Pelimoottori.KirjoitaRuuudulle("Ansaitset siitä hyvästä yhden pisteen.");
                                Pelimoottori.KirjoitaRuuudulle("Eikun avaamaan arkkua!");
                            }
                        }
                        Tyyppi.pisteet += 2;
                        Pelimoottori.KirjoitaRuuudulle("Ou yeah! Saat kultaa niin että ropisee ja pisteitä 2 kappaletta");
                        valmis = true;
                        break;

                    case "tutki":
                        Pelimoottori.KirjoitaRuuudulle("Huomaat arkussa ansan ja koitat purkaa sen");
                        if (!Pelimoottori.SuoritaHaaste(Tyyppi.näppäryys, 15))
                        {
                            Pelimoottori.KirjoitaRuuudulle(
                            "Onpas hankala ansa, et saa purettua sitä.");
                        }
                        else
                        {
                            ansa = false;
                            Tyyppi.pisteet++;
                            Pelimoottori.KirjoitaRuuudulle(
                            "Easy Piece. Purat ansan kuin parrakas kääpiö konsanaan." + 
                            "Ansaitsit yhden pisteen!");
                        }
                        break;
                    case "mene pois":
                        Pelimoottori.KirjoitaRuuudulle(
                            "Aarteet eivät ole sinua varten, jatkat matkaa kevein repuin eteenpäin\n");
                        valmis = true;
                        break;
                    default:
                        Pelimoottori.KirjoitaRuuudulle("En ymmärrä käskyä");
                        break;
                }
            }
        }

    }
}
