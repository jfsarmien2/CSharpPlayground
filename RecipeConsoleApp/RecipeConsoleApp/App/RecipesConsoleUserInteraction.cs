using RecipeConsoleApp.Recipes;
using RecipeConsoleApp.Recipes.Ingredients;

namespace RecipeConsoleApp.App;

public class RecipesConsoleUserInteraction : IRecipesUserInteraction
{
    private readonly IIngredientRegister _ingredientRegister;

    public RecipesConsoleUserInteraction(IngredientRegister ingredientRegister)
    {
        _ingredientRegister = ingredientRegister;
    }

    public void Exit()
    {
        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
    }

    public void PrintAllExistingRecipe(IEnumerable<Recipe> allRecipes)
    {

        if (allRecipes.Count() > 0)
        {
            int counter = 1;
            foreach (var item in allRecipes)
            {
                Console.WriteLine($"*****{counter}*****");
                Console.WriteLine(item);
                Console.WriteLine();
                ++counter;
            }
        }
    }

    public void PromptToCreateRecipe()
    {
        Console.WriteLine(
            "Create a new recipe! " +
            "Available ingredients are : "
        );

        foreach (var ingredient in _ingredientRegister.All)
        {
            Console.WriteLine(ingredient);
        }
    }

    public IEnumerable<Ingredient> ReadIngredientsFromUser()
    {
        bool shallStop = false;

        var ingredients = new List<Ingredient>();

        while (!shallStop)
        {
            Console.WriteLine("Add ingredient by its ID, " +
                "or type anything else if finished.");

            var userInput = Console.ReadLine();

            if (int.TryParse(userInput, out int id))
            {
                var selectedIngredient = _ingredientRegister.GetById(id);
                if (selectedIngredient is not null)
                {
                    ingredients.Add(selectedIngredient);
                }
            }
            else
            {
                shallStop = true;
            }
        }

        return ingredients;
    }

    public void ShowMessage(string message)
    {
        Console.WriteLine(message);
    }
}

