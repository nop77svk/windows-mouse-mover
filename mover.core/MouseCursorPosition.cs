namespace NoP77svk.Mover.Core;
using System;

public static class MouseCursorPosition
{
    public static void GetAbsolute(out int x, out int y)
    {
        if (Environment.OSVersion.Platform is not PlatformID.Win32NT)
            throw new NotSupportedException($"We don't (yet) support \"${Environment.OSVersion.Platform.ToString()}");

        WindowsPoint result = new WindowsPoint() { X = -1, Y = -1 };
        if (!WindowsDllUser32.GetCursorPos(ref result))
            throw new Exception("Failed to obtain mouse cursor position via user32.dll call");

        x = result.X;
        y = result.Y;
    }

    public static void SetAbsolute(int x, int y)
    {
        if (Environment.OSVersion.Platform is not PlatformID.Win32NT)
            throw new NotSupportedException($"We don't (yet) support \"${Environment.OSVersion.Platform.ToString()}");

        if (!WindowsDllUser32.SetCursorPos(x, y))
            throw new Exception("Failed to set mouse cursor position via user32.dll call");
    }

    public static void SetRelative(int x, int y)
    {
        GetAbsolute(out int absX, out int absY);
        SetAbsolute(absX + x, absY + y);
    }
}
