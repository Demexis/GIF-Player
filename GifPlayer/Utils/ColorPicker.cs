using System.Drawing;
using System.Runtime.InteropServices;

namespace GifPlayer;

public sealed class ColorPicker
{
    [DllImport("user32.dll")]
    private static extern IntPtr GetDC(IntPtr hwnd);

    [DllImport("user32.dll")]
    private static extern int ReleaseDC(IntPtr hwnd, IntPtr hdc);

    [DllImport("gdi32.dll")]
    private static extern uint GetPixel(IntPtr hdc, int nXPos, int nYPos);

    public static Color GetColorAt(int x, int y)
    {
        IntPtr desktopDC = GetDC(IntPtr.Zero);
        uint pixel = GetPixel(desktopDC, x, y);
        ReleaseDC(IntPtr.Zero, desktopDC);
        Color color = Color.FromArgb(
            (int)(pixel & 0x000000FF),
            (int)(pixel & 0x0000FF00) >> 8,
            (int)(pixel & 0x00FF0000) >> 16);
        return color;
    }
}