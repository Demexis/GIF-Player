using System.Globalization;
using System.Reflection;
using Microsoft.Win32;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using ColorPickerWPF;

namespace GifPlayer;

public sealed partial class MainWindow : Window
{
    private bool _codeChangesSliderFlag;

    private ColorPickerController ColorPicker { get; }
    private BitmapFrameSaver BitmapFrameSaver { get; } = new();
        
    private readonly System.Windows.Threading.DispatcherTimer _timer;

    public MainWindow()
    {
        InitializeComponent();

        SetTitle();
        
        SpeedSlider.ValueChanged += SpeedSlider_ValueChanged;
        ColorPicker = new ColorPickerController(color => OnColorPicker(Color.FromArgb(
            color.A,
            color.R,
            color.G,
            color.B)));
            
        WpfAnimatedGif.ImageBehavior.AddAnimationCompletedHandler(GifImage, OnAnimationCompleted);
        WpfAnimatedGif.ImageBehavior.AddAnimationLoadedHandler(GifImage, OnAnimationLoaded);
            
        _timer = new System.Windows.Threading.DispatcherTimer();
        _timer.Interval = TimeSpan.FromMilliseconds(10);
        _timer.Tick += UpdateProgress;
        _timer.Start();
    }

    private void SetTitle()
    {
        var appName = "GIF Player";
        var version = (Assembly.GetExecutingAssembly().GetName().Version ?? new Version(1, 0, 0));

        Title = $"{appName} ({version.Major}.{version.Minor}.{version.Build})";
    }
        
    private void UpdateProgress(object? sender, EventArgs e)
    {
        var controller = WpfAnimatedGif.ImageBehavior.GetAnimationController(GifImage);
        if (controller != null)
        {
            _codeChangesSliderFlag = true;
            ProgressSlider.Value = controller.CurrentFrame;
            _codeChangesSliderFlag = false;
        }
    }
        
    private void PlayPause_Click(object sender, RoutedEventArgs e)
    {
        var controller = WpfAnimatedGif.ImageBehavior.GetAnimationController(GifImage);
        if (controller != null)
        {
            if (controller.IsPaused)
            {
                controller.Play();
                PlayPauseIcon.Source = new BitmapImage(new Uri("Images/pause_icon.png", UriKind.Relative));
            }
            else
            {
                controller.Pause();
                PlayPauseIcon.Source = new BitmapImage(new Uri("Images/play_icon.png", UriKind.Relative));
            }
        }
    }

    private void Stop_Click(object sender, RoutedEventArgs e)
    {
        var controller = WpfAnimatedGif.ImageBehavior.GetAnimationController(GifImage);
        if (controller != null)
        {
            controller.Pause();
            PlayPauseIcon.Source = new BitmapImage(new Uri("Images/play_icon.png", UriKind.Relative));
            controller.GotoFrame(0);
            _codeChangesSliderFlag = true;
            ProgressSlider.Value = 0;
            _codeChangesSliderFlag = false;
        }
    }
        
    private void ProgressSlider_OnValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
    {
        if (_codeChangesSliderFlag)
        {
            return;
        }
            
        var controller = WpfAnimatedGif.ImageBehavior.GetAnimationController(GifImage);
        if (controller != null)
        {
            var frame = (int)e.NewValue;
            controller.GotoFrame(frame);
        }
    }
        
    private void OnAnimationLoaded(object sender, RoutedEventArgs e)
    {
        var controller = WpfAnimatedGif.ImageBehavior.GetAnimationController(GifImage);
        if (controller != null)
        {
            _codeChangesSliderFlag = true;
            ProgressSlider.Maximum = controller.FrameCount - 1;
            ProgressSlider.IsEnabled = true;
            _codeChangesSliderFlag = false;
        }
    }

    private void OnAnimationCompleted(object sender, RoutedEventArgs e)
    {
        var controller = WpfAnimatedGif.ImageBehavior.GetAnimationController(GifImage);
        if (controller != null)
        {
            _codeChangesSliderFlag = true;
            ProgressSlider.Value = controller.CurrentFrame;
            _codeChangesSliderFlag = false;
        }
    }
        
