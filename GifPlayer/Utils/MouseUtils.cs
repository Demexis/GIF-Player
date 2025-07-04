using System.Drawing;
using System.Windows;
using System.Windows.Input;

namespace GifPlayer;

public static class MouseUtils
{
    private static System.Windows.Point GetCursorPosition()
    {
        var mainWindow = Application.Current.MainWindow!;
        var relativePoint = Mouse.GetPosition(mainWindow);
        return mainWindow.PointToScreen(relativePoint);
    }

    public static Color GetCursorColor()
    {
        var cursorPosition = GetCursorPosition();
        return ColorPicker.GetColorAt((int)cursorPosition.X, (int)cursorPosition.Y);
    }
}