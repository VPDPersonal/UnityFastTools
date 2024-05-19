# Unity Fast Tools
**Unity Fast Tools** это набор инструментов, который минимизирует написание рутинного кода в Unity с помощью
генераторов исходного кода.

**Примечание к версии 0.1:** в данной версии отсутствуют несколько необходимых анализаторов кода, для повышения работоспособности,
а так же могут присутствовать не предусмотренные сценарии использования.
Буду рад вашей обратной связи для повышению работоспособности набора и расширения его возможностей.

## Unity Handler
**UnityHandlerAttribute** это аттрибут предназначенный для автоматического добавления подписок и отписок на UnityEvent.

```csharp
// Класс должен иметь модификатор 'partial', иначе будет ошибка.
public partial class SomeMono : MonoBehaviour
{
    // Предпочтительный способ использования.
    [UnityHandler(UnityHandlerType.Click, nameof(OnClicked))]
    [SerializeField] private Button _button1;
    
    // Данный способ более подвержен к ошибке. Если у вас опечатка в параметрах,
    // то будет ошибка компиляции в сгенерированном коде.
    [UnityHandler("onClick", "OnClicked"]
    [SerializeField] private Button _button2;
    
    // Есть поддержка массивов.
    [UnityHandler(UnityHandlerType.Click, nameof(OnClicked))]
    [SerializeField] private Button _buttons;

    // Необходимо вызвать метод SubscribeUnityHandler,
    // чтобы подписаться на все необходимые события.
    private void OnEnable() =>
        SubscribeUnityHandler();
       
    // Необходимо вызвать метод UnsubscribeUnityHandler,
    // чтобы отписаться от все необходимых событий.
    private void OnDisable() =>
        UnsubscribeUnityHandler();

    private void OnClicked() 
    {
        // Сделать что-то
    }
}
```

### UnityHandlerType
**UnityHandlerType** это статический класс с константами, которые содержат основные названия событий, которые используют Unity:
* Click - onClick
* ValueChanged - onValueChanged

### Ограничения
В данный момент отсутствует анализатор ошибок в параметрах атрибута и может возникнуть ошибка в сгенерированном коде.
Будьте внимательны!!!

**UnityHandlerAttribute** не поддерживает:
* Свойства без модификатора get
* Формат типа: [field: UnityHandler(..., ...)]
* Коллекции. Поддерживается только массив

## Get Component
**GetComponentAttribute** это аттрибут предназначенный для автоматического GetComponent для полей и свойств.

```csharp
public partial class SomeMono : MonoBehaviour
{
    // Вызывает 'GetComponent' для '_image'.
    [GetComponent] private Image _image;
    
    // Вызывает 'GetComponentInChildren' для '_childImage'.
    [GetComponent(GetComponentType.Child)] private Image _childImage;
    
    // Вызывает 'GetComponentInParent' для '_parentImage'.
    [GetComponent(GetComponentType.Parent)] private Image _parentImage;
    
    // Есть поддержка массивов. Вызывает 'GetComponentsInChildren' для '_images'.
    [GetComponent(GetComponentType.Child)] private Image[] _images;
    
    // Необходимо вызвать 'GetUnityComponents', чтобы вызвать у всех помеченных полей 'GetComponent'.
    private void Awake() =>
        GetUnityComponents();
}
```
### GetComponentType
**GetComponentType** это перечисление типов методов GetComponent
* Self - GetComponent
* Child - GetComponentInChildren
* Parent - GetComponentInParent

### Ограничения
**GetComponentAttribute** не поддерживает:
* Свойства без модификатора set
* Формат типа: [field: GetComponentAttribute]
* Коллекции. Поддерживается только массив

## Get Component Property
**GetComponentAttribute** это атрибут для полей, который автоматический создает свойство, 
которое инициализирует поле через GetComponent

```csharp
public partial class SomeMono : MonoBehaviour
{
    // Создает свойство:
    // public CachedText => _text ? _text : (_text = GetComponent<TMP_Text>())
    [GetComponentProperty] private TMP_Text _text;
    
    // Создает свойство:
    // public CachedImage => _image ? _image : (_image = GetComponentInChildren<Image>())
    [GetComponentProperty(GetComponentType.Child)] private Image _image;
    
    // Создает свойство:
    // public CachedTransform => _transform ? _transform : (_transform = GetComponent<Transform>())
    [GetComponentProperty(PropertyAccess.Public) private Transform _transform;
    
    // Есть поддержка массива. Создает свойство: 
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
**GetComponentType** это перечисление типов методов GetComponent
* Self - GetComponent
* Child - GetComponentInChildren
* Parent - GetComponentInParent

### PropertyAccess
**PropertyAccess** это перечисление модификаторов доступа к свойству
* Private - private
* Protected - protected
* Public - public

### Ограничения
**GetComponentAttribute** не поддерживает:
* Свойства
* Коллекции. Поддерживается только массив

## Road Map
* Новые анализаторы для избежания ошибок
* Конфиг для настройки имен методов и свойств