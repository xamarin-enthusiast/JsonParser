using Sprache;

namespace JsonParser
{
    public static class Json
    {
        public static JsonToken Parse(string json) => JsonGrammar.JsonToken.Parse(json);
    }
}