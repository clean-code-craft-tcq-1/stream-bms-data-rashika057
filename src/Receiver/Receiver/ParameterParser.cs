using System;
using System.Collections.Generic;

namespace Receiver
{
    public class ParameterParser
    {
        IParameterParser _parser;
        public ParameterParser(IParameterParser parameterParser)
        {
            if (parameterParser == null)
                throw new ArgumentNullException("parameterParser cannot be null.");
            _parser = parameterParser;
        }

        public List<BatteryParameters> Parser(List<string> parameters)
        {
            return _parser.Parser(parameters);
        }
    }
}
