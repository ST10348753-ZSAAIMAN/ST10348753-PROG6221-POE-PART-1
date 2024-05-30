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

        /// <summary>
        /// Provides a user interface for editing the recipe including displaying, scaling, resetting, or clearing the recipe.
        /// </summary>
        /// <param name="recipe">The recipe to edit.</param>
        /// <returns>The updated recipe.</returns>
        private static Recipe EditRecipe(Recipe recipe)
        {
            Console.Clear();
            Console.WriteLine("Enter a command number:\n1. Display\n2. Scale\n3. Reset\n4. Clear\n5. Exit");

            int command = ReadInt(); // Read the command number, ensuring it's a valid integer
            switch (command)
            {
                case 1: // Display the recipe
                    recipe.DisplayRecipe();
                    break;
                case 2: // Scale the recipe quantities
                    Console.WriteLine("Enter scale factor (e.g., 0.5, 2, 3):");
                    double factor = ReadDouble(); // Read the scale factor, ensuring it's a valid double
                    recipe.ScaleRecipe(factor);
                    Console.Clear();  // Optionally clear the console for a clean display
                    Console.WriteLine("Scaled Recipe:");
                    recipe.DisplayRecipe();  // Display the recipe immediately after scaling
                    break;
                case 3: // Reset the recipe to original quantities
                    recipe.ResetQuantities();
                    break;
                case 4: // Clear all recipe data and start fresh
                    Console.WriteLine("Recipe cleared. Starting a new recipe...");
                    Thread.Sleep(3000); // Provide a pause for the user to see the message
                    recipe = CreateRecipe(); // Create a new recipe
                    break;
                case 5: // Exit the application
                    Environment.Exit(0);
                    break;
                default: // Handle invalid command inputs
                    Console.WriteLine("Invalid command. Please try again.");
                    break;
            }

            return recipe; // Return the potentially modified recipe
        }

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
            while (!double.TryParse(Console.ReadLine(), out result) || result <= 0)
            {
                Console.WriteLine("Invalid input. Please enter a valid positive number:");
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
                // Ensure the format matches expected "Name Quantity Unit"
                if (parts.Length == 3 && double.TryParse(parts[1], out double quantity) && quantity > 0)
                {
                    return new Ingredient(parts[0], quantity, parts[2]);
                }
                Console.WriteLine("Invalid input. Please enter in the format 'Name Quantity Unit':");
            }
        }
    }

}
//------------------------------------------...ooo000 END OF FILE 000ooo...------------------------------------------------------//
