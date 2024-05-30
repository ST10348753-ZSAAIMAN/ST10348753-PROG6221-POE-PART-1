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
    /// Represents an ingredient used in a recipe, detailing its name, quantity, and unit of measurement.
    /// </summary>
    public class Ingredient
    {
        /// <summary>
        /// Gets or sets the name of the ingredient.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the current quantity of the ingredient. This quantity can be scaled and reset.
        /// </summary>
        public double Quantity { get; set; }

        /// <summary>
        /// Gets or sets the unit of measurement for the ingredient's quantity, such as grams or cups.
        /// </summary>
        public string UnitOfMeasurement { get; set; }

        /// <summary>
        /// Private field to hold the original quantity of the ingredient for reset functionality.
        /// </summary>
        private double OriginalQuantity { get; set; }

        /// <summary>
        /// Constructs an Ingredient with specified details. Initializes name, quantity, and unit of measurement and stores the original quantity.
        /// </summary>
        /// <param name="name">The name of the ingredient.</param>
        /// <param name="quantity">The initial quantity of the ingredient.</param>
        /// <param name="unitOfMeasurement">The unit of measurement for the quantity.</param>
        public Ingredient(string name, double quantity, string unitOfMeasurement)
        {
            Name = name;  // Assign the name of the ingredient.
            Quantity = quantity;  // Set the initial quantity.
            UnitOfMeasurement = unitOfMeasurement;  // Define the unit of measurement.
            OriginalQuantity = quantity;  // Store the initial quantity for reset purposes.
        }

        //-----------------------------------------------------------------------------------------

        /// <summary>
        /// Scales the quantity of the ingredient by a specified factor. Adjusts the current quantity based on the original quantity.
        /// </summary>
        /// <param name="factor">The factor by which to scale the quantity, such as 2.0 for doubling.</param>
        /// <exception cref="ArgumentException">Thrown when the factor is less than or equal to zero.</exception>
        public void Scale(double factor)
        {
            if (factor <= 0)
            {
                throw new ArgumentException("Factor must be greater than zero", nameof(factor));
            }
            Quantity = OriginalQuantity * factor; // Calculate the new scaled quantity based on the original.
        }

        //-----------------------------------------------------------------------------------------

        /// <summary>
        /// Resets the quantity of the ingredient back to its original value specified at construction.
        /// </summary>
        public void Reset()
        {
            Quantity = OriginalQuantity;  // Revert the current quantity to the original stored quantity.
        }
    }
}
//------------------------------------------...ooo000 END OF FILE 000ooo...------------------------------------------------------//
