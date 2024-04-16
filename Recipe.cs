// Name & Surname: Zinedean Saaiman
// Student Number: ST10348753
// Group: 2

// References: 
//             https://www.tutorialspoint.com/csharp/csharp_multithreading.htm
//             https://learn.microsoft.com/en-us/dotnet/api/system.array.resize?view=net-8.0
//             https://www.geeksforgeeks.org/c-sharp-encapsulation/
//             https://www.geeksforgeeks.org/recursion-in-c-sharp/  



using System;

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
        /// Gets the array of ingredients used in the recipe.
        /// </summary>
        public Ingredient[] Ingredients { get; private set; }

        /// <summary>
        /// Gets the array of preparation steps for the recipe.
        /// </summary>
        public string[] Steps { get; private set; }

        /// <summary>
        /// Tracks the current number of ingredients to manage additions and array resizing.
        /// </summary>
        private int ingredientCount;

        /// <summary>
        /// Tracks the current number of preparation steps to manage additions and array resizing.
        /// </summary>
        private int stepCount;

        /// <summary>
        /// Initializes a new instance of the Recipe class with a specified name.
        /// It sets initial capacities for Ingredients and Steps arrays.
        /// </summary>
        /// <param name="name">Name of the recipe.</param>
        public Recipe(string name)
        {
            Name = name;  // Set the recipe name
            Ingredients = new Ingredient[10]; // Initialize ingredients array with initial capacity
            Steps = new string[10];           // Initialize steps array with initial capacity
            ingredientCount = 0;              // Initialize ingredient count
            stepCount = 0;                    // Initialize step count
        }

        /// <summary>
        /// Adds an ingredient to the recipe. If the array is full, it is resized to accommodate new ingredients.
        /// </summary>
        /// <param name="ingredient">The ingredient to add. Must not be null.</param>
        /// <exception cref="ArgumentNullException">Thrown when the ingredient is null.</exception>

        public void AddIngredient(Ingredient ingredient)
        {
            if (ingredient == null)
            {
                throw new ArgumentNullException(nameof(ingredient), "Ingredient cannot be null.");
            }

            // Check if the ingredients array is full; if so, resize it
            if (ingredientCount == Ingredients.Length)
            {
                Ingredient[] temp = Ingredients;
                Array.Resize(ref temp, Ingredients.Length * 2); // Double the array size
                Ingredients = temp; // Assign the resized array back
            }

            Ingredients[ingredientCount++] = ingredient; // Add ingredient and increment the count
        }

        /// <summary>
        /// Adds a step to the recipe. If the array is full, it is resized.
        /// </summary>
        /// <param name="step">The preparation step to add. Must not be null or empty.</param>
        /// <exception cref="ArgumentException">Thrown when the step is null or empty.</exception>

        public void AddStep(string step)
        {
            if (string.IsNullOrEmpty(step))
            {
                throw new ArgumentException("Step cannot be null or empty.", nameof(step));
            }

            // Check if the steps array is full; if so, resize it
            if (stepCount == Steps.Length)
            {
                string[] temp = Steps;
                Array.Resize(ref temp, Steps.Length * 2); // Double the array size
                Steps = temp; // Assign the resized array back
            }

            Steps[stepCount++] = step; // Add step and increment the count
        }

        /// <summary>
        /// Displays the complete recipe including name, ingredients, and preparation steps.
        /// </summary>
        public void DisplayRecipe()
        {
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
            Console.ReadKey(); // Pause the console for the user to read the recipe details
        }

        /// <summary>
        /// Scales the quantities of all ingredients in the recipe by a specified factor.
        /// </summary>
        /// <param name="factor">The factor by which to scale the ingredient quantities. Must be greater than zero.</param>
        /// <exception cref="ArgumentOutOfRangeException">Thrown if the scale factor is less than or equal to zero.</exception>
        public void ScaleRecipe(double factor)
        {
            if (factor <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(factor), "Scale factor must be greater than zero.");
            }

            for (int i = 0; i < ingredientCount; i++)
            {
                Ingredients[i].Scale(factor); // Scale each ingredient by the given factor
            }
        }

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

    }
}
