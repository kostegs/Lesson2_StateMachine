using System;

public class StateMachineData
{
    // в каком направлении персонаж двигается по осям
    public float XVelocity;
    public float YVelocity;

    // модуль скорости передвижения персонажа
    private float _speed;
    
    // ввод по горизонтали
    private float _xInput;

    public float XInput
    {
        get => _xInput;
        set
        {
            if (value < -1 || value > 1)
                throw new ArgumentOutOfRangeException(nameof(value));

            _xInput = value;
        }
    }

    public float Speed
    {
        get => _speed;
        set
        {
            if (value < 0)
                throw new ArgumentOutOfRangeException(nameof(value));

            _speed = value;
        }
    }
}
