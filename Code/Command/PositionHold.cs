public class PositionHold<Gen, Pos> : ICommand<IMechanism<Gen, Pos>>
    where Gen : struct
    where Pos : struct, Frame<Pos>
{
    private float duration;
    private Pos position;

    private readonly Pos? tool;
    private readonly Pos? part;

    public PositionHold(float duration, Pos? tool = null, Pos? part = null)
    {
        this.duration = duration;
        this.tool = tool;
        this.part = part;
    }

    public void Init(Controller<IMechanism<Gen, Pos>> controller)
    {
        position = controller.Mechanism.CurrentPosition();
    }
    public Progress Step(Controller<IMechanism<Gen, Pos>> controller, float delta)
    {
        duration -= delta;
        if (duration < 0)
        {
            return Progress.Done;
        }

        if (controller.Mechanism.SetInverse(position) is null)
        {
            return Progress.Error;
        }
        return Progress.Ongoing;
    }
}