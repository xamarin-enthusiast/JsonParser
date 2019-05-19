namespace JsonParser
{
    public class JsonString : JsonToken
    {
        public string Value { get; }

        public JsonString(string value)
        {
            Value = value;
        }

        public override T GetValue<T>()
        {
            if (typeof(T) == typeof(string))
                return (T)(object) Value;

            return base.GetValue<T>();
        }
    }
}