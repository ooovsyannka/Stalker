using System;
using UnityEngine;

public class FollowerCollision : MonoBehaviour
{
    public event Action CollisionDetected;
    [SerializeField] private LayerMask _groundLayer;

    private void OnCollisionEnter(Collision collision)
    {
/*        if (collision.gameObject.layer == _groundLayer == false)
        {
            CollisionDetected?.Invoke();

        }*/

    }
}