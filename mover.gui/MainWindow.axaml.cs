namespace mover.gui;
using System;
using System.Threading;
using System.Threading.Tasks;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;

public partial class MainWindow : Window
{
    private const string btnStartEmulationContentStart = "Start emulation";
    private const string btnStartEmulationContentStop = "Stop emulation";

    private CancellationTokenSource? MouseEmulationCTS;

    public MainWindow()
    {
        InitializeComponent();
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);

        btnStartEmulation = this.Find<Button>("btnStartEmulation");
        if (btnStartEmulation == null)
            throw new NullReferenceException("The emulation start button not found");
            
        btnStartEmulation.Content = btnStartEmulationContentStart;
    }

    private void OnStartEmulationClick(object? sender, RoutedEventArgs e)
    {
        if (MouseEmulationCTS == null || MouseEmulationCTS.Token.IsCancellationRequested)
        {
            MouseEmulationCTS = new CancellationTokenSource();
            btnStartEmulation.Content = btnStartEmulationContentStop;
            StartMouseEmulation();
        }
        else
        {
            MouseEmulationCTS.Cancel();
            btnStartEmulation.Content = btnStartEmulationContentStart;
        }
    }

    private async void StartMouseEmulation()
    {
        if (MouseEmulationCTS == null)
        {
            btnStartEmulation.Content = "Error: Cancellation somehow not possible";
            return;
        }

        while (!MouseEmulationCTS.Token.IsCancellationRequested)
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
    private static void MoveMouse(int x, int y)
    {
        WindowsNativeDllUser32.SetCursorPos(x, y);
    }
}