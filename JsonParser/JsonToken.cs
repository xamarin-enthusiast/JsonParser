using System;
namespace JsonParser
{
    public abstract class JsonToken
    {
        public virtual JsonToken GetChild(int index) =>
            throw new InvalidOperationException($"{GetType().Name} is not a container type.");

        public virtual JsonToken GetChild(string name) =>
            throw new InvalidOperationException($"{GetType().Name} is not a container type.");

        public virtual T GetValue<T>() =>
            throw new InvalidOperationException($"{GetType().Name} cannot be converted to {typeof(T).GetType().Name}.");

        public JsonToken this[int index] => GetChild(index);

        public JsonToken this[string name] => GetChild(name);
    }
}