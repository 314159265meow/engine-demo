using Blazor.Diagrams.Core.Geometry;

namespace EngineDemo.Nodes;

public class AdderNode : EngineNode
{
    public AdderNode(Point point) : base(point)
    {
        Title = "Adder";
    }

    public override void Process()
    {
        var inputConnectors = Connectors.Where(c => c.IsInput);
        var portsWithLinks = inputConnectors.Where(c => c.Port.Links.Count > 0).Select(c => c.Port);
        var inputNodes = portsWithLinks.SelectMany(p => p.Links, (p, l) => l.SourcePort!.Parent).Cast<EngineNode>();
        var inputValues = inputNodes.SelectMany(n => n.Connectors.Where(c => !c.IsInput), (n, c) => (double)c.Value);

        var outputValue = inputValues.Aggregate(0.0, (acc, cur) => acc += cur);

        DisplayValue = string.Join(" + ", inputValues);
        Connectors.First(c => !c.IsInput).Value = outputValue;

        base.Process();
    }
}
