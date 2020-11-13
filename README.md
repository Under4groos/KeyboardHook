[![Dowland](https://i.imgur.com/AnxsELS.png)](https://github.com/Under4groos/KeyboardHook/blob/master/KeyboardHook/bin/Release/KeyboardHook.dll?raw=true)

```csharp
KeyHook KeyHook;
public MainWindow()
{
    InitializeComponent();

    KeyHook = new KeyHook((int)Keys.Space);
    KeyHook.KeyPressed += KeyHook_KeyPressed;
    KeyHook.SetHook();
}

private void KeyHook_KeyPressed(object sender, KeyPressEventArgs e)
{
    Label_.Content += "1";
}
```