using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Classes
{
    /// <summary>
    /// This class provides all user communications, but not much else.
    /// All the "work" of the application should be done elsewhere
    /// </summary>
    public class UserInterface
    {
        private CateringSystem catering = new CateringSystem();

        public void RunMainMenu()
        {
            bool quitMainMenu = false;

            while (!quitMainMenu)
            {
                Console.WriteLine("(1) Display Catering Items");

                Console.WriteLine("(2) Order");

                Console.WriteLine("(3) Quit");

                string mainMenuChoice = Console.ReadLine();

                if(mainMenuChoice == "(1)" || mainMenuChoice == "1" || mainMenuChoice == "one" || mainMenuChoice == "One")
                {

                }
                    // do DisplayCateringItems() method, bro

                if(mainMenuChoice == "(2)" || mainMenuChoice == "2" || mainMenuChoice == "two" || mainMenuChoice == "Two")
                {
                    public void RunOrderMenu()
                    {

                        bool quitOrderMenu = false;

                        while (!quitOrderMenu)
                        {
                            Console.WriteLine("(1) Add Money");

                            Console.WriteLine("(2) Select Products");

                            Console.WriteLine("(3) Complete Transaction");

                            string orderMenuChoice = Console.ReadLine();

                            if (orderMenuChoice == "(1)" || orderMenuChoice == "1" || orderMenuChoice == "one" || orderMenuChoice == "One")
                            {
                                

                                // do AddMoney() method, bro


                            }

                            if (orderMenuChoice == "(2)" || orderMenuChoice == "2" || orderMenuChoice == "two" || orderMenuChoice == "Two")
                            {
                                // do SelectProducts() method, bro
                            }

                            if (orderMenuChoice == "(3)" || orderMenuChoice == "3" || orderMenuChoice == "three" || orderMenuChoice == "Three")
                            {
                                quitOrderMenu = true;
                            }
                        }


                    }
                }

                if (mainMenuChoice == "(3)" || mainMenuChoice == "3" || mainMenuChoice == "three" || mainMenuChoice == "Three")
                {
                    quitMainMenu = true;
                }
            }
        }
    }
}
