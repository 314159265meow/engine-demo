using Blazor.Diagrams.Core.Models;

namespace EngineDemo.Ports;

public class DoubleOutputPort : PortModel
{
    public DoubleOutputPort(NodeModel parent, PortAlignment portAlignment) : base(parent, portAlignment) { }

    public override bool CanAttachTo(PortModel port)
    {
        if (!base.CanAttachTo(port))
            return false;

        if (Links.Any(l => l.TargetPort?.Id == port.Id || l.SourcePort?.Id == port.Id))
            return false;

        return port is DoubleInputPort;
    }
}
