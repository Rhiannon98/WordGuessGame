using System;
using System.IO;
using System.Linq;
using static System.Console;

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
            WriteLine(title);

            CreateAFile();
            MenuScreen();
            DeleteFileAtExit();
        }

        public static void MenuScreen()
        {
            WriteLine("Would you like to do something?");
            /*
                        Console.WriteLine("1. play the damn game!");
            */
            WriteLine("2. view the word list");
            WriteLine("3. edit the list");
            WriteLine("0. get outta here...");

            Write("whatcha gonna do? => ");
            string userInput = ReadLine();
            byte selectedOption = Convert.ToByte(userInput);
            Clear();
            HandleMenuInput(selectedOption);
        }

        public static void HandleMenuInput(byte selectedOption)
        {
            try
            {
                /*if (selectedOption == 1)
                {
                    // add method call of game logic

                }*/

                if (selectedOption == 2)
                {
                    ViewWords();
                }

                if (selectedOption == 3)
                {
                    EditFileMenu();
                }

                if (selectedOption == 0)
                {
                    WriteLine("later, gator");
                }
                if (selectedOption >= 4)
                {
                    WriteLine("please enter a number from the list");
                }
            }
            catch (Exception e)
            {
                WriteLine($@"i think you made a mistake
                    {e.Message}");
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
                WriteLine(e.Message);
            }
        }

        public static string[] ConvertTextFileToStringArray()
        {
            string[] wordsArray = File.ReadAllLines("../../WordList.txt");
            return wordsArray;
        }

        public static void ViewWords()
        {
            string[] wordStrings = ConvertTextFileToStringArray();

            foreach (string word in wordStrings)
            {
                WriteLine(word);
            }
            WriteLine("0. return to main menu");
            string userInput = ReadLine();
            if (userInput == "0")
            {
                Clear();
                MenuScreen();
            }

            if (userInput != "0")
            {
                Clear();
                ViewWords();
            }
        }

        public static void EditFileMenu()
        {
            string[] seeingPurpose = ConvertTextFileToStringArray();
            foreach (string word in seeingPurpose) { WriteLine(word);}
            try
            {
                WriteLine("1. add a word");
                WriteLine("2. delete a word");
                WriteLine("0. back to main menu");

                string viewOptSelected = ReadLine();
                byte selectedOption = Convert.ToByte(viewOptSelected);
                HandleSelectedEditOption(selectedOption);
            }
            catch (Exception e)
            {
                WriteLine($@"something went wrong
                   {e.Message}");
            }
        }

        public static void HandleSelectedEditOption(byte viewOptSelected)
        {
            try
            {
                if (viewOptSelected == 1)
                {
                    AddUserWord();
                }

                if (viewOptSelected == 2)
                {
                    DeleteAWord();
                }

                if (viewOptSelected == 0)
                {
                    Clear();
                    MenuScreen();
                }
            }
            catch (Exception e)
            {
                WriteLine($@"invalid input selected
                {e.Message}");
            }
        }

        public static void AddUserWord()
        {
            try
            {
                WriteLine("please enter the word you would like to add...");
                var newWord = ReadLine()?.ToLower();
                if (newWord != null && (newWord.Contains(" ") || newWord == null))
                {
                    WriteLine("please enter a single word");
                    AddUserWord();
                }

                AddUserWord(newWord);
            }
            catch (Exception e)
            {
                WriteLine($@"you might'ave made a mistake
                {e.Message}");
            }
        }

        public static string AddUserWord(string userWord)
        {   
            TextWriter txtw = new StreamWriter("../../WordList.txt", true);
            try
            {
                txtw.WriteLine(userWord);
                txtw.Close();
                return $"your new word, {userWord}, has been successfully added...";
            }
            catch (Exception e)
            {
                WriteLine("errrrmm.....");
                return e.Message;
            }
        }

        public static string[] DeleteAWord()
        {
            try
            {
                string[] wordsArr = ConvertTextFileToStringArray();
                Write("alright, pick a word => ");
                string deleteWord = ReadLine();

                for (int i = 0; i < wordsArr.Length; i++)
                {
                    if (deleteWord != null && deleteWord.ToLower() == wordsArr[i])
                    {
                        string[] newArr = new string[wordsArr.Length - 1];
                        wordsArr[i].Remove(i);
                        wordsArr = newArr;
                        return wordsArr;
                    }

                    if (!wordsArr.Contains(deleteWord))
                    {
                        WriteLine("sorry, try again");
                        return DeleteAWord();
                    }
                }
                return wordsArr;
            }
            catch (Exception e)
            {
                WriteLine($@"alright, thats not there obviously
                                    {e.Message}");
            }

            return ConvertTextFileToStringArray();
        }

        public static void DeleteFileAtExit()
        {
            File.Delete("../../ WordList.txt");
        }

        // GameLogic
    }
}
