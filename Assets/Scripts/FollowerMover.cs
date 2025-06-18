using TMPro;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class FollowerMover : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _distance = 3;
    [SerializeField] private float _rayLength = 1.3f;

    [SerializeField] private float _gravityFactor;

    private Rigidbody _rigidbody;
    private RaycastHit _slopeDetector;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    public void TryMove(Vector3 targetPosition)
    {
        if (Vector3Extensions.IsEnoughClose(transform.position, targetPosition, _distance) == false)
        {
            Vector3 direction = (targetPosition - transform.position).normalized;

            Move(direction);
        }
    }

    private void Move(Vector3 target)
    {
        _rigidbody.MovePosition(transform.position + _speed * Time.fixedDeltaTime * target);
    }
}