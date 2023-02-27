//This is a program wherein the amount of contribution is organized and computed. 
//Walwal Ambag Tracker is the name of this program. 
//The main menu showed first
//Press 1 = Register 
//Press 2 = It will remove one of the CONTRIBUTEE
//Press 3 = It shows all the members and the total contribution of the members. 
//Overall, this program helps you organize not just in "ambagan" but also in other financial aspects such as classroom funds, Budgeting, etc. 





using System;
using System.Collections.Generic;
using System.Linq;

namespace Henry 
{
    class Attend
    {
        static List<string> registeredWalwalero = new List<string>(){"Host"};
        static List<int> ambagValue = new List<int>(){100};

        public static void Main(string[] args)
        {
            ShowMainMenu();
            
        }

        static void ShowMainMenu()
        {
            Console.WriteLine(">>>>>>>>>>>>>>>>>WELCOME TO WALWAL AMBAG TRACKER<<<<<<<<<<<<<<<<<<");
            
            Console.WriteLine("****************MAIN MENU******************");
            Console.WriteLine("PRESS 1 TO REGISTER");
            Console.WriteLine("PRESS 2 TO REMOVE CONTRIBUTEE");
            Console.WriteLine("PRESS 3 TO VIEW ALL MEMBERS AND CONTRIBUTIONS");
            Console.WriteLine("*******************************************");
            
            string userInput = GetUserInput();
            
            switch (userInput)
            {
                case "1":
                    RegisterWalwalero();
                    break;
                case "2":
                    Console.WriteLine("\n REMOVE ACCOUNT \n\n");
                    Console.Write(">Enter Attendee code to be removed: ");
                    var studRemove = Console.ReadLine();
                    if (IsAttendeeFound(studRemove))
                    {
                        registeredWalwalero.Remove(studRemove);
                        ambagValue.Remove(ambagValue[registeredWalwalero.IndexOf(studRemove)]);
                        Console.WriteLine("\n *************** SUCCESSFULLY REMOVED!!**************\n\n");
                        ShowMainMenu();
                    }
                    
                    else
                    {
                        Console.WriteLine("\n WALWALERO NOT FOUND\n\n");
                        ShowMainMenu();
                        userInput = GetUserInput();
                    }
                    break;
                case "3":
                    int total = ambagValue.Sum();
                    for(int i=0; i<=registeredWalwalero.Count-1; i++)
                    {
                        Console.WriteLine(registeredWalwalero[i] + " = " + ambagValue[i]);
                        
                    }
                    
                    Console.WriteLine("Total ambag = " + total);
                    
                    break;
                default:
                    Console.WriteLine("Wrong input");
                    break;
                    
            }
        }

        static string GetUserInput()
        {
            Console.Write(">> WALWALERO INPUT: "); //user input
            string input = Console.ReadLine();
            return input;
        }

        static void RegisterWalwalero()
        {
            Console.WriteLine("\n **** REGISTRATION FORM**********");
            Console.Write(">> ENTER WALWALERO CODE TO REGISTER: ");
            string code = Console.ReadLine();
            Console.WriteLine("\n SUCCESSFULLY VERIFIED!!!!! \n\n");
            int ambag;
            do
            {
                Console.Write("How much contribution would you like to give?: ");
                ambag = Convert.ToInt32(Console.ReadLine());
                if(ambag<=0)
                {
                    Console.WriteLine("Insufficient contribution! Try again.");
                }
            }
            while(ambag<=0);
            
            if(ambag<=100)
            {
                Console.WriteLine("You have 5 shots and 2 choices of pulutan.");
                askContinue(ambag, code);
                
            }
            else if(ambag<=200 && ambag>100)
            {
                Console.WriteLine("You have 10 shots and 2 choices of pulutan.");
                askContinue(ambag, code);
                
            }
            else if(ambag>200)
            {
                Console.WriteLine("You have unlimited shots and unlimited pulutan.");
                askContinue(ambag, code);
                
            }
            ChooseLiquor();
        
        }
        static void askContinue(int num, string name)
        {
            do
            {
                Console.WriteLine("Do you want to continue?[Y/N]");
                string input = Console.ReadLine().ToUpper();
                if(input=="Y")
                {
                    registeredWalwalero.Add(name);
                    ambagValue.Add(num);
                    Console.WriteLine("Registered!");
                    break;
                }
                else if(input=="N")
                {
                    Console.WriteLine("Cancelled");
                    ShowMainMenu();
                }
                else
                {
                    Console.WriteLine("Wrong input try again!");
                    continue;
                }
            }
            while(true);
            
        }
        static void ChooseLiquor()
        {
            Console.WriteLine("What liquor do you like to drink? Enter number only");
            Console.WriteLine("1.Beer\n2.Hard drink");
            int choice = Convert.ToInt32(Console.ReadLine());
            /////////////////////////////////////////////////////
            if (choice == 1)
            {
                Console.WriteLine("\n Light to moderate beer intake may be associated with a lower risk of heart disease, improved blood sugar control, stronger bones, and reduced dementia risk. However, heavy and binge drinking has the opposite effects.\n\n");
    
            }
        
            else if (choice==2)
            {
                Console.WriteLine("Be careful!!");
            }
            
            ShowMainMenu();
        }

        static bool IsAttendeeFound(string walwalCode)
        {
            int found = registeredWalwalero.IndexOf(walwalCode);

            if (found == -1)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}