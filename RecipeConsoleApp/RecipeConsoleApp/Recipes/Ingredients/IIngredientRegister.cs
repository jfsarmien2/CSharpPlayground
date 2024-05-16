namespace RecipeConsoleApp.Recipes.Ingredients;

public interface IIngredientRegister
{
    List<Ingredient> All { get; }

    Ingredient GetById(int id);
}







