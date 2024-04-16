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
    }
}
