using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Engine.Models
{
    // implementing an interface that notifies other classes if its value changes and updates them
    public class Player : BaseNotificationClass
    {
        // private backing variables
        private string _name;
        private string _characterClass;
        private int _hitPoints;
        private int _experiencePoints;
        private int _level;
        private int _gold;

        public string Name 
        {   
            get { return _name; }
            set 
            {
                _name = value;
                OnPropertyChanged(nameof(Name));
            }
        }
        public string CharacterClass
        {
            get { return _characterClass; }
            set
            {
                _characterClass = value;
                OnPropertyChanged(nameof(CharacterClass));
            }
        }
        public int HitPoints
        {
            get { return _hitPoints; }
            set
            {
                _hitPoints = value;
                OnPropertyChanged(nameof(HitPoints));
            }
        }
        public int ExperiencePoints 
        {
            // get: returns the value stored in _experiencePoints to ExperiencePoints
            // set: sets the value from public ExperiencePoints to private _experiencePoints
            // OnPropertyChanged(): invokes when the property named ExperiencePoints changes
            get { return _experiencePoints; } 
            set 
            { 
                _experiencePoints = value;
                OnPropertyChanged(nameof(ExperiencePoints));
            } 
        }
        public int Level
        {
            get { return _level; }
            set
            {
                _level = value;
                OnPropertyChanged(nameof(Level));
            }
        }
        public int Gold
        {
            get { return _gold; }
            set
            {
                _gold = value;
                OnPropertyChanged(nameof(Gold));
            }
        }

        // Like a list, but...
        // automatically handles notifications, don't have to OnPropertyChanged()
        public ObservableCollection<GameItem> Inventory { get; set; }

        // link statement, using a where clause instead of get/set
        // this is called Deferred Execution. ToList() forces it to be executed
        // it normally executes only when it is needed, but ToList() forces it
        public List<GameItem> Weapons =>
            Inventory.Where(i => i is Weapon).ToList();
        public ObservableCollection<QuestStatus> Quests { get; set; }
        public Player()
        {
            Inventory = new ObservableCollection<GameItem>();
            Quests = new ObservableCollection<QuestStatus>();
        }

        public void AddItemToInventory(GameItem item)
        {
            Inventory.Add(item);

            OnPropertyChanged(nameof(Weapons));
        }
        
        public void RemoveItemFromInventory(GameItem item)
        {
            Inventory.Remove(item);

            OnPropertyChanged(nameof(Weapons));
        }

        public bool HasAllTheseItems(List<ItemQuantity> items)
        {
            foreach(ItemQuantity item in items)
            {
                // checks if the number of items based on the item type id in player's Inventory
                // is less than what is needed
                if(Inventory.Count(i => i.ItemTypeID == item.ItemID) < item.Quantity)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
