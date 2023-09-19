using System;
using UnityEngine;

[Serializable]
public class AirborneStateConfig
{
    [SerializeField] private JumpingStateConfig _jumpingStateConfig;

    public JumpingStateConfig JumpingStateConfig => _jumpingStateConfig;
    public float BaseGravity
        => 2f * _jumpingStateConfig.MaxHeight / (_jumpingStateConfig.TimeToReachMaxHeight * _jumpingStateConfig.TimeToReachMaxHeight);
}
