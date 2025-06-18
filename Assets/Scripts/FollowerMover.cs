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
            Vector3 direction = new Vector3(targetPosition.x - transform.position.x, 0, targetPosition.z - transform.position.z).normalized;

            Move(direction);
        }
    }

    private void Move(Vector3 target)
    {
        _rigidbody.MovePosition(transform.position + target * (_speed * Time.fixedDeltaTime));
    }
}