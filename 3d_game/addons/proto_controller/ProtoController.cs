using Godot;

public sealed partial class ProtoController : CharacterBody3D
{
    private static readonly NodePath headNodePath = "Head";
    private static readonly NodePath colliderNodePath = "Collider";

    [Export]
    private bool _canFreeFly;

    [Export]
    private bool _canJump = true;

    [Export]
    private bool _canMove = true;

    [Export]
    private bool _canSprint;

    [Export]
    private bool _hasGravity = true;

    [ExportGroup("Speeds")]
    [Export]
    private float _lockSpeed = 0.002F;

    [Export]
    private float _baseSpeed = 7F;

    [Export]
    private float _jumpVelocity = 4.5F;

    [Export]
    private float _sprintSpeed = 10F;

    [Export]
    private float _freeFlySpeed = 25F;

    [ExportGroup("Input Actions")]
    [Export]
    private string _inputLeft = "ui_left";

    [Export]
    private string _inputRight = "ui_right";

    [Export]
    private string _inputForward = "ui_up";

    [Export]
    private string _inputBack = "ui_down";

    [Export]
    private string _inputJump = "ui_jump";

    [Export]
    private string _inputSprint = "sprint";

    [Export]
    private string _inputFreeFly = "free_fly";

    private bool _mouseCaptured = false;
    private Vector2 _lookRotation = Vector2.Zero;
    private float _moveSpeed = 0F;
    private bool _freeFlying = false;
    private Node3D _head = null!;
    private CollisionShape3D _collider = null!;

    public override void _Ready()
    {
        base._Ready();

        _head = GetNodeOrNull<Node3D>(headNodePath);
        _collider = GetNodeOrNull<CollisionShape3D>(colliderNodePath);
    }

    public override void _UnhandledInput(InputEvent @event)
    {
        base._UnhandledInput(@event);

        if (Input.IsMouseButtonPressed(MouseButton.Left))
        {
            SetMouseCaptured();
        }

        if (Input.IsKeyPressed(Key.Escape))
        {
            SetMouseReleased();
        }

        if (_mouseCaptured && @event is InputEventMouseMotion)
        {

        }

        if (_canFreeFly && Input.IsActionJustPressed(_inputFreeFly))
        {

        }

# Mouse capturing
        if Input.is_mouse_button_pressed(MOUSE_BUTTON_LEFT):
        capture_mouse()
        if Input.is_key_pressed(KEY_ESCAPE):
        release_mouse()

# Look around
        if mouse_captured and event is InputEventMouseMotion:
        rotate_look(event.relative)

# Toggle freefly mode
        if can_freefly and Input.is_action_just_pressed(input_freefly):
        if not freeflying:
        enable_freefly()
        else:
        disable_freefly()
    }

    private void SetMouseCaptured()
    {
        Input.SetMouseMode(Input.MouseModeEnum.Captured);
        _mouseCaptured = true;
    }

    private void SetMouseReleased()
    {
        Input.SetMouseMode(Input.MouseModeEnum.Visible);
        _mouseCaptured = false;
    }

    private void EnableFreeFly()
    {
        _collider.Disabled = true;
        _freeFlying = true;

    }

    func enable_freefly():
    collider.disabled = true
    freeflying = true
    velocity = Vector3.ZERO

        func disable_freefly():
        collider.disabled = false
    freeflying = false
}
