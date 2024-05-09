namespace CsvProject.CsvReading;

public interface ICsvReader
{
    CsvData Read(string filePath);
}