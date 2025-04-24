# BindablePropertyGenerator
Source generator to generate boilerplate code for bindable properties in .NET MAUI.

Go from this:
```
public partial class LifeCard : ContentView
{
    public LifeCard()
    {
      InitializeComponent();
    }

    public static readonly BindableProperty TitleProperty = CreateBindableProperty(nameof(Title), "");

    public string Title
    {
        get => (string)GetValue(TitleProperty);
        set => SetValue(TitleProperty, value);
    }

    public static readonly BindableProperty DescriptionProperty = CreateBindableProperty(nameof(Description), "");

    public string Description
    {
        get => (string)GetValue(DescriptionProperty);
        set => SetValue(DescriptionProperty, value);
    }

    public static readonly BindableProperty ImageUriProperty = CreateBindableProperty(nameof(ImageUri), "");

    public string ImageUri
    {
        get => (string)GetValue(ImageUriProperty);
        set => SetValue(ImageUriProperty, value);
    }

    public static readonly BindableProperty IsCompactLayoutProperty = CreateBindableProperty(nameof(IsCompactLayout), false);

    public bool IsCompactLayout
    {
        get => (bool)GetValue(IsCompactLayoutProperty);
        set => SetValue(IsCompactLayoutProperty, value);
    }

    private static BindableProperty CreateBindableProperty<T>(
string propertyName, T defaultValue, BindableProperty.BindingPropertyChangedDelegate propertyChanged = null, BindingMode defaultBindingMode = BindingMode.TwoWay)
    {
        return BindableProperty.Create(
            propertyName: propertyName,
            returnType: typeof(T),
            declaringType: typeof(LifeCard),
            defaultValue: defaultValue,
            defaultBindingMode: defaultBindingMode,
            propertyChanged: propertyChanged
        );
    }
}
```

To this:
```
public partial class LifeCard : ContentView
{
    public LifeCard()
    {
        InitializeComponent();
    }

    [GenerateBindableProperty(typeof(string))]
    public static readonly BindableProperty TitleProperty = CreateBindableProperty(nameof(Title), "");

    [GenerateBindableProperty(typeof(string))]
    public static readonly BindableProperty DescriptionProperty = CreateBindableProperty(nameof(Description), "");

    [GenerateBindableProperty(typeof(string))]
    public static readonly BindableProperty ImageUriProperty = CreateBindableProperty(nameof(ImageUri), "");

    [GenerateBindableProperty(typeof(bool))]
    public static readonly BindableProperty IsCompactLayoutProperty = CreateBindableProperty(nameof(IsCompactLayout), false);
}
```

## How to use:
1. Install BindablePropertyGenerator.Attributes and BindablePropertyGenerator.SourceGenerators from nuget.org
2. In the code-behind of your content views simply decorate your bindable properties with `[GenerateBindableProperty(typeof(<ObjectType>))]`
