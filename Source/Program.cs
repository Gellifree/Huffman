using System;
using System.Collections.Generic;

namespace Huffmann
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            //int[] teszt = new int[5];

            //teszt[0] = 4;
            //teszt[1] = 0;
            //teszt[2] = 12;
            //teszt[3] = 1;
            //teszt[4] = 0;

            HuffmannCoding H = new HuffmannCoding();

            //Console.WriteLine("{0}. - {1}.",H.MinimumSearch(teszt).First, H.MinimumSearch(teszt).Second);
            List<CharStringCouple> Teszt = new List<CharStringCouple>();
            Console.WriteLine("Adjon meg egy kódolni kívánt szöveget: ");
            string teststring = Convert.ToString(Console.ReadLine());
            Teszt = H.EnCode(teststring);

            for (int i = 0; i < Teszt.Count; i++)
            {
                Console.WriteLine("{0}: {1}",Teszt[i].character,Teszt[i].stringData);
            }

        }
    }
}
