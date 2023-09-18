using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class Character : MonoBehaviour
{
    private PlayerInput _input;
    private CharacterStateMachine _stateMachine;
    private CharacterController _controller;

    public PlayerInput Input => _input;
    public CharacterController Controller => _controller;

    private void Awake()
    {
        _controller = GetComponent<CharacterController>();
        _input = new PlayerInput();
        _stateMachine = new CharacterStateMachine();
    }

    private void Update()
    {
        _stateMachine.HandleInput();

        _stateMachine.Update();
    }

    private void OnEnable() => _input.Enable();

    private void OnDisable() => _input.Disable();    
}
