using System;
namespace Huffmann
{
    public class StringIntCouple
    {
        public StringIntCouple()
        {
            combinedChars = "";
            numbers = 0;
        }

        public StringIntCouple(string combinedChars,int numbers)
        {
            this.combinedChars = combinedChars;
            this.numbers = numbers; 
        }

        public string combinedChars;
        public int numbers;
    }
}
