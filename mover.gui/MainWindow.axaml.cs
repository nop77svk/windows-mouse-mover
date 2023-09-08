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
    private CancellationTokenSource? MouseEmulationCTS;

    public MainWindow()
    {
        InitializeComponent();
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);

        btnStartEmulation = this.Find<Button>("btnStartEmulation");
    }

    private void btnStartEmulation_Click(object? sender, RoutedEventArgs e)
    {
        if (MouseEmulationCTS == null || MouseEmulationCTS.Token.IsCancellationRequested)
        {
            MouseEmulationCTS = new CancellationTokenSource();
            StartMouseEmulation();
        }
        else
        {
            MouseEmulationCTS.Cancel();
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
/*
    [DllImport("user32.dll")]
    static extern bool SetCursorPos(int x, int y);
*/
    private void MoveMouse(int x, int y)
    {
        btnStartEmulation.Content = $"{x},{y}";
// 2do!        SetCursorPos(x, y);
    }
}