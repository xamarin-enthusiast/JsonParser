using System.Collections.Generic;
using System.Linq;

namespace JsonParser
{
    public class JsonArray : JsonToken
    {
        public IReadOnlyList<JsonToken> Children { get; }

        public JsonArray(IReadOnlyList<JsonToken> children)
        {
            Children = children;
        }

        public override JsonToken GetChild(int index) => Children.ElementAtOrDefault(index);
    }
}