using CsvProject.CsvReading;

namespace CsvProject.Interface;

public interface ITableDataBuilder
{
    ITableData Build(CsvData csvData);
}