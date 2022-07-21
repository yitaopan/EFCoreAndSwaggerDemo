using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using Newtonsoft.Json;

namespace EFCoreAndSwaggerDemo.Common.RichEnum
{
    public interface IEnumeration : IComparable
    {
        int Value { get; }
        string Name { get; }
    }

    /// <summary>
    ///     An Enum like class that enhance the C# enum and allows us to define type hierarchies.
    /// </summary>
    /// <remarks>
    ///     C# enum is supported by the compiler so it has some helper methods generated when defined.
    ///     We need to write these static methods in derived classes manually for now. With .NET 5+ code generator, we may
    ///     do some source code level meta programming and reduce those repeated work.
    /// </remarks>
    public abstract class Enumeration : IEnumeration
    {
        private enum CacheMethodType
        {
            ParseInt,
            ParseString,
            TryParseInt,
            TryParseString
        }

        private static readonly ConcurrentDictionary<(Type, CacheMethodType), MethodInfo> ConvertersCache =
            new ConcurrentDictionary<(Type, CacheMethodType), MethodInfo>();

        protected Enumeration(int id, string name)
        {
            Value = id;
            Name = name;
        }

        public int Value { get; }

        public string Name { get; }

        public int CompareTo(object obj)
        {
            return Value.CompareTo(((Enumeration)obj).Value);
        }

        public override string ToString()
        {
            return Name;
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Enumeration otherValue))
            {
                return false;
            }

            if (GetType() != otherValue.GetType())
            {
                return false;
            }

