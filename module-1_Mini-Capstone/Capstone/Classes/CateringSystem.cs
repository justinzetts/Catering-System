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
        private readonly List<CateringItem> items = new List<CateringItem>();

        public double Balance { get; set; } = 0;
        public void AddMoney(int deposit)
        {
            
            if ((Balance+deposit) <= 1000 && Balance+deposit >= 0)
            { // Merritt said I could break this
                Balance += deposit;
            }
            
        }
        public void AddCateringItem(CateringItem item)
        {
            items.Add(item);
        }
        
        public void DisplayCateringItems()
        {
            foreach(CateringItem item in items)
            {
                if (item.Quantity == 0)
                {
                    Console.WriteLine($"{item.Name} ~~ {item.ID} ~~ ${item.Price} ~~ SOLD OUT ");
                }
                Console.WriteLine($"{item.Name} ~~ {item.ID} ~~ ${item.Price} ~~ {item.Quantity} ");
                // name, id, price, quantity
            }
           
        }
    }
}
