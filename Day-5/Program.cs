Part1();
Part2();

static bool InRange(long value, long min, long max) => value >= min && value <= max;
static long TranslateRange(List<(long destination, long source, long length)> ranges, long value)
{
    foreach (var range in ranges)
    {
        if (InRange(value, range.source, range.source + range.length))
        {
            long offset = value - range.source;
            return range.destination + offset;
        }
    }

    return value;
}

static void Part1()
{
    using StreamReader reader = new("..\\..\\..\\input.txt");

    string? line = reader.ReadLine();

    if (line == null) return;

    string seeds = line[7..];

    List<long> seedList = [];

    foreach (string seed in seeds.Split(' '))
        seedList.Add(Convert.ToInt64(seed));

    line = reader.ReadLine();

    while (line != null)
    {
        line = reader.ReadLine();
        line = reader.ReadLine();

        List<(long destination, long source, long length)> translations = [];

        while (line != "\n" && !string.IsNullOrEmpty(line))
        {
            string[] numbers = line.Split(' ');
            translations.Add((Convert.ToInt64(numbers[0]), Convert.ToInt64(numbers[1]), Convert.ToInt64(numbers[2])));

            line = reader.ReadLine();
        }

        for (int i = 0; i < seedList.Count; i++)
            seedList[i] = TranslateRange(translations, seedList[i]);
    }

    Console.WriteLine($"Summa 1: {seedList.Min()}");
}

static (long seed, long length) TranslateRange2(List<(long destination, long source, long length)> ranges, (long seed, long length) value)
{
    foreach (var range in ranges)
    {
        if (InRange(value.seed, range.source, range.source + range.length))
            return (value.seed - range.source + range.destination, range.source + range.length - value.seed);
        else if (InRange(range.source, value.seed, value.seed + value.length))
            return (range.destination, value.seed + value.length - range.source);
    }

    return value;
}

static void Part2()
{
    using StreamReader reader = new("..\\..\\..\\input.txt");

    string? line = reader.ReadLine();

    if (line == null) return;

    string seeds = line[7..];

    List<(long seed, long length)> seedList = [];

    long temp = 0;

    foreach (string seed in seeds.Split(' '))
    {
        if (temp == 0)
            temp = Convert.ToInt64(seed);
        else
        {
            seedList.Add((temp, Convert.ToInt64(seed)));
            temp = 0;
        }
    }

    line = reader.ReadLine();

    while (line != null)
    {
        line = reader.ReadLine();
        line = reader.ReadLine();

        List<(long destination, long source, long length)> translations = [];

        while (line != "\n" && !string.IsNullOrEmpty(line))
        {
            string[] numbers = line.Split(' ');
            translations.Add((Convert.ToInt64(numbers[0]), Convert.ToInt64(numbers[1]), Convert.ToInt64(numbers[2])));

            line = reader.ReadLine();
        }

        for (int i = 0; i < seedList.Count; i++)
            seedList[i] = TranslateRange2(translations, seedList[i]);
    }

    Console.WriteLine($"Seed 2: {seedList.Min().seed}");
}