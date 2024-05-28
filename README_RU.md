# Unity Fast Tools
**Unity Fast Tools** это набор инструментов, который минимизирует написание рутинного кода в Unity с помощью
генераторов исходного кода и анализаторов.

Этот набор включает:
* [Генераторы кода](https://github.com/VPDPersonal/UnityFastToolsGenerators)
* [Анализаторы кода](https://github.com/VPDPersonal/UnityFastToolsAnalyzers)

**Примечание к версии 0.1:** Это версия со стабильным генератором исходного кода и полным набором анализаторов кода.
Если вы считаете, что что-то можно улучшить, я буду ждать вашей обратной связи.

## Unity Handler
**UnityHandlerAttribute** - это атрибут, предназначенный для автоматической подписки и отписки от событий UnityEvent.

```csharp
// Класс должен иметь модификатор 'partial', в противном случае возникнет ошибка UTF0002
public partial class SomeMono : MonoBehaviour
{
    // Этот подход работает только для: Button, Toggle, Slider, RectScroll.
    [UnityHandler(nameof(OnClicked))]
    [SerializeField] private Button _button1;
    
    // Этот подход работает для тех типов, у которых есть событие onClick или onValueChanged.
    [UnityHandler(UnityEventName.Click, nameof(OnClicked))]
    [SerializeField] private Button _button2;
    
    // Этот способ более подвержен ошибкам. Если вы допустите опечатку в параметрах,
    // возникнет ошибка компиляции в сгенерированном коде.
    [UnityHandler("onClick", "OnClicked"]
    [SerializeField] private Button _button2;
    
    // Поддерживаются массивы.
    [UnityHandler(UnityHandlerType.Click, nameof(OnClicked))]
    [SerializeField] private Button _buttons;

    // Вы должны вызвать метод 'SubscribeUnityHandler'
    // для подписки на все необходимые события.
    private void OnEnable() =>
        SubscribeUnityHandler();
       
    // Вы должны вызвать метод 'UnsubscribeUnityHandler'
    // для отписки от всех необходимых событий.
    private void OnDisable() =>
        UnsubscribeUnityHandler();

    private void OnClicked() 
    {
        // Сделать что-то
    }
}
```

### UnityEventName
**UnityEventName** перечисления имен UnityEvents
* Click - onClick
* ValueChanged - onValueChanged

### Ограничения
Неправильные параметры атрибута приведут к ошибкам в сгенерированном коде.

**UnityHandlerAttribute** не поддерживает:
* Свойства без модификатора доступа 'get'
* Формат типа: [field: UnityHandler(..., ...)]
* Коллекции, отличные от массивов

## Get Component
**GetComponentAttribute** это атрибут, предназначенный для автоматического вызова метода GetComponent для полей и свойств.

```csharp
// Класс должен иметь модификатор 'partial', в противном случае возникнет ошибка UTF0002
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
### WhereGet
**WhereGet** это перечисление типов методов GetComponent
* Self - GetComponent
* Child - GetComponentInChildren
* Parent - GetComponentInParent

### Ограничения
**GetComponentAttribute** не поддерживает:
* Свойства без модификатора доступа 'set'
* Формат типа: [field: GetComponentAttribute]
* Коллекции, отличные от массивов

## Get Component Property
**GetComponentAttribute** это атрибут для полей, который автоматический создает свойство, 
которое инициализирует поле с помощью GetComponent

```csharp
// Класс должен иметь модификатор 'partial', в противном случае возникнет ошибка UTF0002
public partial class SomeMono : MonoBehaviour
{
    // Создает свойство:
    // public TMP_Text CachedText => _text ? _text : (_text = GetComponent<TMP_Text>())
    [GetComponentProperty] private TMP_Text _text;
    
    // Создает свойство:
    // public Image CachedImage => _image ? _image : (_image = GetComponentInChildren<Image>())
    [GetComponentProperty(GetComponentType.Child)] private Image _image;
    
    // Создает свойство:
    // public Transform CachedTransform => _transform ? _transform : (_transform = GetComponent<Transform>())
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
### WhereGet
**WhereGet** это перечисление типов методов GetComponent
* Self - GetComponent
* Child - GetComponentInChildren
* Parent - GetComponentInParent

### Access
**Access** это перечисление модификаторов доступа к свойству
* Private - private
* Protected - protected
* Public - public

### Ограничения
**GetComponentAttribute** не поддерживает:
* Свойства
* Коллекции, отличные от массивов

## Roadmap
* Новые анализаторы для избегания ошибок
* Конфиг для установки имен, методов и свойств
* Sender в UnityHandler для возможности передачи самого объекта в качестве параметра
* Добавление адаптеров для любой сущности с UnityEvent
* 
## На рассмотрение:
* Аттрибуты для отрисовки Inspector  и EditorWindow
* Адаптре для Odin Inspector, Tri Inspector и других для плавного переуключения между ними
* Сериализация. Dictionary, tuple
