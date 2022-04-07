using System;
using System.Collections.Generic;
using System.Text;

/* When importing images, click on the file in the Solution Explorer
 * change the Build Action in Property 
 * from None to Resource
 * They will disappear from the folder but it should be included in Engine.csproj
 */
namespace Engine.Models
{
    public class Location
    {
        public int XCoordinate { get; set; }
        public int YCoordinate { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageName { get; set; }

        //don't have to initialize the List in a constructor if done here
        public List<Quest> QuestsAvailableHere { get; set; } = new List<Quest>();
    }
}
