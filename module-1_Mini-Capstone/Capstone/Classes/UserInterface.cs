using System;
using System.Collections.Generic;
using System.Text;
using System.IO;


namespace Capstone.Classes
{
    /// <summary>
    /// This class provides all user communications, but not much else.
    /// All the "work" of the application should be done elsewhere
    /// </summary>
    public class UserInterface
    {
        private CateringSystem catering = new CateringSystem();
        private FileAccess file = new FileAccess();

 //>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>             >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>       
//>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  MAIN MENU  >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
//>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>             >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
        public void RunMainMenu()
        {
            file.ReadFiles(catering);
            bool quitMainMenu = false;

            while (!quitMainMenu)
            {
                Console.WriteLine("(1) Display Catering Items");

                Console.WriteLine("(2) Order");

                Console.WriteLine("(3) Quit");

                string mainMenuChoice = Console.ReadLine();
//>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> OPTION 1 (DISPLAY CATERING ITEMS) >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>

                if(mainMenuChoice == "(1)" || mainMenuChoice == "1" || mainMenuChoice == "one" || mainMenuChoice == "One")
                {
                    List<string> menu = catering.BuildCateringMenu(); 
                     
                    foreach(string menuItem in menu)
                    {
                        Console.WriteLine(menuItem);
                    }
                }
//>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> OPTION 2 (ORDER ITEM) >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>

                else if(mainMenuChoice == "(2)" || mainMenuChoice == "2" || mainMenuChoice == "two" || mainMenuChoice == "Two")
                {
                    RunOrderMenu();
                }
//>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> OPTION 3 (QUIT PROGRAM) >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>

                else if (mainMenuChoice == "(3)" || mainMenuChoice == "3" || mainMenuChoice == "three" || mainMenuChoice == "Three")
                {
                    quitMainMenu = true;
                }
                else
                {
                    Console.WriteLine("Please select an actual option, idiot.");
                }
            }
        }

//>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>                     >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
//>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> ORDER/PURCHASE MENU >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
//>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>                     >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
        public void RunOrderMenu()
        {

            bool quitOrderMenu = false;

            while (!quitOrderMenu)
            {
                Console.WriteLine("(1) Add Money");

                Console.WriteLine("(2) Select Products");

                Console.WriteLine("(3) Complete Transaction");

                Console.WriteLine($"Your Current Account Balance is: ${Math.Round(catering.Balance, 2)}");

                string orderMenuChoice = Console.ReadLine();

//>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> OPTION 1 (ADD MONEY) >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>

                if (orderMenuChoice == "(1)" || orderMenuChoice == "1" || orderMenuChoice == "one" || orderMenuChoice == "One")
                {


                    Console.WriteLine("How much money would you like to add? ");
                    Console.WriteLine("Deposit amount must be in whole dollars (1/5/25/50?)");
                    Console.WriteLine("Balance may not exceed $1000");
                    int deposit = int.Parse(Console.ReadLine());
                    // do AddMoney() method, bro
                    Console.WriteLine(catering.AddMoney(deposit)); 


                }

//>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> OPTION 2 (SELECT PRODUCTS) >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>

                if (orderMenuChoice == "(2)" || orderMenuChoice == "2" || orderMenuChoice == "two" || orderMenuChoice == "Two")
                {
                    Console.WriteLine("Please enter the product ID of the item you'd like to purchase");
                    string selectProductChoice = Console.ReadLine();
                    string upProductID = selectProductChoice.ToUpper();
                    Console.WriteLine("Please enter the quantity you would like to purchase.");
                    int productAmount = int.Parse(Console.ReadLine());
                    
                    Console.WriteLine(catering.SelectProduct(upProductID, productAmount));
                    
                    // do SelectProducts() method, bro
                }

//>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> OPTION 3 (COMPLETE TRANSACTION) >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>

                if (orderMenuChoice == "(3)" || orderMenuChoice == "3" || orderMenuChoice == "three" || orderMenuChoice == "Three")
                {
                    List<string> purchaseReport = catering.BuildScreenReport();
                    foreach (string purchase in purchaseReport)
                    {
                        Console.WriteLine(purchase);
                    }
                    Console.WriteLine($"Total: ${catering.PrintAmountSpent()}");

                    Console.WriteLine(catering.ReturnMoney());
                    quitOrderMenu = true;

                }
            }
            return;


        }
 
}
}
