namespace RecipeConsoleApp.FileAccess;

public static class FileFormatExtension
{
    public static string AsFileExtesion(this FileFormat format)
        => format == FileFormat.Json ? "json" : "txt";
}

