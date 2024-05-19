using System;

// ReSharper disable once CheckNamespace
namespace UnityFastTools
{
    [AttributeUsage(AttributeTargets.Field)]
    public sealed class GetComponentPropertyAttribute : Attribute
    {
        public GetComponentPropertyAttribute(GetComponentType type) { }
        
        public GetComponentPropertyAttribute(PropertyAccess access) { }
        
        public GetComponentPropertyAttribute(PropertyAccess access = PropertyAccess.Private, GetComponentType type = GetComponentType.Self) { }
    }
}