using System;

class SoTK_EP1
{
    private class Location
    {
        public int Width { get; set; }
        public int Height { get; set; }
        public int minV { get; set; }
        public int minH { get; set; }
        public int X { get; set; }
        public int Y { get; set; }

        public Location(int x, int y)
        {
            X = x;
            Y = y;
            minH = 0;
            minV = 0;
        }

        public void NextStep(string direction)
        {
            string vertical = "UD", horizontal = "LR";
            foreach (char dir in direction)
            {
                if (vertical.Contains(dir))
                {
                    int current = Y, maxLength = Height, startIndex = minV;
                    BinarySearch(ref current, ref maxLength, ref startIndex, dir);
                    Y = current; Height = maxLength; minV = startIndex;
                }
                else if (horizontal.Contains(dir))
                {
                    int current = X, maxLength = Width, startIndex = minH;
                    BinarySearch(ref current, ref maxLength, ref startIndex, dir);
                    X = current; Width = maxLength; minH = startIndex;
                }
            };
        }

        private static void BinarySearch(ref int current, ref int maxLength, ref int startIndex, char direction)
        {
            if ("DR".Contains(direction)) // Get middle location between current - maxLength
            {
                startIndex = current;
                double distance = maxLength - startIndex;
                int steps = (int)Math.Ceiling(distance / 2);
                current = current + steps;
            }
            else // Get middle location between start/0 - current
            {
                maxLength = current;
                double distance = maxLength - startIndex;
                int steps = (int)Math.Ceiling(distance / 2);
                current = current - steps;
            }
        }

        public override string ToString()
        {
            return string.Format("{0} {1}", X, Y);
        }
    }

    static void Main(string[] args)
    {
        string[] inputs;
        inputs = Console.ReadLine().Split(' ');
        int width = int.Parse(inputs[0]); // width of the building.
        int height = int.Parse(inputs[1]); // height of the building.
        int turns = int.Parse(Console.ReadLine()); // maximum number of turns before game over.
        inputs = Console.ReadLine().Split(' ');
        // Starting position of batman
        int X0 = int.Parse(inputs[0]);
        int Y0 = int.Parse(inputs[1]);
        Location batman = new Location(X0, Y0) { Height = height, Width = width };
        // ================================= GAME LOOP  ================================= //
        while (true)
        {
            // the direction (U, UR, R, DR, D, DL, L or UL)
            string bombDir = Console.ReadLine();
            batman.NextStep(bombDir);
            // the location of the next window Batman should jump to.
            Console.WriteLine(batman.ToString());
        }
    }

}
// Write an action using Console.WriteLine()
// To debug: Console.Error.WriteLine("Debug messages...");