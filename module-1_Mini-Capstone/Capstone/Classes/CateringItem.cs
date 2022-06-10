using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Classes
{
    /// <summary>
    /// This represents a single catering item in your system
    /// </summary>
    /// <remarks>
    /// This class MUST be abstract
    /// This class MUST be inherited by at least 2 other classes
    /// Those other classes MUST be used in your program.
    /// </remarks>
    public abstract class CateringItem
    {
        public string Name { get; set; }

        public double Price { get; set; }

        public string ID { get; set; }

        public int Quantity { get; set; } = 10;

        public CateringItem(string name, double price, string id, int quantity)
        {
            this.Name = name;
            this.Price = price;
            this.ID = id;
            this.Quantity = quantity;
        }

        public CateringItem() { }

    }
}
