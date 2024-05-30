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

        //---------------------------------------------------------------------------------------------

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

        //---------------------------------------------------------------------------------------------

        /// <summary>
        /// Provides a user interface for editing the recipe including displaying, scaling, resetting, or clearing the recipe.
        /// </summary>
        /// <param name="recipe">The recipe to edit.</param>
        /// <returns>The updated recipe.</returns>
        private static Recipe EditRecipe(Recipe recipe)
        {
            Console.Clear();
            Console.WriteLine("Enter a command number:\n1. Display\n2. Scale\n3. Reset\n4. Clear\n5. Exit");

            int command = ReadInt();
            switch (command)
            {
                case 1:
                    recipe.DisplayRecipe();
                    break;
                case 2:
                    Console.WriteLine("Enter scale factor (e.g., 0.5, 2, 3):");
                    double factor = ReadDouble();
                    recipe.ScaleRecipe(factor);
                    Console.Clear();
                    Console.WriteLine("Scaled Recipe:");
                    recipe.DisplayRecipe();
                    break;
                case 3:
                    recipe.ResetQuantities();
                    break;
                case 4:
                    recipe.ClearRecipe();
                    break;
                case 5:
                    Environment.Exit(0);
                    break;
                default:
                    // Display error message in red text
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid command. Please try again.");
                    Console.ResetColor();
                    break;
            }

            return recipe;
        }

        //---------------------------------------------------------------------------------------------


        /// <summary>
        /// Reads a positive integer from the console, ensuring valid input.
        /// </summary>
        /// <returns>A valid positive integer.</returns>
        private static int ReadInt()
        {
            int result;
            // Loop until a valid positive integer is entered
            while (!int.TryParse(Console.ReadLine(), out result) || result < 1)
            {
                // Display error message in red text
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid input. Please enter a valid positive integer:");
                Console.ResetColor();
            }
            return result;
        }


        /// <summary>
        /// Reads a positive double from the console, ensuring valid input.
        /// </summary>
        /// <returns>A valid positive double.</returns>
        private static double ReadDouble()
        {
            double result;
            // Loop until a valid positive double is entered
            while (!double.TryParse(Console.ReadLine(), out result) || result <= 0)
            {
                // Display error message in red text
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid input. Please enter a valid positive number:");
                Console.ResetColor();
            }
            return result;
        }


        /// <summary>
        /// Validates the format of the input for an ingredient and creates an Ingredient object.
        /// </summary>
        /// <returns>A valid Ingredient object.</returns>
        private static Ingredient ReadIngredient()
        {
            while (true)
            {
                string[] parts = Console.ReadLine().Split(' ');
                // Check if the input format is correct and the quantity is valid
                if (parts.Length == 3 && double.TryParse(parts[1], out double quantity) && quantity > 0)
                {
                    return new Ingredient(parts[0], quantity, parts[2]);
                }
                // Display error message in red text
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid input. Please enter in the format 'Name Quantity Unit':");
                Console.ResetColor();
            }
        }

    }

}
//------------------------------------------...ooo000 END OF FILE 000ooo...------------------------------------------------------//
