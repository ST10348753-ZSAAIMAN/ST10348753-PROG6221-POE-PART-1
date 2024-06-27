# ST10348753-PROG6221-POE-PART 3-FINAL

[GitHub](https://github.com/ST10348753-ZSAAIMAN/ST10348753-PROG6221-POE-PART-1.git).

## Introduction
This guide provides comprehensive instructions on how to set up, compile, and use the Recipe Application. The application is designed to help users manage recipes by allowing them to create, edit, and display recipes through a user-friendly graphical user interface.

## Installation Instructions
Download the zip file available on this page or via [this link](https://github.com/ST10348753-ZSAAIMAN/ST10348753-PROG6221-POE-PART-1.git).

### Steps to Run the Application
1. Unzip the downloaded file.
2. Right-click the .sln file and open it with Visual Studio.
3. Build the solution by pressing Ctrl+Shift+B.
4. After the solution has been built successfully, press F5 to run the application.

## App Functionality and How To Use It
The Recipe Application is a WPF-based tool designed to help users create, manage, and display recipes. Here's how you can use each of its features:

### Main Menu Options
1. **Add Recipe**: Allows the user to input a new recipe with a name, ingredients, and preparation steps.
2. **Display a Specific Recipe**: Prompts the user to enter the name of the recipe to display.
3. **View All Recipes**: Lists all recipes in alphabetical order by name.
4. **Scale a Recipe**: Prompts the user to enter a scaling factor to adjust ingredient quantities.
5. **Reset Ingredient Quantities**: Resets all ingredient quantities to their original values.
6. **Clear a Recipe**: Clears all ingredients and steps from a selected recipe.
7. **Exit**: Exits the application.

### Creating a Recipe
1. **Start the Application**: Run the application by pressing F5 in Visual Studio.
2. **Enter Recipe Name**: Click "Add Recipe" and follow the prompts to enter the name of the recipe.
3. **Add Ingredients**:
   - Follow the prompts to specify the number of ingredients.
   - For each ingredient, specify the name, quantity, unit of measurement, calories, and food group.
4. **Add Preparation Steps**:
   - Specify the number of preparation steps.
   - Enter each step one at a time when prompted. The steps are numbered automatically.

### Editing a Recipe
Once a recipe is created, you can modify it using the following options:
- **Display Recipe**: Prints the current state of the recipe to the UI, including all ingredients and steps.
- **Scale Recipe**: Allows you to scale the quantities of ingredients. You will be prompted to enter a scaling factor (e.g., to double the recipe, enter `2`).
- **Reset Recipe**: Resets all ingredient quantities to their original values.
- **Clear Recipe**: Clears all ingredients and steps from the recipe, allowing you to start fresh.

### Exiting the Application
- To exit the application, click the "Exit" button in the main menu.

## Hardware Requirements
The minimum hardware requirements provided by Microsoft for running applications on the .NET Framework v4.8 are as follows:

- Processor - 1GHz
- RAM - 512MB
- Minimum Disk Space - 4.5GB

## Software Requirements
This application was developed in C# on the [.NET Framework v4.8](https://support.microsoft.com/en-us/topic/microsoft-net-framework-4-8-offline-installer-for-windows-9d23f658-3b97-68ab-d013-aa3c3e7495e0).

To view the code for this application, you can use an application such as [Microsoft Visual Studio](https://visualstudio.microsoft.com/vs/community/).

Recommended OS: Windows 11 64-bit

## Contributions
Please feel free to comment on the work and make pull requests. Open an issue ticket to start a conversation about changes.

## License
[MIT](https://choosealicense.com/licenses/mit/)
