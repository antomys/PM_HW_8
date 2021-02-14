using System.Linq;
using DesignPatterns.IoC.Impl;

namespace DesignPatterns.IoC
{
    using System;
    using System.Collections.Generic;
    public class ServiceCollection : IServiceCollection
    {
        private readonly Dictionary<Type, object> _singleton = new Dictionary<Type, object>();
        private readonly Dictionary<Type, object> _transient = new Dictionary<Type, object>();
        

        public IServiceCollection AddTransient<T>()
        {
            _transient.Add(typeof(T),null);
            return this;
        }

        public IServiceCollection AddTransient<T>(Func<T> factory)
        {
            if (!ContainsValue(_transient, factory))
            {
                _transient.Add(typeof(T), factory);
            }
                
            return this;
        }

        public IServiceCollection AddTransient<T>(Func<IServiceProvider, T> factory)
        {
            if (!ContainsValue(_transient, factory))
            {
                _transient.Add(typeof(T), factory);
            }
                
            return this;
        }

        public IServiceCollection AddSingleton<T>()
        {
            _singleton.Add(typeof(T),null);
            return this;
            //throw new NotImplementedException();
        }

        public IServiceCollection AddSingleton<T>(T service)
        {
            /*var lazy = new Lazy<T>(service);
            AddSingleton<T>(() => lazy.Value);*/

            if (!ContainsValue(_singleton, service))
            {
                _singleton.Add(typeof(T),service);
            }
                
            return this;
        }

        public IServiceCollection AddSingleton<T>(Func<T> factory)
        {
            var process = factory.Invoke();
            if (!ContainsValue(_singleton, process))
            {
                _singleton.Add(typeof(T),process);
            }
                
            return this;
            //throw new NotImplementedException();
        }

        public IServiceCollection AddSingleton<T>(Func<IServiceProvider, T> factory)
        {
            var process = factory.Invoke(BuildServiceProvider());
            if (!ContainsValue(_singleton, process))
            {
                _singleton.Add(typeof(T),process);
            }
            return this;
            //throw new NotImplementedException();
        }

        public IServiceProvider BuildServiceProvider()
        {
            //throw new NotImplementedException();
            return new ServiceProvider(_singleton,_transient);
        }

        private static bool ContainsValue(Dictionary<Type,object> dictionary, object value)
        {
            return dictionary.ContainsValue(value);
        }
        [Obsolete ("This method was used in trying to make with Dictionary<Type,Func<object>>")]
        private static bool ContainsValue(Dictionary<Type,Func<object>> dictionary, object value)
        {
            return dictionary.Any(values => values.Value.Equals(value));
        }
    }
}