
using RecipeConsoleApp.Recipes;
using RecipeConsoleApp.Recipes.Ingredients;

namespace RecipeConsoleApp.App;

public interface IRecipesUserInteraction
{
    void Exit();
    void PrintAllExistingRecipe(IEnumerable<Recipe> allRecipes);
    void PromptToCreateRecipe();
    IEnumerable<Ingredient> ReadIngredientsFromUser();
    void ShowMessage(string message);
}

