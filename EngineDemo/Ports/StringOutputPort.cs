using Blazor.Diagrams.Core.Models;

namespace EngineDemo.Ports;

public class StringOutputPort : PortModel
{
    public StringOutputPort(NodeModel parent, PortAlignment portAlignment) : base(parent, portAlignment) { }

    public override bool CanAttachTo(PortModel port)
    {
        if (!base.CanAttachTo(port))
            return false;

        if (Links.Any(l => l.TargetPort?.Id == port.Id || l.SourcePort?.Id == port.Id))
            return false;

        return port is StringInputPort;
    }
}
