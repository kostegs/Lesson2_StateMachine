using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class FastRunningState : RunningState
{
    public FastRunningState(IStateSwitcher stateSwitcher, StateMachineData data, Character character) : base(stateSwitcher, data, character)
    {
    }

    public override void Enter()
    {
        base.Enter();

        Data.Speed = Config.FastRunSpeed;

        View.StartRunning();
    }

    protected override void AddInputActionsCallback()
    {
        base.AddInputActionsCallback();

        Input.Movement.FastRun.canceled += OnFastRunKeyCancelled;
    }

    protected override void RemoveInputActionsCallback() 
    {  
        base.RemoveInputActionsCallback();

        Input.Movement.FastRun.canceled -= OnFastRunKeyCancelled;
    }

    private void OnFastRunKeyCancelled(InputAction.CallbackContext context)
    {
        if (IsHorizontalInputZero())
            StateSwitcher.SwitchState<IdlingState>();
        else
            StateSwitcher.SwitchState<RunningState>();
    }
}
