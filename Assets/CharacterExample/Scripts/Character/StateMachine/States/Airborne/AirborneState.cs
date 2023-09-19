using UnityEngine;

public abstract class AirborneState : MovementState
{
    private float _baseGravity;

    public AirborneState(IStateSwitcher stateSwitcher, StateMachineData data, Character character) : base(stateSwitcher, data, character)
        => _baseGravity = character.Config.AirborneStateConfig.BaseGravity;

    public override void Update()
    {
        base.Update();

        Data.YVelocity -= GetGravityMultiplier() * Time.deltaTime;
    }

    protected virtual float GetGravityMultiplier() => _baseGravity;

}
