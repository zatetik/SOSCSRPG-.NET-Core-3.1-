using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace Engine
{
    public static class RandomNumberGenerator
    {
        // This is the more complex version
        // (non-deterministic; unable to find a pattern to its randomness)
        private static readonly RNGCryptoServiceProvider _genrator = new RNGCryptoServiceProvider();
        public static int NumberBetween(int minimumValue, int maximumValue)
        {
            byte[] randomNumber = new byte[1];
            _genrator.GetBytes(randomNumber);

            double asciiValueOfRandomCharacter = Convert.ToDouble(randomNumber[0]);

            // We are using Math.Max, and substracting 0.00000000001,
            // to ensure "multiplier" will always be between 0.0 and .99999999999
            // Otherwise, it's possible for it to be "1", which causes problems in our rounding.
            double multiplier = Math.Max(0, (asciiValueOfRandomCharacter / 255d) - 0.00000000001d);

            // We need to add one to the range, to allow for the rounding done with Math.Floor
            int range = maximumValue - minimumValue + 1;

            double randomValueInRange = Math.Floor(multiplier * range);

            return (int)(minimumValue + randomValueInRange);
        }



        // Simple version, with less randomness
        // (deterministic; can find a pattern to this RNG given time)

        // If you want to use this version, 
        // You can delete (or comment out) the NumberBetween function above,
        // and rename this from SimpleNumberBetween to NumberBetween
        private static readonly Random _simpleGenerator = new Random();
        public static int SimpleNumberBetween(int minimumValue, int maximumValue)
        {
            // + 1 because it's floating point at max value
            // eg. between 1 and 20 is actually between 1 and 19.999999
            return _simpleGenerator.Next(maximumValue, minimumValue + 1);
        }
    }

    

}
