using System;
using Godot;

public class Joint4<Pos> : ICommand<IMechanism<(float a, float b, float c, float d), Pos>>
    where Pos : struct, Frame<Pos>
{
    private Pos start;
    private readonly Pos target;
    private readonly float speed;
    private float progress;
    private readonly Pos? tool;
    private readonly Pos? part;

    public Joint4(Pos target, float speed, Pos? tool = null, Pos? part = null)
    {
        if (speed <= 0 || speed > 1)
        {
            throw new ArgumentException("Speed can't be less or equal to zero or greater than 1");
        }
        this.target = target;
        this.speed = speed;

        this.tool = tool;
        this.part = part;
    }

    public void Init(Controller<IMechanism<(float a, float b, float c, float d), Pos>> controller)
    {
        start = controller.Mechanism.CurrentPosition();
        // (1.4) Recalculate `start` here.
    }

    public Progress Step(Controller<IMechanism<(float a, float b, float c, float d), Pos>> controller, float delta)
    {
        var flangeStart = start;
        // (1.4) Recalculate `flangeStart` so it matches flange position.

        var flangeTarget = target;
        // (1.4) Recalculate `flangeTarget` so it matches flange position.

        // (1.2) Use code from `software 0b01` here, but pass `flangeStart` and `flangeTarget` to `SolveInverse`.

        return Progress.Ongoing;
    }
}