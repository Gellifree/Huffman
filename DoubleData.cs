using System;
namespace Huffmann
{
    public class DoubleData
    {
        public DoubleData()
        {
            First = 0;
            Second = 0;
        }

        public DoubleData(int First, int Second)
        {
            this.First = First;
            this.Second = Second;
        }

        public int First;
        public int Second;
    }
}
