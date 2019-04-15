using System;
using System.Collections.Generic;

class MIME_TYPE
{
    const string unkown = "UNKNOWN"; const char dot = '.';
    static List<string> availableFileExtentions = new List<string>();
    static List<string> availableMIMES = new List<string>();
    static void Main(string[] args)
    {
        int N = int.Parse(Console.ReadLine()); // Number of elements which make up the association table.
        int Q = int.Parse(Console.ReadLine()); // Number of file names to be analyzed.
        // ------- Get all available file types ------- //
        for (int i = 0; i < N; i++)
        {
            string rawInput = Console.ReadLine();
            string[] inputs = rawInput.Split(' ');
            string EXT = inputs[0]; // file extension
            string MT = inputs[1]; // MIME type
            availableFileExtentions.Add(EXT.ToLower()); // Make sure to lower case all extentions for easy string comparison
            availableMIMES.Add(MT);
        }
        // ------- Get all file names and execute function "DetectAndPrintMIME_Type" ------- //
        for (int i = 0; i < Q; i++)
        {
            string FNAME = Console.ReadLine(); // One file name per line.
            DetectAndPrintMIME_Type(FNAME);
        }
    }

    static void DetectAndPrintMIME_Type(string fileName)
    {
        string[] file = fileName.Split(dot);
        if (file.Length > 1)
        {
            var indexOfMINE = availableFileExtentions.IndexOf(file[file.Length - 1].ToLower());
            if (indexOfMINE != -1)
            {
                Console.WriteLine(availableMIMES[indexOfMINE]);
                return;
            }
        }
        Console.WriteLine(unkown);
    }
}
// Write an action using Console.WriteLine()
// To debug: Console.Error.WriteLine("Debug messages...");