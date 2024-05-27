using System;

// ReSharper disable once CheckNamespace
namespace UnityFastTools.GetComponents
{
    [AttributeUsage(AttributeTargets.Field)]
    public sealed class GetComponentPropertyAttribute : Attribute
    {
        public GetComponentPropertyAttribute(WhereGet type) { }
        
        public GetComponentPropertyAttribute(Access access) { }
        
        public GetComponentPropertyAttribute(Access access = Access.Private, WhereGet where = WhereGet.Self) { }
    }
}