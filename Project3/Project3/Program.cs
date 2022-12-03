
using System.Diagnostics.Metrics;

int prioritySum1 = 0;
int ii = 0;
int prioritySum2 = 0;

string[] lines = File.ReadAllLines("file.txt");

foreach (string line in lines)
{
    string left = line.Substring(0, line.Length / 2);
    string right = line.Substring(line.Length / 2);

    foreach (char letterLeft in left)
    {
        if (right.Contains(letterLeft))
        {
            if (letterLeft.ToString() == letterLeft.ToString().ToLower())
            {
                prioritySum1 += Convert.ToInt32(letterLeft) - 96;
            }
            else if (letterLeft.ToString() == letterLeft.ToString().ToUpper())
            {
                prioritySum1 += Convert.ToInt32(letterLeft) - 38;
            }
            break;
        }
    }


}

while (ii < lines.Length)
{
    string bag1 = lines[ii];
    string bag2 = lines[ii + 1];
    string bag3 = lines[ii + 2];

    foreach (char letter in bag1)
    {
        if (bag2.Contains(letter) && bag3.Contains(letter))
        {
            if (letter.ToString() == letter.ToString().ToLower())
            {
                prioritySum2 += Convert.ToInt32(letter) - 96;
            }
            else if (letter.ToString() == letter.ToString().ToUpper())
            {
                prioritySum2 += Convert.ToInt32(letter) - 38;
            }
            ii += 3;
            break;
        }
    }
}

Console.WriteLine(prioritySum1);
Console.WriteLine(prioritySum2);
//Console.WriteLine($"a=1 {Convert.ToInt32('z')}");

////Console.WriteLine($"a=1 {Convert.ToInt32('b') - 96}");

////Console.WriteLine($"a=1 {Convert.ToInt32('z') - 96}");

//Console.WriteLine($"a=1 {Convert.ToInt32('A') - 38}");

//Console.WriteLine($"a=1 {Convert.ToInt32('B') - 38}");

//Console.WriteLine($"a=1 {Convert.ToInt32('Z') - 38}");


