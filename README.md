[![Dowland](https://i.imgur.com/AnxsELS.png)](https://github.com/Under4groos/KeyboardHook/blob/master/KeyboardHook/bin/Release/KeyboardHook.dll?raw=true)


```csharp
using KeyboardHook;
```

```csharp
KeyHook KeyHook;
public MainWindow()
{
    InitializeComponent();

    KeyHook = new KeyHook((int)Keys.Space);
    KeyHook.KeyPressed += KeyHook_KeyPressed;
    KeyHook.SetHook(); // KeyHook.Dispose();
}

private void KeyHook_KeyPressed(object sender, KeyPressEventArgs e)
{
    Label_.Content += "1";
}
```
=================================================
```csharp
TimerTick Timer = new TimerTick()
{
    Time = 1
};
Timer.Tick += delegate (object sender, EventArgs e)
{
    Label_.Content = Keyboard.IsKeyDown(Keys.Space).ToString();
};
Timer.Start();
```

# License
MIT - do whatever you want.
