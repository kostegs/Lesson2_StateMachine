public class IdlingState : MovementState
{
    public IdlingState(IStateSwitcher stateSwitcher, StateMachineData data, Character character) : base(stateSwitcher, data, character)
    {
    }

    public override void Update()
    {
        base.Update();

        if (IsHorizontalInputZero())
            return;

        StateSwitcher.SwitchState<RunningState>();        
    }
}
