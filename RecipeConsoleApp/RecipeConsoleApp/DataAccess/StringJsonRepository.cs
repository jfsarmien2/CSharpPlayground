using System.Text.Json;

namespace RecipeConsoleApp.DataAccess;

public class StringJsonRepository : StringRepository
{

    protected override string? StringsToText(List<string> strings)
    {
        return JsonSerializer.Serialize(strings);
    }

    protected override List<string> TextToStrings(string fileContents)
    {
        return JsonSerializer.Deserialize<List<string>>(fileContents);
    }
}

