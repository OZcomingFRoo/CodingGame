using System;
using System.Text;
using System.Collections.Generic;

class ACSII_ART
{
    const string ALL_LETTERS = "ABCDEFGHIJKLMNOPQRSTUVWXYZ?";
    static List<List<string>> asciiLetters;
    static int height;
    static int width;

    static void Main(string[] args)
    {
        width = int.Parse(Console.ReadLine()); // Get width
        height = int.Parse(Console.ReadLine()); // Get height
        string input = Console.ReadLine().ToUpper(); // Get input and uppercase all lowercase letter
        GetLetterInASCII(); // Assing input to "asciiLetters"
        StringBuilder renderer = new StringBuilder();
        for (int heightIndex = 0; heightIndex < height; heightIndex++) // render each level.
        {
            renderer.Clear(); // Reset input
            for (int inputCharIndex = 0; inputCharIndex < input.Length; inputCharIndex++)
            {
                // Get character
                char letter = input[inputCharIndex];
                // Get cell's index from "asciiLetters" ("ALL_LETTERS" are the "keys" to fetch those indexes)
                int letterIndex = ALL_LETTERS.IndexOf(letter);
                // If no character was found , then letter index is considered "unknown" index (i.e. '?')
                if (letterIndex == -1) 
                { 
                    letterIndex = ALL_LETTERS.IndexOf('?');
                }
                renderer.Append(asciiLetters[heightIndex][letterIndex]);
            }
            renderer.AppendLine();
            Console.Write(renderer.ToString());
        }
    }
    /// <summary>
    /// Gets input from "CodingGames"
    /// Adds input to "asciiLetters"
    /// </summary>
    static void GetLetterInASCII()
    {
        asciiLetters = new List<List<string>>();
        for (int i = 0; i < height; i++)
        {
            string ROW = Console.ReadLine();
            asciiLetters.Add(SplitByWidth(ROW));
        }
    }

    /// <summary>
    /// Utility function to split a set of partial ASCII letters (all are from the same height index) to each cell
    /// </summary>
    static List<string> SplitByWidth(string row)
    {
        List<string> returnedObj = new List<string>();
        for (int i = 0; i < row.Length; i += width)
        {
            int index = i;
            StringBuilder SB = new StringBuilder();
            while (index < i + width)
            {
                SB.Append(row[index]);
                index++;
            }
            returnedObj.Add(SB.ToString());
        }
        return returnedObj;
    }
}
// Write an action using Console.WriteLine()
// To debug: Console.Error.WriteLine("Debug messages...");