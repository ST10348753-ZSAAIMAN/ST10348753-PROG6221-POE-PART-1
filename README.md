# ST10348753-PROG6221-POE-PART 2
https://github.com/ST10348753-ZSAAIMAN/ST10348753-PROG6221-POE-PART-1.git

## Introduction
This guide provides comprehensive instructions on how to set up, compile, and use the Recipe Application. The application is designed to help users manage recipes by allowing them to create, edit, display, and scale recipes through a user-friendly console interface. This release includes advanced features such as calorie calculation, notifications for high-calorie recipes, and support for multiple recipes.

## Installation Instructions
Download the zip file available on this page or via this link https://github.com/ST10348753-ZSAAIMAN/ST10348753-PROG6221-POE-PART-1.git.

## App Functionality and How To Use It
The Recipe Application is a console-based tool designed to help users create, manage, and display recipes. Here's how you can use each of its features:

## Creating a Recipe
1. **Start the Application**: Run the application using the command line by navigating to the application directory and typing dotnet run.
2. **Enter Recipe Name**: Upon launch, the application will prompt you to enter the name of the recipe.
3. **Add Ingredients**:
The application will ask how many ingredients you want to add.
For each ingredient, you will need to specify the name, quantity, unit of measurement, calories, and food group. Enter each detail separated by a space (e.g., Sugar 2 cups 100 Sweeteners).
4. **Add Preparation Steps**:
Next, you will specify how many preparation steps are involved.
Enter each step one at a time when prompted. The steps are numbered automatically.

## Managing Multiple Recipes
1. **Add Recipe**: Allows you to add a new recipe to the collection.
2. **List Recipes**: Displays all recipes in alphabetical order.
3. **Select Recipe**: Allows you to choose a specific recipe to view or edit.

##Editing a Recipe
Once a recipe is created, you can modify it using the following options:
1. **Display Recipe**: Prints the current state of the recipe to the console, including all ingredients and steps.
2. **Scale Recipe**: Allows you to scale the quantities of ingredients. You will be prompted to enter a scaling factor (e.g., to double the recipe, enter 2).
3. **Reset Recipe**: Resets all ingredient quantities to their original values.
4. **Clear Recipe**: Clears all ingredients and steps from the recipe, allowing you to start fresh.
5. **Calculate Total Calories**: Calculates and displays the total calories of the recipe. An alert is displayed if the total calories exceed 300.

## Exiting the Application
To exit the application, follow the prompts to navigate back to the main menu and choose the exit option.

## Navigational Tips
The application uses simple text commands and prompts to navigate through the recipe creation and editing process.
At any point, if you make a mistake in entry, the application will notify you and often allow you to re-enter the correct information.
This intuitive interface makes it easy to manage recipes without needing complex interactions, making it ideal for users of all technical levels.

## Hardware Requirements
The minimum hardware requirements provided by Microsoft for running applications on the .NET Framework v4.8 are as follows:

- Processor - 1GHz
- RAM - 512MB
- Minimum Disk Space - 4.5GB

## Software Requirements
- This application was developed in C# on the .NET Framework v4.8.
- To view the code for this application, you can use an application such as Microsoft Visual Studio.
- Recommended OS: Windows 11 64-bit

##Changes Based on Lecturer’s Feedback
Based on the lecturer's feedback, several improvements and features were added to enhance the application:

- **Error Handling**: Improved error handling to manage null values and incorrect data types effectively. Proper error messages are displayed to guide the user.
- **Colored Text Display**: Incorporated colored text to enhance the user interface, making error messages, warnings, and information more distinguishable.
- **Scaling Units**: Ensured that the units of measurement are correctly handled when scaling recipes. This includes appropriate conversions for better accuracy.
- **Confirmation for Clearing Data: Added a user confirmation step before clearing all recipe data to prevent accidental data loss.
- **Coding Standards**: Improved coding standards by adding separator lines between methods, end-of-file lines, and comprehensive comments explaining variables, methods, and the logic of the code.
- **Generic Collections**: Transitioned from using arrays to generic collections (List) for storing recipes, ingredients, and steps, allowing for unlimited entries and easier data management.
- **Delegate for Calorie Alerts**: Implemented a delegate to notify users when a recipe's total calories exceed 300, providing a more interactive user experience.
- **Unit Testing**: Added unit tests to extensively cover scenarios for the total calorie calculation, ensuring the reliability and correctness of the feature.

## Contributions
Please feel free to comment on the work and make pull requests. Open an issue ticket to start a conversation about changes.

## License
https://choosealicense.com/licenses/mit/






