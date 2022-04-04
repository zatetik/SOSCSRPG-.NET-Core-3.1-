using System;
using System.Collections.Generic;
using System.Text;

namespace Engine.Models
{
    public class World
    {
        private List<Location> _locations = new List<Location>();

        // only want WorldFactory to access this function
        internal void AddLocation(int xCoordinate, int yCoordinate, 
            string name, string description, string imageName)
        {
            Location loc = new Location();
            loc.XCoordinate = xCoordinate;
            loc.YCoordinate = yCoordinate;
            loc.Name = name;
            loc.Description = description;
            loc.ImageName = imageName;

            // add the new object to the list
            _locations.Add(loc);
        }

        public Location LocationAt(int x, int y)
        {
            foreach(Location loc in _locations)
            {
                if(loc.XCoordinate == x && loc.YCoordinate == y)
                {
                    return loc;
                }
            }
            return null;
        }
    }
}
