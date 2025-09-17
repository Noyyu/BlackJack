using System.Numerics;

namespace BlackJack
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string line = "";
            int timing = 30; //Standard timing
            int currentCard = 0;
            bool pass = false;
            bool exit = false;
            bool playerWon = false;

            Cards dealer = new Cards("the Dealer");
            Cards player = new Cards("the Player");

            //Intro();

            play(player);
            play(dealer);

            SpellItOut("Dealer: " + dealer.GetTotalValue() + ", Player: " + player.GetTotalValue(), timing);


            while (exit == false)
            {
                if (pass == false) 
                {
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.WriteLine("1: another card, 2. stay");
                    Console.ForegroundColor = ConsoleColor.White;
                }

                if (YesOrNo() == true)
                {
                    pass = false;
                }
                else
                {
                    pass = true;
                }

                // Play
                if (pass == false)
                {
                    play(player);
                }
                play(dealer);

                SpellItOut("Dealer: " + dealer.GetTotalValue() + ", Player: " + player.GetTotalValue(), timing);
                //---


                // Win check
                if (player.CheckStat() == 1 || dealer.CheckStatAgainstThis(player.GetTotalValue()) || dealer.CheckStat() == 2) //If the player has gotten a total value of more than 21 OR if the player have passed and the dealer got a higher total value than the player under 21 OR the dealer got 21..
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


            }

            if (playerWon == true)
            {
                SpellItOut("Dealer: " + dealer.GetTotalValue() + ", Player: " + player.GetTotalValue(), timing);
                Console.WriteLine("Player won");
            }
            else
            {
                SpellItOut("Dealer: " + dealer.GetTotalValue() + ", Player: " + player.GetTotalValue(), timing);
                Console.WriteLine("Player lost");
            }

        }
        //Methods

        static int play(Cards cards)
        {

            SpellItOut(cards.GetName() + " receaved a " + cards.GiveNewCard(), 30);
            cards.GetCurrentCardGraphic();
            Thread.Sleep(2000);

            return cards.GetCardValue();
        }
        static void Intro()
        {
            string line = "";
            int timing = 50; //Standard timing

            //Story
            line = "Hello there, Creature!";
            SpellItOut(line, timing);
            Thread.Sleep(1000); //1 sek

            line = "I am the dealer, and this is Black Jack";
            SpellItOut(line, timing);
            Thread.Sleep(1000);

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
        }
        static void SpellItOut(string line, int timing)
        {
            string stringToFill = "";

            for (int i = 0; i < line.Length; i++)
            {
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
        static void Tutorial()
        {
            Console.Clear();
            Console.WriteLine("Tutorial:");
            Console.WriteLine("You are playing against the dealer.");
            Console.WriteLine("Each of you will get one card each for each round.");
            Console.WriteLine("The goal is to get as close to the total sum of 21 as you can");
            Console.WriteLine("Each round you get to choose if you want to get a new card to add to your sum");
            Console.WriteLine("If your sum ends up bigger than 21, you loose");
            Console.WriteLine();
            Console.ReadKey();
        }
    }
}
