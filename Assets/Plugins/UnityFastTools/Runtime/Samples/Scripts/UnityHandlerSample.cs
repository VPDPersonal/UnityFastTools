using UnityEngine;
using UnityEngine.UI;

// ReSharper disable once CheckNamespace
namespace UnityFastTools.Samples
{
    public partial class UnityHandlerSample : MonoBehaviour
    {
        [UnityHandler(UnityHandlerType.Click, nameof(OnClicked1))]
        [SerializeField] private Button _singleButton1;
        
        // This option can lead to errors in the generated code if you make an error in the parameters
        [UnityHandler("onClick", "OnClicked2")]
        [SerializeField] private Button _singleButton2;
        
        [UnityHandler(UnityHandlerType.Click, nameof(OnClicked2))]
        [UnityHandler(UnityHandlerType.Click, nameof(OnClicked3))]
        [SerializeField] private Button _singleButton3;
        
        [field: SerializeField]
        [UnityHandler(UnityHandlerType.Click, nameof(OnClickedProperty1))]
        public Button PropertyButton1 { get; private set; }
        
        [UnityHandler(UnityHandlerType.Click, nameof(OnClickedProperty2))]
        private Button PropertyButton2 { get; set; }
        
        [UnityHandler(UnityHandlerType.Click, nameof(OnClickedArrayButtons))]
        [SerializeField] private Button[] _arrayButtons1;
        
        private void OnEnable()
        {
            PropertyButton2 = PropertyButton1;
            SubsribesUnityHandler();
        }
        
        private void OnDisable() =>
            UnsubsribesUnityHandler();
        
        private void OnClicked1() =>
            Debug.Log(nameof(OnClicked1));
        
        private void OnClicked2() =>
            Debug.Log(nameof(OnClicked2));
        
        private void OnClicked3() =>
            Debug.Log(nameof(OnClicked3));
        
        private void OnClickedProperty1() =>
            Debug.Log(nameof(OnClickedProperty1));
        
        private void OnClickedProperty2() =>
            Debug.Log(nameof(OnClickedProperty2));
        
        private void OnClickedArrayButtons() =>
            Debug.Log(nameof(OnClickedArrayButtons));
    }
}
