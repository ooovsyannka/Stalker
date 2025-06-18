using UnityEngine;

[RequireComponent(typeof(Looking), typeof(PlayerMover))]

public class Player : MonoBehaviour
{
    [SerializeField] private InputReader _inputReader;

    private Looking _looking;
    private PlayerMover _mover;

    private void Awake()
    {
        _looking = GetComponent<Looking>();
        _mover = GetComponent<PlayerMover>();
    }

    private void Update()
    {
        _mover.Move(_inputReader.InputDirection);
        _looking.Look(_inputReader.MouseDelta);
        _mover.TryFall();
    }
}
