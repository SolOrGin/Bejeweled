using System;

public class Display
{
    public void DrawGrid(Grid grid)
    {
        Console.WriteLine();
        Console.WriteLine("  0 1 2 3 4 5 6 7");
        for (int row = 0; row < 8; row++)
        {
            Console.Write(row + " ");
            for (int col = 0; col < 8; col++)
            {
                char symbol = grid.GetGem(row, col).Type switch
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

    public void DrawScore(int score)
    {
        Console.WriteLine($"Score: {score}");
    }

    public void DrawMessage(string message)
    {
        Console.WriteLine(message);
    }
}
