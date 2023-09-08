namespace mover.gui;
using System;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;

public partial class MainWindow : Window
{
    private CancellationTokenSource? cancellationTokenSource;

    public MainWindow()
    {
        InitializeComponent();
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }

    private void OnStartEmulationClick(object sender, RoutedEventArgs e)
    {
        if (cancellationTokenSource == null || cancellationTokenSource.Token.IsCancellationRequested)
        {
            cancellationTokenSource = new CancellationTokenSource();
            StartMouseEmulation();
        }
        else
        {
            cancellationTokenSource.Cancel();
        }
    }

    private async void StartMouseEmulation()
    {
        if (cancellationTokenSource == null)
            throw new ArgumentNullException(nameof(cancellationTokenSource));

        while (!cancellationTokenSource.Token.IsCancellationRequested)
        {
            // Emulate mouse movement here
            // You can use P/Invoke to call user32.dll functions to move the mouse
            // Example:
            MoveMouse(Random.Shared.Next(100), Random.Shared.Next(100));

            // Delay for a short period to control the movement speed
            await Task.Delay(1000);
        }
    }

    // Define the MoveMouse function using P/Invoke
    [DllImport("user32.dll")]
    static extern bool SetCursorPos(int x, int y);

    private void MoveMouse(int x, int y)
    {
        SetCursorPos(x, y);
    }
}