using System;
using System.Collections.Generic;

public class Grid
{
    private Gem[,] _board = new Gem[8, 8];
    private int _rows = 8;
    private int _cols = 8;
    private Random _random = new Random();

    public void GenerateGrid()
    {
        for (int row = 0; row < _rows; row++)
        {
            for (int col = 0; col < _cols; col++)
            {
                int randomType = _random.Next(1, 5);
                _board[row, col] = new Gem((GemType)randomType);
            }
        }
    }

    public void SwapGems(int row1, int col1, int row2, int col2)
    {
        Gem temp = _board[row1, col1];
        _board[row1, col1] = _board[row2, col2];
        _board[row2, col2] = temp;
    }

    public Gem GetGem(int row, int col)
    {
        if (row >= 0 && row < _rows && col >= 0 && col < _cols)
        {
            return _board[row, col];
        }
        return new Gem();
    }

    public bool IsLocationEmpty(int row, int col)
    {
        return GetGem(row, col).IsGemEmpty();
    }

    public void ShiftGemsDown()
    {
        for (int i = 0; i < _rows - 1; i++)
        {
            for (int col = 0; col < _cols; col++)
            {
                for (int row = _rows - 1; row > 0; row--)
                {
                    if (_board[row, col].IsGemEmpty() && !_board[row - 1, col].IsGemEmpty())
                    {
                        SwapGems(row, col, row - 1, col);
                    }
                }
            }
        }
    }

    public void RemoveGems(List<Match> matches)
    {
        foreach (Match match in matches)
        {
            List<Coordinate> coordsToClear = match.GetCoords();
            foreach (Coordinate coord in coordsToClear)
            {
                _board[coord.Row, coord.Col].Type = GemType.Empty;
            }
        }
    }

    public void RefillTop()
    {
        for (int col = 0; col < _cols; col++)
        {
            for (int row = 0; row < _rows; row++)
            {
                if (_board[row, col].IsGemEmpty())
                {
                    int randomType = _random.Next(1, 5);
                    _board[row, col] = new Gem((GemType)randomType);
                }
                else
                {
                    break;
                }
            }
        }
    }
}