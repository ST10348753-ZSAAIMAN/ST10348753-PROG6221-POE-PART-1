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

        /// <summary>
        /// Guides the user through the creation of a new recipe by entering ingredients and steps.
        /// </summary>
        /// <returns>The newly created recipe.</returns>
        private static Recipe CreateRecipe()
        {
            Console.WriteLine("Enter the name of the recipe:");
            string name = Console.ReadLine(); // Obtain the recipe name from user input
            Console.Clear();  // Clear the console to maintain a clean interface

            Recipe myRecipe = new Recipe(name); // Initialize a new recipe with the given name

            // Prompt and collect ingredients from the user
            Console.WriteLine("Enter the number of ingredients:");
            int numIngredients = ReadInt(); // Read the number of ingredients, ensuring it's a valid integer

            for (int i = 0; i < numIngredients; i++)
            {
                Console.Clear();
                Console.WriteLine($"Enter name, quantity, and unit of measurement for ingredient {i + 1} (e.g., Sugar 1.5 cups):");
                Ingredient ingredient = ReadIngredient(); // Read each ingredient using the specified format
                myRecipe.AddIngredient(ingredient); // Add the ingredient to the recipe
                Console.Clear();  // Clear the console after each ingredient is added
            }

            // Prompt and collect preparation steps from the user
            Console.WriteLine("Enter the number of steps:");
            int numSteps = ReadInt(); // Read the number of steps, ensuring it's a valid integer
            Console.Clear();

            for (int i = 0; i < numSteps; i++)
            {
                Console.WriteLine($"Enter the description for step {i + 1}:");
                string step = Console.ReadLine(); // Read each step description from user input
                myRecipe.AddStep(step); // Add the step to the recipe
            }

            return myRecipe; // Return the fully constructed recipe
        }
    }
}
