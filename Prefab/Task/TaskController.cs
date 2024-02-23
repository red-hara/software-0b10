using Godot;

public partial class TaskController : Node
{
    private Controller<IMechanism<(float a, float b, float c, float d), Pose4>> controller;

    [Export]
    public TaskRobot robot;

    public override void _Ready()
    {
        controller = new(robot);

        InitCommands();
    }

    private void InitCommands()
    {
        var redTool = new Pose4(new Vector3(0.5f, 0, -0.5f), 0);

        controller.EnqueueCommand(new Joint4<Pose4>(new Pose4(new Vector3(1, 0, 2), 0), 0.25f));
        controller.EnqueueCommand(new PositionHold<(float a, float b, float c, float d), Pose4>(1));
        controller.EnqueueCommand(new Joint4<Pose4>(new Pose4(new Vector3(2, 0, 1), 0), 0.25f, redTool));
        controller.EnqueueCommand(new PositionHold<(float a, float b, float c, float d), Pose4>(1));
        controller.EnqueueCommand(new Joint4<Pose4>(new Pose4(new Vector3(2, 0.3f, 1), 0), 0.25f, redTool));
        controller.EnqueueCommand(new PositionHold<(float a, float b, float c, float d), Pose4>(1));
        controller.EnqueueCommand(new Joint4<Pose4>(new Pose4(new Vector3(2, -0.3f, 1), 0), 0.25f, redTool));
        controller.EnqueueCommand(new PositionHold<(float a, float b, float c, float d), Pose4>(1));

        // (2.3) Uncomment following lines for the second task

        // var greenTool = new Pose4(new Vector3(0, 0.5f, -0.5f), 0);
        // var greenPart = new Pose4(new Vector3(0, 1.5f, 0.3f), 45);

        // controller.EnqueueCommand(
        //     new Joint4<Pose4>(new Pose4(new Vector3(0.15f, 0.15f, 0.25f), 180), 1, greenTool, greenPart));
        // controller.EnqueueCommand(new Linear4<(float a, float b, float c, float d)>(
        //     new Pose4(new Vector3(0.15f, 0.15f, 0), 180), (0.1f, 90), greenTool, greenPart));
    }

    public override void _Process(double delta)
    {
        if (controller is not null)
        {
            var status = controller.Step((float)delta);
            if (status == Status.Error)
            {
                GD.Print("Encountered error!");
                controller = null;
            }
        }
    }
}