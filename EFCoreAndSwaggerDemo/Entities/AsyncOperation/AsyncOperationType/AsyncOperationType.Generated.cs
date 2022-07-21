// This file is auto generated. DO NOT update it manually.
using System;
using System.Collections.Generic;

namespace EFCoreAndSwaggerDemo.Models.Entities.AsyncOperation.AsyncOperationType
{
    [Newtonsoft.Json.JsonConverter(typeof(EFCoreAndSwaggerDemo.Common.RichEnum.EnumerationConverter), false)]
    public partial class AsyncOperationType
    {
        public static AsyncOperationType Parse(int value)
        {
            if (ValueMapping.TryGetValue(value, out var type))
            {
                return type;
            }

            throw new ArgumentException($"AsyncOperationType does not have a enumeration with value {value}");
        }

        public static AsyncOperationType Parse(string value)
        {
            if (NameMapping.TryGetValue(value?.ToUpper(), out var type))
            {
                return type;
            }

            throw new ArgumentException($"AsyncOperationType does not have a enumeration with name {value}");
        }

        public static bool TryParse(int value, out AsyncOperationType type)
        {
            return ValueMapping.TryGetValue(value, out type);
        }

        public static bool TryParse(string value, out AsyncOperationType type)
        {
            return NameMapping.TryGetValue(value?.ToUpper(), out type);
        }

        public EnumValue RawEnum { get; }

        private AsyncOperationType(EnumValue value, string name) : base((int)value, name)
        {
            RawEnum = value;
        }

        #region EnumDefinitions
        
        public static readonly AsyncOperationType Generic = new AsyncOperationType(EnumValue.Generic, nameof(Generic));
        
        #endregion

        // This needs to be placed after all enum fields definition to get their values
        private static readonly IReadOnlyDictionary<int, AsyncOperationType> ValueMapping = GetValueMapping<AsyncOperationType>();
        private static readonly IReadOnlyDictionary<string, AsyncOperationType> NameMapping = GetNameMapping<AsyncOperationType>();
    }
}
