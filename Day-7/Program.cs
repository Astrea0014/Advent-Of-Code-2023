Part1();
Part2();

static Kind GetKind(string hand)
{
    List<(char character, int encounters)> processedHand = [];

    foreach (char c in hand)
    {
        if (processedHand.Any(processed => c == processed.character))
        {
            int index = processedHand.FindIndex(processed => c == processed.character);
            processedHand[index] = (processedHand[index].character, processedHand[index].encounters + 1);
        }
        else
            processedHand.Add((c, 1));
    }

    switch (processedHand.Count)
    {
        case 1:
            return Kind.FiveOfAKind;
        case 2:
            foreach ((char c, int encounters) in processedHand)
                if (encounters == 4)
                    return Kind.FourOfAKind;
            return Kind.FullHouse;
        case 3:
            foreach ((char c, int encounters) in processedHand)
                if (encounters == 3) return Kind.ThreeOfAKind;
            return Kind.TwoPair;
        case 4:
            return Kind.OnePair;
        default:
            return Kind.None;
    }
}
static int GetValueOf(char c)
{
    int value;
    if (int.TryParse(c.ToString(), out value))
        return value;

    switch (c)
    {
        case 'T':
            return 10;
        case 'J':
            return 11;
        case 'Q':
            return 12;
        case 'K':
            return 13;
        case 'A':
            return 14;
        default:
            return 0;
    }
}

static void Part1()
{
    int sum = 0;

    using StreamReader reader = new("..\\..\\..\\input.txt");

    string? line = reader.ReadLine();

    List<(string hand, int bid)> hands = [];

    while (line != null)
    {
        string[] split = line.Split(' ');
        hands.Add((split[0], Convert.ToInt32(split[1])));

        line = reader.ReadLine();
    }

    hands.Sort((item1, item2) =>
    {
        int result = (int)GetKind(item2.hand) - (int)GetKind(item1.hand);
        if (result != 0) return result;

        for (int i = 0; i < item1.hand.Length; i++)
        {
            result = GetValueOf(item2.hand[i]) - GetValueOf(item1.hand[i]);
            if (result != 0) return result;
        }

        return 0;
    });

    int rank = hands.Count;

    foreach (var hand in hands)
    {
        sum += rank * hand.bid;
        rank--;
    }

    Console.WriteLine($"Summa 1: {sum}");
}

static Kind GetKind2(string hand)
{
    List<(char character, int encounters)> processedHand = [];

    foreach (char c in hand)
    {
        if (processedHand.Any(processed => c == processed.character))
        {
            int index = processedHand.FindIndex(processed => c == processed.character);
            processedHand[index] = (processedHand[index].character, processedHand[index].encounters + 1);
        }
        else
            processedHand.Add((c, 1));
    }

    if (processedHand.Any(t => t.character == 'J'))
    {
        int ij = processedHand.FindIndex(t => t.character == 'J');

        switch (processedHand.Count)
        {
            case 1: // JJJJJ - Five of a kind
            case 2: // QQQJJ - Five of a kind
                return Kind.FiveOfAKind;
            case 3: // KQQJJ - Four of a kind, KKQQJ - Full House
                if (processedHand[ij].encounters == 3) return Kind.FourOfAKind;

                foreach ((char c, int encounters) in processedHand)
                {
                    if (c == 'J') continue;

                    if (encounters == 3 || (encounters == 2 && processedHand[ij].encounters == 2))
                        return Kind.FourOfAKind;
                }
                return Kind.FullHouse;
            case 4: // JJKQT - Three of a kind, JKQTT - Three of a kind
                return Kind.ThreeOfAKind;
            case 5:
                return Kind.OnePair;
            default:
                return Kind.None;
        }
    }
    else switch (processedHand.Count)
        {
            case 1:
                return Kind.FiveOfAKind;
            case 2:
                foreach ((char c, int encounters) in processedHand)
                    if (encounters == 4)
                        return Kind.FourOfAKind;
                return Kind.FullHouse;
            case 3:
                foreach ((char c, int encounters) in processedHand)
                    if (encounters == 3) return Kind.ThreeOfAKind;
                return Kind.TwoPair;
            case 4:
                return Kind.OnePair;
            default:
                return Kind.None;
        }
}
static int GetValueOf2(char c)
{
    int value;
    if (int.TryParse(c.ToString(), out value))
        return value;

    switch (c)
    {
        case 'T':
            return 10;
        case 'J':
            return 0;
        case 'Q':
            return 12;
        case 'K':
            return 13;
        case 'A':
            return 14;
        default:
            return 0;
    }
}

static void Part2()
{
    int sum = 0;

    using StreamReader reader = new("..\\..\\..\\input.txt");

    string? line = reader.ReadLine();

    List<(string hand, int bid)> hands = [];

    while (line != null)
    {
        string[] split = line.Split(' ');
        hands.Add((split[0], Convert.ToInt32(split[1])));

        line = reader.ReadLine();
    }

    hands.Sort((item1, item2) =>
    {
        int result = (int)GetKind2(item2.hand) - (int)GetKind2(item1.hand);
        if (result != 0) return result;

        for (int i = 0; i < item1.hand.Length; i++)
        {
            result = GetValueOf2(item2.hand[i]) - GetValueOf2(item1.hand[i]);
            if (result != 0) return result;
        }

        return 0;
    });

    int rank = hands.Count;

    foreach (var hand in hands)
    {
        sum += rank * hand.bid;
        rank--;
    }

    Console.WriteLine($"Summa 2: {sum}");
}

enum Kind
{
    None,
    OnePair,
    TwoPair,
    ThreeOfAKind,
    FullHouse,
    FourOfAKind,
    FiveOfAKind
}