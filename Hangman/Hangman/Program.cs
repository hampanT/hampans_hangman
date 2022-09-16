

using System.Text.RegularExpressions;

namespace Hangman
{
    internal class Hangman
    {

        public class Intro
        {
            public static void meddelande() //intro klass som printar lite välkomnande text och instruktioner för spelet
            {
                Console.WriteLine("Välkommen till hänga gubbe!");
                Console.WriteLine("Gissa vad ordet är genom att skriva olika bokstäver");
            }
        }
        public class Ord //klass som skapar ordlista samt innehåller metoder för att slumpa ett ord samt skriva ut _ _ _ för antalet bokstäver i det slumpade ordet.
        {
            public List<string> ordLista = new List<string> { "Hej", "Kaffe", "Dator", "Yxa", "Middag", "Bok" };

            Random generera = new Random();

            public string GetRandomWord()
            {
                int slumpatNummer = generera.Next(ordLista.Count);

                string randomWord = ordLista[slumpatNummer];

                return randomWord;
            }

            
            public void countChars()
            {
                int antalChars = 0;

                List<string> charSpaces = new List<string>();

                string countCharsInWord = GetRandomWord();

                foreach (char c in countCharsInWord)
                {
                    antalChars++;
                    charSpaces.Add(" _ ");
                    Console.Write(" _ ");
                }
            }


        }


        public class Spelare //klass som håller koll på spelarens input
        {

                //Kanske borde ha använt mig av en var testinput = console.readkey eller något liknande :-)

                string testInput = Console.ReadLine().ToLower();

                //Metod som validerar input från användaren
                public static void checkInput(string testInput)
                {

                    if (testInput.Length > 1)
                    {
                        Console.WriteLine("Du får endast gissa en bokstav åt gången!");
                        testInput = Console.ReadLine();
                    }
                    else if (testInput.Any(char.IsDigit))
                    {
                        Console.WriteLine("Din gissning måste vara en bokstav!");
                        testInput = Console.ReadLine();
                    }

                }
        }

        public class hangArt //klass som har console-art som ändras baserat på antalet felgissningar av spelaren
        {
            public void kulle()
            {
                Console.WriteLine("------");
                Console.WriteLine("|/   I");
                Console.WriteLine("|");
                Console.WriteLine("|");
                Console.WriteLine("|");
                Console.WriteLine("|");
                Console.WriteLine("========");
                Console.WriteLine("|      |");
            }

            public void huvud()
            {
                Console.WriteLine("------");
                Console.WriteLine("|/   I");
                Console.WriteLine("|    O");
                Console.WriteLine("|     ");
                Console.WriteLine("|");
                Console.WriteLine("|");
                Console.WriteLine("========");
                Console.WriteLine("|      |");
            }
            public void kropp()
            {
                Console.WriteLine("------");
                Console.WriteLine("|/   I");
                Console.WriteLine("|    O");
                Console.WriteLine("|    |");
                Console.WriteLine("|");
                Console.WriteLine("|");
                Console.WriteLine("========");
                Console.WriteLine("|      |");
            }
            public void arm1()
            {
                Console.WriteLine("------");
                Console.WriteLine("|/   |");
                Console.WriteLine("|    O");
                Console.WriteLine("|   /|");
                Console.WriteLine("|");
                Console.WriteLine("|");
                Console.WriteLine("========");
                Console.WriteLine("|      |");
            }
            public void arm2()
            {
                Console.WriteLine("------");
                Console.WriteLine("|/   |");
                Console.WriteLine("|    O");
                Console.WriteLine("|   /|\\");
                Console.WriteLine("|");
                Console.WriteLine("|");
                Console.WriteLine("========");
                Console.WriteLine("|      |");
            }
            public void ben1()
            {
                Console.WriteLine("------");
                Console.WriteLine("|/   |");
                Console.WriteLine("|    O");
                Console.WriteLine("|   /|\\");
                Console.WriteLine("|   /");
                Console.WriteLine("|");
                Console.WriteLine("========");
                Console.WriteLine("|      |");
            }
            public void ben2()
            {
                Console.WriteLine("------");
                Console.WriteLine("|/   |");
                Console.WriteLine("|    O");
                Console.WriteLine("|   /|\\");
                Console.WriteLine("|   / \\");
                Console.WriteLine("|");
                Console.WriteLine("========");
                Console.WriteLine("|      |");
            }



        }

