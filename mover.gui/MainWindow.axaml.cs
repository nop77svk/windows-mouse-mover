namespace NoP77svk.Mover.Gui;
using System;
using System.Threading;
using System.Threading.Tasks;
using Avalonia.Controls;
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

        btnStartEmulation = this.Find<Button>("btnStartEmulation");
        if (btnStartEmulation == null)
            throw new NullReferenceException("The emulation start button not found");

        btnStartEmulation.Content = BtnStartEmulationContentStart;
    }

    private void OnStartEmulationClick(object? sender, RoutedEventArgs e)
    {
        if (mouseEmulationCTS == null || mouseEmulationCTS.Token.IsCancellationRequested)
        {
            mouseEmulationCTS = new CancellationTokenSource();
            btnStartEmulation.Content = BtnStartEmulationContentStop;
            StartMouseEmulation();
        }
        else
        {
            mouseEmulationCTS.Cancel();
            btnStartEmulation.Content = BtnStartEmulationContentStart;
        }
    }

    private async void StartMouseEmulation()
    {
        if (mouseEmulationCTS == null)
        {
            btnStartEmulation.Content = "Error: Cancellation somehow not possible";
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