namespace NoP77svk.Mover.Gui;
using System;
using System.Threading;
using System.Threading.Tasks;
using Avalonia.Controls;
using Avalonia.Controls.Primitives;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using NoP77svk.Mover.Core;

internal partial class MainWindow : Window
{
    private const string BtnStartEmulationContentStart = "Start emulation";
    private const string BtnStartEmulationContentStop = "Stop emulation";

    private const int MaxRelativeMouseMove = 5;

    private CancellationTokenSource? mouseEmulationCTS;

    internal MainWindow()
    {
        InitializeComponent();
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);

        btnToggleEmulation = this.Find<ToggleButton>("btnToggleEmulation");
        if (btnToggleEmulation == null)
            throw new NullReferenceException("The emulation start button not found");
    }

    private void OnStartEmulation(object? sender, RoutedEventArgs e)
    {
        mouseEmulationCTS?.Cancel();

        if (mouseEmulationCTS == null || mouseEmulationCTS.Token.IsCancellationRequested)
            mouseEmulationCTS = new CancellationTokenSource();

        StartMouseEmulation();
    }

    private void OnStopEmulation(object? sender, RoutedEventArgs e)
    {
        mouseEmulationCTS?.Cancel();
    }

    private async void StartMouseEmulation()
    {
        if (mouseEmulationCTS == null)
        {
            btnToggleEmulation.Content = "Error: Cancellation somehow not possible";
            return;
        }

        IMouseCursorMover mouseCursorMover = new RelativeMouseCursorMover(MaxRelativeMouseMove);

        while (!mouseEmulationCTS.Token.IsCancellationRequested)
        {
            mouseCursorMover.NextMove();
            await Task.Delay(10);
        }
    }
}