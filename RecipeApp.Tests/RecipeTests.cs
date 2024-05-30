using NUnit.Framework;
using ST10348753_PROG6221_POE_PART_1;

namespace RecipeApp.Tests
{
    [TestFixture]
    public class RecipeTests
    {
        [Test]
        public void CalculateTotalCalories_WithNoIngredients_ReturnsZero()
        {
            // Arrange
            var recipe = new Recipe("Test Recipe");

            // Act
            double totalCalories = recipe.CalculateTotalCalories();

            // Assert
            Assert.AreEqual(0, totalCalories);
        }

        [Test]
        public void CalculateTotalCalories_WithIngredients_ReturnsCorrectTotal()
        {
            // Arrange
            var recipe = new Recipe("Test Recipe");
            recipe.AddIngredient(new Ingredient("Sugar", 1.5, "cups", 300, "Sweeteners"));
            recipe.AddIngredient(new Ingredient("Flour", 2, "cups", 200, "Grains"));

            // Act
            double totalCalories = recipe.CalculateTotalCalories();

            // Assert
            Assert.AreEqual(500, totalCalories);
        }

        [Test]
        public void CalculateTotalCalories_WhenTotalExceeds300_CalorieExceededEventTriggered()
        {
            // Arrange
            var recipe = new Recipe("High Calorie Recipe");
            recipe.AddIngredient(new Ingredient("Butter", 1, "cup", 400, "Dairy"));

            bool eventTriggered = false;
            recipe.OnCalorieExceeded += (recipeName) =>
            {
                eventTriggered = true;
            };

            // Act
            double totalCalories = recipe.CalculateTotalCalories();

            // Assert
            Assert.IsTrue(eventTriggered);
            Assert.AreEqual(400, totalCalories);
        }

        [Test]
        public void CalculateTotalCalories_WhenTotalDoesNotExceed300_CalorieExceededEventNotTriggered()
        {
            // Arrange
            var recipe = new Recipe("Low Calorie Recipe");
            recipe.AddIngredient(new Ingredient("Apple", 1, "piece", 80, "Fruits"));

            bool eventTriggered = false;
            recipe.OnCalorieExceeded += (recipeName) =>
            {
                eventTriggered = true;
            };

            // Act
            double totalCalories = recipe.CalculateTotalCalories();

            // Assert
            Assert.IsFalse(eventTriggered);
            Assert.AreEqual(80, totalCalories);
        }
    }
}
