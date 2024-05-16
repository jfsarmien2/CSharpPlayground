

namespace RecipeConsoleApp.Recipes.Ingredients;

public class IngredientRegister : IIngredientRegister
{
    public List<Ingredient> All { get; } = new List<Ingredient>
    {
        new Wheatflour(),
        new Speltlour(),
        new Butter(),
        new Chocolate(),
        new Cinnamon(),
        new Sugar(),
        new Cardamon(),
        new CocoaPowder(),
    };

    public Ingredient GetById(int id)
    {
        foreach (var ingredient in All)
        {
            if (ingredient.Id == id)
            {
                return ingredient;
            }
        }
        return null;
    }
}







