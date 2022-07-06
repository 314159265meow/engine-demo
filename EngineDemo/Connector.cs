using Blazor.Diagrams.Core.Models;

namespace EngineDemo;

public class Connector
{
    public string Description { get; set; } = "";
    public bool IsInput { get; set; }
    public PortModel Port { get; set; } = null!;
    public ConnectorType Type { get; set; }
    public object Value { get; set; } = null!;
}
