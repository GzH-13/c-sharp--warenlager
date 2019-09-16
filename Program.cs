using System;
using System.Collections.Generic;


namespace Warenlager_Vorlage

{

    class Program

    {

        //Deklaration des Strukturtyps

        public struct Artikel

        {

            public ulong Kennzahl;

            public string Bezeichnung;

            public double Preis;

            public ulong Anzahl;

            //Konstruktor der Struktur

            public Artikel(ulong kenn, string bez, double pr, ulong an)

            {

                Kennzahl = kenn;

                Bezeichnung = bez;

                Preis = pr;

                Anzahl = an;

            }

        };



        static void Main(string[] args)

        {


            Artikel[] Warenlager = new Artikel[]
            {

                        new Artikel(815, "stuhl", 136.93, 3),

                        new Artikel(999, "tisch", 371.35, 2),

                        new Artikel(525, "bett", 551.43, 5),

                        new Artikel(775, "hocker", 22.15, 7),

                        new Artikel(189, "regal", 112.79, 6),

                        new Artikel(189, "schrank", 2198.99, 15),

            };

            double[] preisliste  ;
            double[] preisbereich;
            double anfpreis;
            double endpreis;
            string input; // Main Input variable
            ulong eingabe2;


            do
            {
                Console.WriteLine("---------------- Hauptmenue ----------------");
                Console.WriteLine(" Wählen Sie zwischen");
                Console.WriteLine(" [A]rtikelsuche nach Bezeichnung oder Anfangsbuchstaben:");
                Console.WriteLine(" Artikelsuche nach [K]ennzahl:");
                Console.WriteLine(" Artikelsuche nach [P]reisbereich:");
                Console.WriteLine(" Sortierte [L]iste (preiswerteste zuerst):");
                Console.WriteLine(" [B]earbeiten von Artikeln(Neues Menü)");
                Console.WriteLine(" [E]nde des Programms:");

                input = Console.ReadLine().ToLower();

                switch (input)
                {
                    case "a":
                        bool error = true;
                        Console.Clear();
                        Console.WriteLine("Bitte Suchbegriff eingeben:");
                        string eingabe = Console.ReadLine().ToUpper();

                        Console.Clear();
                        for (int i = 0; i < Warenlager.Length; i++)
                        {
                            if (eingabe == Warenlager[i].Bezeichnung.ToUpper() || eingabe == Warenlager[i].Bezeichnung.ToUpper().Substring(0, 1))
                            {
                                if (Warenlager[i].Bezeichnung != "") {
                                    Console.WriteLine("Der Artikel {0} mit der Kennzahl {1} hat {3} im Lager und kostet {2} Euro", Warenlager[i].Bezeichnung, Warenlager[i].Kennzahl, Warenlager[i].Preis, Warenlager[i].Anzahl);
                                    error = false;
                                }
                            }
                        }

                        if (error)
                        {
                            Console.WriteLine("Der Artikel mit der Name \"{0}\" wurde nicht gefunden", eingabe);
                        }

                        Console.ReadKey();
                        break;

                    case "k":
                        Console.Clear();
                        eingabe = "";
                        Console.WriteLine("Bitte Kennzahl eingeben:");
                        ulong.TryParse(Console.ReadLine(), out eingabe2);

                        for (int i = 0; i < Warenlager.Length; i++)
                        {
                            if (eingabe2 == Warenlager[i].Kennzahl)
                            {
                                eingabe = Warenlager[i].Bezeichnung;
                            }
                        }

                        Console.Clear();
                        if (eingabe == "")
                        {
                            Console.WriteLine("Es wurde kein Artikel gefunden mit der Kennzahl \"{0}\"", eingabe2);
                        }
                        else
                        {
                            for (int i = 0; i < Warenlager.Length; i++)
                            {
                                if (Warenlager[i].Bezeichnung == eingabe)
                                {
                                    Console.WriteLine("Der Artikel {0} mit der Kennzahl {1} hat {3} im Lager und kostet {2} Euro", Warenlager[i].Bezeichnung, Warenlager[i].Kennzahl, Warenlager[i].Preis, Warenlager[i].Anzahl);
                                }
                            }
                        }
                        Console.ReadKey();
                        break;

                    case "p":
                        preisbereich = new double[Warenlager.Length];
                        bool test = true;
                        for (int i = 0; i < Warenlager.Length; i++)
                        {
                            preisbereich[i] = 0;
                        }

                        Console.Clear();
                        Console.WriteLine("Bitte den anfangspreis eingeben:");
                        double.TryParse(Console.ReadLine(), out anfpreis);
                        Console.WriteLine("Bitte den endpreis eingeben:");
                        double.TryParse(Console.ReadLine(), out endpreis);

                        Console.Clear();
                        for (int i = 0; i < Warenlager.Length; i++)
                        {
                            if (anfpreis <= Warenlager[i].Preis && endpreis >= Warenlager[i].Preis)
                            {
                                if (Warenlager[i].Preis != 0) {
                                    Console.WriteLine("Der Artikel {0} mit der Kennzahl {1} hat {3} im Lager und kostet {2} Euro", Warenlager[i].Bezeichnung, Warenlager[i].Kennzahl, Warenlager[i].Preis, Warenlager[i].Anzahl);
                                    test = false;
                                }
                            }
                        }

                        if (test)
                        {
                            Console.WriteLine("Es gibt kein Artikel zwischen die Preise {0} und {1}", anfpreis, endpreis);
                        }

                        Console.ReadKey();

                        break;

                    case "l":
                        Console.Clear();
                        int j = 0;
                        preisliste = new double[Warenlager.Length];
                        for (int i = 0; i < Warenlager.Length; i++)
                        {
                            preisliste[i] = Warenlager[i].Preis;
                        }

                        Array.Sort(preisliste);


                        for (int i = 0; i < Warenlager.Length; i++)
                        {
                            for (int t = 0; t < Warenlager.Length; t++)
                            {
                                if (preisliste[j] == Warenlager[t].Preis)
                                {
                                    if (Warenlager[i].Preis != 0) {
                                        Console.WriteLine("Der Artikel {0} mit der Kennzahl {1} hat {3} im Lager und kostet {2} Euro", Warenlager[i].Bezeichnung, Warenlager[i].Kennzahl, Warenlager[i].Preis, Warenlager[i].Anzahl);
                                    }
                                }
                            }
                            j++;
                        }

                        Console.ReadKey();
                        break;

                    case "b":
                        string input2;
                        do
                        {
                            Console.Clear();
                            Console.WriteLine("-------------- 2 Menü --------------");
                            Console.WriteLine(" Ein neuen Artikel [H]inzufügen:");
                            Console.WriteLine(" Preis, Anzahl oder Bezeichnung ändern[B]:");
                            Console.WriteLine(" Ein Artikel [L]öschen:");
                            Console.WriteLine(" [Z]urück:");

                            input2 = Console.ReadLine();
                            Console.Clear();
                            switch (input2)
                            {
                                case "h":
                                    string bb;
                                    double pp = 0;
                                    ulong an = 0;
                                    bool adderror = false;

                                    Console.Clear();

                                    Console.WriteLine("Bezeichnung:");
                                    bb = Console.ReadLine();

                                    Console.WriteLine("Preis:");
                                    double.TryParse(Console.ReadLine(), out pp);

                                    Console.WriteLine("Anzahl:");
                                    ulong.TryParse(Console.ReadLine(), out an);

                                    Array.Resize(ref Warenlager, Warenlager.Length + 1);

                                    for (int i = 0; i < Warenlager.Length; i++)
                                    {
                                        
                                        if (Warenlager[i].Preis == 0)
                                        {
                                            adderror = true;
                                            Random Kennzahl = new Random();
                                            int mainKennzahl = Kennzahl.Next(minValue: Warenlager.Length+Warenlager.Length, maxValue: Warenlager.Length + Warenlager.Length+1);
                                            Convert.ToUInt64(mainKennzahl);
                                            Warenlager[i].Kennzahl = Convert.ToUInt64(mainKennzahl);
                                            Warenlager[i].Bezeichnung = bb.ToLower();
                                            Warenlager[i].Preis = pp;
                                            Warenlager[i].Anzahl = an;
                                            
                                        }
                                        
                                    }

                                    Console.Clear();
                                    if (adderror)
                                    {

                                        Console.WriteLine("Erfolg!");
                                        Console.ReadKey();
                                    }
                                    else
                                    {
                                        Console.WriteLine("Fehler. Bitte versuchen Sie erneut");
                                        Console.ReadKey();
                                    }

                                    break;

                                case "b":
                                    Console.Clear();
                                    byte eingabeaenderung = 0;
                                    Console.WriteLine("[1] Bezeichnung ändern");
                                    Console.WriteLine("[2] Preis ändern");
                                    Console.WriteLine("[3] Anzahl ändern");
                                    byte.TryParse(Console.ReadLine(), out eingabeaenderung);
                                    Console.Clear();
                                    switch (eingabeaenderung)
                                    {
                                        case (1):
                                            bool error2 = false;
                                            string prufung = "";
                                            string pastBezeichnung;
                                            string newBezeichnung = "";

                                            Console.WriteLine("Bitte die Bezeichnung des Artikels eingeben:");
                                            pastBezeichnung = Console.ReadLine();
                                            for (int i = 0; i < Warenlager.Length; i++)
                                            {
                                                if (Warenlager[i].Bezeichnung == pastBezeichnung.ToLower())
                                                {
                                                    error2 = true;
                                                    prufung = Warenlager[i].Bezeichnung.ToLower();
                                                    Console.Clear();
                                                    Console.WriteLine("Neue Bezeichnung eingeben:");
                                                    newBezeichnung = Console.ReadLine();

                                                    Warenlager[i].Bezeichnung = newBezeichnung.ToLower();

                                                }
                                            }

                                            Console.Clear();
                                            if (error2)
                                            {

                                                Console.WriteLine("Erfolg!");
                                                Console.ReadKey();
                                            }
                                            else
                                            {
                                                Console.WriteLine("Fehler. Bitte versuchen Sie erneut");
                                                Console.ReadKey();
                                            }
                                            break;

                                        case (2):
                                            error2 = false;
                                            double newPreis;

                                            Console.WriteLine("Bitte die Bezeichnung des Artikels eingeben:");
                                            pastBezeichnung = Console.ReadLine();

                                            for (int i = 0; i < Warenlager.Length; i++)
                                            {
                                                if (Warenlager[i].Bezeichnung == pastBezeichnung.ToLower())
                                                {
                                                    error2 = true;
                                                    Console.Clear();
                                                    Console.WriteLine("Neu Preis eingeben:");
                                                    double.TryParse(Console.ReadLine(), out newPreis);

                                                    Warenlager[i].Preis = newPreis;
                                                }
                                            }

                                            Console.Clear();
                                            if (error2)
                                            {

                                                Console.WriteLine("Erfolg!");
                                                Console.ReadKey();
                                            }
                                            else
                                            {
                                                Console.WriteLine("Fehler. Bitte versuchen Sie erneut");
                                                Console.ReadKey();
                                            }
                                            break;

                                        case (3):
                                            error2 = false;
                                            ulong newAnzahl;

                                            Console.WriteLine("Bitte die Bezeichnung des Artikels eingeben:");
                                            pastBezeichnung = Console.ReadLine();

                                            for (int i = 0; i < Warenlager.Length; i++)
                                            {
                                                if (Warenlager[i].Bezeichnung == pastBezeichnung.ToLower())
                                                {
                                                    error2 = true;
                                                    Console.Clear();
                                                    Console.WriteLine("Neu Anzahl eingeben:");
                                                    UInt64.TryParse(Console.ReadLine(), out newAnzahl);

                                                    Warenlager[i].Anzahl = newAnzahl;
                                                }
                                            }

                                            Console.Clear();
                                            if (error2)
                                            {

                                                Console.WriteLine("Erfolg!");
                                                Console.ReadKey();
                                            }
                                            else
                                            {
                                                Console.WriteLine("Fehler. Bitte versuchen Sie erneut");
                                                Console.ReadKey();
                                            }
                                            break;
                                    }
                                    break;

                                case "l":
                                     bool loschenError = false;
                                     string pastBezeichnung2;


                                     Console.WriteLine("Bitte die Bezeichnung des Artikels eingeben die Sie Löschen wollen:");
                                     pastBezeichnung2 = Console.ReadLine();
                                     Console.Clear();
                                    for (int i = 0; i < Warenlager.Length; i++)
                                    {
                                        if (Warenlager[i].Bezeichnung == pastBezeichnung2.ToLower())
                                        {
                                            if (Warenlager[i].Anzahl == 0) {
                                                loschenError = true;
                                                Console.Clear();
                                                Warenlager[i].Anzahl = 0;
                                                Warenlager[i].Bezeichnung = "";
                                                Warenlager[i].Preis = 0;
                                                Warenlager[i].Kennzahl = 0;
                                            }
                                            else
                                            {
                                                Warenlager[i].Anzahl = Warenlager[i].Anzahl - 1;
                                            }
                                        }

                                    }

                                    Console.Clear();
                                    if (loschenError)
                                    {

                                        Console.WriteLine("Erfolg!");
                                        Console.ReadKey();
                                    }
                                    else
                                    {
                                        Console.WriteLine("Fehler. Bitte versuchen Sie erneut");
                                        Console.ReadKey();
                                    }

                                    break;


                            }
                        } while (input2 != "z");
                        break;

               }
                Console.Clear();
            } while (input != "e");
        }

    }

}