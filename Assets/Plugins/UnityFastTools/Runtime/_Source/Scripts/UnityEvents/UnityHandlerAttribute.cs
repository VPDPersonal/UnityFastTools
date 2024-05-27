using System;

// ReSharper disable once CheckNamespace
namespace UnityFastTools.UnityEvents
{
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, AllowMultiple = true)]
    public sealed class UnityHandlerAttribute : Attribute
    {
        /// <summary>
        /// Whether to pass the subscription object itself
        /// </summary>
        public bool EnableSender { get; set; }
        
        /// <summary>
        /// Works only with known types. Such as:
        /// Button, ScrollRect, Slider, Toggle
        /// </summary>
        /// <param name="methodName"></param>
        public UnityHandlerAttribute(string methodName) { }
        
        public UnityHandlerAttribute(string eventName, string methodName) { }
        
        public UnityHandlerAttribute(UnityEventName eventName, string methodName) { }
    }
}