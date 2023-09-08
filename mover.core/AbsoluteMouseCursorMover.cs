namespace NoP77svk.Mover.Core;

public class AbsoluteMouseCursorMover : IMouseCursorMover
{
    public AbsoluteMouseCursorMover(int livelinessFactor)
    {
        LivelinessFactorX = livelinessFactor;
        LivelinessFactorY = livelinessFactor;
    }

    public AbsoluteMouseCursorMover(int livelinessFactorX, int livelinessFactorY)
    {
        LivelinessFactorX = livelinessFactorX;
        LivelinessFactorY = livelinessFactorY;
    }

    public int LivelinessFactorX { get; }
    public int LivelinessFactorY { get; }

    public void NextMove()
    {
        MouseCursorPosition.SetAbsolute(Random.Shared.Next(LivelinessFactorX), Random.Shared.Next(LivelinessFactorY));
    }
}
