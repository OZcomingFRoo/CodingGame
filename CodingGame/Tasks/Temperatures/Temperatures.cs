using System;

class Temperatures
{
    static void Main(string[] args)
    {
        int result = int.MaxValue;
        int resultDistance = int.MaxValue;
        int n = int.Parse(Console.ReadLine()); // the number of temperatures to analyse
        string[] inputs = Console.ReadLine().Split(' ');
        for (int i = 0; i < n; i++)
        {
            int t = int.Parse(inputs[i]); // a temperature expressed as an integer ranging from -273 to 5526
            int tDistnace = DistanceFrom0(t);
            if (tDistnace < resultDistance)
            {
                result = t;
                resultDistance = tDistnace;

            }
            else if (tDistnace == resultDistance)
            {
                result = Math.Max(t, result);
            }
        }

        // Write an action using Console.WriteLine()
        // To debug: Console.Error.WriteLine("Debug messages...");
        Console.WriteLine(result == int.MaxValue ? 0 : result);
    }
    static int DistanceFrom0(int num)
    {
        return num < 0 ? (-1 * num) : num;
    }
}

