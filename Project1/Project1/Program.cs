
class Program
{
    static int Main(string[] args)
    {
        List<int> maxes = new List<int>();
        int sum = 0;

        foreach (string line in File.ReadLines("file.txt"))
        {

            if (line == "")
            {
                maxes.Add(sum);
                sum = 0;
            }
            else
            {
                sum += Convert.ToInt32(line);
            }
        }

        sum = 0;
        maxes.Sort();

        for (int i = 1; i <= 3; i++)
        {
            Console.WriteLine($"{i} Miejsce: {maxes[maxes.Count - i]}");
            sum += maxes[maxes.Count - i];
        }

        Console.WriteLine($"SUMA: {sum}");

        return 0;
    }
}