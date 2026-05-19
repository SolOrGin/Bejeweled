using System;
using System.Collections.Generic;

public enum GameState
{
    Running,
    Paused,
    Gameover
}

public class GameController
{
    private Grid _grid = new Grid();
    private ScoreKeeper _scoreKeeper = new ScoreKeeper();
    private MoveValidator _validator = new MoveValidator();
    private GameState _state = GameState.Running;

    public void StartGame()
    {
        _grid.GenerateGrid();
        // Clear any matches present in the initial random board
        ProcessMatches();

        while (_state == GameState.Running)
        {
            DisplayGrid();
            Console.WriteLine($"Score: {_scoreKeeper.totalScore}");
            Console.WriteLine("Enter move (row1 col1 row2 col2) or 'q' to quit:");

            string input = Console.ReadLine() ?? "";
            if (input.Trim() == "q")
            {
                _state = GameState.Gameover;
                break;
            }

            string[] parts = input.Trim().Split(' ');
            if (parts.Length != 4)
            {
                Console.WriteLine("Invalid input — enter four numbers separated by spaces.");
                continue;
            }

            if (!int.TryParse(parts[0], out int r1) || !int.TryParse(parts[1], out int c1) ||
                !int.TryParse(parts[2], out int r2) || !int.TryParse(parts[3], out int c2))
            {
                Console.WriteLine("Invalid input — all four values must be integers.");
                continue;
            }

            if (!_validator.IsValidSwap(r1, c1, r2, c2))
            {
                Console.WriteLine("Invalid swap — gems must be adjacent (no diagonals).");
                continue;
            }

            _grid.SwapGems(r1, c1, r2, c2);
            List<Match> matches = _validator.FindMatches(_grid);

            if (matches.Count == 0)
            {
                _grid.SwapGems(r1, c1, r2, c2); // undo swap
                Console.WriteLine("No matches formed — swap undone.");
            }
            else
            {
                ProcessMatches();
            }
        }

        Console.WriteLine($"Game over! Final score: {_scoreKeeper.totalScore}");
    }

    // Remove matches, shift gems down, refill, and repeat until no matches remain
    private void ProcessMatches()
    {
        List<Match> matches = _validator.FindMatches(_grid);
        while (matches.Count > 0)
        {
            foreach (Match m in matches)
                _scoreKeeper.AddPoints(m.GetPoints());

            _grid.RemoveGems(matches);
            _grid.ShiftGemsDown();
            _grid.RefillTop();
            matches = _validator.FindMatches(_grid);
        }
    }

    private void DisplayGrid()
    {
        Console.WriteLine();
        Console.WriteLine("  0 1 2 3 4 5 6 7");
        for (int row = 0; row < 8; row++)
        {
            Console.Write(row + " ");
            for (int col = 0; col < 8; col++)
            {
                char symbol = _grid.GetGem(row, col).Type switch
                {
                    GemType.Red    => 'R',
                    GemType.Blue   => 'B',
                    GemType.Green  => 'G',
                    GemType.Yellow => 'Y',
                    _              => '.'
                };
                Console.Write(symbol + " ");
            }
            Console.WriteLine();
        }
        Console.WriteLine();
    }
}
