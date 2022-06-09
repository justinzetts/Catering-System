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

        public void SelectProduct(string choice, int amount)
        {
            if (items.ContainsKey(choice) && items[choice].Quantity - amount >= 0 && (Balance >= ((items[choice].Price * amount))))
            {
                items[choice].Quantity -= amount;
                Balance -= (items[choice].Price * amount);
            }

        }
    }  
}
