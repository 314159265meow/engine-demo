using EngineDemo.Nodes;
using Microsoft.AspNetCore.Components;

namespace EngineDemo.Components;

public partial class ToStringComponent : ComponentBase, IDisposable
{
    [Parameter]
    public ToStringNode Node { get; set; } = null!;

    public void Dispose()
    {
        Node.ProcessFinished -= OnNodeProcessFinished;
        GC.SuppressFinalize(this);
    }

    protected override void OnInitialized()
    {
        Node.ProcessFinished += OnNodeProcessFinished;
    }

    private void OnNodeProcessFinished()
    {
        StateHasChanged();
    }
}
