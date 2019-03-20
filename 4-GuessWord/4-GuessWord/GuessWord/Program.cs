using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuessWord
{
    class Program
    {
        static void Main(string[] args)
        {
            // this is a word guessing game. This code will randomly pick one of the 10 mystery words
            string[] wordArray = new string[10] { "helmet", "wizard", "realty", "shovel", "summer", "reason", "exotic", "tiring", "easily", "genius" };
            Random ourRandomMachine = new Random();
            string mysteryWord = wordArray[ourRandomMachine.Next(0, 10)]; // now we have the word to be guessed.

            //mysteryWord = "dog"; // I set my mysteryWord to dog for me to verify that my loop works.

            bool success = false; // we will use this to decide when we have won.

            string[] lettersNotFound = new string[20];
            string[] lettersFound = new string[6] {" _ ", " _ ", " _ ", " _ ", " _ ", " _ "};

            
            do
            {
                Console.WriteLine();
                Console.WriteLine("Guess one letter that might be in the 6 letter word: ");

                    Console.Write("Here are your old bad guesses --  ");
                    for (int i = 0; i < lettersNotFound.Length; i++)  // write out the array
                    {
                        Console.Write(lettersNotFound[i] + " ");
                    }
                    Console.WriteLine();


                string letterGuess = Console.ReadLine().ToLower();  // get new letter

                int where = mysteryWord.IndexOf(letterGuess);  // is it there (we only catch the first one!)

                if (where < 0)
                {
                    Console.WriteLine("Sorry! Your guess letter is not in the word!");

                    for (int i = 0; i < lettersNotFound.Length; i++) // loop thru array until find first null, then save it
                    {
                        if (lettersNotFound[i] == null)
                        {
                            lettersNotFound[i] = letterGuess;
                            break;
                        }
                    }  
                }
                else
                {
                    Console.WriteLine("There is at least one of those in the word!");
                    Console.WriteLine("And it is in location {0}!", where + 1);  // +1 as humans count from 1, not 0

                    for (int i = 0; i < lettersFound.Length; i++)  // add the found letter to the partial word
                    {
                        lettersFound[where] = letterGuess;
                        Console.Write(lettersFound[i]);
                    }
                }

                Console.WriteLine();
                Console.WriteLine("Now, guess what the word is: ");
                string userGuess = Console.ReadLine().ToLower();

                if (mysteryWord == userGuess)
                {
                    Console.WriteLine("You got it! Congratulations :)");
                    success = true;
                }
                else
                {
                    Console.WriteLine("This is not the word. Guess again!");
                }

            } while (success == false);


            Console.ReadLine();
        }
    }
}
