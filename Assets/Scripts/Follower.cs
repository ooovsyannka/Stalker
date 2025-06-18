using UnityEngine;

public class Follower : MonoBehaviour
{
    [SerializeField] private FollowerMover _mover;
    [SerializeField] private FollowerLooking _looking;
    [SerializeField] private Player _player;

    private void FixedUpdate()
    {
        Vector3 target = _player.transform.position;
        _mover.TryMove(target);
        _looking.LookAtPlayer(_player.transform);
    }
}
