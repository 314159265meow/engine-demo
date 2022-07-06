using Blazor.Diagrams.Core.Geometry;

namespace EngineDemo.Nodes;

public class StringInputNode : EngineNode
{
    public string Text { get; set; } = "";

    public StringInputNode(Point point) : base(point)
    {
        Title = "String Input";
    }

    public override void Process()
    {
        Connectors.First().Value = Text;

        base.Process();
    }
}
