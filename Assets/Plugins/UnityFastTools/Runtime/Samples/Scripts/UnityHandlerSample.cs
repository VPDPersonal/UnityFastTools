using System;
using UnityEngine;
using UnityEngine.UI;
using UnityFastTools.UnityEvents;

// ReSharper disable once CheckNamespace
namespace UnityFastTools.Samples
{
    // This class must be partial.
    public sealed partial class UnityHandlerSample : MonoBehaviour
    {
        #region Button Members
        // This approach works only for: Button, Toggle, Slider, RectScroll.
        [UnityHandler(nameof(OnClicked1))]
        [SerializeField] private Button _singleButton1;
        
        [UnityHandler(UnityEventName.Click, nameof(OnClicked2))]
        [SerializeField] private Button _singleButton2;
        
        // This option can lead to errors in the generated code if there are mistakes in the parameters.
        [UnityHandler("onClick", nameof(OnClicked3))]
        [SerializeField] private Button _singleButton3;
        
        [UnityHandler(nameof(OnClickedArray1))]
        [SerializeField] private Button[] _arrayButton1;
        
        // field: Not supported.
        // [field: UnityHandler(nameof(OnClickedProperty1))]
        [UnityHandler(nameof(OnClickedProperty1))]
        [field: SerializeField] private Button PropertyButton1 { get; set; }
        
        [UnityHandler(nameof(OnClickedProperty2))]
        private Button PropertyButton2 => PropertyButton1;
        
        // Not supported.
        // [UnityHandler(nameof(OnClickedProperty2))]
        // private Button PropertyButton3
        // {
        //     set
        //     {
        //         // Set button
        //     }
        // }
        #endregion
        
        #region Toggle Members
        // This approach works only for: Button, Toggle, Slider, RectScroll.
        // [UnityHandler(nameof(OnValueChanged1))]
        // [SerializeField] private Toggle _singleToggle1;
        //
        // [UnityHandler(UnityEventName.ValueChanged, nameof(OnValueChanged2))]
        // [SerializeField] private Toggle _singleToggle2;
        
        // This option can lead to errors in the generated code if there are mistakes in the parameters.
        // [UnityHandler("onValueChanged", nameof(OnValueChanged3))]
        // [SerializeField] private Toggle _singleToggle3;
        
        [UnityHandler(nameof(OnValueChangedArray1))]
        [SerializeField] private Toggle[] _arrayToggle1;
        
        // field: Not supported.
        // [field: UnityHandler(nameof(OnValueChangedProperty1))]
        // [UnityHandler(nameof(OnValueChangedProperty1))]
        // [field: SerializeField] private Toggle PropertyToggle1 { get; set; }
        //
        // [UnityHandler(nameof(OnValueChangedProperty2))]
        // private Toggle PropertyToggle2 => PropertyToggle1;
        
        // Not support
        // [UnityHandler(nameof(OnValueChangedProperty2))]
        // private Toggle PropertyButton3
        // {
        //     set
        //     {
        //         // Set Toggle
        //     }
        // }
        #endregion
        
        private void OnEnable() =>
            SubsribesUnityHandler();
        
        private void OnDisable() =>
            UnsubsribesUnityHandler();
        
        #region OnClicked Methods
        private void OnClicked1() => Debug.Log(nameof(OnClicked1));
        
        private void OnClicked2() => Debug.Log(nameof(OnClicked2));
        
        private void OnClicked3() => Debug.Log(nameof(OnClicked3));
        
        private void OnClickedArray1() => Debug.Log(nameof(OnClickedArray1));
        
        private void OnClickedProperty1() => Debug.Log(nameof(OnClickedProperty1));
        
        private void OnClickedProperty2() => Debug.Log(nameof(OnClickedProperty2));
        #endregion
        
        #region OnClicked Methods
        private void OnValueChanged1(bool isOn) => Debug.Log(nameof(OnValueChanged1));
        
        private void OnValueChanged2(bool isOn) => Debug.Log(nameof(OnValueChanged2));
        
        private void OnValueChanged3(bool isOn) => Debug.Log(nameof(OnValueChanged3));
        
        private void OnValueChangedArray1(bool isOn) => Debug.Log(nameof(OnValueChangedArray1));
        
        private void OnValueChangedProperty1(bool isOn) => Debug.Log(nameof(OnValueChangedProperty1));
        
        private void OnValueChangedProperty2(bool isOn) => Debug.Log(nameof(OnValueChangedProperty2));
        #endregion
    }
    
    [Serializable]
    // This class must be partial.
    public abstract partial class A
    {
        [UnityHandler(nameof(OnClicked1))]
        [SerializeField] private Button _singleButton1;
        
        protected virtual void Enable()
        {
            SubsribesUnityHandler();
        }
        
        protected virtual void Disable()
        {
            UnsubsribesUnityHandler();
        }
        
        private void OnClicked1() => Debug.Log(nameof(OnClicked1));
    }
    
    [Serializable]
    // This class must be partial.
    public sealed partial class B : A
    {
        [UnityHandler(nameof(OnClicked2))]
        [SerializeField] private Button[] _arrayButton1;
        
        protected override void Enable()
        {
            SubsribesUnityHandler();
            base.Enable();
        }
        
        protected override void Disable()
        {
            UnsubsribesUnityHandler();
            base.Disable();
        }
        
        private void OnClicked2() => Debug.Log(nameof(OnClicked2));
    }
    
    [Serializable]
    // This class must be partial.
    public partial class GenericA<T1>
        where T1 : Button
    {
        // Not supported.
        // [UnityHandler(nameof(OnClicked1))]
        [UnityHandler(UnityEventName.Click, nameof(OnClicked1))]
        [SerializeField] private T1 _singleButton1;
        
        private void OnClicked1() => Debug.Log(nameof(OnClicked1));
    }
}
