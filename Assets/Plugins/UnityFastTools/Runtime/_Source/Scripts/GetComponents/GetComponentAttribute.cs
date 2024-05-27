using System;

// ReSharper disable once CheckNamespace
namespace UnityFastTools.GetComponents
{
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
    public sealed class GetComponentAttribute : Attribute
    {
        public GetComponentAttribute(WhereGet type = WhereGet.Self) { }
    }
}