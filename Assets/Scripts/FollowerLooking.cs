using UnityEngine;

public class FollowerLooking : MonoBehaviour
{
    public void LookAtPlayer(Transform player)
    {
        Vector3 directionBody = new Vector3(player.position.x, transform.position.y, player.position.z);

        transform.LookAt(directionBody);
    }
}