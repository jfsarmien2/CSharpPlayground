using RecipeConsoleApp.Recipes;

namespace RecipeConsoleApp.App;

public class RecipesApp
{
    private readonly IRecipesRepository _recipesRepository;
    private readonly IRecipesUserInteraction _recipesUserInteraction;
    public RecipesApp(RecipesRepository recipesRepository, IRecipesUserInteraction recipesUserInteraction)
    {
        _recipesRepository = recipesRepository;
        _recipesUserInteraction = recipesUserInteraction;
    }

    public void Run(string filePath)
    {
        // Get all recipes from a file
        var allRecipes = _recipesRepository.Read(filePath);

        // Print all existing recipes
        _recipesUserInteraction.PrintAllExistingRecipe(allRecipes);

        // Prompt user to create a recipe
        _recipesUserInteraction.PromptToCreateRecipe();

        // Read the ingredient from the user
        var ingredients = _recipesUserInteraction.ReadIngredientsFromUser();

        if (ingredients.Count() > 0)
        {
            var recipe = new Recipe(ingredients);

            allRecipes.Add(recipe);

            _recipesRepository.Write(filePath, allRecipes);

            _recipesUserInteraction.ShowMessage("Recipe added:");
            _recipesUserInteraction.ShowMessage(recipe.ToString());
        }
        else
        {
            _recipesUserInteraction.ShowMessage(
                "No ingredients have been selected." +
                "Recipe will not be saved."
                );
        }

        _recipesUserInteraction.Exit();
    }
}

