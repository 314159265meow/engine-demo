using Blazor.Diagrams.Core.Geometry;

namespace EngineDemo.Nodes;

public class BooleanInputNode : EngineNode
{
    public bool IsChecked { get; set; }

    public BooleanInputNode(Point point) : base(point)
    {
        Title = "Boolean Input";
    }

    public override void Process()
    {
        Connectors.First().Value = IsChecked;

        base.Process();
    }
}
