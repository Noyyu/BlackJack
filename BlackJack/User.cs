using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack
{
    internal class User
    {
        string filePath = "userData.txt";
        public string UserName { get; private set; } = "unnamed";
        public string UserPassword { get; private set; } = "password";
        public bool IsAlive { get; private set; } = true;

        public User(string userName, string userPassword)
        {
            this.UserName = userName;
            this.UserPassword = userPassword;

            File.AppendAllText(filePath, "User:\n" + this.UserName + "\n" + this.UserPassword + "\n");
        }
        public User()
        {

        }

        public User[] FindExistingUsers()
        {
            string[] lines = File.ReadAllLines(filePath);
            User[] users = new User[lines.Length % 3]; //Each user SHOULD take up 4 lines
            string name = "Unnamed";
            string password = "password";
            int count = 0;
            int userAmount = 0;

            for (int i = 0; i < lines.Length; i++)
            {
                if (lines[i].Contains("User:"))
                {
                    for (int j = i + 1; j <= 2 && j < lines.Length; j++)
                    {                  
                        if (count == 0)
                        {
                            name = lines[i];
                        }
                        if (count == 1)
                        {
                            password = lines[i];
                        }
                        count++;
                    }
                    users[userAmount] = new User(name, password);
                    userAmount++;
                }
            }
            return users;
        }

        public void KillUser(string userName)
        {
            List<string> lines = new List<string>(File.ReadAllLines(filePath));

            for (int i = 0; i < lines.Count; i++)
            {
                if (lines[i].Contains(userName))
                {
                    lines.RemoveRange((i - 1), (i + 1));
                    break;
                }
            }
        }
        public bool LogIn(string userName, string password)
        {
            if (userName == UserName && password == UserPassword)
            {
                Console.WriteLine();
                Console.WriteLine("Wellcome " + UserName + "! ");
                Console.WriteLine();
                return true;
            }
            else if (!IsAlive)
            {
                Console.WriteLine();
                Console.Write("This user is too poor to play");
                Console.WriteLine();
                return false;
            }
            else
            {
                return false;
            }
            
        }
    }
}
