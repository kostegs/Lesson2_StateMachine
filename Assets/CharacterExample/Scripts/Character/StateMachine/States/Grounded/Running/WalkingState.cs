using UnityEngine.InputSystem;

public class WalkingState : RunningState
{
    public WalkingState(IStateSwitcher stateSwitcher, StateMachineData data, Character character) : base(stateSwitcher, data, character)
    {
    }

    public override void Enter()
    {
        base.Enter();

        Data.Speed = Config.WalkingSpeed;

        View.StartRunning();
    }

    protected override void AddInputActionsCallback()
    {
        base.AddInputActionsCallback();

        Input.Movement.Walking.canceled += OnWalkingKeyCancelled;
    }

    protected override void RemoveInputActionsCallback()
    {
        base.RemoveInputActionsCallback();

        Input.Movement.Walking.canceled -= OnWalkingKeyCancelled;
    }

    private void OnWalkingKeyCancelled(InputAction.CallbackContext context)
    {
        if (IsHorizontalInputZero())
            StateSwitcher.SwitchState<IdlingState>();
        else
            StateSwitcher.SwitchState<RunningState>();
    }
}
