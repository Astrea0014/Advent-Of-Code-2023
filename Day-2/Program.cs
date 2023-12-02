Part1();
Part2();

static void Part1()
{
    int sum = 0;

    using StreamReader reader = new("..\\..\\..\\input.txt");

    string? line = reader.ReadLine();

    while (line != null)
    {
        bool found = false;

        int gameNumber = Convert.ToInt32(line.Substring(5, line.IndexOf(':') - 5));
        line = line.Remove(0, line.IndexOf(":") + 2);

        string[] sequences = line.Split("; ");

        foreach (string sequence in sequences)
        {
            string[] splitSequence = sequence.Split(", ");

            foreach (string split in splitSequence)
            {
                string[] dividedSplit = split.Split(' ');

                switch (dividedSplit[1])
                {
                    case "red":
                        if (Convert.ToInt32(dividedSplit[0]) > 12)
                            found = true;
                        break;
                    case "green":
                        if (Convert.ToInt32(dividedSplit[0]) > 13)
                            found = true;
                        break;
                    case "blue":
                        if (Convert.ToInt32(dividedSplit[0]) > 14)
                            found = true;
                        break;
                }

                if (found) break;
            }

            if (found) break;
        }

        if (!found)
            sum += gameNumber;

        line = reader.ReadLine();
    }

    Console.WriteLine($"Summa 1: {sum}");
}

static void Part2()
{
    int sum = 0;

    using StreamReader reader = new("..\\..\\..\\input.txt");

    string? line = reader.ReadLine();

    while (line != null)
    {
        List<int> redCount = [];
        List<int> greenCount = [];
        List<int> blueCount = [];

        line = line.Remove(0, line.IndexOf(":") + 2);

        string[] sequences = line.Split("; ");

        foreach (string sequence in sequences)
        {
            string[] splitSequence = sequence.Split(", ");

            foreach (string split in splitSequence)
            {
                string[] dividedSplit = split.Split(' ');

                switch (dividedSplit[1])
                {
                    case "red":
                        redCount.Add(Convert.ToInt32(dividedSplit[0]));
                        break;
                    case "green":
                        greenCount.Add(Convert.ToInt32(dividedSplit[0]));
                        break;
                    case "blue":
                        blueCount.Add(Convert.ToInt32(dividedSplit[0]));
                        break;
                }
            }
        }

        redCount.Sort();
        greenCount.Sort();
        blueCount.Sort();

        sum += redCount.Last() * greenCount.Last() * blueCount.Last();

        line = reader.ReadLine();
    }

    Console.WriteLine($"Summa 2: {sum}");
}