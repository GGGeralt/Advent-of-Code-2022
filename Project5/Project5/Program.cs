
using System;
using System.Diagnostics.Metrics;
using System.Reflection.Metadata;
using System.Text.RegularExpressions;

string fileName = "file.txt";

Console.WriteLine("Which part: 1|2");
int part = Convert.ToInt32(Console.ReadLine());

string[] lines = File.ReadAllLines(fileName);


int emptyLineIndex = FindEmptyLineIndex();

//generating empty stacks with enough room
int numberOfStacks = Convert.ToInt32(Regex.Replace(lines[emptyLineIndex - 1], @"\s+", " ").Trim().Split(' ').Last());

Stack<char>[] stacks = new Stack<char>[numberOfStacks];
int stackSize = numberOfStacks * (emptyLineIndex - 1);

for (int j = 0; j < numberOfStacks; j++)
{
    stacks[j] = new Stack<char>(stackSize);
}

for (int i = emptyLineIndex - 2; i >= 0; i--)
{
    for (int j = 0; j < numberOfStacks; j++)
    {
        if (lines[i][1 + j * 4] != ' ')
        {
            stacks[j].Push(lines[i][1 + j * 4]);
        }
    }
}

// wypisz stack
WriteOutAllStacks(stacks);

for (int i = emptyLineIndex + 1; i < lines.Length; i++)
{
    int moves = Convert.ToInt32(Regex.Replace(lines[i], @"\s+", " ").Trim().Split(' ')[1]);
    int fromIndex = Convert.ToInt32(Regex.Replace(lines[i], @"\s+", " ").Trim().Split(' ')[3]) - 1;
    int toIndex = Convert.ToInt32(Regex.Replace(lines[i], @"\s+", " ").Trim().Split(' ').Last()) - 1;

    Stack<char> tmp = new Stack<char>(stackSize);


    for (int j = 0; j < moves; j++)
    {
        if (part == 1)
        {
            stacks[toIndex].Push(stacks[fromIndex].Pop());

        }
        else if (part == 2)
        {
            tmp.Push(stacks[fromIndex].Pop());
        }
    }


    while (tmp.Count != 0)
    {
        WriteOutStack(tmp);
        stacks[toIndex].Push(tmp.Pop());
    }
}

WriteOutAllStacks(stacks);
WriteOutFinal(stacks);


void WriteOutAllStacks(Stack<char>[] stacks)
{
    for (int i = 0; i < stacks.Count(); i++)
    {
        WriteOutStack(stacks[i]);
    }
    Console.WriteLine();
}

void WriteOutStack(Stack<char> stack)
{
    foreach (char letter in stack)
    {
        Console.Write(letter);
    }
    Console.WriteLine();
}

void WriteOutFinal(Stack<char>[] stacks)
{
    foreach (Stack<char> stack in stacks)
    {
        if (stack.Count != 0)
        {
            Console.Write(stack.Pop());
        }
    }
}

int FindEmptyLineIndex()
{
    int index = 0;
    foreach (string line in lines)
    {
        if (line == string.Empty)
        {
            break;
        }
        index++;
    }
    return index;
}
