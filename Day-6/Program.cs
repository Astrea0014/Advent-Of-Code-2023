Part1();
Part2();

static void Part1()
{
    int sum = 1;

    using StreamReader reader = new("..\\..\\..\\input.txt");

    string? timeString = reader.ReadLine();
    string? distanceString = reader.ReadLine();

    if (timeString == null || distanceString == null) return;

    List<int> times = [];

    int x = 0;
    foreach (string timeSplit in timeString.Split(' '))
        if (int.TryParse(timeSplit, out x))
            times.Add(x);

    List<int> distances = [];

    foreach (string distanceSplit in distanceString.Split(' '))
        if (int.TryParse(distanceSplit, out x))
            distances.Add(x);

    foreach ((int time, int distance) in times.Zip(distances))
    {
        int count = 0;

        for (int i = 0; i < time; i++)
        {
            // i = mm/ms

            if (i * (time - i) > distance)
                count++;
        }

        if (count > 0)
            sum *= count;
    }

    Console.WriteLine($"Summa 1: {sum}");
}

static void Part2()
{
    long sum = 0;

    using StreamReader reader = new("..\\..\\..\\input.txt");

    string? timeString = reader.ReadLine();
    string? distanceString = reader.ReadLine();

    if (timeString == null || distanceString == null) return;

    long time = Convert.ToInt64(timeString.Remove(0, 11).Replace(" ", ""));
    long distance = Convert.ToInt64(distanceString.Remove(0, 11).Replace(" ", ""));

    for (int i = 0; i < time; i++)
    {
        // i = mm/ms

        if (i * (time - i) > distance)
            sum++;
    }

    Console.WriteLine($"Summa 2: {sum}");
}