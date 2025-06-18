using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class FollowerMover : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _distance = 3;

    private Rigidbody _rigidbody;

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

    private void Move(Vector3 direction)
    {
        _rigidbody.MovePosition(transform.position + direction * (_speed * Time.fixedDeltaTime));
    }
}