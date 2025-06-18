using UnityEngine;

public class Looking : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private float _horizontalTurnSensitivity;
    [SerializeField] private float _verticalTurnSensitivity = 10f;
    [SerializeField] private float _verticalMinAngel = -89f;
    [SerializeField] private float _verticalMaxAngel = 89f;

    private float _cameraAngel = 0;

    private void Awake()
    {
        _cameraAngel = _camera.transform.localEulerAngles.x;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void Look(Vector3 mouseDelta)
    {
        HorizontalRotation(mouseDelta.y);
            VerticalRotation(mouseDelta.x);
    }

    private void HorizontalRotation(float mouseDeltaY)
    {
        _cameraAngel -= mouseDeltaY * _verticalTurnSensitivity;
        _cameraAngel =  Mathf.Clamp(_cameraAngel, _verticalMinAngel, _verticalMaxAngel);
        _camera.transform.localEulerAngles = Vector3.right * _cameraAngel;
    }

    private void VerticalRotation(float mouseDeltaX)
    {
        transform.Rotate(Vector3.up * _horizontalTurnSensitivity * mouseDeltaX);
    }
}