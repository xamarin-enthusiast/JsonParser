namespace JsonParser
{
    public class JsonNull : JsonToken
    {
        public override T GetValue<T>()
        {
            if (default(T) == null)
                return default(T);

            return base.GetValue<T>();
        }
    }
}