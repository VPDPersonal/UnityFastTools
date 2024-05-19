using UnityEngine;
using UnityEngine.UI;

// ReSharper disable once CheckNamespace
namespace UnityFastTools.Samples
{
    public partial class GetComponentPropertySample : MonoBehaviour
    {
        [UnityHandler(UnityHandlerType.Click, nameof(InitializeProperties))]
        [SerializeField] private Button _initializeButton;
        
        [GetComponentProperty] private Transform _privateTransform;
        [GetComponentProperty(GetComponentType.Child)] private Transform _privateTransformChild;
        [GetComponentProperty(GetComponentType.Parent)] private Transform _privateTransformParent;
        
        [GetComponentProperty(PropertyAccess.Public)] private Transform _publicTransform;
        [GetComponentProperty(PropertyAccess.Public, GetComponentType.Child)] private Transform _publicTransformChild;
        [GetComponentProperty(PropertyAccess.Public, GetComponentType.Parent)] private Transform _publicTransformParent;
        
        [GetComponentProperty(PropertyAccess.Protected)] private Transform _protectedTransform;
        [GetComponentProperty(PropertyAccess.Protected, GetComponentType.Child)] private Transform _protectedTransformChild;
        [GetComponentProperty(PropertyAccess.Protected, GetComponentType.Parent)] private Transform _protectedTransformParent;
        
        [GetComponentProperty] private Transform[] _privateTransforms;
        [GetComponentProperty(GetComponentType.Child)] private Transform[] _privateTransformsChild;
        [GetComponentProperty(GetComponentType.Parent)] private Transform[] _privateTransformsParent;
        
        [GetComponentProperty(PropertyAccess.Public)] private Transform[] _publicTransforms;
        [GetComponentProperty(PropertyAccess.Public, GetComponentType.Child)] private Transform[] _publicTransformsChild;
        [GetComponentProperty(PropertyAccess.Public, GetComponentType.Parent)] private Transform[] _publicTransformsParent;
        
        [GetComponentProperty(PropertyAccess.Protected)] private Transform[] _protectedTransforms;
        [GetComponentProperty(PropertyAccess.Protected, GetComponentType.Child)] private Transform[] _protectedTransformsChild;
        [GetComponentProperty(PropertyAccess.Protected, GetComponentType.Parent)] private Transform[] _protectedTransformsParent;
        
        private void OnEnable() =>
            SubsribesUnityHandler();
        
        private void OnDisable() =>
            UnsubsribesUnityHandler();
        
        private void InitializeProperties()
        {
            // UFT0001: Field '_privateTransform' with [GetComponentProperty] should not be used outside its declaration. Use cached property instead.
            // Debug.Log(_privateTransform.gameObject.name);
            
            Debug.Log($"{CachedPrivateTransform}: " + CachedPrivateTransform.gameObject.name);
            Debug.Log($"{CachedPrivateTransformChild}: " + CachedPrivateTransformChild.gameObject.name);
            Debug.Log($"{CachedPrivateTransformParent}: " + CachedPrivateTransformParent.gameObject.name);
            
            Debug.Log($"{CachedPublicTransform}: " + CachedPublicTransform.gameObject.name);
            Debug.Log($"{CachedPublicTransformChild}: " + CachedPublicTransformChild.gameObject.name);
            Debug.Log($"{CachedPublicTransformParent}: " + CachedPublicTransformParent.gameObject.name);
            
            Debug.Log($"{CachedProtectedTransform}: " + CachedProtectedTransform.gameObject.name);
            Debug.Log($"{CachedProtectedTransformChild}: " + CachedProtectedTransformChild.gameObject.name);
            Debug.Log($"{CachedProtectedTransformParent}: " + CachedProtectedTransformParent.gameObject.name);
            
            foreach (var currentTransform in CachedPrivateTransforms)
                Debug.Log($"{currentTransform}: " + currentTransform.gameObject.name);
            foreach (var currentTransform in CachedPrivateTransformsChild)
                Debug.Log($"{currentTransform}: " + currentTransform.gameObject.name);
            foreach (var currentTransform in CachedPrivateTransformsParent)
                Debug.Log($"{currentTransform}: " + currentTransform.gameObject.name);
            
            foreach (var currentTransform in CachedPublicTransforms)
                Debug.Log($"{currentTransform}: " + currentTransform.gameObject.name);
            foreach (var currentTransform in CachedPublicTransformsChild)
                Debug.Log($"{currentTransform}: " + currentTransform.gameObject.name);
            foreach (var currentTransform in CachedPublicTransformsParent)
                Debug.Log($"{currentTransform}: " + currentTransform.gameObject.name);
            
            foreach (var currentTransform in CachedProtectedTransforms)
                Debug.Log($"{currentTransform}: " + currentTransform.gameObject.name);
            foreach (var currentTransform in CachedProtectedTransformsChild)
                Debug.Log($"{currentTransform}: " + currentTransform.gameObject.name);
            foreach (var currentTransform in CachedProtectedTransformsParent)
                Debug.Log($"{currentTransform}: " + currentTransform.gameObject.name);
        }
    }
}