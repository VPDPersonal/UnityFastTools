# Unity Fast Tools
**Unity Fast Tools** is a set of tools designed to minimize routine code writing in Unity using source code generators.

This set includes:
* [Source Generators](https://github.com/VPDPersonal/UnityFastToolsGenerators)
* [Code Analyzers](https://github.com/VPDPersonal/UnityFastToolsAnalyzers)

**Note for version 0.1.5:** This is a version with a stable source code generator and a full set of code analyzers.
If you think something can be improved, I will be waiting for your feedback.

## Unity Handler
**UnityHandlerAttribute** is an attribute designed to automatically add subscriptions and unsubscribes to a UnityEvent.

```csharp
// The class must have the 'partial' modifier, otherwise an error will occur UTF0002
public partial class SomeMono : MonoBehaviour
{
    // This approach works only for: Button, Toggle, Slider, RectScroll.
    [UnityHandler(nameof(OnClicked))]
    [SerializeField] private Button _button1;
    
    // This approach works for those types who have onClick or onValueChanged event
    [UnityHandler(UnityEventName.Click, nameof(OnClicked))]
    [SerializeField] private Button _button2;
    
    // This method is more error-prone. If you have a typo in the parameters,
    // there will be a compilation error in the generated code.
    [UnityHandler("onClick", "OnClicked"]
    [SerializeField] private Button _button3;
    
    // Arrays are supported.
    [UnityHandler(nameof(OnClicked))]
    [SerializeField] private Button[] _buttons;

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
        // Do something
    }
}
```

### UnityEventName
**UnityEventName** enum names of UnityEvents
* Click - onClick
* ValueChanged - onValueChanged

### Restrictions
Incorrect parameters in the attribute will result in errors in the generated code.

**UnityHandlerAttribute** does not support:
* Properties without the 'get' accessor
* Type format: [field: UnityHandler(..., ...)]
* Collections other than arrays

## Get Component
**GetComponentAttribute** is an attribute designed to automatically call GetComponent for fields and properties.

```csharp
// The class must have the 'partial' modifier, otherwise an error will occur UTF0002
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
        GetUnityComponents(this);
}
```
### WhereGet
**WhereGet** is an enum representing the types of GetComponent methods:
* Self - GetComponent
* Child - GetComponentInChildren
* Parent - GetComponentInParent

### Restrictions
**GetComponentAttribute** does not support:
* Properties without the 'set' accessor
* Type format: [field: GetComponentAttribute]
* Collections other than arrays

## Get Component Property
**GetComponentAttribute** is an attribute for fields that automatically creates a property initializing the field via GetComponent.

```csharp
// The class must have the 'partial' modifier, otherwise an error will occur UTF0002
public partial class SomeMono : MonoBehaviour
{
    // Creates a property:
    // public TMP_Text CachedText => _text ? _text : (_text = GetComponent<TMP_Text>())
    [GetComponentProperty] private TMP_Text _text;
    
    // Creates a property:
    // public Image CachedImage => _image ? _image : (_image = GetComponentInChildren<Image>())
    [GetComponentProperty(GetComponentType.Child)] private Image _image;
    
    // Creates a property:
    // public Transform CachedTransform => _transform ? _transform : (_transform = GetComponent<Transform>())
    [GetComponentProperty(PropertyAccess.Public) private Transform _transform;
    
    // Arrays are supported. Creates a property:
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
### WhereGet
**WhereGet** is an enum representing the types of GetComponent methods:
* Self - GetComponent
* Child - GetComponentInChildren
* Parent - GetComponentInParent

### Access
**Access** is an enum representing the access levels for the properties:
* Private - private
* Protected - protected
* Public - public

### Restrictions
**GetComponentAttribute** does not support:
* Properties
* Collections other than arrays

## Roadmap
* New analyzers to avoid errors
* Configuration for setting names, methods, and properties
* Add sender to UnityHandler to allow the object to pass itself as a parameter
* Add adapters for any entity with UnityEvent

## For consideration:
* Attributes for rendering Inspector and EditorWindow
* Adapter for Odin Inspector, Tri Inspector and others for smooth switching between them
* Serialization. Dictionary, tuple