            public static void Restart()
            {
                //Intro-info
                Console.Clear();
                Intro.meddelande();

            Ord o = new Ord();

            //o.countChars();

            hangArt h = new hangArt();

            //skapa lista med ord
            List<string> ordLista = new List<string> { "Hej", "Kaffe", "Dator", "Yxa", "Middag", "Bok", "tall", "vatten" };

            //konverterade min ordlista till ToLower(), var för lat för att skriva alla ord med små bokstäver :-)
            List<string> lowerCase = ordLista.Select(x => x.ToLower()).ToList();

            //introducera slumpen
            Random rng = new Random();

            int randomNumber = rng.Next(lowerCase.Count);

            //Väljer ett slumpat ord från ordlistan baserat på det slumpade indexet
            string slumpatOrd = lowerCase[randomNumber];

            //Räknar och skriver ut antalet bokstäver i det slumpade ordet

            int antalChars = 0;

            List<string> chars = new List<string>();

            //foreach (char c in o.GetRandomWord())
            //{
            //    antalChars++;
            //    chars.Add(" _ ");
            //    Console.Write(" _ ");
            //}

            foreach (char c in slumpatOrd)
            {
                antalChars++;
                chars.Add(" _ ");
                Console.Write(" _ ");
            }

            int forsok = 0;

            List<string> korrektGissning = new List<string>();
            List<string> felGissning = new List<string>();

            //int index = 0;

            bool win = false;
            while (forsok < 7 | win == false)
            {
                win = korrektGissning.Count == slumpatOrd.Length;
                Console.WriteLine("\n");
                Console.WriteLine("Skriv din bokstav");
                string playerInput = Console.ReadLine().ToLower();
                Spelare.checkInput(playerInput);
                bool containsKorrekt = korrektGissning.Contains(playerInput);
                bool containsFel = felGissning.Contains(playerInput);


                if (containsKorrekt == true | containsFel == true)
                {
                    Console.WriteLine("Du har redan gissat på bokstaven: {0}", playerInput);
                }
                else if (!slumpatOrd.Contains(playerInput))
                {
                    Console.WriteLine("\n");
                    Console.WriteLine("Du gissade fel");
                    forsok++;
                    felGissning.Add(playerInput);

                    Console.WriteLine("Du har {0} försök på dig kvar", (7 - forsok));
                    Console.WriteLine("\n");

                    foreach (var item in chars)
                    {
                        Console.Write(item);
                    }

                    Console.WriteLine("\n");

                    //JÄÄÄÄÄÄKLIGT fult sätt att göra det på, will do for now though

                    if (forsok == 1)
                    {
                        h.kulle();
                    }
                    else if (forsok == 2)
                    {
                        h.huvud();
                    }
                    else if (forsok == 3)
                    {
                        h.kropp();
                    }
                    if (forsok == 4)
                    {
                        h.arm1();
                    }
                    else if (forsok == 5)
                    {
                        h.arm2();
                    }
                    else if (forsok == 6)
                    {
                        h.ben1();
                    }
                    else if (forsok == 7)
                    {
                        h.ben2();
                    }
                    Console.WriteLine(string.Format("Detta är bokstäverna du gissat fel på: ({0}).", string.Join(", ", felGissning)));
                }
                else if (slumpatOrd.Contains(playerInput))
                {
                    foreach (var bokstav in slumpatOrd)
                    {
                        if (playerInput == bokstav.ToString())
                        {
                            Console.WriteLine("Grattis! Du gissade rätt, bokstaven {0} finns i ordet!", playerInput);
                            korrektGissning.Add(bokstav.ToString());
                            win = korrektGissning.Count == slumpatOrd.Length;

                            List<int> foundIndexes = new List<int>();

                            for (int i = slumpatOrd.IndexOf(bokstav); i > -1; i = slumpatOrd.IndexOf(bokstav, i + 1))
                            {
                                foundIndexes.Add(i);
                            }


                            foreach (var item in foundIndexes)
                            {
                                chars[item] = playerInput + " ";
                            }

                            //JÄÄÄÄÄÄKLIGT fult sätt att göra det på, will do for now though

                            if (forsok == 1)
                            {
                                h.kulle();
                            }
                            else if (forsok == 2)
                            {
                                h.huvud();
                            }
                            else if (forsok == 3)
                            {
                                h.kropp();
                            }
                            if (forsok == 4)
                            {
                                h.arm1();
                            }
                            else if (forsok == 5)
                            {
                                h.arm2();
                            }
                            else if (forsok == 6)
                            {
                                h.ben1();
                            }
                            else if (forsok == 7)
                            {
                                h.ben2();
                            }

                            Console.WriteLine(string.Format("Detta är bokstäverna du gissat fel på: ({0}).", string.Join(", ", felGissning)));

                            //ATT GÖRA NÄSTA GÅNG, chars[index] att funka för duplikata bokstäver. Utvidga checkinput för mellanslag + , och andra specialtecken
                            //Efter det, kolla restart av spel samt integration av ord-API
                            //Sist, dela in saker i olika klasser

                            if (slumpatOrd.Length - korrektGissning.Count == 1)
                            {
                                Console.WriteLine("Det återstår bara en bokstav");
                            }
                            else
                            {
                                Console.WriteLine("Det återstår {0} bokstäver kvar att gissa på", (slumpatOrd.Length - korrektGissning.Count));
                            }



                            foreach (var item in chars)
                            {
                                Console.Write(item);
                            }
                        }
                    }
                }


                if (win == true)
                {
                    Console.Clear();
                    Console.WriteLine("Grattis du vann!");
                    Console.WriteLine("Det slumpade ordet var: {0}", slumpatOrd);
                    break;
                }
                if (forsok == 7)
                {
                    Console.WriteLine("\n");
                    Console.WriteLine("Hah du torskade, sopa");
                    Console.WriteLine("Det slumpade ordet var: {0}", slumpatOrd);
                    Console.WriteLine("XDDDDDD");
                    break;
                }


            }
            Console.WriteLine("Vill du spela igen?");
            Console.WriteLine("\n");
            Console.WriteLine("Tryck på ENTER för att spela igen, för att avsluta tryck på valfri knapp");
            var finish = Console.ReadKey();

            if (finish.Key == ConsoleKey.Enter)
            {
                Restart();
            }
            else
            {
                System.Environment.Exit(0);
            }
        }

