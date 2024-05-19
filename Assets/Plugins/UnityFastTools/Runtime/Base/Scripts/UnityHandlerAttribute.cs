using System;

// ReSharper disable once CheckNamespace
namespace UnityFastTools
{
    // В данный момент времени два аттрибута временно не поддерживаются
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, AllowMultiple = true)]
    public sealed class UnityHandlerAttribute : Attribute
    {
        public UnityHandlerAttribute(string eventName, string methodName) { }
    }
}