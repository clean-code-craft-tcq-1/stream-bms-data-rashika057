using Newtonsoft.Json;
using System.Collections.Generic;

namespace Receiver
{
    public class JSONParameterParser : IParameterParser
    {
        public List<BatteryParameters> Parser(List<string> parameters)
        {
            if (parameters == null)
                throw new System.ArgumentNullException("parameters cannot be null.");
            return JsonConvert.DeserializeObject<List<BatteryParameters>>("[" + string.Join(",", parameters.ToArray()) + "]");
        }
    }
}
