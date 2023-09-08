namespace NoP77svk.Mover.Core;
using System.Runtime.InteropServices;

internal static class WindowsNativeAPI
{
    [DllImport("user32.dll")]
    [return: MarshalAs(UnmanagedType.Bool)]
    internal static extern bool SetCursorPos(int x, int y);

    [DllImport("user32.dll")]
    [return: MarshalAs(UnmanagedType.Bool)]
    internal static extern bool GetCursorPos(ref WindowsPoint point);
}
