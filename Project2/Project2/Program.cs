class Program
{
    static int Main(string[] args)
    {
        int points = 0;
        Console.WriteLine("Which part to solve 1|2");
        int part = Convert.ToInt32(Console.ReadLine());

        foreach (string line in File.ReadLines("file.txt"))
        {
            if (part == 1)
            {
                points += SolvePartOne(line);
            }
            else
            {
                points += SolvePartTwo(line);
            }
        }
        Console.WriteLine(points);
        return 0;
    }

    static int SolvePartOne(string line)
    {
        //A-   rock   -X
        //B-   paper  -Y
        //C- scissors -Z
        int points = 0;

        switch (line[2])
        {
            case 'X':
                points += 1;
                break;
            case 'Y':
                points += 2;
                break;
            case 'Z':
                points += 3;
                break;
        }
        switch ((line[2] - line[0]) % 3)
        {
            case 0:
                points += 6;
                break;
            case 1:
                points += 0;
                break;
            case 2:
                points += 3;
                break;
        }
        return points;
    }
    private static int SolvePartTwo(string line)
    {
        int points = 0;

        //A- rock
        //B- paper
        //C- scissors

        //X- lose
        //Y- draw
        //Z- win

        switch (line)
        {
            case "A X":
                points += 3 + 0;
                break;
            case "A Y":
                points += 1 + 3;
                break;
            case "A Z":
                points += 2 + 6;
                break;

            case "B X":
                points += 1 + 0;
                break;
            case "B Y":
                points += 2 + 3;
                break;
            case "B Z":
                points += 3 + 6;
                break;

            case "C X":
                points += 2 + 0;
                break;
            case "C Y":
                points += 3 + 3;
                break;
            case "C Z":
                points += 1 + 6;
                break;
        }

        return points;
    }
}