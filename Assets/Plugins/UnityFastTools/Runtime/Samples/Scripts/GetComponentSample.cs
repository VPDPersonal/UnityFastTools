using UnityEngine;
using UnityEngine.UI;

// ReSharper disable once CheckNamespace
namespace UnityFastTools.Samples
{
    public partial class GetComponentSample : MonoBehaviour
    {
        [GetComponent] private Image _selfImage;
        [GetComponent(GetComponentType.Child)] private Image _childImage;
        [GetComponent(GetComponentType.Parent)] private Image _parentImage;
        
        [GetComponent] private Image[] _selfImages;
        [GetComponent(GetComponentType.Child)] private Image[] _childImages;
        [GetComponent(GetComponentType.Parent)] private Image[] _parentImages;
        
        private void Awake()
        {
            GetUnityComponents();
        }
    }
}