using EngineDemo.Nodes;
using Microsoft.AspNetCore.Components;

namespace EngineDemo.Components;

public partial class EnabledComponent : ComponentBase
{
    [Parameter]
    public BooleanInputNode Node { get; set; } = null!;
}
