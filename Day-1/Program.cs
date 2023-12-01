Part1();
Part2();

static void Part1()
{
    int sum = 0;

    using StreamReader reader = new("..\\..\\..\\input.txt");

    string? line = reader.ReadLine();

    while (line != null)
    {
        List<char> numbers = [];

        foreach (char c in line)
            if (char.IsDigit(c))
                numbers.Add(c);

        sum += Convert.ToInt32("" + numbers.First() + numbers.Last());

        line = reader.ReadLine();
    }

    Console.WriteLine($"Summa 1: {sum}");
}

static void Part2()
{
    string[] textNumbers = ["one", "two", "three", "four", "five", "six", "seven", "eight", "nine"];
    char[] charNumbers = ['1', '2', '3', '4', '5', '6', '7', '8', '9'];

    int sum = 0;

    using StreamReader reader = new("..\\..\\..\\input.txt");

    string? line = reader.ReadLine();

    while (line != null)
    {
        List<(char, int)> numbers = [];

        for (int i = 0; i < textNumbers.Length; i++)
        {
            numbers.Add((charNumbers[i], line.IndexOf(textNumbers[i])));
            numbers.Add((charNumbers[i], line.LastIndexOf(textNumbers[i])));
        }

        for (int i = 0; i < line.Length; i++)
            if (char.IsDigit(line[i]))
                numbers.Add((line[i], i));

        numbers.RemoveAll((item) => item.Item2 == -1);
        numbers.Sort(((char, int) x, (char, int) y) => x.Item2 - y.Item2);

        sum += Convert.ToInt32("" + numbers.First().Item1 + numbers.Last().Item1);

        line = reader.ReadLine();
    }

    Console.WriteLine($"Summa 2: {sum}");
}