using System;
namespace Huffmann
{
    public class CharIntCouple
    {
        public CharIntCouple()
        {
            Character = '0';
            Number = 0;
        }

        public CharIntCouple(char Character, int Number)
        {
            this.Character = Character;
            this.Number = Number;
        }

        public char Character;
        public int Number;
    }
}
