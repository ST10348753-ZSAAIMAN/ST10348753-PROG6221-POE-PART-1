// Name & Surname: Zinedean Saaiman
// Student Number: ST10348753
// Group: 2

// References: 
//             https://www.tutorialspoint.com/csharp/csharp_multithreading.htm
//             https://learn.microsoft.com/en-us/dotnet/api/system.array.resize?view=net-8.0
//             https://www.geeksforgeeks.org/c-sharp-encapsulation/
//             https://www.geeksforgeeks.org/recursion-in-c-sharp/
//             https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/generics/
//             https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/events/
//             https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/delegates/
//             https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/exceptions/
//             https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1?view=net-8.0
//             https://www.tutorialsteacher.com/csharp/csharp-delegates
//             https://www.geeksforgeeks.org/c-sharp-events/
//             https://code-maze.com/csharp-collections/


using System;
using System.Collections.Generic;

namespace ST10348753_PROG6221_POE_PART_2
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

        /// <summary>
        /// Event triggered when total calories exceed a specified limit.
        /// </summary>
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
                // Display error message if the ingredient is null
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Ingredient cannot be null.");
                Console.ResetColor();
                return;
            }

            Ingredients.Add(ingredient);
        }

        //-----------------------------------------------------------------------------------------

        /// <summary>
        /// Adds a step to the recipe.
        /// </summary>
        /// <param name="step">The preparation step to add. Must not be null or empty.</param>
        public void AddStep(string step)
        {
            if (string.IsNullOrEmpty(step))
            {
                // Display error message if the step is null or empty
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Step cannot be null or empty.");
                Console.ResetColor();
                return;
            }

            Steps.Add(step);
        }

        //-----------------------------------------------------------------------------------------

        // <summary>
        /// Displays the complete recipe including name, ingredients, and preparation steps.
        /// </summary>
        public void DisplayRecipe()
        {
            // Display recipe name and ingredients
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"********** Recipe Name: {Name} **********");
            Console.WriteLine("Ingredients:");
            foreach (var ingredient in Ingredients)
            {
                Console.WriteLine($"{ingredient.Quantity} {ingredient.UnitOfMeasurement} of {ingredient.Name} - {ingredient.Calories} calories, {ingredient.FoodGroup}");
            }

            // Display preparation steps
            Console.WriteLine("\nPreparation Steps:");
            for (int i = 0; i < Steps.Count; i++)
            {
                Console.WriteLine($"Step {i + 1}: {Steps[i]}");
            }
            Console.ResetColor();
            Console.WriteLine("----------------------------------------");
            Console.WriteLine("Press any key to return to the previous menu");
            Console.ReadKey();
        }

        //-----------------------------------------------------------------------------------------

        /// <summary>
        /// Scales the quantities of all ingredients in the recipe by a specified factor.
        /// </summary>
        /// <param name="factor">The factor by which to scale the ingredient quantities. Must be greater than zero.</param>
        public void ScaleRecipe(double factor)
        {
            if (factor <= 0)
            {
                // Display error message if the scale factor is less than or equal to zero
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Scale factor must be greater than zero.");
                Console.ResetColor();
                return;
            }

            foreach (var ingredient in Ingredients)
            {
                ingredient.Scale(factor);
            }
        }

        //-----------------------------------------------------------------------------------------

        /// <summary>
        /// Resets the quantities of all ingredients in the recipe to their original values.
        /// </summary>
        public void ResetQuantities()
        {
            foreach (var ingredient in Ingredients)
            {
                ingredient.Reset();
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
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Are you sure you want to clear the recipe? (yes/no)");
            Console.ResetColor();
            if (Console.ReadLine().ToLower() == "yes")
            {
                Ingredients.Clear();
                Steps.Clear();
                Console.WriteLine("Recipe cleared. You can start a new recipe.");
            }
            else
            {
                Console.WriteLine("Clearing canceled.");
            }
        }

        /// <summary>
        /// Calculates the total calories of all ingredients in the recipe.
        /// </summary>
        /// <returns>The total calories of the recipe.</returns>
        public double CalculateTotalCalories()
        {
            double totalCalories = 0;
            foreach (var ingredient in Ingredients)
            {
                totalCalories += ingredient.Calories;
            }

            // Provide an explanation based on the total calories
            Console.ForegroundColor = ConsoleColor.Cyan;
            if (totalCalories < 200)
            {
                Console.WriteLine("This recipe is low in calories, suitable for a snack.");
            }
            else if (totalCalories >= 200 && totalCalories <= 500)
            {
                Console.WriteLine("This recipe has moderate calories, suitable for a balanced meal.");
            }
            else
            {
                Console.WriteLine("This recipe is high in calories and should be consumed sparingly.");
            }
            Console.ResetColor();

            // Trigger the calorie exceeded event if total calories exceed 300
            if (totalCalories > 300)
            {
                OnCalorieExceeded?.Invoke(Name);
            }

            return totalCalories;
        }
    }
}
//------------------------------------------...ooo000 END OF FILE 000ooo...------------------------------------------------------//

