namespace RecipeConsoleApp.FileAccess;

public class FileMetaData
{
    public string Name { get; set; }
    public FileFormat Format { get; set; }

    public FileMetaData(string name, FileFormat format)
    {
        Name = name;
        Format = format;
    }

    public string ToPath() => $"{Name}.{Format.AsFileExtesion()}";


}

