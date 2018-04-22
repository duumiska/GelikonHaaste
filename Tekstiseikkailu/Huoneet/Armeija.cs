using System;
using System.Collections.Generic;
using System.Text;
using Tekstiseikkailu.Huoneet;

namespace Tekstiseikkailu
{
    class Armeija : IHuone
    {
        public void Aloita()
        {
            Pelimoottori.RuutuVaihto();
            Pelimoottori.KirjoitaRuuudulle(
                "Tulet suureen huoneeseen.\n" +
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
                        Pelimoottori.KirjoitaRuuudulle("Mutta armeija on edelleen sinun ja ulospääsyn edessä.");
                        break;
                    case "juokse":
                        Pelimoottori.RuutuVaihto();
                        Pelimoottori.KirjoitaRuuudulle(
                            "Juokset suoraan päin armeijaa.\n" +
                            "Tulee melkoinen taistelu!");
                        Taistele();
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

        public void Taistele()
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
                                "Onneksi olkoon, sait kolme pistetettä.\n" +
                                "Jatkat eteenpäin.");
                            Tyyppi.pisteet += 3;
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
                            "Hipsit samalla eteenpäin ja ansaitse yhden pisteen");
                        Tyyppi.pisteet += 1;
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
