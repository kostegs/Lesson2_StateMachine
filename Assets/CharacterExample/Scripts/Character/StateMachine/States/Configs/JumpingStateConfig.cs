using System;
using UnityEngine;

[Serializable]
public class JumpingStateConfig
{
    [SerializeField, Range(0, 10)] private float _speed; // скорость прыжка
    [SerializeField, Range(0, 10)] private float _maxHeight; // максимальная высота прыжка
    [SerializeField, Range(0, 10)] private float _timeToReachMaxHeight; // время достижения максимальной высоты прыжка

    public float StartYVelocity => 2 * _maxHeight / _timeToReachMaxHeight;
    public float Speed => _speed;
    public float MaxHeight => _maxHeight;
    public float TimeToReachMaxHeight => _timeToReachMaxHeight;
}
