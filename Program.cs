string input;
string signature = "1023";

//START THE GAME
bool game = true;
while (game)
{
    Console.Write("Guess the input:");
    input = Console.ReadLine();
    while (!IsInputCorrect(input))
    {
        Console.WriteLine();
        Console.WriteLine("Wrong input!");
        Console.WriteLine();
        Console.Write("Guess the input:");
        input = Console.ReadLine();
    }

    int[] bullsAndCows = CheckNumbers(input, signature);
    Console.WriteLine($"{bullsAndCows[0]} bulls and {bullsAndCows[1]} cows!");
    Console.WriteLine();

    if (input == signature) { Console.WriteLine("You won!"); game = false; }
}

static int[] CheckNumbers(string firstNumber, string secondNumber)
{
    int bulls = 0;
    int cows = 0;
    int[] bullsAndCows = new int[2];
    //1234
    //5461     
    for (int i = 0; i < firstNumber.Length; i++)
    {
        for (int j = 0; j < firstNumber.Length; j++)
        {
            if (firstNumber[i] == secondNumber[j])
            {
                if (i == j)
                {
                    bulls++;
                }
                else
                {
                    cows++;
                }
            }
        }
    }

    for (int i = 0; i < bullsAndCows.Length; i++)
    {
        bullsAndCows[i] = bulls;
        bullsAndCows[i + 1] = cows;
        i++;
    }

    return bullsAndCows;
}
static bool IsInputCorrect(string number)
{
    if (number.Length != 4) return false;

    if (!HasSameSymbols(number)) return false;

    if (!int.TryParse(number, out _)) return false;

    if (number[0] == '0') return false;

    return true;
}

static bool HasSameSymbols(string number)
{
    for (int i = 0; i < number.Length - 1; i++)
    {
        for (int j = i + 1; j < number.Length; j++)
        {
            if (number[i] == number[j])
            {
                return false;
            }
        }

    }
    return true;
}