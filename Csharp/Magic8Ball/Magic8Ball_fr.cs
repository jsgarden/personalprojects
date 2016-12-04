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
                Console.WriteLine("Reflexion...");
                Thread.Sleep(sleepTime * 1000);
                

                // Check if user didn't type a question (tell them to type a question)
                if (questionString.Length == 0)
                {
                    Console.WriteLine("Tu dois taper une question !");
                    continue;
                }

                // User insult - t poche (kick them out the program)
                if(questionString.ToLower() == "t poche")
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("T'es encore plus poche ! BYE !");
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
                            Console.WriteLine("OUI!");
                            break;
                        }

                    case 1:
                        {
                            Console.WriteLine("NON!");
                            break;
                        }

                    case 2:
                        {
                            Console.WriteLine("PAS PAN TOUTE!");
                            break;
                        }

                    case 3:
                        {
                            Console.WriteLine("OMG OUI!");
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
            Console.Write("Posez une question : ");
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
            Console.WriteLine("Magic 8 Ball par Jean-Simon (https://github.com/jsgarden) - Codegasm #2");
        }
    }
}
