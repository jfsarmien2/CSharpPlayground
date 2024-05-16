namespace RecipeConsoleApp.DataAccess;

public abstract class StringRepository : IStringsRepository
{

    protected abstract string? StringsToText(List<string> strings);
    protected abstract List<string> TextToStrings(string fileContents);
    public List<string> Read(string filePath)
    {
        if (File.Exists(filePath))
        {
            var fileContents = File.ReadAllText(filePath);
            return TextToStrings(fileContents);
        }

        return new List<string>();

    }


    public void Write(string filePath, List<string> strings) =>
        File.WriteAllText(filePath, StringsToText(strings));

}

