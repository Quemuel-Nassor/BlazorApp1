using Blazorise.DataGrid;
namespace BlazorApp1.Extensions;
using Microsoft.AspNetCore.Components;

public partial class DataGridBase
{
    [Parameter]
    public bool SearchOnInitialize { get; set; }
    public int GridCurrentPage{ get; set; }
    public string GridSorting{ get; set; }

    public event Action OnReadDataAction;

    public void OnReadData<T>(DataGridReadDataEventArgs<T> e)
    {
        if (!e.CancellationToken.IsCancellationRequested)
        {
            string sorting = e.Columns.GetGridSorting();

            if (SearchOnInitialize && (GridCurrentPage != e.Page || !GridSorting.Equals(sorting)))
            {
                GridSorting = sorting;
                GridCurrentPage = e.Page;
                OnReadDataAction?.Invoke();
            }
        }
    }
}