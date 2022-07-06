using Blazor.Diagrams.Core.Models;
using DiagramDemo.Client.Services;
using Microsoft.AspNetCore.Components;

namespace EngineDemo.Components;

public partial class ConnectorRowComponent : ComponentBase
{
    [Parameter]
    public ConnectorRow Row { get; set; } = null!;

    private static string GetClass(PortModel port)
    {
        return PortCSSClass.Get(port);
    }
}
