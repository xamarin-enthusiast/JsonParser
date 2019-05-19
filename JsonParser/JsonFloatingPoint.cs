namespace JsonParser
{
    public class JsonFloatingPoint : JsonToken
    {
        public double Value { get; }

        public JsonFloatingPoint(double value)
        {
            Value = value;
        }

        public override T GetValue<T>()
        {
            if (typeof(T) == typeof(double))
                return (T)(object) Value;

            return base.GetValue<T>();
        }
    }
}