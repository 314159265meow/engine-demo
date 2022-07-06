using Blazor.Diagrams.Core.Geometry;

namespace EngineDemo.Nodes;

public class ResultNode : EngineNode
{
    public ResultNode(Point point) : base(point)
    {
        Title = "Result Display";
    }

    public override void Process()
    {
        var inputConnectors = Connectors.Where(c => c.IsInput);
        var portsWithLinks = inputConnectors.Where(c => c.Port.Links.Count > 0).Select(c => c.Port);
        var inputNodes = portsWithLinks.SelectMany(p => p.Links, (p, l) => l.SourcePort!.Parent).Cast<EngineNode>();
        var inputValues = inputNodes.SelectMany(n => n.Connectors.Where(c => !c.IsInput), (n, c) => c.Value);

        var outputValue = inputValues.Aggregate("", (acc, cur) => acc += (string)cur);

        DisplayValue = outputValue.ToString();

        base.Process();
    }
}
