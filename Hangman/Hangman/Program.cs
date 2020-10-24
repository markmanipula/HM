using System;
using System.Text;
using System.IO;
using System.Collections.Generic;

namespace Hangman
{
    class Program
    {
        //lists of words for easy mode
        public static string[] myDictionaryEasy = { "apple", "orange", "banana", "kiwi" };
        //lists of words for difficult mode
        public static string[] myDictionaryDifficult = { "bandwagon", "bookworm", "precise", "whiteboard", "keyhole" };



        //keeps asking for a valid difficulty input
        public static void ValidDifficulty()
        {
            Console.WriteLine("Please enter a valid input. please pick a difficulty: 1)Easy 2)Difficult");
            string difficulty = Console.ReadLine();
            //bool isOK = Regex.IsMatch(difficulty, @"[1-2]");

            while(difficulty != "1" || difficulty != "2")
            {
                Console.WriteLine("Please enter a valid input. please pick a difficulty: 1)Easy 2)Difficult");
                difficulty = Console.ReadLine();
                //isOK = Regex.IsMatch(difficulty, @"[1-2]");
                if (difficulty == "1") easy();
                else if (difficulty == "2") difficult();
            }
            if (difficulty == "1") easy();
            if (difficulty == "2") difficult();
        }

        //this is the easy mode
        public static void easy()
        {
            Console.WriteLine("You have chosen the easy mode");
            Random random = new Random();
            int remainingGuess = 5;

            //generates a random number between 0 and the length of the array
            int randomWord = random.Next(0, myDictionaryEasy.Length);

            //this is the word to be guessed by the player
            string toGuess = myDictionaryEasy[randomWord];

            //asterisks replace the string to be guessed
            string masked = string.Empty;
            Console.WriteLine("Guess the word");
            for (int i = 0; i < toGuess.Length; i++)
            {
                masked += "*";
            }
            Console.WriteLine(masked);


            //reveals the letter when user guess the correct letter
            var theMasked = new StringBuilder(masked);
            bool keepPlaying = true;
            while (keepPlaying)
            {
                int appearance = 0;
                Console.WriteLine("Remaining guess: " + remainingGuess);

                string alphabetGuess = Console.ReadLine();
                for (int i = 0; i < toGuess.Length; i++)
                {
                    if (toGuess.Substring(i, 1) == alphabetGuess)
                    {
                        //keeps track of how many letters in the word is being guessed
                        appearance++;
                        theMasked.Remove(i, 1).Insert(i, alphabetGuess);
                        //a player wont lose a guess if they get a correct letter
                        if (toGuess.Contains(alphabetGuess))
                        {
                            remainingGuess++;
                        }
                    }

                    //checks if the word is unmasked
                    if (theMasked.ToString() == toGuess)
                    {
                        Console.WriteLine("You got it");
                        keepPlaying = false;
                        break;
                    }
                }
                //player always loses a guess every turn. If they get a correct letter, the above code ads to it 
                remainingGuess--;
                //this prevents adding additional guesses if there are multiple letters in one guess
                if (appearance > 1) remainingGuess -= appearance - 1;

                if (remainingGuess == 0)
                {
                    Console.WriteLine("You've ran out of guesses. The word is " + toGuess);
                    keepPlaying = false;
                    break;
                }
                Console.WriteLine(theMasked);
            }
        }

        //this is the difficult mode
        public static void difficult()
        {
            Console.WriteLine("You have chosen the difficult mode");
            Random random = new Random();
            int remainingGuess = 5;

            //generates a random number between 0 and the length of the array
            int randomWord = random.Next(0, myDictionaryDifficult.Length);

            //this is the word to be guessed by the player
            string toGuess = myDictionaryDifficult[randomWord];

            //asterisks replace the string to be guessed
            string masked = string.Empty;
            Console.WriteLine("Guess the word");
            for (int i = 0; i < toGuess.Length; i++)
            {
                masked += "*";
            }
            Console.WriteLine(masked);


            //reveals the letter when user guess the correct letter
            var theMasked = new StringBuilder(masked);
            bool keepPlaying = true;
            while (keepPlaying)
            {
                int appearance = 0;
                Console.WriteLine("Remaining guess: " + remainingGuess);

                string alphabetGuess = Console.ReadLine();
                for (int i = 0; i < toGuess.Length; i++)
                {
                    if (toGuess.Substring(i, 1) == alphabetGuess)
                    {
                        //keeps track of how many letters in the word is being guessed
                        appearance++;
                        theMasked.Remove(i, 1).Insert(i, alphabetGuess);
                        //a player wont lose a guess if they get a correct letter
                        if (toGuess.Contains(alphabetGuess))
                        {
                            remainingGuess++;
                        }
                    }

                    //checks if the word is unmasked
                    if (theMasked.ToString() == toGuess)
                    {
                        Console.WriteLine("You got it");
                        keepPlaying = false;
                        break;
                    }
                }
                //player always loses a guess every turn. If they get a correct letter, the above code ads to it 
                remainingGuess--;
                //this prevents adding additional guesses if there are multiple letters in one guess
                if (appearance > 1) remainingGuess -= appearance - 1;

                if (remainingGuess == 0)
                {
                    Console.WriteLine("You've ran out of guesses. The word is " + toGuess);
                    keepPlaying = false;
                    break;
                }
                Console.WriteLine(theMasked);
            }
        }

        public static void welcome()
        {
            Console.WriteLine("Welcome to Hangman \n" +
                              "please pick a difficulty: 1)Easy 2)Difficult");
            string playerChoice = Console.ReadLine();
            if (playerChoice == "1") easy();
            else if (playerChoice == "2") difficult();
            else ValidDifficulty();
        }

        public static void readFromDictionary()
        {
            List<string> myList = new List<string>();
            
            string fileName = "usa.txt";
            using (var file = new StreamReader($"./{fileName}"))
            {
                myList.Add(file.ReadLine());
            }
        }

        static void Main()
        {
            welcome();
        }
    }
}
