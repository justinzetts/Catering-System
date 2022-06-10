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
    }  
}
