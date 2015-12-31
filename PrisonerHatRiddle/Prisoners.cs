using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrisonerHatRiddle
{
    public class Prisoners
    {
        public string GetAllResponses(string hats)
        {
            string [] hatsArray = hats.Split(' ');
            int arrayLength = hatsArray.Length;
            List<string> resposeList = new List<string>();
            hatsArray = RemoveFirstItemIfExists(hatsArray);
            bool memOddParity = GetOddParityOfBlackHats(hatsArray);
            for (int i = 0; i < arrayLength; i++)
            {
                bool oddParity = GetOddParityOfBlackHats(hatsArray);
                if (hatsArray.Length == arrayLength - 1 || hatsArray.Length == 0)
                {
                    resposeList.Add(memOddParity ? "B" : "W");
                }
                else
                {
                    resposeList.Add(memOddParity ^ oddParity ? "B" : "W");
                }
                memOddParity = NegateParityIfOddIsDifferent(memOddParity, oddParity);
                hatsArray = RemoveFirstItemIfExists(hatsArray);
            }
            
            return string.Join(" ", resposeList.ToArray());
        }

        private bool NegateParityIfOddIsDifferent(bool prevParity, bool actualParity)
        {
            return (prevParity != actualParity) ? !prevParity : prevParity;
        }

        private string[] RemoveFirstItemIfExists(string[] hatsArray)
        {
            if (hatsArray.Length == 0)
                return hatsArray;
            List<string> hatList = new List<string>(hatsArray);
            hatList.RemoveAt(0);
            return hatList.ToArray();
        }
        
        private bool GetOddParityOfBlackHats(string[] hatsArray)
        {
            return IsOdd(CountHatsOfSpecificColor(hatsArray, "B"));
        }

        private int CountHatsOfSpecificColor(string[] hatsArray, string hatsColor)
        {
            List<string> sHatList = new List<string>(hatsArray);
            return sHatList.Count(x => x == hatsColor);
        }

        private bool IsOdd(int number)
        {
            return number % 2 == 1;
        }
    }
}
