using Blazorise.DataGrid;
using Microsoft.AspNetCore.Components;

namespace BlazorApp1.Extensions
{
    public abstract class DataGridBase : ComponentBase
    {
        [Parameter]
        public bool InitGrid { get; set; } = true;
        public int GridCurrentPage { get; set; } = 1;
        public string GridSorting { get; set; } = "CreationTime Desc";

        public event Action OnReadDataAction;

        public void OnReadData<T>(DataGridReadDataEventArgs<T> e)
        {
            if (!e.CancellationToken.IsCancellationRequested)
            {
                string sorting = e.Columns.GetGridSorting();

                Console.WriteLine($"initGrid: {InitGrid}");
                Console.WriteLine($"sorting: event=({sorting}) - ({GridSorting})");
                Console.WriteLine($"page: event=({e.Page}) - ({GridCurrentPage})");

                if (InitGrid && (GridCurrentPage != e.Page || !GridSorting.Equals(sorting)))
                {
                    GridSorting = sorting;
                    GridCurrentPage = e.Page;
                    OnReadDataAction?.Invoke();
                }
            }
        }
    }
}