Part1();
Part2();

static bool InRange(int number, int min, int max) => number >= min && number <= max;
static void Part1()
{
    int sum = 0;

    List<(int line, int index)> symbols = [];
    List<(int line, int index, int number, int length)> numbers = [];

    using StreamReader reader = new("..\\..\\..\\input.txt");

    string? line = reader.ReadLine();

    for (int i = 1; line != null; i++)
    {
        for (int j = 0; j < line.Length; j++)
        {
            if (line[j] != '.')
            {
                if (char.IsDigit(line[j]))
                {
                    int relativeEndIndex = -1;
                    for (int k = 0; k < line.Length - j; k++)
                        if (!char.IsDigit(line[j + k]))
                        {
                            relativeEndIndex = k;
                            break;
                        }

                    string sub = string.Empty;
                    if (relativeEndIndex > 0)
                        sub = line.Substring(j, relativeEndIndex);
                    else
                        sub = line.Substring(j);

                    numbers.Add((i, j, Convert.ToInt32(sub), sub.Length));

                    j += sub.Length - 1;
                }
                else
                {
                    symbols.Add((i, j));
                }
            }
        }

        line = reader.ReadLine();
    }

    foreach ((int line, int index, int number, int length) number in numbers)
    {
        foreach ((int line, int index) symbol in symbols)
        {
            if (InRange(symbol.line, number.line - 1, number.line + 1) &&
                InRange(symbol.index, number.index - 1, number.index + number.length))
                sum += number.number;
        }
    }

    Console.WriteLine($"Summa 1: {sum}");
}

static void Part2()
{
    int sum = 0;

    List<(int line, int index)> symbols = [];
    List<(int line, int index, int number, int length)> numbers = [];

    using StreamReader reader = new("..\\..\\..\\input.txt");

    string? line = reader.ReadLine();

    for (int i = 1; line != null; i++)
    {
        for (int j = 0; j < line.Length; j++)
        {
            if (line[j] != '.')
            {
                if (char.IsDigit(line[j]))
                {
                    int relativeEndIndex = -1;
                    for (int k = 0; k < line.Length - j; k++)
                        if (!char.IsDigit(line[j + k]))
                        {
                            relativeEndIndex = k;
                            break;
                        }

                    string sub = string.Empty;
                    if (relativeEndIndex > 0)
                        sub = line.Substring(j, relativeEndIndex);
                    else
                        sub = line.Substring(j);

                    numbers.Add((i, j, Convert.ToInt32(sub), sub.Length));

                    j += sub.Length - 1;
                }
                else if (line[j] == '*')
                {
                    symbols.Add((i, j));
                }
            }
        }

        line = reader.ReadLine();
    }

    foreach ((int line, int index) gear in symbols)
    {
        List<int> gears = [];
        foreach ((int line, int index, int number, int length) number in numbers)
        {
            int numberLastIndex = number.index + number.length - 1;

            if (InRange(number.line, gear.line - 1, gear.line + 1) &&
                (InRange(number.index, gear.index - 1, gear.index + 1) || InRange(numberLastIndex, gear.index - 1, gear.index + 1)))
                gears.Add(number.number);
        }

        
        if (gears.Count == 2)
            sum += gears.First() * gears.Last();
                
    }

    Console.WriteLine($"Summa 2: {sum}");
}