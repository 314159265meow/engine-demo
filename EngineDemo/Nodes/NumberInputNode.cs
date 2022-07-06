using Blazor.Diagrams.Core.Geometry;

namespace EngineDemo.Nodes;

public class NumberInputNode : EngineNode
{
    public double Number { get; set; }

    public NumberInputNode(Point point) : base(point)
    {
        Title = "Number Input";
    }

    public override void Process()
    {
        Connectors.First().Value = Number;

        base.Process();
    }
}
