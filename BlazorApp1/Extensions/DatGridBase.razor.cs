using Blazorise.DataGrid;
using Microsoft.AspNetCore.Components;

namespace BlazorApp1.Extensions
{
    public abstract class DataGridBase : ComponentBase
    {
        [Parameter]
        public bool InitGrid { get; set; } = true;
        public int GridPageNumber { get; set; }
        public int GridPageSize { get; set; }
        public string GridSorting { get; set; }

        public event Action OnReadDataAction;

        public void OnReadData<T>(DataGridReadDataEventArgs<T> e)
        {
            if (!e.CancellationToken.IsCancellationRequested)
            {
                string sorting = e.Columns.GetGridSorting();

                if (InitGrid && 
                    (GridPageNumber != e.Page || 
                     GridSorting != sorting || 
                     GridPageSize != e.PageSize))
                {
                    GridSorting = sorting;
                    GridPageSize = e.PageSize;
                    GridPageNumber = e.Page;
                    OnReadDataAction?.Invoke();
                }
            }
        }
    }
}