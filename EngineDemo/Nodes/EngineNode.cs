using Blazor.Diagrams.Core.Geometry;
using Blazor.Diagrams.Core.Models;
using EngineDemo.Ports;

namespace EngineDemo.Nodes;

public class EngineNode : NodeModel
{
    public event Action? ProcessFinished;

    public List<Connector> Connectors { get; } = new();
    public List<ConnectorRow> ConnectorRows { get; } = new();
    public new string Title { get; set; } = "";
    public string DisplayValue { get; set; } = "";

    public EngineNode(Point point) : base(point) { }
    public virtual void Process()
    {
        ProcessFinished?.Invoke();
    }

    public void AddConnector(ConnectorType connectorType, bool isInput, string description)
    {
        var port = GetPort(connectorType, isInput);
        Connector connector = new()
        {
            Description = description,
            IsInput = isInput,
            Port = port,
            Type = connectorType
        };

        Connectors.Add(connector);
        AddPort(port);

        CalculateConnectorRows();
    }

    private void CalculateConnectorRows()
    {
        ConnectorRows.Clear();
        var inputConnectors = Connectors.Where(c => c.IsInput).ToList();
        var outputConnectors = Connectors.Where(c => !c.IsInput).ToList();

        for (var i = 0; i < Math.Max(inputConnectors.Count, outputConnectors.Count); i++)
        {
            ConnectorRows.Add(new()
            {
                Input = inputConnectors.ElementAtOrDefault(i)!,
                Output = outputConnectors.ElementAtOrDefault(i)!
            });
        }
    }

    private PortModel GetPort(ConnectorType type, bool isInput)
    {
        switch (type)
        {
            case ConnectorType.Boolean:
                if (isInput)
                    return new BooleanInputPort(this, PortAlignment.Left);
                else
                    return new BooleanOutputPort(this, PortAlignment.Right);
            case ConnectorType.Double:
                if (isInput)
                    return new DoubleInputPort(this, PortAlignment.Left);
                else
                    return new DoubleOutputPort(this, PortAlignment.Right);
            case ConnectorType.String:
                if (isInput)
                    return new StringInputPort(this, PortAlignment.Left);
                else
                    return new StringOutputPort(this, PortAlignment.Right);
            default:
                throw new Exception("Invalid connector type");
        }
    }
}
