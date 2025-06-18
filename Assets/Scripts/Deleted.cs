using System;
using UnityEngine;

public class Deleted : MonoBehaviour
{
    public event Action<Player> PlayerDetected;
    public event Action<Vector3> PlayerUndetected;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.TryGetComponent(out Player player))
        {
            PlayerDetected?.Invoke(player);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out Player player))
        {
            PlayerUndetected?.Invoke(player.transform.position);
        }
    }
}