            static void Main(string[] args)
            {
                //Intro-info
                Intro.meddelande();

                Ord o = new Ord();

                //o.countChars();

                hangArt h = new hangArt();

                //skapa lista med ord
                List<string> ordLista = new List<string> { "Hej", "Kaffe", "Dator", "Yxa", "Middag", "Bok", "tall", "vatten" };

                //konverterade min ordlista till ToLower(), var för lat för att skriva alla ord med små bokstäver :-)
                List<string> lowerCase = ordLista.Select(x => x.ToLower()).ToList();

                //introducera slumpen
                Random rng = new Random();

                int randomNumber = rng.Next(lowerCase.Count);

                //Väljer ett slumpat ord från ordlistan baserat på det slumpade indexet
                string slumpatOrd = lowerCase[randomNumber];



                //Räknar och skriver ut antalet bokstäver i det slumpade ordet

                int antalChars = 0;

                List<string> chars = new List<string>();

            //foreach (char c in o.GetRandomWord())
            //{
            //    antalChars++;
            //    chars.Add(" _ ");
            //    Console.Write(" _ ");
            //}

            foreach (char c in slumpatOrd)
            {
                antalChars++;
                chars.Add(" _ ");
                Console.Write(" _ ");
            }



                int forsok = 0;

                List<string> korrektGissning = new List<string>();
                List<string> felGissning = new List<string>();

                //int index = 0;

                bool win = false;
                while (forsok < 7 | win == false)
                {
                    win = korrektGissning.Count == slumpatOrd.Length;
                    Console.WriteLine("\n");
                    Console.WriteLine("Skriv din bokstav");
                    string testInput = Console.ReadLine().ToLower();
                    Spelare.checkInput(testInput);
                    bool containsKorrekt = korrektGissning.Contains(testInput);
                    bool containsFel = felGissning.Contains(testInput);


                    if (containsKorrekt == true | containsFel == true)
                    {
                        Console.WriteLine("Du har redan gissat på bokstaven: {0}", testInput);
                    }
                    else if (!slumpatOrd.Contains(testInput))
                    {
                        Console.WriteLine("\n");
                        Console.WriteLine("Du gissade fel");
                        forsok++;
                        felGissning.Add(testInput);
                        
                        Console.WriteLine("Du har {0} försök på dig kvar", (7 - forsok));
                        Console.WriteLine("\n");

                        foreach (var item in chars)
                        {
                            Console.Write(item);
                        }

                        Console.WriteLine("\n");

                    //JÄÄÄÄÄÄKLIGT fult sätt att göra det på, will do for now though

                    if (forsok == 1)
                    {
                        h.kulle();
                    }
                    else if (forsok == 2)
                    {
                        h.huvud();
                    }
                    else if (forsok == 3)
                    {
                        h.kropp();
                    }
                    if (forsok == 4)
                    {
                        h.arm1();
                    }
                    else if (forsok == 5)
                    {
                        h.arm2();
                    }
                    else if (forsok == 6)
                    {
                        h.ben1();
                    }
                    else if (forsok == 7)
                    {
                        h.ben2();
                    }
                    Console.WriteLine(string.Format("Detta är bokstäverna du gissat fel på: ({0}).", string.Join(", ", felGissning)));
                }
                    else if (slumpatOrd.Contains(testInput))
                    {
                        foreach (var bokstav in slumpatOrd)
                        {
                            if (testInput == bokstav.ToString())
                            {
                                Console.WriteLine("Grattis! Du gissade rätt, bokstaven {0} finns i ordet!", testInput);
                                korrektGissning.Add(bokstav.ToString());
                                win = korrektGissning.Count == slumpatOrd.Length;

                                List<int> foundIndexes = new List<int>();

                                for (int i = slumpatOrd.IndexOf(bokstav); i > -1; i = slumpatOrd.IndexOf(bokstav, i + 1))
                                {
                                    foundIndexes.Add(i);
                                }


                                foreach (var item in foundIndexes)
                                {
                                    chars[item] = testInput + " ";
                                }

                                //JÄÄÄÄÄÄKLIGT fult sätt att göra det på, will do for now though

                            if (forsok == 1)
                            {
                                h.kulle();
                            }
                            else if (forsok == 2)
                            {
                                h.huvud();
                            }
                            else if (forsok == 3)
                            {
                                h.kropp();
                            }
                            if (forsok == 4)
                            {
                                h.arm1();
                            }
                            else if (forsok == 5)
                            {
                                h.arm2();
                            }
                            else if (forsok == 6)
                            {
                                h.ben1();
                            }
                            else if (forsok == 7)
                            {
                                h.ben2();
                            }

                            Console.WriteLine(string.Format("Detta är bokstäverna du gissat fel på: ({0}).", string.Join(", ", felGissning)));

                            //ATT GÖRA NÄSTA GÅNG, chars[index] att funka för duplikata bokstäver. Utvidga checkinput för mellanslag + , och andra specialtecken
                            //Efter det, kolla restart av spel samt integration av ord-API
                            //Sist, dela in saker i olika klasser







                            if (slumpatOrd.Length - korrektGissning.Count == 1)
                                {
                                    Console.WriteLine("Det återstår bara en bokstav");
                                }
                                else
                                {
                                    Console.WriteLine("Det återstår {0} bokstäver kvar att gissa på", (slumpatOrd.Length - korrektGissning.Count));
                                }

                           
                            
                            




                            foreach (var item in chars)
                                {
                                    Console.Write(item);
                                }
                            }
                        }
                    }


                    if (win == true)
                    {
                        Console.Clear();
                        Console.WriteLine("Grattis du vann!");
                        Console.WriteLine("Det slumpade ordet var: {0}", slumpatOrd);
                        break;
                    }
                    if (forsok == 7)
                    {
                        Console.WriteLine("\n");
                        Console.WriteLine("Hah du torskade, sopa");
                        Console.WriteLine("Det slumpade ordet var: {0}", slumpatOrd);
                        Console.WriteLine("XDDDDDD");
                        break;
                    }


                }
                    Console.WriteLine("Vill du spela igen?");
                    Console.WriteLine("\n");
                    Console.WriteLine("Tryck på ENTER för att spela igen, för att avsluta tryck på valfri knapp");
                    var finish = Console.ReadKey();

                    if (finish.Key == ConsoleKey.Enter)
                    {
                        Restart();
                    }
                    else
                    {
                        System.Environment.Exit(0);
                    }
            }
        }

}


