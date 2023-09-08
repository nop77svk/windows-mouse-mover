namespace mover.gui;
using System.Runtime.InteropServices;

public static class WindowsNativeDllUser32
{
    [DllImport("user32.dll")]
    [return: MarshalAs(UnmanagedType.Bool)]
    public static extern bool SetCursorPos(int x, int y);
}
