using System.Linq;
using System.Collections.Generic;

namespace JsonParser
{
    public class JsonObject : JsonToken
    {
        public IReadOnlyList<JsonProperty> Properties { get; }

        public JsonObject(IReadOnlyList<JsonProperty> properties)
        {
            Properties = properties;
        }

        public override JsonToken GetChild(int index) => Properties.ElementAtOrDefault(index)?.Value;

        public override JsonToken GetChild(string name) => Properties.FirstOrDefault(p => p.Name == name)?.Value;
    }
}