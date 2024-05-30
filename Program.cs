// Name & Surname: Zinedean Saaiman
// Student Number: ST10348753
// Group: 2

// References: 
//             https://www.tutorialspoint.com/csharp/csharp_multithreading.htm
//             https://learn.microsoft.com/en-us/dotnet/api/system.array.resize?view=net-8.0
//             https://www.geeksforgeeks.org/c-sharp-encapsulation/
//             https://www.geeksforgeeks.org/recursion-in-c-sharp/  


using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace ST10348753_PROG6221_POE_PART_2
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
            // List to store multiple recipes
            List<Recipe> recipes = new List<Recipe>();

            // Main loop to process user commands
            while (true)
            {
                Console.Clear();
                // Display the main menu options
                Console.WriteLine("Enter a command number:\n1. Add Recipe\n2. List Recipes\n3. Select Recipe\n4. Exit");
                int command = ReadInt(); // Read user command
                switch (command)
                {
                    case 1:
                        // Add a new recipe
                        recipes.Add(CreateRecipe());
                        break;
                    case 2:
                        // List all recipes in alphabetical order
                        ListRecipes(recipes);
                        break;
                    case 3:
                        // Select a recipe to display and edit
                        SelectRecipe(recipes);
                        break;
                    case 4:
                        // Exit the application
                        Environment.Exit(0);
                        break;
                    default:
                        // Handle invalid command
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Invalid command. Please try again.");
                        Console.ResetColor();
                        break;
                }
            }
        }

        //---------------------------------------------------------------------------------------------

        /// <summary>
        /// Guides the user through the creation of a new recipe by entering ingredients and steps.
        /// </summary>
        /// <returns>The newly created recipe.</returns>
        private static Recipe CreateRecipe()
        {
            // Prompt for recipe name
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
                // Prompt for ingredient details
                Console.WriteLine($"Enter name, quantity, unit of measurement, calories, and food group for ingredient {i + 1} (e.g., Sugar 1.5 cups 100 Sweeteners):");
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
                // Prompt for step description
                Console.WriteLine($"Enter the description for step {i + 1}:");
                string step = Console.ReadLine(); // Read each step description from user input
                myRecipe.AddStep(step); // Add the step to the recipe
            }

            // Subscribe to the CalorieExceeded event
            myRecipe.OnCalorieExceeded += recipeName =>
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Warning: The total calories for {recipeName} exceed 300!");
                Console.ResetColor();
            };

            return myRecipe; // Return the fully constructed recipe
        }

        //---------------------------------------------------------------------------------------------

        /// <summary>
        /// Lists all recipes in alphabetical order.
        /// </summary>
        /// <param name="recipes">The list of recipes to display.</param>
        private static void ListRecipes(List<Recipe> recipes)
        {
            Console.Clear();
            if (recipes.Count == 0)
            {
                // No recipes to display
                Console.WriteLine("No recipes available.");
            }
            else
            {
                // Display sorted list of recipe names
                var sortedRecipes = recipes.OrderBy(r => r.Name).ToList();
                Console.WriteLine("Recipes:");
                foreach (var recipe in sortedRecipes)
                {
                    Console.WriteLine(recipe.Name);
                }
            }
            Console.WriteLine("Press any key to return to the previous menu");
            Console.ReadKey();
        }

        //---------------------------------------------------------------------------------------------

        /// <summary>
        /// Allows the user to select a recipe to display and edit.
        /// </summary>
        /// <param name="recipes">The list of recipes to select from.</param>
        private static void SelectRecipe(List<Recipe> recipes)
        {
            Console.Clear();
            if (recipes.Count == 0)
            {
                // No recipes to select
                Console.WriteLine("No recipes available.");
            }
            else
            {
                // Prompt for recipe name to select
                Console.WriteLine("Enter the name of the recipe you want to select:");
                string name = Console.ReadLine();
                var recipe = recipes.FirstOrDefault(r => r.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
                if (recipe != null)
                {
                    // Edit the selected recipe
                    EditRecipe(recipe);
                }
                else
                {
                    // Recipe not found
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Recipe not found.");
                    Console.ResetColor();
                    Console.WriteLine("Press any key to return to the previous menu");
                    Console.ReadKey();
                }
            }
        }

        //---------------------------------------------------------------------------------------------

        /// <summary>
        /// Provides a user interface for editing the recipe including displaying, scaling, resetting, or clearing the recipe.
        /// </summary>
        /// <param name="recipe">The recipe to edit.</param>
        /// <returns>The updated recipe.</returns>
        private static Recipe EditRecipe(Recipe recipe)
        {
            while (true)
            {
                Console.Clear();
                // Display edit menu options
                Console.WriteLine("Enter a command number:\n1. Display\n2. Scale\n3. Reset\n4. Clear\n5. Calculate Total Calories\n6. Exit");
                int command = ReadInt();
                switch (command)
                {
                    case 1:
                        // Display the recipe
                        recipe.DisplayRecipe();
                        break;
                    case 2:
                        // Scale the recipe
                        Console.WriteLine("Enter scale factor (e.g., 0.5, 2, 3):");
                        double factor = ReadDouble();
                        recipe.ScaleRecipe(factor);
                        Console.Clear();
                        Console.WriteLine("Scaled Recipe:");
                        recipe.DisplayRecipe();
                        break;
                    case 3:
                        // Reset ingredient quantities
                        recipe.ResetQuantities();
                        break;
                    case 4:
                        // Clear the recipe
                        recipe.ClearRecipe();
                        break;
                    case 5:
                        // Calculate total calories
                        double totalCalories = recipe.CalculateTotalCalories();
                        Console.WriteLine($"Total Calories: {totalCalories}");
                        if (totalCalories > 300)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Warning: Total calories exceed 300!");
                            Console.ResetColor();
                        }
                        Console.WriteLine("Press any key to return to the previous menu");
                        Console.ReadKey();
                        break;
                    case 6:
                        // Exit edit menu
                        return recipe;
                    default:
                        // Handle invalid command
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Invalid command. Please try again.");
                        Console.ResetColor();
                        break;
                }
            }
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

        //---------------------------------------------------------------------------------------------


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

        //---------------------------------------------------------------------------------------------


        /// <summary>
        /// Validates the format of the input for an ingredient and creates an Ingredient object.
        /// </summary>
        /// <returns>A valid Ingredient object.</returns>
        private static Ingredient ReadIngredient()
        {
            while (true)
            {
                // Prompt for ingredient details
                string[] parts = Console.ReadLine().Split(' ');
                if (parts.Length == 5 && double.TryParse(parts[1], out double quantity) && quantity > 0 && double.TryParse(parts[3], out double calories))
                {
                    return new Ingredient(parts[0], quantity, parts[2], calories, parts[4]);
                }
                // Display error message for invalid input format
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid input. Please enter in the format 'Name Quantity Unit Calories FoodGroup':");
                Console.ResetColor();
            }
        }
    }
}
//------------------------------------------...ooo000 END OF FILE 000ooo...------------------------------------------------------//
