using Engine.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
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
        
        public List<MonsterEncounter> MonstersHere { get; set; } =
            new List<MonsterEncounter>();

        // This is done to give some intelligence, so that we don't accidentally add the same monster multiple times
        public void AddMonster(int monsterID, int chanceOfEncountering)
        {
            // LINQ
            if(MonstersHere.Exists(m => m.MonsterID == monsterID))
            {
                // This monster has already been added to this location
                // So, overwrite the ChanceOfEncountering with the new number
                // ((get the first monster it finds with the monsterID
                // and set the ChanceOfEncountering with chanceOfEncountering))
                MonstersHere.First(m => m.MonsterID == monsterID).ChanceOfEncountering = chanceOfEncountering;
            }
            else
            {
                // This monster is not already at this location, so add it
                MonstersHere.Add(new MonsterEncounter(monsterID, chanceOfEncountering));
            }
        }

        public Monster GetMonster()
        {
            if (!MonstersHere.Any())
            {
                return null;
            }

            // Total the percentages of all monsters at this location
            // ((add up all ChanceOfEnountering in the List at this location))
            int totalChances = MonstersHere.Sum(m => m.ChanceOfEncountering);

            // Select a random number between 1 and the total (in this case the total chances is not 100)
            int randomNumber = RandomNumberGenerator.NumberBetween(1, totalChances);

            // Loop through monster list, 
            // adding the monster's percentage chance of appearing to the runningTotal variable.
            // When the random number is lower than the runningTotal,
            // that is the monster to return.

            int runningTotal = 0;
            
            foreach(MonsterEncounter monsterEncounter in MonstersHere)
            {
                runningTotal += monsterEncounter.ChanceOfEncountering;

                if(randomNumber <= runningTotal)
                {
                    return MonsterFactory.GetMonster(monsterEncounter.MonsterID);
                }
            }

            // If there was any problem, return the last monster in the list
            return MonsterFactory.GetMonster(MonstersHere.Last().MonsterID);
        }


    }
}
