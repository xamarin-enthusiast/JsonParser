namespace JsonParser
{
    public class JsonBoolean : JsonToken
    {
        public bool Value { get; }

        public JsonBoolean(bool value)
        {
            Value = value;
        }

        public override T GetValue<T>()
        {
            if (typeof(T) == typeof(bool))
                return (T)(object) Value;

            return base.GetValue<T>();
        }
    }
}