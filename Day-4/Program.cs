Part1();
Part2();

static void Part1()
{
    int sum = 0;

    using StreamReader reader = new("..\\..\\..\\input.txt");

    string? line = reader.ReadLine();

    while (line != null)
    {
        List<int> cardNumbers = [];
        List<int> winningNumbers = [];

        line = line[(line.IndexOf(':') + 2)..];

        string cardNumberString = line[..(line.IndexOf('|') - 1)];
        string winningNumberString = line[(line.IndexOf('|') + 2)..];

        foreach (string cardNumber in cardNumberString.Split(' '))
            if (!string.IsNullOrEmpty(cardNumber))
                cardNumbers.Add(Convert.ToInt32(cardNumber));

        foreach (string winningNumber in winningNumberString.Split(' '))
            if (!string.IsNullOrEmpty(winningNumber))
                winningNumbers.Add(Convert.ToInt32(winningNumber));

        int winnings = 0;

        foreach (int winningNumber in winningNumbers)
            foreach (int cardNumber in cardNumbers)
                if (winningNumber == cardNumber)
                    if (winnings != 0)
                        winnings *= 2;
                    else
                        winnings = 1;

        sum += winnings;

        line = reader.ReadLine();
    }

    Console.WriteLine($"Summa 1: {sum}");
}

static void Part2()
{
    using StreamReader reader = new("..\\..\\..\\input.txt");

    string? line = reader.ReadLine();

    int[] cardInstances = new int[197];

    for (int i = 0; i < cardInstances.Length; i++)
        cardInstances[i] = 1;

    while (line != null)
    {
        int cardNumber = Convert.ToInt32(line.Substring(5, 3).Trim());

        List<int> cardNumbers = [];
        List<int> winningNumbers = [];

        line = line.Substring(line.IndexOf(':') + 2);

        string cardNumberString = line.Substring(0, line.IndexOf('|') - 1);
        string winningNumberString = line.Substring(line.IndexOf('|') + 2);

        foreach (string aCardNumber in cardNumberString.Split(' '))
            if (!string.IsNullOrEmpty(aCardNumber))
                cardNumbers.Add(Convert.ToInt32(aCardNumber));

        foreach (string winningNumber in winningNumberString.Split(' '))
            if (!string.IsNullOrEmpty(winningNumber))
                winningNumbers.Add(Convert.ToInt32(winningNumber));

        int winningCount = 0;

        foreach (int winningNumber in winningNumbers)
            foreach (int aCardNumber in cardNumbers)
                if (winningNumber == aCardNumber)
                    winningCount++;

        for (int i = 0; i < winningCount; i++)
            cardInstances[cardNumber + i] += cardInstances[cardNumber - 1];

        line = reader.ReadLine();
    }

    Console.WriteLine($"Summa 2: {cardInstances.Sum()}");
}