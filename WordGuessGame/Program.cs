using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;

namespace WordGuessGame
{
    public class Program
    {
        /// <summary>
        /// Main method that does some initial art and then calss the other methods to load. 
        /// </summary>
        /// <param name="args">calls methods below</param>
        public static void Main(string[] args)
        {
            // something that works, with some flare
            string title = @"
            _ _ _ ____ ____ ___  ____ _  _ ____ ____ ____ 
            | | | |  | |__/ |  \ | __ |  | |___ [__  [__  
            |_|_| |__| |  \ |__/ |__] |__| |___ ___] ___]
            ";
            Console.WriteLine(title);

            CreateAFile();
            ViewFile();
/*
            MenuScreen();
*/
        }

        public static void MenuScreen()
        {
            Console.WriteLine("Would you like to do something?");
            Console.WriteLine("1. play the damn game!");
            Console.WriteLine("2. view the word list");
            Console.WriteLine("3. edit the word list");
            Console.WriteLine("0. get outta here...");
            Console.Write("whatcha gonna do? => ");
            string userInput = Console.ReadLine();


            try
            {
                byte selectedOption = Convert.ToByte(userInput);
                HandleMenuInput(selectedOption);
            }
            catch (Exception e)
            {
                Console.WriteLine("there seems to be an issue", e.Message);
            }
        }

        public static void HandleMenuInput(byte selectedOption)
        {
            MenuScreen();
            try
            {
                if (selectedOption == 1)
                {
                    // add function call for playing the game
                }

                if (selectedOption == 2)
                {
                    // add function call for viewing the list
                }

                if (selectedOption == 3)
                {
                    // add function to edit the word list
                }

                if (selectedOption == 0)
                {
                    Console.WriteLine("later, gator");
                }
                if (selectedOption >= 4)
                {
                    Console.WriteLine("please enter a number from the list");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("i think you made a mistake", e.Message);
            }
        }

        public static void CreateAFile()
        {
            string path = "../../WordList.txt";
            try
            {
                if (!File.Exists(path))
                {
                    string[] createText = { "screaminggoats","zoolander","toolkit","babyboomer","gamegrumps","markiplier","jacksepticeye","marydoodles","headphones","youtubers","vimeoisdead","idkidc","supercalifragilisticexpielladocious","google","microsoft","codefellows","onlinelearning","university","randomwords","havingfun","boredom","creativity","funemployed"};
                    File.WriteAllLines(path, createText);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
   
        public static void ViewFile()
        {         
            try
            {
                // counter to prove that file is being read
                int counter = 0;
                // prints out the words from the file
                string line;
                // reading the file
                StreamReader file = new StreamReader("../../WordList.txt");
                // while there are still words in the file per line, display it.
                while ((line = file.ReadLine()) != null)
                {
                    Console.WriteLine(line);
                    // updating counter to display correct amt of lines in the file
                    counter++;
                }

                file.Close();
                Console.WriteLine("there are {0} words in this list", counter);
                Console.ReadLine();
            }
            catch (Exception e)
            {
                Console.WriteLine("something went wrong");
                Console.WriteLine(e.Message);
            }
        }

        public static string[] ConvertTextFileToString()
        {
            string filler = "";
            string words = "";
            StreamReader file = new StreamReader("../../WordList.txt");
            while ((filler = file.ReadLine()) != null)
            {
                words = filler + " ";
            }

            string[] wordArray = words.Split();
            return wordArray;
        }

        public static void GetUserWord()
        {
            try
            {
                Console.WriteLine("please enter the word you would like to add...");
                string newWord = Console.ReadLine().ToLower();
                if (newWord.Contains(" ") || newWord == null)
                {
                    Console.WriteLine("please enter a single word");
                    GetUserWord();
                }

                AddUserWord(newWord);
            }
            catch (Exception e)
            {
                Console.WriteLine("i think you made a mistake", e.Message);
            }
        }

        public static string AddUserWord(string userWord)
        {
            using (StreamWriter sw = File.AppendText("../../WordList.txt"))
            {
                sw.WriteLine(userWord);
            } 
            return $"your new word, {userWord}, had been successfully added..."
        }
    }
}
