﻿using Engine.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Engine.Factories
{
    // a static class makes the class unable to be instantiated (create objects from the class)
    // instead, we can use the functions directly without instantiating 'new ItemFactory()'
    // eg. ItemFactory.CreateFactory();
    public static class ItemFactory
    {
        // since this is a static class, all methods/functions must be static
        // since this is a static class, there are no constructors because there is 'nothing' to construct
        // However, you can run this function the first time anyone uses anything in this class

        private static List<GameItem> _standardGameItems;

        static ItemFactory()
        {
            _standardGameItems = new List<GameItem>();

            _standardGameItems.Add(new Weapon(1001, "Pointy Stick", 1, 1, 2));
            _standardGameItems.Add(new Weapon(1002, "Rusty Sword", 5, 1, 3));
        }

        public static GameItem CreateGameItem(int itemTypeID)
        {
            GameItem standardItem = _standardGameItems.FirstOrDefault(item => item.ItemTypeID == itemTypeID);
            if(standardItem != null)
            {
                // cloning an object
                return standardItem.Clone();
            }

            return null;
        }
            
    }
}
