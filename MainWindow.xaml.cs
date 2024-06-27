using System.Collections.Generic;
using System.Windows;

namespace ST10348753_PROG6221_POE_PART_2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // List to store multiple recipes
        private List<Recipe> recipes = new List<Recipe>();

        /// <summary>
        /// Initializes a new instance of the MainWindow class.
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles the AddRecipe button click event. Opens the AddRecipeWindow.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The event data.</param>
        private void AddRecipe_Click(object sender, RoutedEventArgs e)
        {
            AddRecipeWindow addRecipeWindow = new AddRecipeWindow(recipes);
            addRecipeWindow.Show();
        }

        /// <summary>
        /// Handles the DisplayRecipe button click event. Opens the DisplayRecipeWindow.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The event data.</param>
        private void DisplayRecipe_Click(object sender, RoutedEventArgs e)
        {
            DisplayRecipeWindow displayRecipeWindow = new DisplayRecipeWindow(recipes);
            displayRecipeWindow.Show();
        }

        /// <summary>
        /// Handles the ViewAllRecipes button click event. Opens the ViewAllRecipesWindow.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The event data.</param>
        private void ViewAllRecipes_Click(object sender, RoutedEventArgs e)
        {
            ViewAllRecipesWindow viewAllRecipesWindow = new ViewAllRecipesWindow(recipes);
            viewAllRecipesWindow.Show();
        }

        /// <summary>
        /// Handles the ScaleRecipe button click event. Opens the ScaleRecipeWindow.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The event data.</param>
        private void ScaleRecipe_Click(object sender, RoutedEventArgs e)
        {
            ScaleRecipeWindow scaleRecipeWindow = new ScaleRecipeWindow(recipes);
            scaleRecipeWindow.Show();
        }

        /// <summary>
        /// Handles the ResetQuantities button click event. Opens the ResetQuantitiesWindow.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The event data.</param>
        private void ResetQuantities_Click(object sender, RoutedEventArgs e)
        {
            ResetQuantitiesWindow resetQuantitiesWindow = new ResetQuantitiesWindow(recipes);
            resetQuantitiesWindow.Show();
        }

        /// <summary>
        /// Handles the ClearRecipe button click event. Opens the ClearRecipeWindow.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The event data.</param>
        private void ClearRecipe_Click(object sender, RoutedEventArgs e)
        {
            ClearRecipeWindow clearRecipeWindow = new ClearRecipeWindow(recipes);
            clearRecipeWindow.Show();
        }

        /// <summary>
        /// Handles the Exit button click event. Shuts down the application.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The event data.</param>
        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
