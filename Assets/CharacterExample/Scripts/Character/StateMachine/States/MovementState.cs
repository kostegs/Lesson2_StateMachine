using UnityEngine;

public abstract class MovementState : IState
{
    protected readonly IStateSwitcher StateSwitcher;
    protected readonly StateMachineData Data;
    
    protected PlayerInput Input => _character.Input;
    protected CharacterController Controller => _character.Controller;

    private readonly Character _character;
    private Quaternion TurnRight => new Quaternion(0, 0, 0, 0);
    private Quaternion TurnLeft => Quaternion.Euler(0, 180, 0);

    public MovementState(IStateSwitcher stateSwitcher, StateMachineData data, Character character)
    {
        StateSwitcher = stateSwitcher;
        Data = data;
        _character = character;
    }

    public virtual void Enter() => Debug.Log(GetType());

    public virtual void Exit() {}

    public void HandleInput()
    {
        Data.XInput = ReadHorizontalInput();
        Data.XVelocity = Data.XInput * Data.Speed;
    }

    public virtual void Update()
    {
        Vector3 velocity = GetConvertedVelocity();

        Controller.Move(velocity * Time.deltaTime);
        _character.transform.rotation = GetRotationFrom(velocity);
    }

    protected bool IsHorizontalInputZero() => Data.XInput == 0;

    private float ReadHorizontalInput() => Input.Movement.Move.ReadValue<float>();

    private Vector3 GetConvertedVelocity() => new Vector3(Data.XVelocity, Data.YVelocity, 0);

    private Quaternion GetRotationFrom(Vector3 velocity)
    {
        if (velocity.x > 0)
            return TurnRight;
        else if (velocity.x < 0)
            return TurnLeft;

        return _character.transform.rotation;   
    }
}
