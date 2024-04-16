// Name & Surname: Zinedean Saaiman
// Student Number: ST10348753
// Group: 2

// References: 
//             https://www.tutorialspoint.com/csharp/csharp_multithreading.htm
//             https://learn.microsoft.com/en-us/dotnet/api/system.array.resize?view=net-8.0
//             https://www.geeksforgeeks.org/c-sharp-encapsulation/
//             https://www.geeksforgeeks.org/recursion-in-c-sharp/  


using System;
using System.Threading;

namespace ST10348753_PROG6221_POE_PART_1
{
    /// <summary>
    /// Main class of the application, managing user interactions and recipe management operations.
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// The main entry point for the application. Manages the lifecycle of recipe creation and editing.
        /// </summary>
        private static void Main(string[] args)
        {
            // Begin by creating the initial recipe based on user input
            Recipe myRecipe = CreateRecipe();

            // Continuously process user commands until the application is explicitly exited
            while (true)
            {
                myRecipe = EditRecipe(myRecipe);
            }
        }
    }
}
