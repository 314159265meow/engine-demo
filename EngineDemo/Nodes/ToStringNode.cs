using Blazor.Diagrams.Core.Geometry;

namespace EngineDemo.Nodes;

public class ToStringNode : EngineNode
{
    public ToStringNode(Point point) : base(point)
    {
        Title = "To String";
    }

    public override void Process()
    {
        var inputConnectors = Connectors.Where(c => c.IsInput).ToList();
        var portsWithLinks = inputConnectors.Where(c => c.Port.Links.Count > 0).Select(c => c.Port).ToList();
        var inputNodes = portsWithLinks.SelectMany(p => p.Links, (p, l) => l.SourcePort!.Parent).Cast<EngineNode>().ToList();
        var inputValues = inputNodes.SelectMany(n => n.Connectors.Where(c => !c.IsInput), (n, c) => c.Value).ToList();

        var outputValue = inputValues.Aggregate("", (acc, cur) => acc += cur.ToString());

        DisplayValue = outputValue.ToString();
        Connectors.First(c => !c.IsInput).Value = outputValue;

        base.Process();
    }
}
