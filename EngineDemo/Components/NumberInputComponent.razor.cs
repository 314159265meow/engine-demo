using EngineDemo.Nodes;
using Microsoft.AspNetCore.Components;

namespace EngineDemo.Components;

public partial class NumberInputComponent : ComponentBase
{
    [Parameter]
    public NumberInputNode Node { get; set; } = null!;
}
