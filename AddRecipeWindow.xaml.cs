using System.Collections.Generic;
using System.Windows;

namespace ST10348753_PROG6221_POE_PART_2
{
    public partial class AddRecipeWindow : Window
    {
        private List<Recipe> recipes;

        public AddRecipeWindow(List<Recipe> recipes)
        {
            InitializeComponent();
            this.recipes = recipes;
        }

        private void AddRecipeButton_Click(object sender, RoutedEventArgs e)
        {
            string recipeName = RecipeNameTextBox.Text;
            int numIngredients;
            if (int.TryParse(NumIngredientsTextBox.Text, out numIngredients))
            {
                Recipe newRecipe = new Recipe(recipeName);
                for (int i = 0; i < numIngredients; i++)
                {
                    // Add logic to input ingredient details
                }
                recipes.Add(newRecipe);
                MessageBox.Show("Recipe added successfully!");
                this.Close();
            }
            else
            {
                MessageBox.Show("Please enter a valid number of ingredients.");
            }
        }
    }
}
