﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Engine.Models
{
    // implementing an interface that notifies other classes if its value changes and updates them
    public class Player : INotifyPropertyChanged
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
                OnPropertyChanged("Name");
            }
        }
        public string CharacterClass
        {
            get { return _characterClass; }
            set
            {
                _characterClass = value;
                OnPropertyChanged("CharacterClass");
            }
        }
        public int HitPoints
        {
            get { return _hitPoints; }
            set
            {
                _hitPoints = value;
                OnPropertyChanged("HitPoints");
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
                OnPropertyChanged("ExperiencePoints");
            } 
        }
        public int Level
        {
            get { return _level; }
            set
            {
                _level = value;
                OnPropertyChanged("Level");
            }
        }
        public int Gold
        {
            get { return _gold; }
            set
            {
                _gold = value;
                OnPropertyChanged("Gold");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
