using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using Microsoft.Win32;

namespace GifPlayer;

public sealed class BitmapFrameSaver {
    public void SaveFrame(Image image, int frameNumber) {
        if (image.Source == null) {
            MessageBox.Show("Image not found.", "Error",
                MessageBoxButton.OK, MessageBoxImage.Warning);
            return;
        }

        var currentFrame = GetCurrentFrame(image.Source as BitmapSource);

        if (currentFrame == null) {
            MessageBox.Show("Failed to get current frame.", "Error",
                MessageBoxButton.OK, MessageBoxImage.Error);
            return;
        }

        var saveFileDialog = new SaveFileDialog {
            Filter = "PNG Image|*.png|JPEG Image|*.jpg|BMP Image|*.bmp|All Files|*.*",
            Title = "Save current GIF frame",
            FileName = $"gif_frame_{frameNumber}.png",
            DefaultExt = ".png"
        };

        if (saveFileDialog.ShowDialog() != true) {
            return;
        }

        try {
            SaveBitmapSourceToFile(currentFrame, saveFileDialog.FileName);
        }
        catch (Exception ex) {
            MessageBox.Show($"Error while saving: {ex.Message}", "Error",
                MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }

    private BitmapSource? GetCurrentFrame(BitmapSource? bitmapSource) {
        if (bitmapSource == null) {
            return null;
        }

        return new WriteableBitmap(bitmapSource);
    }

    private void SaveBitmapSourceToFile(BitmapSource bitmapSource, string fileName) {
        var extension = Path.GetExtension(fileName).ToLower();
        var encoder = GetEncoder(extension);

        encoder.Frames.Add(BitmapFrame.Create(bitmapSource));

        using (var stream = new FileStream(fileName, FileMode.Create)) {
            encoder.Save(stream);
        }
    }

    private BitmapEncoder GetEncoder(string fileExtension) {
        return fileExtension switch {
            ".jpg" or ".jpeg" => new JpegBitmapEncoder(),
            ".bmp" => new BmpBitmapEncoder(),
            ".gif" => new GifBitmapEncoder(),
            ".tiff" => new TiffBitmapEncoder(),
            _ => new PngBitmapEncoder()
        };
    }
}