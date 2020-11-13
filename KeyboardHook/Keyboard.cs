using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace KeyboardHook
{
    public static class Keyboard
    {
        [Flags]
        public enum KeyStates
        {
            None = 0,
            Down = 1,
            Toggled = 2
        }

        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        private static extern short GetKeyState(int keyCode);
        /// <summary>
        /// Получить текущий статус кнопки.
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static KeyStates GetKeyState(Keys key)
        {
            KeyStates state = KeyStates.None;

            short retVal = GetKeyState((int)key);

            if ((retVal & 0x8000) == 0x8000)
                state |= KeyStates.Down;

            if ((retVal & 1) == 1)
                state |= KeyStates.Toggled;

            return state;
        }

        /// <summary>
        /// Клавиша нажата?
        /// </summary>
        public static bool IsKeyDown(Keys key)
        {
            return KeyStates.Down == (GetKeyState(key) & KeyStates.Down);
        }

        /// <summary>
        /// Клавиша отпущена?
        /// </summary>
        public static bool IsKeyToggled(Keys key)
        {
            return KeyStates.Toggled == (GetKeyState(key) & KeyStates.Toggled);
        }
        /// <summary>
        /// Список нажатых кнопок на клавиатуре.
        /// </summary>
        /// <returns></returns>
        public static List<string> KeysDown()
        {
            List<string> listKeyDown = new List<string>();
            Array KeyList = Enum.GetValues(typeof(Keys));

            foreach (int ID_key in KeyList)
            {
                if (IsKeyDown((Keys)ID_key) == true)
                {

                    string keyDown = ((Keys)Enum.Parse(
                        typeof(Keys),
                        ((Keys)ID_key).ToString()
                        )
                    ).ToString();

                    if (keyDown.Length > 1)
                        keyDown = keyDown[0].ToString() == "D".ToString() ? keyDown[1].ToString() : keyDown;
                    switch (keyDown)
                    {
                        case "ControlKey": break;
                        case "Menu": break;
                        case "ShiftKey": break;
                        case "LButton":
                            listKeyDown.Add("Mouse left");
                            break;
                        case "RButton":
                            listKeyDown.Add("Mouse right");
                            break;
                        default:
                            listKeyDown.Add(keyDown);
                            break;
                    }
                    for (int i = 0; i < listKeyDown.Count; i++)
                    {
                        if (i == 0)
                            continue;
                        if (listKeyDown[i - 1].ToLower() == keyDown.ToLower())
                        {
                            listKeyDown.RemoveAt(i);
                        }
                    }
                }

            }

            return listKeyDown;
        }

    }
}