            return Value == otherValue.Value;
        }

        public override int GetHashCode()
        {
            return Value.GetHashCode();
        }

        public static implicit operator int(Enumeration e)
        {
            return e.Value;
        }

        public static implicit operator string(Enumeration e)
        {
            return e.Name;
        }

        public static bool operator ==(Enumeration lhs, Enumeration rhs)
        {
            if (ReferenceEquals(lhs, null))
            {
                if (ReferenceEquals(rhs, null))
                {
                    return true;
                }
                return false;
            }

            return lhs.Equals(rhs);
        }

        public static bool operator !=(Enumeration lhs, Enumeration rhs)
        {
            return !(lhs == rhs);
        }

        public static IEnumerable<T> GetAll<T>() where T : Enumeration
        {
            return GetAll(typeof(T)).Cast<T>();
        }

        public static IEnumerable<Enumeration> GetAll(Type t)
        {
            CheckConcreteType(t);

            return t.GetFields(BindingFlags.Public |
                               BindingFlags.Static |
                               BindingFlags.DeclaredOnly)
                .Select(f => f.GetValue(null))
                .Where(v => v != null && v.GetType() == t)
                .Cast<Enumeration>();
        }

        public static IReadOnlyDictionary<int, T> GetValueMapping<T>() where T : Enumeration
        {
            return GetAll<T>().ToDictionary(e => e.Value, e => e);
        }

        public static IReadOnlyDictionary<string, T> GetNameMapping<T>() where T : Enumeration
        {
            return GetAll<T>().ToDictionary(e => e.Name.ToUpper(), e => e);
        }

        /// <summary>
        ///     The default implementation to convert string value to a given enumeration type. We should prefer to define concrete
        ///     convert methods in subclass to improve performance.
        /// </summary>
        /// <param name="value">the enumeration name</param>
        /// <param name="t">the enumeration type</param>
        /// <param name="enumerationResolver">Optional resolver for abstract enumeration parsing. <c>EnumerationResolver.Default</c> will be used if absent or null.</param>
        /// <returns>the corresponding enumeration value</returns>
        /// <exception cref="ArgumentException">if type is null or not a concrete Enumeration subclass</exception>
        /// <exception cref="InvalidOperationException">if no value mapping was found</exception>
        public static Enumeration Parse(string value, Type t, IEnumerationResolver enumerationResolver = null)
        {
            enumerationResolver ??= EnumerationResolver.Default;
            t = enumerationResolver.ResolveImplementation(t);

            var convertMethod = ConvertersCache.GetOrAdd(
                (t, CacheMethodType.ParseString),
                tuple => LookupParseMethod(tuple.Item1, tuple.Item1, "Parse", typeof(string)));
            try
            {
                return (Enumeration)convertMethod.Invoke(null, new object[] {value});
            }
            catch (TargetInvocationException e) when (e.InnerException != null)
            {
                throw e.InnerException;
            }
        }

        public static T Parse<T>(string value, IEnumerationResolver enumerationResolver = null) where T : Enumeration
        {
            return (T)Parse(value, typeof(T), enumerationResolver);
        }

        /// <summary>
        ///     The default implementation to convert int value to a given enumeration type. We should prefer to define concrete
        ///     convert methods in subclass to improve performance.
        /// </summary>
        /// <param name="value">the enumeration ID</param>
        /// <param name="t">the enumeration type</param>
        /// <param name="enumerationResolver">Optional resolver for abstract enumeration parsing. <c>EnumerationResolver.Default</c> will be used if absent or null.</param>
        /// <returns>the corresponding enumeration value</returns>
        /// <exception cref="ArgumentException">if type is null or not a concrete Enumeration subclass</exception>
        /// <exception cref="InvalidOperationException">if no value mapping was found</exception>
        public static Enumeration Parse(int value, Type t, IEnumerationResolver enumerationResolver = null)
        {
            enumerationResolver ??= EnumerationResolver.Default;
            t = enumerationResolver.ResolveImplementation(t);

            var convertMethod = ConvertersCache.GetOrAdd(
                (t, CacheMethodType.ParseInt),
                tuple => LookupParseMethod(tuple.Item1, tuple.Item1, "Parse", typeof(int)));
            try
            {
                return (Enumeration)convertMethod.Invoke(null, new object[] {value});
            }
            catch (TargetInvocationException e) when (e.InnerException != null)
            {
                throw e.InnerException;
            }
        }

        public static T Parse<T>(int value, IEnumerationResolver enumerationResolver = null) where T : Enumeration
        {
            return (T)Parse(value, typeof(T), enumerationResolver);
        }

        /// <summary>
        ///     Try parse the int value to an instance of Enumeration type T.
        /// </summary>
        /// <typeparam name="T">The enumeration type. If it's abstract, a concrete subtype must be registered in <c>EnumerationResolver</c> before hand.</typeparam>
        /// <param name="value">The int enumeration value.</param>
        /// <param name="result">The result. null on failure.</param>
        /// <param name="enumerationResolver">Optional resolver for abstract enumeration parsing. <c>EnumerationResolver.Default</c> will be used if absent or null.</param>
        /// <returns>true if parsed successfully, false otherwise</returns>
        /// <see cref="EnumerationResolver"/>
        public static bool TryParse<T>(int value, out T result, IEnumerationResolver enumerationResolver = null) where T : Enumeration
        {
            var ret = TryParse(value, typeof(T), out var baseResult, enumerationResolver);
            result = ret ? (T) baseResult : null;
            return ret;
        }

        /// <summary>
        ///     Try parse the int value to an instance of Enumeration type identified by argument <c>t</c>.
        /// </summary>
        /// <param name="value">The int enumeration value.</param>
        /// <param name="t">The enumeration type. If it's abstract, a concrete subtype must be registered in <c>EnumerationResolver</c> before hand.</param>
        /// <param name="result">The result. null on failure.</param>
        /// <param name="enumerationResolver">Optional resolver for abstract enumeration parsing. <c>EnumerationResolver.Default</c> will be used if absent or null.</param>
        /// <returns>true if parsed successfully, false otherwise</returns>
        /// <see cref="EnumerationResolver"/>
        public static bool TryParse(int value, Type t, out Enumeration result, IEnumerationResolver enumerationResolver = null)
        {
            enumerationResolver ??= EnumerationResolver.Default;
            t = enumerationResolver.ResolveImplementation(t);
            CheckConcreteType(t);

            var tryParseMethod = ConvertersCache.GetOrAdd(
                (t, CacheMethodType.TryParseInt),
                tuple => LookupParseMethod(tuple.Item1, typeof(bool), "TryParse", typeof(int), t.MakeByRefType()));

            try
            {
                var parameters = new object[] {value, null};
                var ret = (bool) tryParseMethod.Invoke(null, parameters);
                result = (Enumeration) parameters[1];
                return ret;
            }
            catch (TargetInvocationException e) when (e.InnerException != null)
            {
                throw e.InnerException;
            }
        }

        /// <summary>
        ///     Try parse the name to an instance of Enumeration type T.
        /// </summary>
        /// <typeparam name="T">The enumeration type. If it's abstract, a concrete subtype must be registered in <c>EnumerationResolver</c> before hand.</typeparam>
        /// <param name="value">The string enumeration name. Case insensitive.</param>
        /// <param name="result">The result. null on failure.</param>
        /// <param name="enumerationResolver">Optional resolver for abstract enumeration parsing. <c>EnumerationResolver.Default</c> will be used if absent or null.</param>
        /// <returns>true if parsed successfully, false otherwise</returns>
        /// <see cref="EnumerationResolver"/>
        public static bool TryParse<T>(string value, out T result, IEnumerationResolver enumerationResolver = null) where T : Enumeration
        {
            var ret = TryParse(value, typeof(T), out var baseResult, enumerationResolver);
            result = ret ? (T)baseResult : null;
            return ret;
        }

        /// <summary>
        ///     Try parse the name to an instance of Enumeration type identified by argument <c>t</c>.
        /// </summary>
        /// <param name="value">The string enumeration name.</param>
        /// <param name="t">The enumeration type. If it's abstract, a concrete subtype must be registered in <c>EnumerationResolver</c> before hand.</param>
        /// <param name="result">The result. null on failure.</param>
        /// <param name="enumerationResolver">Optional resolver for abstract enumeration parsing. <c>EnumerationResolver.Default</c> will be used if absent or null.</param>
        /// <returns>true if parsed successfully, false otherwise</returns>
        /// <see cref="EnumerationResolver"/>
        public static bool TryParse(string value, Type t, out Enumeration result, IEnumerationResolver enumerationResolver = null)
        {
            enumerationResolver ??= EnumerationResolver.Default;
            t = enumerationResolver.ResolveImplementation(t);
            CheckConcreteType(t);

            var tryParseMethod = ConvertersCache.GetOrAdd(
                (t, CacheMethodType.TryParseString),
                tuple => LookupParseMethod(tuple.Item1, typeof(bool), "TryParse", typeof(string), t.MakeByRefType()));

            try
            {
                var parameters = new object[] {value, null};
                var ret = (bool) tryParseMethod.Invoke(null, parameters);
                result = (Enumeration) parameters[1];
                return ret;
            }
            catch (TargetInvocationException e) when (e.InnerException != null)
            {
                throw e.InnerException;
            }
        }

        /// <summary>
        ///     Clear the converters cache. Used when the registration changes (mainly in tests).
        /// </summary>
        internal static void ClearConvertersCache()
        {
            ConvertersCache.Clear();
        }

        private static MethodInfo LookupParseMethod(Type t, Type returnType, string name,  params Type[] parameterTypes)
        {
            var method = t.GetMethod(
                name,
                BindingFlags.DeclaredOnly | BindingFlags.Static | BindingFlags.Public,
                null,
                parameterTypes,
                null);
            if (method != null && method.ReturnType == returnType)
            {
                return method;
            }

            return null;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static void CheckConcreteType(Type t)
        {
            if (t == null)
            {
                throw new ArgumentException("type is null", nameof(t));
            }

            if (t.IsAbstract || !typeof(Enumeration).IsAssignableFrom(t))
            {
                throw new ArgumentException("type is abstract or not Enumeration", nameof(t));
            }
        }

        // TODO(menxiao): single instance based serialization & deserialization
    }

    /// <summary>
    ///     A Enumeration JSON converter which will be mainly used when we need to serialize the Enumeration value as string.
    ///
    ///     <pre>
    ///         <code>
    ///         [JsonConverter(typeof(EnumerationConverter))]
    ///         public SomeEnumeration Prop { get; set; }
    ///         </code>
    ///     </pre>
    /// </summary>
    public class EnumerationConverter : JsonConverter
    {
        public bool AsString { get; }

        public EnumerationConverter() : this(true) {}

        public EnumerationConverter(bool asString)
        {
            AsString = asString;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            if (value == null)
            {
                writer.WriteNull();
                return;
            }

            var e = (Enumeration)value;
            if (AsString)
            {
                writer.WriteValue(e.Name);
            }
            else
            {
                writer.WriteValue(e.Value);
            }
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null)
            {
                return null;
            }

            try
            {
                if (reader.TokenType == JsonToken.String)
                {
                    var name = reader.Value.ToString();
                    if (string.IsNullOrEmpty(name))
                    {
                        return null;
                    }

                    return Enumeration.Parse(name, objectType);
                }

                if (reader.TokenType == JsonToken.Integer)
                {
                    // Integer may be represented by Int64 in JSON
                    var id = Convert.ToInt32(reader.Value);
                    return Enumeration.Parse(id, objectType);
                }
            }
            catch (Exception ex)
            {
                throw new JsonSerializationException(
                    FormatMessage(reader, $"Error converting value {ToString(reader.Value)} to type {objectType}."),
                    ex);
            }
            
            throw new JsonSerializationException(
                FormatMessage(reader, $"Unexpected token {reader.TokenType} when parsing enum."));
        }

        public override bool CanConvert(Type objectType)
        {
            return typeof(Enumeration).IsAssignableFrom(objectType);
        }

        private string FormatMessage(JsonReader reader, string message)
        {
            var lineInfo = reader as IJsonLineInfo;

            message += $" Path '{reader.Path}'";

            if (lineInfo != null && lineInfo.HasLineInfo())
            {
                message += $", line {lineInfo.LineNumber}, position {lineInfo.LinePosition}";
            }

            message += ".";

            return message;
        }

        private string ToString(object value)
        {
            if (value == null)
            {
                return "{null}";
            }

            return (value is string s) ? @"""" + s + @"""" : value.ToString();
        }
    }
}
