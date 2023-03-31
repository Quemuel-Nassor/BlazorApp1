using Blazorise.DataGrid;
using SortDirection = Blazorise.SortDirection;

namespace BlazorApp1.Extensions
{
    public static class DataGridEventExtension
    {
        public static string GetGridSorting(this IEnumerable<DataGridColumnInfo> columns)
        {
            string direction = string.Empty;
            DataGridColumnInfo? columnInfo = columns.FirstOrDefault(x => x.SortDirection != SortDirection.Default);

            if (columnInfo == null)
                return string.Empty;

            switch (columnInfo.SortDirection)
            {
                case SortDirection.Ascending:
                    direction = " asc";
                    break;
                case SortDirection.Descending:
                    direction = " desc";
                    break;
                default:
                    break;
            }

            return columnInfo.SortField + direction;
        }
    }
}
