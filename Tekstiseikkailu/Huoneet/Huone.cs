using System;
using System.Collections.Generic;
using System.Text;

namespace Tekstiseikkailu
{
    class Huone
    {
        public static void Aloita()
        {
            Pelimoottori.RuutuVaihto();
            Pelimoottori.KirjoitaRuuudulle(
                "Synnyt huoneeseen.\n" +
                "Keksi miten pääset pois.\n" +
                "Näet siellä armeijan.");

            bool valmis = false;
            while (!valmis)
            {

                string vastaus = Pelimoottori.TeeValinta("piiloudu", "juokse", "ei mitään");

                switch (vastaus)
                {
                    case "piiloudu":
                        Pelimoottori.KirjoitaRuuudulle("Menet piiloon ja armeija ei näe sinua.");
                        break;
                    case "juokse":
                        Pelimoottori.RuutuVaihto();
                        Pelimoottori.KirjoitaRuuudulle(
                            "Juokset suoraan päin armeijaa.\n" +
                            "Tulee melkoinen taistelu!");
                        Huone.Taistele();
                        valmis = true;
                        break;
                    case "ei mitään":
                        Pelimoottori.KirjoitaRuuudulle(
                            "Armeija luulee sinua patsaaksi ja jatkaa matkaa.\n" +
                            "Pääset pinteestä ja voi jatkaa eteenpäin");
                        valmis = true;
                        break;
                    default:
                        Pelimoottori.KirjoitaRuuudulle("En ymmärrä käskyä");
                        break;
                }
            }
        }

        public static void Taistele()
        {
            bool valmis = false;
            while (!valmis)
            {

                string vastaus = Pelimoottori.TeeValinta("lyö", "pyörry", "tuijota");
                switch (vastaus)
                {
                    case "lyö":
                        if (Pelimoottori.SuoritaHaaste(Tyyppi.taisteluvoima, 10))
                        {
                            Pelimoottori.KirjoitaRuuudulle(
                                "Päihität armeijen helposti.\n" +
                                "Onneksi olkoon, sait uuden tason.\n" +
                                "Jatkat eteenpäin.");
                        }
                        else
                        {
                            Pelimoottori.KirjoitaRuuudulle(
                                "Oi voi, armeija on liian vahva sinulle.\n" +
                                "Tyyppisi on mennytty, kiitos pelaamisesta.\n" +
                                "Parempaa onnea ensi kerralla");
                            Tyyppi.Kuole();
                        }
                        valmis = true;
                        break;
                    case "pyörry":
                        Pelimoottori.KirjoitaRuuudulle(
                                "Pyörryt ja armeija ihmettelee mikä sinulle tuli.\n" +
                                "Vähän aikaa ne tökkii sinua mutta jatkavat sitten eteenpäin.\n" +
                                "Onneksi olkoon selvisit, voit jatkaa eteenpäin.");
                        valmis = true;
                        break;
                    case "tuijota":
                        Pelimoottori.KirjoitaRuuudulle(
                            "Armeija huutaa: TUIJOTUSKILPAILU!!!" +
                            "Nyt alkaa armoton tuijotus." +
                            "Armeija alkaa räpytellä ja voitat!" +
                            "Armeija suuttuu toisilleen ja alkavat kinastelee" +
                            "Hipsit samalla eteenpäin");
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
