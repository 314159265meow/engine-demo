using EngineDemo.Nodes;
using Microsoft.AspNetCore.Components;

namespace EngineDemo.Components;

public partial class ResultComponent : ComponentBase, IDisposable
{
    [Parameter]
    public ResultNode Node { get; set; } = null!;

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
