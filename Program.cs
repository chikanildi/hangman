using System;
using System.Collections.Generic;

public class Hangman
{
    public static void Main(string[] args)
    {
        var words = new List<string> { "skyline", "cupboard", "newsweek", "monkeyface", "hurricane", "dogfood", "forest", "waterpipe" };

        Random R = new Random();
        int randomNumber = R.Next(0, words.Count);

        string randomWord = words[randomNumber];

        List<string> guessedLetters = new List<string>();

        int guessLimit = 15;
        Console.WriteLine($"This is a hangman game \nTry to guess the word by entering a letter. You have {guessLimit} guesses.\n");

        Console.Write($"the word is {randomWord.Length} letters long:\n\n");
        for (int k = 0; k < randomWord.Length; k++)
        {
            Console.Write("_");
        }
        Console.WriteLine("\n\n");

        int i = 0;
        while (i < guessLimit)
        {
            string letterGuess = Console.ReadLine().ToLower();

            if (letterGuess.Length != 1 || !Char.IsLetter(letterGuess[0]))
            {
                Console.WriteLine("Please enter a single letter.");
                continue;
            }

            if (guessedLetters.Contains(letterGuess))
            {
                Console.WriteLine($"You already guessed the letter '{letterGuess}'.");
                continue;
            }

            guessedLetters.Add(letterGuess);

            bool containsLetter = randomWord.Contains(letterGuess);

            if (containsLetter)
            {
                Console.WriteLine($"The letter '{letterGuess}' is in the word!");

                bool guessedWholeWord = true;
                foreach (char ch in randomWord)
                {
                    if (guessedLetters.Contains(ch.ToString()))
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

                if (guessedWholeWord)
                {
                    Console.WriteLine("Congratulations! You guessed the whole word!");
                    return;
                }
            }
            else
            {
                Console.WriteLine($"The letter '{letterGuess}' is not in the word.");
            }

            i++;
        }

        Console.WriteLine($"You guessed {i} times. GAME OVER.");
        Console.WriteLine($"The word was: {randomWord}");
        Console.WriteLine("Would you like to play again? Press Y/N");
        string playAgain = Console.ReadLine().ToLower();

        if (playAgain == "y")
        {
            Console.Clear();
            Main(args);
        }
        else
        {
            Console.WriteLine("Thanks for playing!");
            return;
        }
    }
}
