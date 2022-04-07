using System;
using System.Collections.Generic;
using System.Text;

namespace Engine.Models
{
    public class ItemQuantity
    {
        public int ItemID { get; set; }
        public int Quantity { get; set; }

        public ItemQuantity(int itemId, int quantity)
        {
            ItemID = itemId;
            Quantity = quantity;
        }
    }
}
