using UnityEngine;

[RequireComponent(typeof(CharacterController))]

public class PlayerMover : MonoBehaviour
{
    [SerializeField] private float _noramlSpeed;
    [SerializeField] private float _speedSprint;
    [SerializeField] private float _strafeSpeed;
    [SerializeField] private float _gravityFactor = 2;
    [SerializeField] private float _jumpForce;
    [SerializeField] private Camera _camera;

    private float _currentSpeed;
    private Vector3 _verticalVelocity;
    private CharacterController _characterController;

    private void Awake()
    {
        _characterController = GetComponent<CharacterController>();
        SetNoramlSpeed();
    }

    public void Move(Vector3 direction)
    {
        Vector3 playerSpeed = GetMovementDirection(_camera.transform.forward) * direction.z * _currentSpeed + GetMovementDirection(_camera.transform.right) * direction.x * _strafeSpeed;

        _characterController.Move((playerSpeed + _verticalVelocity) * Time.deltaTime);
    }

    public void TryJump()
    {
        if (_characterController.isGrounded)
        {
            _verticalVelocity = Vector3.up * _jumpForce;
        }
    }

    public void SetSprintSpeed()
    {
        _currentSpeed = _speedSprint;
    }

    public void SetNoramlSpeed()
    {
        _currentSpeed = _noramlSpeed;
    }

    public void TryFall()
    {
        if (_characterController.isGrounded == false)
        {

            Vector3 horizontalVelocity = _characterController.velocity;
            horizontalVelocity.y = 0;
            _verticalVelocity += Physics.gravity * Time.deltaTime * _gravityFactor;
        }
    }

    private Vector3 GetMovementDirection(Vector3 camera) =>
        Vector3.ProjectOnPlane(camera, Vector3.up).normalized;

}