using CsvProject.CsvReading;
using CsvProject.Interface;
using CsvProject.OldSolution;

namespace CsvProject.NewSolution;

public class FastTableDataBuilder : ITableDataBuilder
{
    public ITableData Build(CsvData csvData)
    {
        var resultRows = new List<FastRow>();

        foreach (var row in csvData.Rows)
        {
            //var newRowData = new Dictionary<string, object>();
            var newRow = new FastRow();
            for (int columnIndex = 0; columnIndex < csvData.Columns.Length; ++columnIndex)
            {
                var column = csvData.Columns[columnIndex];
                string valueAsString = row[columnIndex];
                //object value = ConvertValueToTargetType(valueAsString);

                if (string.IsNullOrEmpty(valueAsString))
                {
                    continue;
                }
                else if (valueAsString == "TRUE")
                {
                    new FastRow().AssignCell(column, true);
                }
                else if (valueAsString == "FALSE")
                {
                    new FastRow().AssignCell(column, false);
                }
                else if (valueAsString.Contains(".") && decimal.TryParse(valueAsString, out var valueAsDecimal))
                {
                    new FastRow().AssignCell(column, valueAsDecimal);
                }
                else if (int.TryParse(valueAsString, out var valueAsInt))
                {
                    new FastRow().AssignCell(column, valueAsInt);
                }
                else {

                    new FastRow().AssignCell(column, valueAsString);
                }

                //if (value is not null) 
                //{
                //    newRowData[column] = value;
                //}
            }

            resultRows.Add(newRow);
        }

        return new FastTableData(csvData.Columns, resultRows);
    }
}
