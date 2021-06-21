using System.Collections.Generic;

namespace Receiver
{
    public interface IParameterParser
    {
        List<BatteryParameters> Parser(List<string> parameters);
    }
}
