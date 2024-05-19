# Unity Fast Tools
**Unity Fast Tools** is a set of tools that minimizes the writing of routine code in Unity using source code generators.

**Note for version 0.1:** this version lacks several necessary code analyzers, and there may also be unforeseen use cases. 
I will be glad to receive your feedback to improve the performance of the set and expand its capabilities.

## Unity Handler
**UnityHandlerAttribute** is an attribute designed to automatically add subscriptions and unsubscribes to a UnityEvent.

```csharp
// The class must have the 'partial' modifier, otherwise there will be an error.
public partial class SomeMono : MonoBehaviour
{
    // Preferred usage.
    [UnityHandler(UnityHandlerType.Click, nameof(OnClicked))]
    [SerializeField] private Button _button1;
    
    // This method is more error prone. If you have a typo in the parameters
    // there will be a compilation error in the generated code.
    [UnityHandler("onClick", "OnClicked"]
    [SerializeField] private Button _button2;
    
    // There is support for arrays.
    [UnityHandler(UnityHandlerType.Click, nameof(OnClicked))]
    [SerializeField] private Button _buttons;

    // You must call the the 'SubscribeUnityHandler' method
    // to subscribe to all necessary events.
    private void OnEnable() =>
        SubscribeUnityHandler();
       
    // You must call the the 'UnsubscribeUnityHandler' method
    // to unsubscribe to all necessary events.
    private void OnDisable() =>
        UnsubscribeUnityHandler();

    private void OnClicked() 
    {
        // To do something
    }
}
```

### UnityHandlerType
**UnityHandlerType** is a static class with constants that contain the main names of events that Unity uses:
* Click - onClick
* ValueChanged - onValueChanged

### Restrictions
There is currently no error analyzer in the attribute parameters and an error may occur in the generated code.

**UnityHandlerAttribute** does not support:
* Properties without the 'get' modifier
* Type format: [field: UnityHandler(..., ...)]
* Collections. Only array supported

## Get Component
**GetComponentAttribute** is an attribute designed to automatically GetComponent for fields and properties.

```csharp
public partial class SomeMono : MonoBehaviour
{
    // Calls 'GetComponent' on '_image'.
    [GetComponent] private Image _image;
    
    // Calls 'GetComponentInChildren' on '_childImage'.
    [GetComponent(GetComponentType.Child)] private Image _childImage;
    
    // Calls 'GetComponentInParent' on '_parentImage'.
    [GetComponent(GetComponentType.Parent)] private Image _parentImage;
    
    // There is support for arrays. Calls 'GetComponentsInChildren' on '_images'.
    [GetComponent(GetComponentType.Child)] private Image[] _images;
    
    // You must call 'GetUnityComponents' to force all marked fields to 'GetComponent'.
    private void Awake() =>
        GetUnityComponents();
}
```
### GetComponentType
**GetComponentType** is an enum of the types of GetComponent methods
* Self - GetComponent
* Child - GetComponentInChildren
* Parent - GetComponentInParent

### Restrictions
**GetComponentAttribute** does not support:
* Properties without the 'set' modifier
* Type format: [field: GetComponentAttribute]
* Collections. Only array supported

## Get Component Property
**GetComponentAttribute** is an attribute for fields that automatically creates a property 
that initializes the field via GetComponent

```csharp
public partial class SomeMono : MonoBehaviour
{
    // Creates a property:
    // public CachedText => _text ? _text : (_text = GetComponent<TMP_Text>())
    [GetComponentProperty] private TMP_Text _text;
    
    // Creates a property:
    // public CachedImage => _image ? _image : (_image = GetComponentInChildren<Image>())
    [GetComponentProperty(GetComponentType.Child)] private Image _image;
    
    // Creates a property:
    // public CachedTransform => _transform ? _transform : (_transform = GetComponent<Transform>())
    [GetComponentProperty(PropertyAccess.Public) private Transform _transform;
    
    // There is support for arrays. Creates a property: 
    // protected Image[] CachedImages => _images != null && _images.Length > 0 ? _images : (_images = GetComponentsInParent<Image());
    [GetComponentProperty(PropertyAccess.Protected, GetComponentType.Parent) private Image[] _images;
    
    private void Start()
    {
        CachedText.text = "";
        CachedImage.sprite = null;
        CachedTransform.position = Vector3.zero;
        
        foreach (image in CachedImages)
            image.enable = false;
    }
}
```
### GetComponentType
**GetComponentType** is an enum of the types of GetComponent methods
* Self - GetComponent
* Child - GetComponentInChildren
* Parent - GetComponentInParent

### PropertyAccess
**PropertyAccess** is an enum of the types of GetComponent methods
* Private - private
* Protected - protected
* Public - public

### Restrictions
**GetComponentAttribute** does not support:
* Properties
* Collections. Only array supported

## Road Map
* New analyzers to avoid errors.
* Config for setting names, methods and properties.