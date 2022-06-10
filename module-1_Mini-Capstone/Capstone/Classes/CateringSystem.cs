using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Classes
{
    /// <summary>
    /// This class should contain all the "work" for catering system management
    /// </summary>
    public class CateringSystem
    {
        public CateringSystem()
        {

        }
        private Dictionary<string, CateringItem> items = new Dictionary<string, CateringItem>();
        public List<CateringItem> purchasedItems = new List<CateringItem>();
        public double Balance { get; set; } = 0;
        public string AddMoney(int deposit)
        {

            if (deposit < 0)
            {
                return $"The feature says add money not subratact, this ain't a bank G";
            }
            else if ((Balance + deposit) <= 1000 && Balance + deposit >= 0)
            { // Merritt said I could break this
                Balance += deposit;
                return $"Your new Balance is: ${Balance}";
            }
            else if(Balance + deposit > 1000)
            {
                return "I already told you to keep it under $1000, stop wasting my time and try again.";
            }
            else 
            {
                return "I blame John for this.";
            }

        }
        public void AddCateringItem(string id, CateringItem item)
        {
            items.Add(item.ID, item);
        }

        public void BuildCateringMenu(List<string> menu)
        {
            
            foreach (KeyValuePair<string, CateringItem> kvp in items)
            {
                if (kvp.Value.Quantity == 0)
                {
                     menu.Add($"{kvp.Value.Name} ~~ {kvp.Value.ID} ~~ ${kvp.Value.Price} ~~ SOLD OUT ");
                }
                 menu.Add($"{kvp.Value.Name} ~~ {kvp.Value.ID} ~~ ${kvp.Value.Price} ~~ {kvp.Value.Quantity} ");
                // name, id, price, quantity
            }
             
        }

        public string SelectProduct(string choice, int amountToPurchase)
        {
            bool choiceIsInDictionary = items.ContainsKey(choice);
            int amountAvailable = items[choice].Quantity;
            double costOfPurchase = items[choice].Price * amountToPurchase;
            


            if (choiceIsInDictionary && (amountAvailable - amountToPurchase) >= 0 && (Balance >= costOfPurchase))
            {
                //if purchase will be successful
                items[choice].Quantity -= amountToPurchase;
                Balance -= (costOfPurchase);
                purchasedItems.Add(items[choice]);
                return $"Your purchase of {choice} was successful, your new balance is ${Balance}";
                

            }
            else if (!choiceIsInDictionary) // item does not exist
            {
                return $"Sorry your selected choice of {choice} does not exist, please select product listed above.";
               
            }
            else if (amountAvailable <= 0) //Item sold out
            {
                return $"We are currently out of {choice}, please select different item";
                
            }
            else if ((amountAvailable - amountToPurchase) < 0) //insufficient stock amount
            {
                return "Insufficient stock for amount requested.";  

            }
            else
            {
                return "random thing we didn't think about";
            }
        }

        public string ReturnMoney()
        {
            string change;
            int numberOf20s = 0;
            int numberOf10s = 0;
            int numberOf5s = 0;
            int numberOf1s = 0;
            int numberOfQuarters = 0;
            int numberOfDimes = 0;
            int numberOfNickels = 0;

            while (Balance >= 0.05)
            {
                if (Balance / 20 >= 1)
                {
                    numberOf20s = Convert.ToInt32(Math.Floor(Balance / 20));
                    Balance -= 20 * numberOf20s;
                }
                else if (Balance / 10 >= 1)
                {
                    numberOf10s = Convert.ToInt32(Math.Floor(Balance / 10));
                    Balance -= 10 * numberOf10s;
                }
                else if (Balance / 5 >= 1)
                {
                    numberOf5s = Convert.ToInt32(Math.Floor(Balance / 5));
                    Balance -= 5 * numberOf5s;
                }
                else if (Balance / 1 >= 1)
                {
                    numberOf1s = Convert.ToInt32(Math.Floor(Balance / 1));
                    Balance -= numberOf1s;
                }
                else if (Balance / .25 >= 1)
                {
                    numberOfQuarters = Convert.ToInt32(Math.Floor(Balance / .25));
                    Balance -= numberOfQuarters * .25;
                }
                else if (Balance / .1 >= 1)
                {
                    numberOfDimes = Convert.ToInt32(Math.Floor(Balance / .1));
                    Balance -= numberOfDimes * .1;
                }
                else if (Balance / .05 >= 1)
                {
                    numberOfNickels = Convert.ToInt32(Math.Floor(Balance / .05));
                    Balance -= numberOfNickels * .05;
                }
            }

            change = $"Your change will be returned as follows: {numberOf20s} Twenty Dollar Bill(s), {numberOf10s} Ten Dollar Bill(s)," +
                $"{numberOf5s} Five Dollar Bill(s), {numberOf1s} One Dollar Bill(s), {numberOfQuarters} Quarter(s), {numberOfDimes} Dime(s), & {numberOfNickels} Nickel(s).";
            return change;
        }

    }  
}
