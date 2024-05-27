// ReSharper disable once CheckNamespace
namespace UnityFastTools.GetComponents
{
    /// <summary>
    /// GetComponent method type.
    /// Changes may prevent correct code generation.
    /// If you want to edit WhereGet, you will also need to edit UnityFastToolsGenerators.
    /// </summary>
    public enum WhereGet
    {
        /// <summary>
        /// GetComponent
        /// </summary>
        Self,
        /// <summary>
        /// GetComponentInChildren
        /// </summary>
        Child,
        /// <summary>
        /// GetComponentInParent
        /// </summary>
        Parent,
    }
}