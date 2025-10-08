using System.Drawing;
using System.Numerics;

namespace BlackJack
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int timing = 30; //Standard timing
            bool exit = false;
            Wallet playerWallet = new Wallet();
            User[] users = new User().FindExistingUsers();



            Intro();

            while (!exit)
            {
                bool playerWon = false;
                bool pass = false;

                Cards dealer = new Cards("the Dealer");
                Cards player = new Cards("the Player");
                

                if (playerWallet.WalletValue <= 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    SpellItOut("You're broke, get out of here!", 10);                   
                    exit = true;
                    continue;
                }
                Console.Clear();
                playerWallet.Bet();
                play(player);
                play(dealer);

                SpellItOut("Dealer: " + dealer.TotalValue + ", Player: " + player.TotalValue, timing);

                //Game start
                while (!exit)
                {
                    // Player turn
                    if (!pass) //If the player didn't pass last round
                    {
                        Console.ForegroundColor = ConsoleColor.DarkGray;
                        Console.WriteLine("1: another card, 2. stay");
                        Console.ForegroundColor = ConsoleColor.White;

                        if (YesOrNo())
                        {
                            pass = false;
                            play(player);
                        }
                        else { pass = true;}
                    }

                    if (dealer.CheckStatAgainstThis(player.TotalValue) && pass) //If the player is stupid and decides to kill itself
                    {
                        exit = true;
                        continue; 
                    }
                    if (player.TotalValue > 21)
                    {
                        exit = true;
                        continue;
                    }

                    play(dealer); //dealer plays until he wins or looses

                    


                    // Win check
                    if (player.CheckStat() == 1 || dealer.CheckStat() == 2) //If the player has gotten a total value of more than 21 OR the dealer got 21..
                    {
                        exit = true;
                        //You lost
                    }
                    else if (pass && dealer.CheckStatAgainstThis(player.TotalValue)) //If the player have passed and the dealer gets a higher alue than the player below 21
                    {
                        exit = true;
                        //You lost
                    }
                    else if (player.CheckStat() == 2 || dealer.CheckStat() == 1) //If the player got 21 or if the dealer got more than 21
                    {
                        exit = true;
                        playerWon = true;
                        //You have won
                    }

                    SpellItOut("Dealer: " + dealer.TotalValue + ", Player: " + player.TotalValue, timing);
                    Thread.Sleep(1000);
                }
                if (playerWallet.WalletValue <= 0)
                {
                    continue;
                }
                exit = EndGame(playerWon, dealer.TotalValue, player.TotalValue, playerWallet);
            }

        }
        //Methods

        static void LogIn()
        {
            Console.WriteLine("New or existing user?");
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("1: New, 2: Existing");

            if (YesOrNo())
            {
                string name;
                string password;
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("User name?");
                name = Console.ReadLine();
                Console.Clear();
                Console.WriteLine("Password?");
                password = Console.ReadLine();

                //Hej Nikki!
                //Du behöver lägga till hur mycket pengar varje användare har och ändra "kill user"
                // Ide: Skapa en fil i wallet också och använd ID så man kan matcha ihop dom. 

            }

        }
        static void Intro()
        {
            string line = "";
            int timing = 20; //Standard timing

            //Story
            line = "Hello there, Creature!";
            SpellItOut(line, timing);
            Console.ReadKey(intercept: true);

            line = "I am the dealer, and this is Black Jack";
            SpellItOut(line, timing);
            Console.ReadKey(intercept: true);

            line = "Have you played Black Jack before?";
            timing = 30;
            SpellItOut(line, timing);
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("Yes: 1, No: 2");
            Console.ForegroundColor = ConsoleColor.White;

            if (YesOrNo() == false)
            {
                Tutorial();
            }

            line = "Lets start";
            SpellItOut(line, timing);
            Thread.Sleep(1000);
        }

        static int play(Cards cards)
        {
            SpellItOut(cards.name + " receaved a " + cards.GiveNewCard(), 30);
            cards.CardGraphic(cards.CurrentCard);
            Thread.Sleep(2000);

            return cards.CurrentCardGameValue;
        }

        static bool EndGame(bool playerWinCheck, int dealerSum, int playerSum, Wallet playerWallet)
        {

            if (playerWinCheck == true)
            {
                WinMessage();
                Console.WriteLine();
                playerWallet.Result(true);
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Player lost :( ");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine();
                playerWallet.Result(false);
            }

            Console.WriteLine("play again?");
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("Yes: 1, No: 2");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();
            return !YesOrNo();
        }

       
        static void SpellItOut(string line, int timing)
        {
            string stringToFill = "";

            for (int i = 0; i < line.Length; i++)
            {
                if (Console.KeyAvailable)
                {
                    Console.ReadKey(intercept: true);
                    i = line.Length;
                    Console.Clear();
                    Console.WriteLine(line);
                    continue;
                }              

                Console.Clear();
                stringToFill += line[i];
                Console.WriteLine(stringToFill);
                Thread.Sleep(timing);
            }
        }
        static bool YesOrNo()
        {
            int input = -1;
            while (input == -1)
            {
                if (int.TryParse(Console.ReadLine(), out input) && input == 1)
                {
                    return true;
                }
                else if (input == 2)
                {
                    return false;
                }
                else
                {
                    Console.WriteLine("Choose a valid option");
                    input = -1;
                }
            }
            return false;
        }

        static void WinMessage()
        {
            ConsoleColor[] colors = (ConsoleColor[])ConsoleColor.GetValues(typeof(ConsoleColor));

            foreach (var color in colors)
            {
                if (color == Console.BackgroundColor) continue;
                Console.Clear();
                Console.ForegroundColor = color;
                Console.WriteLine("PLAYER WON!");
                Thread.Sleep(200);
            }

        }
        static void Tutorial()
        {
            Console.Clear();
            Console.WriteLine("Tutorial:");
            Console.WriteLine("You are playing against the dealer.");
            Console.WriteLine("Each of you will get one card each for each round.");
            Console.WriteLine("The goal is to get as close to the total sum of 21 as you can");
            Console.WriteLine("Each round you get to choose if you want to get a new card to add to your sum");
            Console.WriteLine("If your sum ends up bigger than 21, you loose");
            Console.WriteLine("Clothed cards are worth 10");
            Console.WriteLine("Ace is worth 1 or 11 depending on if it will kill you if the value is 11");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("Enter to continnue");
            Console.ForegroundColor = ConsoleColor.White;
            Console.ReadKey();
        }
    }
}
