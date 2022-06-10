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
        public void AddMoney(int deposit)
        {

            if ((Balance + deposit) <= 1000 && Balance + deposit >= 0)
            { // Merritt said I could break this
                Balance += deposit;
            }

        }
        public void AddCateringItem(string id, CateringItem item)
        {
            items.Add(item.ID, item);
        }

        public void DisplayCateringItems()
        {
            foreach (KeyValuePair<string, CateringItem> kvp in items)
            {
                if (kvp.Value.Quantity == 0)
                {
                    Console.WriteLine($"{kvp.Value.Name} ~~ {kvp.Value.ID} ~~ ${kvp.Value.Price} ~~ SOLD OUT ");
                }
                Console.WriteLine($"{kvp.Value.Name} ~~ {kvp.Value.ID} ~~ ${kvp.Value.Price} ~~ {kvp.Value.Quantity} ");
                // name, id, price, quantity
            }
        }

        public void SelectProduct(string choice, int amountToPurchase)
        {
            bool choiceIsInDictionary = items.ContainsKey(choice);
            int itemQuantity = items[choice].Quantity;
            double costOfPurchase = items[choice].Price * amountToPurchase;

            if (choiceIsInDictionary && (itemQuantity - amountToPurchase) >= 0 && (Balance >= costOfPurchase))
            {
                //if purchase will be successful
                items[choice].Quantity -= amountToPurchase;
                Balance -= (costOfPurchase);
                purchasedItems.Add(items[choice]);

            }
            else if (!choiceIsInDictionary)
            {
                Console.WriteLine($"Sorry your selected choice of {choice} does not exist, please select product listed above.");
                
            }
            else if(itemQuantity<= 0)
            {
                Console.WriteLine($"We are currently out of {choice}, please select different item");
                
            }
            else if ((itemQuantity - amountToPurchase) < 0)
            {
                Console.WriteLine($"Insufficient stock for amount requested.");
            }



        }
    }  
}
