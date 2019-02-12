using System;
using System.Collections.Generic;

class ThereIsNoSpoon
{
    static void Main(string[] args)
    {
        // Get width and height data
        int width = int.Parse(Console.ReadLine()); // the number of cells on the X axis
        int height = int.Parse(Console.ReadLine()); // the number of cells on the Y axis
        Grid grid = new Grid(width, height); // Init Grid
        for (int i = 0; i < height; i++)
        {
            string line = Console.ReadLine();
            grid.AddLine(line);
        } // Get Nodes and insert to Grid
        grid.Print(); // Print all power nodes' coordinates
    }
}

public class Grid
{
    private const string EMPTY_CELL = "-1 -1";
    private List<string> grid;
    private readonly int _width;
    private readonly int _height;
    public Grid(int width, int height)
    {
        this._width = width;
        this._height = height;
        this.grid = new List<string>();
    }

    public void AddLine(string line)
    {
        this.grid.Add(line);
    }

    private string GetPowerNode(int x, int y)
    {
        if (x >= _width || y >= _height)
        {
            return EMPTY_CELL;
        }
        else
        {
            char cell = this.grid[y][x];
            return cell == '.' ? EMPTY_CELL : string.Format("{0} {1}", x, y);
        }
    }

    private string GetRightNeighbor(int x2, int y2)
    {
        if (x2 > _width)
        {
            return EMPTY_CELL;
        }
        else
        {
            string currentCell = GetPowerNode(x2, y2);
            return currentCell == EMPTY_CELL ? GetRightNeighbor(x2 + 1, y2) : currentCell;
        }
    }

    private string GetBottomNeighbor(int x3, int y3)
    {
        if (y3 > _height)
        {
            return EMPTY_CELL;
        }
        else
        {
            string currentCell = GetPowerNode(x3, y3);
            return currentCell == EMPTY_CELL ? GetBottomNeighbor(x3, y3 + 1) : currentCell;
        }
    }

    private void PrintCell(int x1, int y1)
    {
        string node = GetPowerNode(x1, y1); // => x1, y1
        if (node != EMPTY_CELL)
        {
            string rightNeighbor = GetRightNeighbor(x1 + 1, y1); // => x2, y2
            string bottomNeighbor = GetBottomNeighbor(x1, y1 + 1); // => x3, y3
            Console.WriteLine("{0} {1} {2}", node, rightNeighbor, bottomNeighbor);
        }
    }

    public void Print()
    {
        for (int hIndex = 0; hIndex < _height; hIndex++)
        {
            for (int wIndex = 0; wIndex < _width; wIndex++)
            {
                PrintCell(wIndex, hIndex);
            }
        }
    }
}