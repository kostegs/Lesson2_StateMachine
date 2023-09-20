using System;
using UnityEngine;

[Serializable]
public class RunningStateConfig 
{
    [SerializeField, Range(0, 10)] private float _runningSpeed;
    [SerializeField, Range(0, 10)] private float _fastRunSpeed;
    [SerializeField, Range(0, 10)] private float _walkingSpeed;

    public float RunningSpeed => _runningSpeed;
    public float FastRunSpeed => _fastRunSpeed;
    public float WalkingSpeed => _walkingSpeed;

    public void Validate()
    {
        if ((_runningSpeed, _fastRunSpeed, _walkingSpeed) == (0, 0, 0))
            return;

        if (_runningSpeed > _fastRunSpeed)
            _fastRunSpeed = _runningSpeed;

        if (_walkingSpeed > _runningSpeed)
            _walkingSpeed = _runningSpeed;
    }
}
