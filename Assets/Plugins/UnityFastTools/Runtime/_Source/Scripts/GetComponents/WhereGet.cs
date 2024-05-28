// ReSharper disable once CheckNamespace
namespace UnityFastTools.GetComponents
{
    /// <summary>
    /// Specifies the method to use for GetComponent.
    /// Modifications might prevent correct code generation.
    /// If you want to modify WhereGet, you will also need to modify UnityFastToolsGenerators.
    /// </summary>
    public enum WhereGet
    {
        /// <summary>
        /// Use GetComponent on the same GameObject.
        /// </summary>
        Self,
        /// <summary>
        /// Use GetComponentInChildren to search in child GameObjects.
        /// </summary>
        Child,
        /// <summary>
        /// Use GetComponentInParent to search in parent GameObjects.
        /// </summary>
        Parent,
    }
}