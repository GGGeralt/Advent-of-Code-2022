
int num = 0;
int overlaps = 0;

foreach (string line in File.ReadLines("file.txt"))
{
    string first = line.Substring(0, line.IndexOf(','));
    string second = line.Substring(line.IndexOf(',') + 1);

    int firstLeft = Convert.ToInt16(first.Substring(0, first.IndexOf('-')));
    int firstRight = Convert.ToInt16(first.Substring(first.IndexOf('-') + 1));
    int secondLeft = Convert.ToInt16(second.Substring(0, second.IndexOf('-')));
    int secondRight = Convert.ToInt16(second.Substring(second.IndexOf('-') + 1));

    //Console.WriteLine(firstLeft + "-----" + firstRight);
    //Console.WriteLine(secondLeft + "-----" + secondRight);

    if (firstLeft <= secondLeft && firstRight >= secondRight)
    {
        num++;
        //Console.WriteLine($"first {first[0]} is smaller than {second[0]}");
        //Console.WriteLine($"first {first[2]} is bigger/equal than {second[2]}");
    }
    else if (secondLeft <= firstLeft && secondRight >= firstRight)
    {
        num++;
        //Console.WriteLine($"first {second[0]} is smaller than {first[0]}");
        //Console.WriteLine($"first {second[2]} is bigger/equal than {first[2]}");
    }


    if ((firstLeft <= secondRight && secondLeft <= firstRight) || (secondRight <= firstLeft && firstRight <= secondLeft))
    {
        overlaps++;
        //Console.WriteLine($"first {first[0]} is smaller than {second[0]}");
        //Console.WriteLine($"first {first[2]} is bigger/equal than {second[2]}");
    }
}

Console.WriteLine(num);
Console.WriteLine(overlaps);