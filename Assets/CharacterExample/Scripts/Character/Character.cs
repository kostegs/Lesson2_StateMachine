using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class Character : MonoBehaviour
{
    [SerializeField] private CharacterConfig _config;
    [SerializeField] private CharacterView _view;
    [SerializeField] private GroundChecker _groundChecker;

    private PlayerInput _input;
    private CharacterStateMachine _stateMachine;
    private CharacterController _controller;

    public PlayerInput Input => _input;
    public CharacterController Controller => _controller;
    public CharacterConfig Config => _config;
    public CharacterView View => _view;
    public GroundChecker GroundChecker => _groundChecker;

    private void Awake()
    {
        _view.Initialize();
        _controller = GetComponent<CharacterController>();
        _input = new PlayerInput();
        _stateMachine = new CharacterStateMachine(this);
    }


    private void Update()
    {
        _stateMachine.HandleInput();

        _stateMachine.Update();
    }

    private void OnEnable() => _input.Enable();

    private void OnDisable() => _input.Disable();    
}
