using System;

// ReSharper disable once CheckNamespace
namespace UnityFastTools
{
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
    public sealed class GetComponentAttribute : Attribute
    {
        public GetComponentAttribute(GetComponentType type = GetComponentType.Self) { }
    }
}