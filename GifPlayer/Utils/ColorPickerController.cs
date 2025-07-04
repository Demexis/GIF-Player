using System.Drawing;
using System.Windows.Threading;

namespace GifPlayer;

public sealed class ColorPickerController : IDisposable
{
    private bool IsPickingColor { get; set; }
    private readonly DispatcherTimer _pickerTimer = new()
    {
        Interval = TimeSpan.FromMilliseconds(50)
    };

    private Action<Color> OnPickingColor { get; }

    public ColorPickerController(Action<Color> onPickingColor)
    {
        OnPickingColor = onPickingColor;
    }

    public void Switch()
    {
        if (IsPickingColor)
        {
            StopColorPicker();
        }
        else
        {
            StartColorPicker();
        }
    }
    
    private void StartColorPicker()
    {
        IsPickingColor = true;
        _pickerTimer.Tick += PickerTimer_Tick;
        _pickerTimer.Start();
    }

    public void StopColorPicker()
    {
        IsPickingColor = false;
        _pickerTimer.Stop();
        _pickerTimer.Tick -= PickerTimer_Tick;
    }

    private void PickerTimer_Tick(object? sender, EventArgs e)
    {
        OnPickingColor.Invoke(MouseUtils.GetCursorColor());
    }

    public void Dispose()
    {
        if (IsPickingColor)
        {
            StopColorPicker();
        }
    }
}