namespace NoP77svk.Mover.Core;

public class RelativeMouseCursorMover : IMouseCursorMover
{
    public RelativeMouseCursorMover(int livelinessFactor)
        : this(livelinessFactor, livelinessFactor)
    {
    }

    public RelativeMouseCursorMover(int livelinessFactorX, int livelinessFactorY)
    {
        LivelinessFactorX = livelinessFactorX;
        LivelinessFactorY = livelinessFactorY;
    }

    public int LivelinessFactorX { get; }
    public int LivelinessFactorY { get; }

    public void NextMove()
    {
        MouseCursorPosition.SetRelative(Random.Shared.Next(maxLivelinessRandomizerX) - LivelinessFactorX, Random.Shared.Next(maxLivelinessRandomizerY) - LivelinessFactorY);
    }

    private int maxLivelinessRandomizerX { get => LivelinessFactorX * 2 + 1; }
    private int maxLivelinessRandomizerY { get => LivelinessFactorY * 2 + 1; }
}
