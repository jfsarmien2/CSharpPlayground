using RecipeConsoleApp.App;
using RecipeConsoleApp.DataAccess;
using RecipeConsoleApp.FileAccess;
using RecipeConsoleApp.Recipes;
using RecipeConsoleApp.Recipes.Ingredients;



const FileFormat format = FileFormat.Json;
const string fileName = "recipes";

//var filePath = format == FileFormat.Json ?
//    $"{fileName}.json" :
//    $"{fileName}.txt";

IStringsRepository stringsRepository = format == FileFormat.Json ? 
    new StringJsonRepository():
    new StringTextualRepository();

var ingredientRegister = new IngredientRegister();

var recipeApp = new RecipesApp(
    new RecipesRepository(stringsRepository, ingredientRegister), 
    new RecipesConsoleUserInteraction(ingredientRegister));

var fileMetaData = new FileMetaData(fileName, format);

recipeApp.Run(fileMetaData.ToPath());











