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

namespace ST10348753_PROG6221_POE_PART_1
{
    /// <summary>
    /// Represents a recipe, which includes a collection of ingredients and a list of steps for preparation.
    /// </summary>
    public class Recipe
    {
        /// <summary>
        /// Gets the name of the recipe.
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Gets the list of ingredients used in the recipe.
        /// </summary>
        public List<Ingredient> Ingredients { get; private set; }

        /// <summary>
        /// Gets the list of preparation steps for the recipe.
        /// </summary>
        public List<string> Steps { get; private set; }


        /// <summary>
        /// Delegate for notifying when total calories exceed a specified limit.
        /// </summary>
        public delegate void CalorieExceededHandler(string recipeName);
        public event CalorieExceededHandler OnCalorieExceeded;

        /// <summary>
        /// Initializes a new instance of the Recipe class with a specified name.
        /// </summary>
        /// <param name="name">Name of the recipe.</param>
        public Recipe(string name)
        {
            Name = name;
            Ingredients = new List<Ingredient>();
            Steps = new List<string>();
        }

        /// <summary>
        /// Adds an ingredient to the recipe. 
        /// </summary>
        /// <param name="ingredient">The ingredient to add. Must not be null.</param>
        public void AddIngredient(Ingredient ingredient)
        {
            if (ingredient == null)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Ingredient cannot be null.");
                Console.ResetColor();
                return;
            }

            Ingredients.Add(ingredient);
        }

        //-----------------------------------------------------------------------------------------

        /// <summary>
        /// Adds a step to the recipe. If the array is full, it is resized.
        /// </summary>
        /// <param name="step">The preparation step to add. Must not be null or empty.</param>
        /// <exception cref="ArgumentException">Thrown when the step is null or empty.</exception>
        public void AddStep(string step)
        {
            // Check if the step is null or empty
            if (string.IsNullOrEmpty(step))
            {
                // Display error message in red text
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Step cannot be null or empty.");
                Console.ResetColor();
                return;
            }

            // Check if the steps array is full; if so, resize it
            if (stepCount == Steps.Length)
            {
                Array.Resize(ref Steps, Steps.Length * 2);
            }

            // Add the step to the array and increment the count
            Steps[stepCount++] = step;
        }

        //-----------------------------------------------------------------------------------------

        /// <summary>
        /// Displays the complete recipe including name, ingredients, and preparation steps.
        /// </summary>
        public void DisplayRecipe()
        {
            // Display recipe name in green text
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Recipe Name: {Name}");
            Console.WriteLine("Ingredients:");
            for (int i = 0; i < ingredientCount; i++)
            {
                Ingredient ingredient = Ingredients[i];
                Console.WriteLine($"{ingredient.Quantity} {ingredient.UnitOfMeasurement} of {ingredient.Name}");
            }

            Console.WriteLine("\nPreparation Steps:");
            for (int i = 0; i < stepCount; i++)
            {
                Console.WriteLine($"Step {i + 1}: {Steps[i]}");
            }
            Console.WriteLine("Press any key to return to the previous menu");
            Console.ResetColor();
            Console.ReadKey(); // Pause the console for the user to read the recipe details
        }

        //-----------------------------------------------------------------------------------------

        /// <summary>
        /// Scales the quantities of all ingredients in the recipe by a specified factor.
        /// </summary>
        /// <param name="factor">The factor by which to scale the ingredient quantities. Must be greater than zero.</param>
        /// <exception cref="ArgumentOutOfRangeException">Thrown if the scale factor is less than or equal to zero.</exception>
        public void ScaleRecipe(double factor)
        {
            // Check if the scale factor is less than or equal to zero
            if (factor <= 0)
            {
                // Display error message in red text
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Scale factor must be greater than zero.");
                Console.ResetColor();
                return;
            }

            // Scale each ingredient by the given factor
            for (int i = 0; i < ingredientCount; i++)
            {
                Ingredients[i].Scale(factor);
            }
        }

        //-----------------------------------------------------------------------------------------

        /// <summary>
        /// Resets the quantities of all ingredients in the recipe to their original values.
        /// </summary>
        public void ResetQuantities()
        {
            for (int i = 0; i < ingredientCount; i++)
            {
                Ingredients[i].Reset(); // Reset each ingredient to its original quantity
            }
        }

        //-----------------------------------------------------------------------------------------

        /// <summary>
        /// Clears all ingredients and steps from the recipe, effectively resetting it.
        /// Asks for user confirmation before clearing the data.
        /// </summary>
        public void ClearRecipe()
        {
            // Ask for user confirmation before clearing the recipe
            Console.WriteLine("Are you sure you want to clear the recipe? (yes/no)");
            string confirmation = Console.ReadLine();
            if (confirmation?.ToLower() == "yes")
            {
                // Clear the recipe data
                Ingredients = new Ingredient[10];
                Steps = new string[10];
                ingredientCount = 0;
                stepCount = 0;
                // Display confirmation message in yellow text
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Recipe cleared. Starting a new recipe...");
                Console.ResetColor();
            }
            else
            {
                // Display cancellation message in yellow text
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Clear recipe canceled.");
                Console.ResetColor();
            }
        }


    }
}
//------------------------------------------...ooo000 END OF FILE 000ooo...------------------------------------------------------//

