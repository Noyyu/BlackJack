using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack
{
    internal class Wallet
    {
        public enum CurrencyType
        {
            DaysOfHappinessValue = 10,
            HoursOfHappinessValue = 5,
            MinutesOfHappinessValue = 1
        }
        public int DaysOfHappiness     { get; private set; } = 0;
        public int HoursOfHappiness    { get; private set; } = 0;
        public int MinutesOfHappiness  { get; private set; } = 0;

        private int betDays = 0;
        private int betHours = 0;
        private int betMinutes = 0;

        public int WalletValue { get; private set; } = 0;


        //Konstruktorer
        public Wallet()
        {
            DaysOfHappiness    = 1;
            HoursOfHappiness   = 5;
            MinutesOfHappiness = 10;

            WalletValue += (DaysOfHappiness    * (int)CurrencyType.DaysOfHappinessValue);
            WalletValue += (HoursOfHappiness   * (int)CurrencyType.DaysOfHappinessValue);
            WalletValue += (MinutesOfHappiness * (int)CurrencyType.MinutesOfHappinessValue);
        }
        public Wallet (int daysOfHappiness, int hoursOfHappiness, int minutesOfHappiness)
        {
            DaysOfHappiness = daysOfHappiness;
            HoursOfHappiness = hoursOfHappiness;
            MinutesOfHappiness = minutesOfHappiness;

            WalletValue = 0;
            WalletValue += (DaysOfHappiness * (int)CurrencyType.DaysOfHappinessValue);
            WalletValue += (HoursOfHappiness * (int)CurrencyType.DaysOfHappinessValue);
            WalletValue += (MinutesOfHappiness * (int)CurrencyType.MinutesOfHappinessValue);
        }

        public void ShowWallet()
        {
            Console.WriteLine("You have: ");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine(DaysOfHappiness + " Days of Happiness");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine(HoursOfHappiness + " Hours of Happiness");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine(MinutesOfHappiness + " Minites of Happiness");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();
            Console.WriteLine("With a total value of: " + WalletValue);
        }
        public void Bet()
        {
            int userInput;

            ShowWallet();

            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("How much do you want to bet?");
            Console.WriteLine();
            
            if (DaysOfHappiness > 0)
            {
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("Days of happiness: ");
                while (!int.TryParse(Console.ReadLine(),out userInput) || userInput > DaysOfHappiness)
                {
                    Console.WriteLine("Input a valid value");
                }
                betDays = userInput;
                Console.WriteLine();
            }
            if (HoursOfHappiness > 0)
            {
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine("Hours of happiness: ");
                while (!int.TryParse(Console.ReadLine(), out userInput) || userInput > HoursOfHappiness)
                {
                    Console.WriteLine("Input a valid value");
                }
                betHours = userInput;
                Console.WriteLine();
            }
            if (MinutesOfHappiness > 0)
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("Minutes of happiness: ");
                while (!int.TryParse(Console.ReadLine(), out userInput) || userInput > MinutesOfHappiness)
                {
                    Console.WriteLine("Input a valid value");
                }
                betMinutes = userInput;
                Console.WriteLine();
            }
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("You bet: ");            

            if (betDays > 0)
            {
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.Write(betDays + " Days of Happiness");
            }
            if (betHours > 0)
            {
                if (betDays > 0 && betMinutes > 0)
                {
                    Console.Write(", ");
                }
                else if( betDays > 0)
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write(" and ");
                }
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.Write(betDays + " Hours of Happiness");
            }
            if (betMinutes > 0)
            {Console.ForegroundColor = ConsoleColor.Yellow;
                if (betHours > 0)
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine(" and ");
                }
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.Write(betMinutes + " Minutes of Happiness");
            }
            Console.ForegroundColor = ConsoleColor.White;
        }

        public void Result(bool didPlayerWin)
        {
            if (didPlayerWin)
            {
                AddToWallet(CurrencyType.DaysOfHappinessValue, betDays * 2);
                AddToWallet(CurrencyType.HoursOfHappinessValue, betHours * 2);
                AddToWallet(CurrencyType.MinutesOfHappinessValue, betMinutes * 2);
            }
            else
            {
                RemoveFromWallet(CurrencyType.DaysOfHappinessValue, betDays);
                RemoveFromWallet(CurrencyType.HoursOfHappinessValue, betHours);
                RemoveFromWallet(CurrencyType.MinutesOfHappinessValue, betMinutes);
            }
            betDays = 0;
            betHours = 0;
            betMinutes = 0;
        }
        private void AddToWallet(CurrencyType currency, int amount)
        {
            switch (currency)
            {
                case CurrencyType.DaysOfHappinessValue:
                    DaysOfHappiness += amount;
                    break;
                case CurrencyType.HoursOfHappinessValue:
                    HoursOfHappiness += amount;
                    break;
                case CurrencyType.MinutesOfHappinessValue:
                    MinutesOfHappiness += amount;
                    break;
                default:
                    break;
            }

            WalletValue = 0;
            WalletValue += (DaysOfHappiness * (int)CurrencyType.DaysOfHappinessValue);
            WalletValue += (HoursOfHappiness * (int)CurrencyType.DaysOfHappinessValue);
            WalletValue += (MinutesOfHappiness * (int)CurrencyType.MinutesOfHappinessValue);
        }

        private void RemoveFromWallet(CurrencyType currency, int amount)
        {
            switch (currency)
            {
                case CurrencyType.DaysOfHappinessValue:
                    DaysOfHappiness -= amount;
                    break;
                case CurrencyType.HoursOfHappinessValue:
                    HoursOfHappiness -= amount;
                    break;
                case CurrencyType.MinutesOfHappinessValue:
                    MinutesOfHappiness -= amount;
                    break;
                default:
                    break;
            }

            WalletValue = 0;
            WalletValue += (DaysOfHappiness * (int)CurrencyType.DaysOfHappinessValue);
            WalletValue += (HoursOfHappiness * (int)CurrencyType.DaysOfHappinessValue);
            WalletValue += (MinutesOfHappiness * (int)CurrencyType.MinutesOfHappinessValue);
        }
    }
}
