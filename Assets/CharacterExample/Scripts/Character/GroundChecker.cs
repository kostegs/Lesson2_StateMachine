using UnityEngine;

public class GroundChecker : MonoBehaviour
{
    [SerializeField] private LayerMask _ground;
    [SerializeField, Range(0.01f, 1f)] private float _distanceToCheck;

    public bool IsTouches { get; private set; }

    private void Update() => IsTouches = Physics.CheckSphere(transform.position, _distanceToCheck, _ground);
}
