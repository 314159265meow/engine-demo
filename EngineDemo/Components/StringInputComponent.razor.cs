using EngineDemo.Nodes;
using Microsoft.AspNetCore.Components;

namespace EngineDemo.Components
{
    public partial class StringInputComponent : ComponentBase
    {
        [Parameter]
        public StringInputNode Node { get; set; } = null!;
    }
}
