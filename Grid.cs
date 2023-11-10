using ThiefAndPolice;

public class Grid
{
    public int X { get; set; }
    public int Y { get; set; }
    

    public static void Print(int x, int y, Person[,]matrix)
    {
        for (int i = 0; i < y + 2; i++) //print top line
        {
            Console.Write("-");
        }
        Console.WriteLine();

        for (int row = 0; row < x; row++) //loop x
        {
            Console.Write("#"); // Left border

            for (int col = 0; col < y; col++) //loop y
            {
                if (matrix[row, col] == null)
                {
                    Console.Write(" ");
                }
                else if (matrix[row, col] is Thief)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("T");
                    Console.ResetColor();
                }
                else if (matrix[row, col] is Police)
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write("P");
                    Console.ResetColor();
                }
                else if (matrix[row, col] is Citizen) //comment
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("C");
                    Console.ResetColor();
                }

            }
            Console.WriteLine("#"); // Right border
        }

        for (int i = 0; i < y + 2; i++)
        {
            Console.Write("-");
        }
        Console.WriteLine();

    }



}