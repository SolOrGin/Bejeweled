using System;
using System.Collections.Generic;

public class MoveValidator
{
    // Two gems are adjacent if they differ by exactly 1 in row OR column (not diagonal)
    public bool IsValidSwap(int row1, int col1, int row2, int col2)
    {
        int rowDiff = Math.Abs(row1 - row2);
        int colDiff = Math.Abs(col1 - col2);
        return (rowDiff == 1 && colDiff == 0) || (rowDiff == 0 && colDiff == 1);
    }

    // Scan the grid for all horizontal and vertical runs of 3+ matching gems
    public List<Match> FindMatches(Grid grid)
    {
        List<Match> matches = new List<Match>();

        // Horizontal
        for (int row = 0; row < 8; row++)
        {
            int col = 0;
            while (col < 8)
            {
                GemType type = grid.GetGem(row, col).Type;
                if (type == GemType.Empty) { col++; continue; }

                List<Coordinate> coords = new List<Coordinate>();
                while (col < 8 && grid.GetGem(row, col).Type == type)
                {
                    coords.Add(new Coordinate(row, col));
                    col++;
                }
                if (coords.Count >= 3)
                    matches.Add(new Match(coords, type));
            }
        }

        // Vertical
        for (int col = 0; col < 8; col++)
        {
            int row = 0;
            while (row < 8)
            {
                GemType type = grid.GetGem(row, col).Type;
                if (type == GemType.Empty) { row++; continue; }

                List<Coordinate> coords = new List<Coordinate>();
                while (row < 8 && grid.GetGem(row, col).Type == type)
                {
                    coords.Add(new Coordinate(row, col));
                    row++;
                }
                if (coords.Count >= 3)
                    matches.Add(new Match(coords, type));
            }
        }

        return matches;
    }
}
