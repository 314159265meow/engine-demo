using Blazor.Diagrams.Core;
using EngineDemo.Nodes;

namespace EngineDemo.Services;

public static class Engine
{
    public static void Run(Diagram diagram)
    {
        var voNodes = diagram.Nodes.OfType<EngineNode>();
        var processingNodes = GetStartingNodes(voNodes).ToList();
        while (processingNodes.Count > 0)
        {
            foreach (var node in processingNodes)
            {
                Console.WriteLine($"Processing node {node.Id}");
                node.Process();
            }

            var nextNodes = GetFollowingNodes(processingNodes);
            processingNodes.Clear();
            processingNodes.AddRange(nextNodes);
        }
    }

    private static IEnumerable<EngineNode> GetStartingNodes(IEnumerable<EngineNode> nodes)
    {
        return nodes.Where(n => !n.Connectors.Any(c => c.IsInput && c.Port.Links.Count > 0));
    }

    private static IEnumerable<EngineNode> GetFollowingNodes(IEnumerable<EngineNode> nodes)
    {
        var result = new List<EngineNode>();

        foreach (var node in nodes)
        {
            var outputConnectors = node.Connectors.Where(c => !c.IsInput);
            var portsWithLinks = outputConnectors.Where(c => c.Port.Links.Count > 0).Select(c => c.Port);
            var nextNodes = portsWithLinks.SelectMany(p => p.Links, (p, l) => l.TargetPort!.Parent).Cast<EngineNode>();

            foreach (var nextNode in nextNodes)
                if (!result.Contains(nextNode))
                    result.Add(nextNode);
        }

        return result;
    }
}
