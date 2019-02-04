using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;


/**
 * Auto-generated code below aims at helping you parse
 * the standard input according to the problem statement.
 **/
class ACSII_ART
{
    static int L;
    static int H;
    const string ALL_LETTERS = "ABCDEFGHIJKLMNOPQRSTUVWXYZ?";
    static List<List<string>> coll;

    static void Main(string[] args)
    {
        L = int.Parse(Console.ReadLine());
        H = int.Parse(Console.ReadLine());
        string T = Console.ReadLine().ToUpper();
        GetLetterInASCII();
        for (int heightIndex = 0; heightIndex < H; heightIndex++)
        {
            StringBuilder SB = new StringBuilder();
            for (int tIndex = 0; tIndex < T.Length; tIndex++)
            {
                char letter = T[tIndex];
                int letterIndex = ALL_LETTERS.IndexOf(letter);
                if (letterIndex == -1)
                {
                    letterIndex = ALL_LETTERS.IndexOf('?');
                }
                SB.Append(coll[heightIndex][letterIndex]);
            }
            SB.AppendLine();
            Console.Write(SB.ToString());
        }
    }
    static void GetLetterInASCII()
    {
        coll = new List<List<string>>();
        for (int i = 0; i < H; i++)
        {
            string ROW = Console.ReadLine();
            coll.Add(SplitLol(ROW));
        }
    }

    static List<string> SplitLol(string s)
    {
        List<string> returnedObj = new List<string>();
        for (int i = 0; i < s.Length; i += L)
        {
            int index = i;
            StringBuilder SB = new StringBuilder();
            while (index < i + L)
            {
                SB.Append(s[index]);
                index++;
            }
            returnedObj.Add(SB.ToString());
        }
        return returnedObj;
    }
}
// Write an action using Console.WriteLine()
// To debug: Console.Error.WriteLine("Debug messages...");