using System;
using System.Collections.Concurrent;

namespace EFCoreAndSwaggerDemo.Common.RichEnum
{
    public interface IEnumerationResolver
    {
        void Register<T>(bool replace = false);
        void Register<T, TBase>(bool replace = false) where T : TBase;

        /// <summary>
        ///     Clear all the enumeration registrations. This will generally be used in test.
        /// </summary>
        void ClearRegistration();

        Type ResolveImplementation<TBase>() where TBase : Enumeration;
        Type ResolveImplementation(Type t);
    }

    /// <summary>
    ///     Resolves the implementation of an abstract enumeration.
    /// </summary>
    /// <remarks>
    ///     Ideally, we need a implementation similar to the Java
    ///     <a href="https://docs.oracle.com/javase/8/docs/api/java/util/ServiceLoader.html">ServiceLoader</a>,
    ///     which allows application to discover service providers at runtime dynamically. This is widely used in Spring Boot
    ///     to load service / configurations and auto configure them.
    ///     <p>
    ///         Here we use explicit registration instead of dynamic discovery for simplicity, and restrict the use for Enumeration only.
    ///     </p>
    /// </remarks>
    public class EnumerationResolver : IEnumerationResolver
    {
        public static readonly IEnumerationResolver Default = new EnumerationResolver();

        private readonly ConcurrentDictionary<Type, Type> _mapping = new ConcurrentDictionary<Type, Type>();

        public void Register<T>(bool replace)
        {
            var t = typeof(T);
            if (t.IsAbstract || t.IsGenericType)
            {
                throw new InvalidOperationException($"Type {t} is abstract or generic");
            }

            if (!typeof(Enumeration).IsAssignableFrom(t))
            {
                throw new InvalidOperationException($"Type {t} is not an Enumeration");
            }

            for (var parent = t.BaseType; parent != null && parent != typeof(Enumeration); parent = parent.BaseType)
            {
                if (Attribute.GetCustomAttribute(parent, typeof(DynamicallyResolvedAttribute)) is
                    DynamicallyResolvedAttribute)
                {
                    Register(t, parent, replace);
                    return;
                }
            }

            throw new InvalidOperationException($"Cannot find dynamically resolved base type for type {t}");
        }

        public void Register<T, TBase>(bool replace) where T : TBase
        {
            var t = typeof(T);
            EnsureConcreteEnumeration(t);

            var tBase = typeof(TBase);
            if (typeof(Enumeration) == tBase)
            {
                throw new InvalidOperationException($"Cannot register implementation for base Enumeration");
            }

            Register(t, tBase, replace);
        }

        public void ClearRegistration()
        {
            _mapping.Clear();
            Enumeration.ClearConvertersCache();
        }

        public Type ResolveImplementation<TBase>() where TBase : Enumeration
        {
            return ResolveImplementation(typeof(TBase));
        }

        public Type ResolveImplementation(Type t)
        {
            if (!t.IsAbstract && !t.IsGenericType && typeof(Enumeration).IsAssignableFrom(t))
            {
                return t;
            }

            if (_mapping.TryGetValue(t, out var impl))
            {
                return impl;
            }

            throw new InvalidOperationException($"No implementation found for {t}");
        }

        private void EnsureConcreteEnumeration(Type t)
        {
            if (t.IsAbstract || t.IsGenericType)
            {
                throw new InvalidOperationException($"Type {t} is abstract or generic");
            }

            if (!typeof(Enumeration).IsAssignableFrom(t))
            {
                throw new InvalidOperationException($"Type {t} is not an Enumeration");
            }
        }

        private void Register(Type impl, Type baseType, bool replace)
        {
            var existing = _mapping.GetOrAdd(baseType, impl);
            if (!replace && existing != impl)
            {
                throw new InvalidOperationException($"Type {baseType} is implemented by both {existing} and {impl}");
            }
        }

        internal EnumerationResolver()
        {
        }
    }

    /// <summary>
    ///     Marker attribute to indicate this <b>abstract</b> enumeration will be resolved at runtime.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
    public class DynamicallyResolvedAttribute : Attribute
    {
    }
}
