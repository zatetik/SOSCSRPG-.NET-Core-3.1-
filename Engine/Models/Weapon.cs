using System;
using System.Collections.Generic;
using System.Text;

namespace Engine.Models
{
    public class Weapon : GameItem
    {
        public int MinimumDamage { get; set; }
        public int MaximumDamage { get; set; }

        // base() will pass the properties to the parent class
        // while minDamage and maxDamage will be set to this class
        public Weapon(int itemTypeID, string name, int price, int minDamage, int maxDamage) 
            : base(itemTypeID, name, price)
        {
            MinimumDamage = minDamage;
            MaximumDamage = maxDamage;
        }

        // 'new' keyword overrides GameItem.Clone()
        // If not, I think it uses GameItem.Clone() instead of this one (different return type)
        public new Weapon Clone()
        {
            return new Weapon(ItemTypeID, Name, Price, MinimumDamage, MaximumDamage);
        }
    }
}