    private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
    {
        ColorPicker.StopColorPicker();
    }

    private void OnColorPicker(Color color)
    {
        ImageBackground.Background = new SolidColorBrush(color);
    }
        
    private void OpenButton_Click(object sender, RoutedEventArgs e)
    {
        var openFileDialog = new OpenFileDialog
        {
            Filter = "GIF Images|*.gif",
            Title = "Select a GIF file"
        };

        if (openFileDialog.ShowDialog() == true)
        {
            LoadGif(openFileDialog.FileName);
        }
    }

    private void LoadGif(string filePath)
    {
        try
        {
            var image = new BitmapImage();
            image.BeginInit();
            image.UriSource = new Uri(filePath);
            image.CacheOption = BitmapCacheOption.OnLoad;
            image.EndInit();

            WpfAnimatedGif.ImageBehavior.SetAnimatedSource(GifImage, image);
            WpfAnimatedGif.ImageBehavior.SetAnimationSpeedRatio(GifImage, SpeedSlider.Value);
                
            PlayPauseIcon.Source = new BitmapImage(new Uri("Images/pause_icon.png", UriKind.Relative));
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error loading GIF: {ex.Message}", "Error", 
                MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }

    private void SpeedSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
    {
        SpeedValueText.Text = $"{e.NewValue:F}x";
            
        if (GifImage.Source != null)
        {
            WpfAnimatedGif.ImageBehavior.SetAnimationSpeedRatio(GifImage, e.NewValue);
        }
    }

    private void ColorPickerButton_Click(object sender, RoutedEventArgs e)
    {
        if (!ColorPickerWindow.ShowDialog(out var color))
        {
            return;
        }
            
        ImageBackground.Background = new SolidColorBrush(color);
    }
        
    private void ColorPickerButtonSwitch_Click(object sender, RoutedEventArgs e)
    {
        ColorPicker.Switch();
    }
    
    private void CaptureFrameButton_Click(object sender, RoutedEventArgs e)
    {
        var controller = WpfAnimatedGif.ImageBehavior.GetAnimationController(GifImage);
        if (controller == null) {
            MessageBox.Show("Image not found.", "Error",
                MessageBoxButton.OK, MessageBoxImage.Warning);
            return;
        }

        BitmapFrameSaver.SaveFrame(GifImage, controller.CurrentFrame);
    }

    private void ShowHidePanelButton_OnClick(object sender, RoutedEventArgs e)
    {
        MainStackPanel.Visibility = MainStackPanel.Visibility == Visibility.Visible ? Visibility.Collapsed : Visibility.Visible;
        CollapseExpandIcon.Source = new BitmapImage(new Uri(MainStackPanel.Visibility == Visibility.Visible ? "Images/collapse_icon.png" : "Images/expand_icon.png", UriKind.Relative));
    }
        
    private void BackgroundImageButton_Click(object sender, RoutedEventArgs e)
    {
        var openFileDialog = new OpenFileDialog
        {
            Title = "Select an image",
            Filter = "Image files (*.png;*.jpeg;*.jpg;*.bmp)|*.png;*.jpeg;*.jpg;*.bmp|All files (*.*)|*.*"
        };

        if (openFileDialog.ShowDialog() != true)
        {
            return;
        }
        
        try
        {
            var brush = new ImageBrush();
            brush.ImageSource = new BitmapImage(new Uri(openFileDialog.FileName));
                    
            brush.Stretch = Stretch.UniformToFill;
                    
            ImageBackground.Background = brush;
        }
        catch
        {
            MessageBox.Show("Failed to load the image.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
        
    private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
    {
        if (sender is not TextBox textBox)
        {
            return;
        }

        var newText = textBox.Text.Insert(textBox.CaretIndex, e.Text);
        var isNumber = double.TryParse(newText, NumberStyles.Any, CultureInfo.InvariantCulture, out _);
        e.Handled = !isNumber;
    }
        
    protected override void OnClosed(EventArgs e)
    {
        ColorPicker.Dispose();
        base.OnClosed(e);
    }
}