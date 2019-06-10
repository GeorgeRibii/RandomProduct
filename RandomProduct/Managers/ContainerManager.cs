using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using RandomProduct.Contracts;
using RandomProduct.Extensions;

namespace RandomProduct.Managers
{
    public class ContainerManager: IContainerManager
    {
        private Dictionary<Type, Type> _container;

        public ContainerManager()
        {
            _container = new Dictionary<Type, Type>(0);
        }

        public IContainerManager Register<TContract, TInstance>()
        {
            if (_container.ContainsKey(typeof(TContract)))
            {
                throw new ArgumentException($"Implementation of {typeof(TContract).Name} is already registered");
            }

            _container.Add(typeof(TContract), typeof(TInstance));

            return this;
        }

        public TContract Resolve<TContract>() where TContract: class
        {
            if (!_container.ContainsKey(typeof(TContract)))
                throw new ArgumentException($"Container does not have registration rule for '{typeof(TContract).Name}'");

            _container.TryGetValue(typeof(TContract), out var instanceType);

            return this.GetType().InvokeGenericMethodWithParameters("Build", instanceType) as TContract;
        }

        private TInstance Build<TInstance>() where TInstance: class
        {
            var constructors = typeof(TInstance).GetConstructors();

            foreach (var constructorInfo in constructors)
            {
                var constructorParameters = constructorInfo.GetParameters();

                if (!constructorParameters.Any())
                {
                    try
                    {
                        return constructorInfo.Invoke(Array.Empty<object>()) as TInstance;
                    }
                    catch // Here could be aggregation for not resolved instances. In scope of this task - let's ignore that
                    {
                        continue;
                    }
                }

                try
                {
                    var resolvedParameters = new List<object>();
                    foreach (var parameter in constructorParameters)
                    {
                        resolvedParameters.Add(this.GetType()
                            .InvokeGenericMethodWithParameters("Resolve", parameter.GetType()));
                    }

                    return constructorInfo.Invoke(resolvedParameters.ToArray()) as TInstance;
                }
                catch // Same note as on top
                {
                    continue;
                }
            }

            throw new ApplicationException($"Could not resolve instance of {typeof(TInstance).Name}"); // Would be great to add additional info what exactly could not been resolved
        }
    }
}
