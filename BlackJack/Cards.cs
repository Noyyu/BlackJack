using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack
{
    internal class Cards
    {
        public int TotalValue         { get; set; } = 0;
        public int CurrentCard       { get; set; } = 0; // usual card value (ace is 1, queen is 12)
        public int CurrentCardGameValue  { get; set; } // the current card value as in, the ace can be 1 or 11 and a queen is 10
        public string name           { get; set; } = "unnamed";

        private bool lost    = false;
        private bool won     = false;



        public Cards(string playerName)
        {
            this.TotalValue = 0;
            this.CurrentCard = 0;
            this.name = playerName;
        }
         public bool CheckStatAgainstThis(int playerSum)
        {
            if (this.TotalValue > playerSum && this.TotalValue <= 21)
            {
                return true;
            }
            return false;
        }
        public int CheckStat()
        {
            if (this.TotalValue > 21)
            {
                this.lost = true;
                return 1;
            }
            else if (this.TotalValue == 21)
            {
                this.won = true;
                return 2;
            }
            return -1;
        }
        public int GiveNewCard()
        {
            int cardValue = new Random().Next(1, 14); //1-13

            this.CurrentCard = cardValue; //Sets the normal card value
            this.CurrentCardGameValue = cardValue; //Sets the game rule card calue

            if (cardValue == 11 || cardValue == 12 || cardValue == 13) // Klädda kort är lika med 10
            {
                this.CurrentCardGameValue = 10; //Sets the game rule card calue

            }
            if (cardValue == 1 && (TotalValue + 11) <= 21) // Om spelaren får ett Ess och totala summan är lika med eller mindre än 21 (om man lägger på 11) så är ess lika med 11, annars är den lika med 1.
            {
                this.CurrentCardGameValue = 11; //Sets the game rule card calue

            }

            TotalValue += this.CurrentCardGameValue; //Adds the game rule card value to the total sum
            return CurrentCardGameValue;
        }

        public void GetCurrenCardGraphic (int cardValue)
            {
            CardGraphic(cardValue);
            }
        public  void CardGraphic(int card)
        {
            if (card == 1)
            {
                Console.WriteLine("_______");
                Console.WriteLine("|A .  |");
                Console.WriteLine("| /.\\ |");
                Console.WriteLine("|(_._)|");
                Console.WriteLine("|  |  |");
                Console.WriteLine("|____V|");
            }
            else if (card == 2)
            {
                Console.WriteLine("_______");
                Console.WriteLine("|2    |");
                Console.WriteLine("|  o  |");
                Console.WriteLine("|     |");
                Console.WriteLine("|  o  |");
                Console.WriteLine("|____Z|");
            }
            else if (card == 3)
            {
                Console.WriteLine("_______");
                Console.WriteLine("|3    |");
                Console.WriteLine("|  o  |");
                Console.WriteLine("|  o  |");
                Console.WriteLine("|  o  |");
                Console.WriteLine("|____E|");
            }
            else if (card == 4)
            {
                Console.WriteLine("_______");
                Console.WriteLine("|4    |");
                Console.WriteLine("| o o |");
                Console.WriteLine("|     |");
                Console.WriteLine("| o o |");
                Console.WriteLine("|____h|");
            }
            else if (card == 5)
            {
                Console.WriteLine("_______");
                Console.WriteLine("|5    |");
                Console.WriteLine("| o o |");
                Console.WriteLine("|  o  |");
                Console.WriteLine("| o o |");
                Console.WriteLine("|____S|");
            }
            else if (card == 6)
            {
                Console.WriteLine("_______");
                Console.WriteLine("|6    |");
                Console.WriteLine("| o o |");
                Console.WriteLine("| o o |");
                Console.WriteLine("| o o |");
                Console.WriteLine("|____9|");
            }
            else if (card == 7)
            {
                Console.WriteLine("_______");
                Console.WriteLine("|7    |");
                Console.WriteLine("| o o |");
                Console.WriteLine("|o o o|");
                Console.WriteLine("| o o |");
                Console.WriteLine("|____L|");
            }
            else if (card == 8)
            {
                Console.WriteLine("_______");
                Console.WriteLine("|8    |");
                Console.WriteLine("|o o o|");
                Console.WriteLine("| o o |");
                Console.WriteLine("|o o o|");
                Console.WriteLine("|____8|");
            }
            else if (card == 9)
            {
                Console.WriteLine("_______");
                Console.WriteLine("|9    |");
                Console.WriteLine("|o o o|");
                Console.WriteLine("|o o o|");
                Console.WriteLine("|o o o|");
                Console.WriteLine("|____6|");
            }
            else if (card == 10)
            {
                Console.WriteLine("_______");
                Console.WriteLine("|10   |");
                Console.WriteLine("|     |");
                Console.WriteLine("|  X  |");
                Console.WriteLine("|     |");
                Console.WriteLine("|___0l|");
            }
            else if (card == 11)
            {
                Console.WriteLine("_______");
                Console.WriteLine("|J    |");
                Console.WriteLine("| /.\\ |");
                Console.WriteLine("|(_._)|");
                Console.WriteLine("|  |  |");
                Console.WriteLine("|____[|");
            }
            else if (card == 12)
            {
                Console.WriteLine("_______");
                Console.WriteLine("|Q    |");
                Console.WriteLine("| /.\\ |");
                Console.WriteLine("|(_._)|");
                Console.WriteLine("|  |  |");
                Console.WriteLine("|____O|");
            }
            else if (card == 13)
            {
                Console.WriteLine("_______");
                Console.WriteLine("|K    |");
                Console.WriteLine("| /.\\ |");
                Console.WriteLine("|(_._)|");
                Console.WriteLine("|  |  |");
                Console.WriteLine("|____>|");
            }
        }
    }
}














