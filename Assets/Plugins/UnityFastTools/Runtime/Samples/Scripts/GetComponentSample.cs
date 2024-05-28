using UnityEngine;
using UnityEngine.UI;
using UnityFastTools.GetComponents;

// ReSharper disable once CheckNamespace
namespace UnityFastTools.Samples
{
    // This class must be partial.
    public partial class GetComponentSample : MonoBehaviour
    {
        [GetComponent] private Image _selfImage;
        [GetComponent(WhereGet.Child)] private Image _childImage;
        [GetComponent(WhereGet.Parent)] private Image _parentImage;
        
        [GetComponent] private Image[] _selfImages;
        [GetComponent(WhereGet.Child)] private Image[] _childImages;
        [GetComponent(WhereGet.Parent)] private Image[] _parentImages;
        
        private void Awake()
        {
            GetUnityComponents(this);
        }
    }
}