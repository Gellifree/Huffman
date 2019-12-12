using System;
using System.Collections.Generic;

namespace Huffmann
{
    public class HuffmannCoding
    {
        private DoubleData MinimumSearchInComplexDataFrame(List<StringIntCouple> complexData)
        {
            DoubleData result = new DoubleData();

            List<int> convertedNumbers = new List<int>();
            for (int i = 0; i < complexData.Count; i++)
            {
                convertedNumbers.Add(complexData[i].numbers);
            }

            result = MinimumSearch(convertedNumbers);

            return result;
        }

        public DoubleData MinimumSearch(List<int> data)
        {
            DoubleData result = new DoubleData();
            int[] marks = new int[data.Count];
            for (int i = 0; i < marks.Length; i++)
            {
                marks[i] = 0;
            }

            int min = int.MaxValue;
            int minPos = 0;



            for (int i = 0; i < data.Count; i++)
            {
                if (marks[i] == 0 && data[i] <= min)
                {
                    min = data[i];
                    minPos = i;
                }
            }

            marks[minPos] = 1;
            result.First = minPos;

            min = int.MaxValue;
            minPos = 0;

            for (int i = 0; i < data.Count; i++)
            {
                if ((marks[i] == 0) && (data[i] <= min))
                {
                    min = data[i];
                    minPos = i;
                }
            }

            marks[minPos] = 1;
            result.Second = minPos;
            return result;
        }

        private bool IsThere(List<char> data, char searched)
        {
            bool result = false;

            for (int i = 0; i < data.Count; i++)
            {
                if (data[i] == searched)
                {
                    result = true;
                    return result; //Kicsit hatekonyabb
                }
            }
            return result;
        }

        private int SearchCharacterPosition(List<char> data, char searched)
        {
            int result = 0;

            for (int i = 0; i < data.Count; i++)
            {
                if(data[i] == searched)
                {
                    result = i;
                }
            }

            return result;
        }

        private int SearchInCharStringList(List<CharStringCouple> data, char searched)
        {
            int result = 0;

            List<char> convertedData = new List<char>();
            for (int i = 0; i < data.Count; i++)
            {
                convertedData.Add(data[i].character);
            }

            result = SearchCharacterPosition(convertedData, searched);

            return result;
        }

        public List<CharIntCouple> RawInput(string rawData)
        {
            List<CharIntCouple> result = new List<CharIntCouple>();

            List<char> characters = new List<char>();
            List<int> numbers = new List<int>();

            for (int i = 0; i < rawData.Length; i++)
            {
                if (IsThere(characters,rawData[i]) == true)
                {
                    numbers[SearchCharacterPosition(characters, rawData[i])] += 1;
                } 
                else
                {
                    characters.Add(rawData[i]);
                    numbers.Add(1);
                }
            }

            for (int i = 0; i < characters.Count; i++)
            {
                result.Add(new CharIntCouple(characters[i], numbers[i]));
            }
            return result;
        }

        private string ReadBacwards(string input)
        {
            string result = "";

            for (int i = input.Length-1; i >= 0; i--)
            {
                result += input[i];
            }
            return result;
        }

        public List<CharStringCouple> EnCode(string rawData)
        {
            List<CharStringCouple> result = new List<CharStringCouple>();

            List<CharIntCouple> data = RawInput(rawData);

            for (int i = 0; i < data.Count; i++)
            {
                result.Add(new CharStringCouple(data[i].Character,""));
            }

            List<StringIntCouple> calculations = new List<StringIntCouple>();

            for (int i = 0; i < data.Count; i++)
            {
                calculations.Add(new StringIntCouple(Convert.ToString(data[i].Character),data[i].Number));
            }


            while (calculations.Count > 1)
            {
                DoubleData minimumPlace = MinimumSearchInComplexDataFrame(calculations);
                calculations.Add(new StringIntCouple(calculations[minimumPlace.First].combinedChars + calculations[minimumPlace.Second].combinedChars, calculations[minimumPlace.First].numbers + calculations[minimumPlace.Second].numbers));

                if(calculations[minimumPlace.First].numbers > calculations[minimumPlace.Second].numbers)
                {
                    for (int i = 0; i < calculations[minimumPlace.First].combinedChars.Length; i++) // Nem biztos hogy megfelel a huffman elveknek a 0-1 adása - kisebb nagyobb
                    {
                        result[SearchInCharStringList(result, calculations[minimumPlace.First].combinedChars[i])].stringData += "1";
                    }
                    for (int i = 0; i < calculations[minimumPlace.Second].combinedChars.Length; i++)
                    {
                        result[SearchInCharStringList(result, calculations[minimumPlace.Second].combinedChars[i])].stringData += "0";
                    }
                }
                else
                {
                    for (int i = 0; i < calculations[minimumPlace.First].combinedChars.Length; i++) // Nem biztos hogy megfelel a huffman elveknek a 0-1 adása - kisebb nagyobb
                    {
                        result[SearchInCharStringList(result, calculations[minimumPlace.First].combinedChars[i])].stringData += "0";
                    }
                    for (int i = 0; i < calculations[minimumPlace.Second].combinedChars.Length; i++)
                    {
                        result[SearchInCharStringList(result, calculations[minimumPlace.Second].combinedChars[i])].stringData += "1";
                    }
                }

                if (minimumPlace.First > minimumPlace.Second) // making sure u are not indexing wrong
                {
                    calculations.RemoveAt(minimumPlace.First);
                    calculations.RemoveAt(minimumPlace.Second);
                }
                else
                {
                    calculations.RemoveAt(minimumPlace.Second);
                    calculations.RemoveAt(minimumPlace.First);
                }
            }

            for (int i = 0; i < result.Count; i++)
            {
                result[i].stringData = ReadBacwards(result[i].stringData);
            }

            return result;
        }
    }
}
