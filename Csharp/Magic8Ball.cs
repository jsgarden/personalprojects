using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

/* FORMATTING

// What this block of code does (what it'll do)

*/
namespace Magic8Ball
{
    /// <summary>
    /// Entry point for Magic 8 Ball program
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {

            //Save current console text color
            ConsoleColor oldColor = Console.ForegroundColor;

            programName();   // Tell which program is running          

            // Create a randomizer object
            Random randomObject = new Random();

            while (true) // Loop this forever
            {
                string questionString = getQuestion();   // Create questionString variable and change its value to user inputted question

                // Making the program think
                int sleepTime = randomObject.Next(5)+1;
                Console.WriteLine("Thinking...");
                Thread.Sleep(sleepTime * 1000);
                

                // Check if user didn't type a question (tell them to type a question)
                if (questionString.Length == 0)
                {
                    Console.WriteLine("You need to type a question fool !");
                    continue;
                }

                // User insult - you suck (kick them out the program)
                if(questionString.ToLower() == "you suck")
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("You suck even more ! BYE !");
                        break;
                }

                // Check if user typed 'quit' or 'exit' (exit the application)
                if (questionString.ToLower() == "quit")
                {
                    break;
                }
                if (questionString.ToLower() == "exit")
                {
                    break;
                }

                // Get a random number
                int randomNumber = randomObject.Next(4);

                switch (randomNumber)
                {
                    case 0:
                        {
                            Console.WriteLine("YES!");
                            break;
                        }

                    case 1:
                        {
                            Console.WriteLine("NO!");
                            break;
                        }

                    case 2:
                        {
                            Console.WriteLine("HELL NO!");
                            break;
                        }

                    case 3:
                        {
                            Console.WriteLine("OMG YES!");
                            break;
                        }                   
                }
            }//End of while loop

            // Cleanup
            Console.ForegroundColor =  oldColor;
        }

        /// <summary>
        /// This function will return text inputted by user in questionString
        /// </summary>
        /// <returns>questionString</returns>
        static string getQuestion()
        {
            // Tell the user to ask a question
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Ask a question : ");
            Console.ForegroundColor = ConsoleColor.DarkGray;
            string questionString = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.Cyan;

            return questionString;
        }


        /// <summary>
        /// Print the name of the program and who created it to the console
        /// </summary>
        static void programName()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Magic 8 Ball by Jean-Simon (https://github.com/jsgarden) - Codegasm #2");
        }
    }
}
