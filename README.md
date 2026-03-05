# ButtonColorPicker

Button Color Picker is a WPF button that opens ColorDialog to select a color. The selected color is then applied to the button's background.

Sample Use:
```xml
<Window ...
        xmlns:ColorPicker="clr-namespace:WPFColorPicker;assembly=ButtonColorPicker">
   
        <ColorPicker:ButtonColorPicker Height="100" Width="100" />
</Window>
```

The Assembly:
```
xmlns:Your_Name="clr-namespace:WPFColorPicker;assembly=ButtonColorPicker"
```

Use:
```
<Your_Name:ButtonColorPicker Height="100" Width="100" />
```


Parts:
System.Windows.Media.Color SelectedColor
event EventHandler<Color>? OnColorSelection;
void OpenColorDialog()
```c#
ButtonColorPicker ColorPicker = new();

Color color = ColorPicker.SelectedColor;
ColorPicker.OnColorSelection += (s, e) =>
    {
        MessageBox.Show($"Selected Color: {e}");
    };
ColorPicker.OpenColorDialog();
```