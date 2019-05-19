namespace JsonParser
{
    public class JsonInteger : JsonToken
    {
        public int Value { get; }

        public JsonInteger(int value)
        {
            Value = value;
        }

        public override T GetValue<T>()
        {
            if (typeof(T) == typeof(int))
                return (T)(object) Value;

            return base.GetValue<T>();
        }
    }
}