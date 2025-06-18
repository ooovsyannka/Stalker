using UnityEngine;

public class InputReader : MonoBehaviour
{
    private const string Horizontal = nameof(Horizontal);
    private const string Vertical = nameof(Vertical);
    private const string AxisMouseX = "Mouse X";
    private const string AxisMouseY = "Mouse Y";

    public Vector3 InputDirection=>  new Vector3(Input.GetAxis(Horizontal), 0, Input.GetAxis(Vertical));
    public Vector3 MouseDelta=> new Vector3(Input.GetAxis(AxisMouseX), Input.GetAxis(AxisMouseY), 0);  
}