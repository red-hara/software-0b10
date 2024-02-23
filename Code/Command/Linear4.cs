using System;
using Godot;

public class Linear4<Gen> : ICommand<IMechanism<Gen, Pose4>>
    where Gen : struct
{
    private Pose4 start;
    private readonly Pose4 target;
    private readonly(float linear, float angular) velocity;
    private float progress;
    private readonly Pose4? tool;
    private readonly Pose4? part;

    public Linear4(Pose4 target, (float linear, float angular)velocity, Pose4? tool = null, Pose4? part = null)
    {
        if (velocity.linear <= 0 || velocity.angular <= 0)
        {
            throw new ArgumentException("Velocity can't be less or equal to zero");
        }
        this.target = target;
        this.velocity = velocity;

        this.tool = tool;
        this.part = part;
    }

    public void Init(Controller<IMechanism<Gen, Pose4>> controller)
    {
        start = controller.Mechanism.CurrentPosition();
        // (2.2) Recalculate `start` here.
    }

    public Progress Step(Controller<IMechanism<Gen, Pose4>> controller, float delta)
    {
        var deltaPose = Pose4.Delta(start, target);
        // (2.1) Use code from `software 0b01` here.

        if (progress >= 1)
        {
            // (2.2) Calculate flange position here.
        }

        // (2.2) Calculate flange position here.

        return Progress.Ongoing;
    }
}