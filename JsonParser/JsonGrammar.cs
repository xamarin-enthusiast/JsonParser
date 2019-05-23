using System.Globalization;
using System.Linq;
using Sprache;

namespace JsonParser
{
    internal static class JsonGrammar
    {
        public static readonly Parser<JsonNull> JsonNull = Parse.String("null").Select(_ => new JsonNull());

        public static readonly Parser<JsonBoolean> TrueJsonBoolean = Parse.String("true").Select(_ => new JsonBoolean(true));

        public static readonly Parser<JsonBoolean> FalseJsonBoolean = Parse.String("false").Select(_ => new JsonBoolean(false));

        public static readonly Parser<JsonBoolean> JsonBoolean = TrueJsonBoolean.Or(FalseJsonBoolean);

        public static readonly Parser<JsonInteger> JsonInteger =
            from minus in Parse.Char('-').Once().Text().Optional()
            from digits in Parse.Digit.AtLeastOnce().Text()
            let str = minus.GetOrDefault() + digits
            let value = int.Parse(str, CultureInfo.InvariantCulture)
            select new JsonInteger(value);

        public static readonly Parser<JsonFloatingPoint> JsonFloatingPoint =
            from minus in Parse.Char('-').Once().Text().Optional()
            from digitsInt in Parse.Digit.AtLeastOnce().Text()
            from separator in Parse.Char('.').Once().Text()
            from digitsFrac in Parse.Digit.AtLeastOnce().Text()
            let str = minus.GetOrDefault() + digitsInt + separator + digitsFrac
            let value = double.Parse(str, CultureInfo.InvariantCulture)
            select new JsonFloatingPoint(value);

        public static readonly Parser<JsonString> JsonString =
            from quoteOpen in Parse.Char('"')
            from str in Parse.CharExcept('"').AtLeastOnce().Text()
            from quoteClose in Parse.Char('"')
            select new JsonString(str);

        public static readonly Parser<JsonProperty> JsonProperty =
            from name in JsonString.Select(j => j.Value).Token()
            from colon in Parse.Char(':')
            from value in JsonToken.Token()
            select new JsonProperty(name, value);

        public static readonly Parser<JsonObject> JsonObject =
            from bracketOpen in Parse.Char('{').Token()
            from properties in JsonProperty.DelimitedBy(Parse.Char(','))
            from bracketClose in Parse.Char('}').Token()
            select new JsonObject(properties.ToArray());

        public static readonly Parser<JsonArray> JsonArray =
            from bracketOpen in Parse.Char('[').Token()
            from children in JsonToken.DelimitedBy(Parse.Char(','))
            from bracketClose in Parse.Char(']').Token()
            select new JsonArray(children.ToArray());

        public static readonly Parser<JsonToken> JsonToken =
            JsonArray.Or<JsonToken>(JsonObject).Or(JsonString).Or(JsonFloatingPoint).Or(JsonInteger).Or(JsonBoolean).Or(JsonNull);
    }
}