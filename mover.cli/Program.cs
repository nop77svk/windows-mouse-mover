namespace NoP77svk.Mover.Cli;
using System;
using NoP77svk.Mover.Core;

internal static class Program
{
    internal static async Task<int> Main(string[] args)
    {
        IMouseCursorMover mover = new RelativeMouseCursorMover(5);
        while (true)
        {
            mover.NextMove();
            await Task.Delay(10);
        }
    }
}