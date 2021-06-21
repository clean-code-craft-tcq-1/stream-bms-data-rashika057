using Newtonsoft.Json;

namespace Receiver
{
    public class BatteryParameters
    {
        [JsonProperty("soc")]
        public float StateOfCharge { get; set; }
        [JsonProperty("temperature")]
        public float Temperature { get; set; }
    }
}