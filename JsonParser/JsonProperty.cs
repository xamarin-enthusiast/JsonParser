namespace JsonParser
{
    public class JsonProperty
    {
        public string Name { get; }

        public JsonToken Value { get; }

        public JsonProperty(string name, JsonToken value)
        {
            Name = name;
            Value = value;
        }
    }
}