using Blazor.Diagrams.Core.Models;
using EngineDemo.Ports;

namespace DiagramDemo.Client.Services
{
    public static class PortCSSClass
    {
        public static string Get(PortModel port)
        {
            if (port is BooleanInputPort ||
                port is BooleanOutputPort)
                return "boolean-port";

            if (port is DoubleInputPort ||
                port is DoubleOutputPort)
                return "double-port";

            if (port is StringInputPort ||
                port is StringOutputPort)
                return "string-port";

            return "";
        }
    }
}
