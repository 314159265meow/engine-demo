using Blazor.Diagrams.Core;
using Blazor.Diagrams.Core.Geometry;
using EngineDemo.Components;
using EngineDemo.Nodes;
using EngineDemo.Services;
using Microsoft.AspNetCore.Components;

namespace EngineDemo.Pages;

public partial class EnginePage : ComponentBase
{
    private Diagram _diagram = null!;
    private int _spawnPointX = 20;
    private int _spawnPointY = 30;

    protected override void OnInitialized()
    {
        InitializeDiagram();
    }

    private void AddAdderNode()
    {
        var node = new AdderNode(GetSpawnPoint());
        node.AddConnector(ConnectorType.Double, true, "Doubles");
        node.AddConnector(ConnectorType.Double, false, "Value");
        _diagram.Nodes.Add(node);
    }

    private void AddBooleanInputNode()
    {
        var node = new BooleanInputNode(GetSpawnPoint());
        node.AddConnector(ConnectorType.Boolean, false, "Value");
        _diagram.Nodes.Add(node);
    }

    private void AddNumberInputNode()
    {
        var node = new NumberInputNode(GetSpawnPoint());
        node.AddConnector(ConnectorType.Double, false, "Value");
        _diagram.Nodes.Add(node);
    }

    private void AddResultNode()
    {
        var node = new ResultNode(GetSpawnPoint());
        node.AddConnector(ConnectorType.String, true, "Text");
        _diagram.Nodes.Add(node);
    }

    private void AddStringInputNode()
    {
        var node = new StringInputNode(GetSpawnPoint());
        node.AddConnector(ConnectorType.String, false, "Value");
        _diagram.Nodes.Add(node);
    }

    private void AddToStringNode()
    {
        var node = new ToStringNode(GetSpawnPoint());
        node.AddConnector(ConnectorType.Boolean, true, "Booleans");
        node.AddConnector(ConnectorType.Double, true, "Doubles");
        node.AddConnector(ConnectorType.String, true, "Strings");
        node.AddConnector(ConnectorType.String, false, "Text");
        _diagram.Nodes.Add(node);
    }

    private Point GetSpawnPoint()
    {
        if ((_spawnPointX += 20) > 600)
            _spawnPointX = 20;
        if ((_spawnPointY += 10) > 600)
            _spawnPointY = 30;
        return new Point(_spawnPointX, _spawnPointY);
    }

    private void InitializeDiagram()
    {
        _diagram = new(new()
        {
            GridSize = 40,
            AllowMultiSelection = true,
            Links = new DiagramLinkOptions
            {
                DefaultPathGenerator = PathGenerators.Straight
            }
        });

        _diagram.RegisterModelComponent<BooleanInputNode, EnabledComponent>();
        _diagram.RegisterModelComponent<NumberInputNode, NumberInputComponent>();
        _diagram.RegisterModelComponent<StringInputNode, StringInputComponent>();
        _diagram.RegisterModelComponent<AdderNode, AdderComponent>();
        _diagram.RegisterModelComponent<ToStringNode, ToStringComponent>();
        _diagram.RegisterModelComponent<ResultNode, ResultComponent>();
    }

    private void RunEngine()
    {
        Engine.Run(_diagram);
    }
}
