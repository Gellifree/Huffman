using System;
namespace Huffmann
{
    public class CharStringCouple
    {
        public CharStringCouple()
        {
            character = '0';
            stringData = "";
        }

        public CharStringCouple(char character, string stringData)
        {
            this.character = character;
            this.stringData = stringData;
        }

        public char character;
        public string stringData;
    }
}
