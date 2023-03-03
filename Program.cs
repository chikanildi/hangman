using System;
using System.Collections.Generic;

public class Hangman
{
    const int GUESS_LIMIT = 15;
    public static void Main(string[] args)
    {
        var words = new List<string> { "skyline", "cupboard", "newsweek", "monkeyface", "hurricane", "dogfood", "forest", "waterpipe" };
        Random random = new Random();

        List<char> guessedLetters = new List<char>();

        while (true)
        {
            int randomNumber = random.Next(words.Count);
            string randomWord = words[randomNumber];

            Console.WriteLine($"This is a hangman game.\nTry to guess the word by entering a letter. You have {GUESS_LIMIT} guesses.\n");
            Console.Write($"The word is {randomWord.Length} letters long:\n\n");
            for (int k = 0; k < randomWord.Length; k++)
            {
                Console.Write("_");
            }
            Console.WriteLine("\n\n");

            int counter = 0;
            while (counter < GUESS_LIMIT)
            {
                char letterGuess = Console.ReadKey().KeyChar;

                if (guessedLetters.Contains(letterGuess))
                {
                    Console.WriteLine($"\nYou already guessed the letter '{letterGuess}'.");
                    continue;
                }

                guessedLetters.Add(letterGuess);
                bool containsLetter = randomWord.Contains(letterGuess);

                if (containsLetter)
                {
                    Console.WriteLine($"\nThe letter '{letterGuess}' is in the word!");
                    bool guessedWholeWord = true;
                    foreach (char ch in randomWord)
                    {
                        if (guessedLetters.Contains(ch))
                        {
                            Console.Write(ch);
                        }
                        else
                        {
                            Console.Write("_");
                            guessedWholeWord = false;
                        }
                    }
                    Console.WriteLine();
                    Console.WriteLine($"You have {GUESS_LIMIT - counter} guesses left.\n");

                    if (guessedWholeWord)
                    {
                        Console.WriteLine("Congratulations! You guessed the whole word!");
                        break;
                    }
                }
                else
                {
                    counter++;
                    Console.WriteLine($"\nThe letter '{letterGuess}' is not in the word.");
                    Console.WriteLine($"You have {GUESS_LIMIT - counter} guesses left.\n");

                }


            }

            Console.WriteLine($"You guessed {counter} times.");
            Console.WriteLine($"The word was: {randomWord}");

            Console.WriteLine("Would you like to play again? Press Y/N");
            char playAgain = Console.ReadKey().KeyChar;

            if (playAgain == 'y')
            {
                guessedLetters.Clear();
                Console.Clear();
            }
            else
            {
                Console.WriteLine("\nThanks for playing!");
                return;
            }
        }
    }
}

