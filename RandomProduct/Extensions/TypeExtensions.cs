using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace RandomProduct.Extensions
{
    public static class TypeExtensions
    {
        public static object InvokeGenericMethodWithParameters(this Type type, string methodName, Type genericType,
            params object[] parameters)
        {
            if (type is null)
                throw new ArgumentException("Type was not provided");

            if (string.IsNullOrWhiteSpace(methodName))
                throw new ArgumentException("Method name was not provided");

            if (genericType is null)
                throw new ArgumentException("Generic type was not provided");

            var methodInfo = type.GetMethod(methodName);

            if (methodInfo is null)
                throw new ArgumentException($"Method {methodName} was not found");

            if (!methodInfo.IsGenericMethod)
                return new ArgumentException($"Method {methodName} is not generic");

            var genericMethod = methodInfo.MakeGenericMethod(genericType);

            return genericMethod.Invoke(null, parameters);
        }
    }
}
