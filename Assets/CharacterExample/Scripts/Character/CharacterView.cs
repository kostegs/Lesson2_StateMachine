using UnityEngine;

[RequireComponent(typeof(Animator))]
public class CharacterView : MonoBehaviour
{
    private const string IsIdling = "IsIdling";
    private const string IsRunning = "IsRunning";

    private Animator _animator;

    public void Initialize() => _animator = GetComponent<Animator>();

    public void StartIdling() => _animator.SetBool(IsIdling, true);

    public void StopIdling() => _animator.SetBool(IsIdling, false);

    public void StartRunning() => _animator.SetBool(IsRunning, true);

    public void StopRunning() => _animator.SetBool(IsRunning, false);
}
