using UnityEngine.InputSystem;
using UnityEngine;

public class RunningState : GroundedState
{
    protected readonly RunningStateConfig Config;

    public RunningState(IStateSwitcher stateSwitcher, StateMachineData data, Character character) : base(stateSwitcher, data, character)
        => Config = character.Config.RunningStateConfig;
    
    public override void Enter()
    {
        base.Enter();

        Data.Speed = Config.RunningSpeed;

        View.StartRunning();
    }

    public override void Exit()
    {
        base.Exit();

        View.StopRunning();
    }

    public override void Update()
    {
        base.Update();

        if (IsHorizontalInputZero())
            StateSwitcher.SwitchState<IdlingState>();
    }

    protected override void AddInputActionsCallback()
    {
        base.AddInputActionsCallback();

        Input.Movement.FastRun.started += OnFastRunKeyPressed;
        Input.Movement.Walking.started += OnWalkingKeyPressed;
    }

    protected override void RemoveInputActionsCallback()
    {
        base.RemoveInputActionsCallback();

        Input.Movement.FastRun.started -= OnFastRunKeyPressed;
        Input.Movement.Walking.started -= OnWalkingKeyPressed;
    }

    private void OnFastRunKeyPressed(InputAction.CallbackContext context) => StateSwitcher.SwitchState<FastRunningState>();

    private void OnWalkingKeyPressed(InputAction.CallbackContext context) => StateSwitcher.SwitchState<WalkingState>();
}
